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
		public PbPlayer Player { get; set; }
		public PbEnemy Enemy { get; set; }
		public List<PbBattleAction> BattleActionQueue { get; set; }
		public List<PbBattleActionResult> BattleActionResults { get; set; }

		public Timer BattleTimer { get; set; }
		public float TempActionBar { get; set; }

		public PbBattle(PbPlayer player, PbEnemy enemy)
		{
			Player = player;
			Enemy = enemy;
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
			BattleTimer = new Timer(PbConstants.Battle.BattleTimerInterval);
			BattleTimer.Start();
			BattleTimer.Elapsed += new ElapsedEventHandler(IncrementActionBar);
		}

		public void ResetBattle()
		{
			Player.Reset();
			Enemy.Reset();
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
			BattleTimer = new Timer(PbConstants.Battle.BattleTimerInterval);
			BattleTimer.Start();
		}

		private void IncrementActionBar(Object source, ElapsedEventArgs e)
		{
			TempActionBar += 10.0f;
			if (TempActionBar > PbConstants.Battle.BattleTimerMax) TempActionBar = 0.0f;
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
					Exp = Enemy.Exp,
					Credits = Enemy.Credits
				};
			}
			else if (GetBattleResult() == PbTypes.BATTLE_RESULT.LOSS)
			{
				reward = new PbBattleReward
				{
					Exp = (int)Math.Ceiling(Enemy.Exp * PbConstants.Battle.BattleLossRewardRatio),
					Credits = (int)Math.Ceiling(Enemy.Credits * PbConstants.Battle.BattleLossRewardRatio)
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
			PrepareAction(ability, Enemy.Abilities[0]);
		}

		public PbAbility GetAbilityByName(string abilityName)
		{
			return Player.Abilities.Find(x => x.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
		}

		public void PrepareAction(PbAbility playerAbilityUsed, PbAbility enemyAbilityUsed)
		{
			PbBattleAction playerAction = new PbBattleAction()
			{
				Source = Player,
				Target = Enemy,
				SourceAbilityUsed = playerAbilityUsed,
				TargetAbilityUsed = enemyAbilityUsed
			};
			PbBattleAction enemyAction = new PbBattleAction()
			{
				Source = Enemy,
				Target = Player,
				SourceAbilityUsed = enemyAbilityUsed,
				TargetAbilityUsed = playerAbilityUsed
			};
			BattleActionQueue.Add(playerAction);
			BattleActionQueue.Add(enemyAction);


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
