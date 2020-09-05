using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Exception;
using ProjectBlazor.Data.Game.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattle
	{
		public PbPlayer Player { get; set; }
		public PbEnemy Enemy { get; set; }
		public List<PbBattleAction> BattleActionQueue { get; set; }
		public List<PbBattleActionResult> BattleActionResults { get; set; }

		public PbBattle(PbPlayer player, PbEnemy enemy)
		{
			Player = player;
			Enemy = enemy;
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
		}

		public void ResetBattle()
		{
			Player.ResetHp();
			Enemy.ResetHp();
			BattleActionQueue = new List<PbBattleAction>();
			BattleActionResults = new List<PbBattleActionResult>();
		}

		public bool CanBattleContinue()
		{
			return !Player.IsDead() && !Enemy.IsDead();
		}

		public PbTypes.BATTLE_RESULT GetBattleResult()
		{
			PbTypes.BATTLE_RESULT result = PbTypes.BATTLE_RESULT.ONGOING;

			if (!CanBattleContinue())
			{
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
			PbAbility ability = Player.Abilities.Find(x => x.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
			InputPlayerAction(ability);
		}

		public void InputPlayerAction(PbAbility abilityUsed)
		{
			PrepareAction(abilityUsed, Enemy.Abilities[0]);
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
