using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Exception;
using ProjectBlazor.Data.Game.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattle
	{
		public IPbBattleReady Player { get; set; }
		public IPbBattleReady Enemy { get; set; }
		public List<PbBattleAction> BattleActionQueue { get; set; }
		public List<PbBattleActionResult> BattleActionResults { get; set; }

		public Timer BattleTimer { get; set; }
		public double PlayerActionBar { get; set; }
		public double EnemyActionBar { get; set; }
		public List<PbAbilityActionBar> PlayerAbilityActionBars { get; set; }
		public List<PbAbilityActionBar> EnemyAbilityActionBars { get; set; }
		public PbAbility PlayerLastAbilityUsed { get; set; }
		public PbAbility EnemyLastAbilityUsed { get; set; }

		public PbBattle(IPbBattleReady player, IPbBattleReady enemy)
		{
			Player = player;
			Enemy = enemy;
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
			BattleTimer = new Timer(PbConstants.Battle.BattleTimerInterval);
			BattleTimer.Elapsed += new ElapsedEventHandler(IncrementActionBars);

			PlayerAbilityActionBars = new List<PbAbilityActionBar>();
			EnemyAbilityActionBars = new List<PbAbilityActionBar>();
			foreach (PbAbility ability in Player.GetAbilities())
			{
				PlayerAbilityActionBars.Add(new PbAbilityActionBar() { Ability = ability, ActionBar = 0.0 });
			}
			foreach (PbAbility ability in Enemy.GetAbilities())
			{
				EnemyAbilityActionBars.Add(new PbAbilityActionBar() { Ability = ability, ActionBar = 0.0 });
			}
		}

		public void ResetBattle()
		{
			Player.Reset();
			Enemy.Reset();
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
			BattleTimer.Stop();
		}

		public void StartBattle()
		{
			BattleTimer.Start();
		}

		private void IncrementActionBars(Object source, ElapsedEventArgs e)
		{
			if (PlayerLastAbilityUsed == null) PlayerLastAbilityUsed = Player.GetAbilities()[0];
			PlayerActionBar += (PbConstants.Battle.ActionBarIncrementBase * PlayerLastAbilityUsed.Stats.SpeedRatio);
			if (PlayerActionBar >= PbConstants.Battle.BattleTimerMax)
			{
				PlayerActionBar = 0.0;
				Player.RecoverAp(1);
				PrepareAction(Player, Enemy, Player.GetAbilities()[0], EnemyLastAbilityUsed);
				RunBattleTurn();
			}

			if (EnemyLastAbilityUsed == null) EnemyLastAbilityUsed = Enemy.GetAbilities()[0];
			EnemyActionBar += (PbConstants.Battle.ActionBarIncrementBase * EnemyLastAbilityUsed.Stats.SpeedRatio);
			if (EnemyActionBar >= PbConstants.Battle.BattleTimerMax)
			{
				EnemyActionBar = 0.0;
				Enemy.RecoverAp(1);
				PbAbility enemyAbility = Enemy.GetAbilities()[0];
				EnemyLastAbilityUsed = enemyAbility;
				PrepareAction(Enemy, Player, enemyAbility, PlayerLastAbilityUsed);
				RunBattleTurn();
			}
			IncrementAbilityActionBars(source, e);
		}

		private void IncrementAbilityActionBars(Object source, ElapsedEventArgs e)
		{
			foreach (PbAbilityActionBar actionBar in PlayerAbilityActionBars)
			{
				if (!actionBar.IsReady()) actionBar.IncrementActionBar(PbConstants.Battle.ActionBarIncrementBase * actionBar.Ability.Stats.ActionBarRatio);
			}
		}

		public bool CanBattleContinue()
		{
			return !Player.IsDead() && !Enemy.IsDead();
		}

		public bool CanPlayerUseAbility(string abilityName)
		{
			PbAbility ability = GetAbilityByName(abilityName);

			return (ability.Stats.ApUse <= Player.GetApCurrent());
		}

		public bool IsAbilityReady(string abilityName)
		{
			PbAbilityActionBar abilityActionBar = GetAbilityBarByName(abilityName);

			return abilityActionBar.IsReady();
		}

		public PbTypes.BATTLE_RESULT GetBattleResult()
		{
			PbTypes.BATTLE_RESULT result = PbTypes.BATTLE_RESULT.ONGOING;

			if (!CanBattleContinue())
			{
				BattleTimer.Stop();
				if (Player.IsDead()) result = PbTypes.BATTLE_RESULT.LOSS;
				else result = PbTypes.BATTLE_RESULT.VICTORY;
			}

			return result;
		}

		public PbBattleReward GetBattleReward()
		{
			PbBattleReward reward;

			if (GetBattleResult() == PbTypes.BATTLE_RESULT.VICTORY)
			{
				reward = new PbBattleReward
				{
					Exp = Enemy.GetExp(),
					Credits = Enemy.GetCredits()
				};
			}
			else if (GetBattleResult() == PbTypes.BATTLE_RESULT.LOSS)
			{
				reward = new PbBattleReward
				{
					Exp = (int)Math.Ceiling(Enemy.GetExp() * PbConstants.Battle.BattleLossRewardRatio),
					Credits = (int)Math.Ceiling(Enemy.GetCredits() * PbConstants.Battle.BattleLossRewardRatio)
				};
			}
			else
			{
				//reward = new PbBattleReward
				//{
				//	Exp = 0,
				//	Credits = 0
				//};
				throw new PbException($"{nameof(GetBattleReward)} - Attempted to get a reward when the battle is still going");
			}

			return reward;
		}

		public void InputPlayerAction(string abilityName)
		{
			PbAbility ability = GetAbilityByName(abilityName);
			PlayerLastAbilityUsed = ability;
			GetAbilityBarByName(ability.Name).ResetActionBar();
			PrepareAction(Player, Enemy, ability, EnemyLastAbilityUsed);
		}

		public PbAbility GetAbilityByName(string abilityName)
		{
			return Player.GetAbilities().Find(x => x.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
		}

		public PbAbilityActionBar GetAbilityBarByName(string abilityName)
		{
			return PlayerAbilityActionBars.Find(x => x.Ability.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
		}

		public void PrepareAction(IPbBattleReady source, IPbBattleReady target, PbAbility sourceAbilityUsed, PbAbility targetAbilityUsed)
		{

			PbBattleAction action = new PbBattleAction()
			{
				Source = source,
				Target = target,
				SourceAbilityUsed = sourceAbilityUsed,
				TargetAbilityUsed = targetAbilityUsed
			};
			BattleActionQueue.Add(action);

			BattleActionQueue = BattleActionQueue.OrderByDescending(x => x.GetSourceSpeed()).ToList();
		}

		public List<PbBattleActionResult> RunBattleTurn()
		{
			List<PbBattleActionResult> battleActionResults = new List<PbBattleActionResult>();

			foreach (PbBattleAction action in BattleActionQueue)
			{
				battleActionResults.Add(action.RunAction());
			}
			BattleActionQueue.Clear();

			return battleActionResults;
		}
	}
}
