using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattle
	{
		public PbPlayer Player { get; set; }
		public PbEnemy Enemy { get; set; }
		public List<PbBattleAction> BattleActionQueue { get; set; }

		public PbBattle(PbPlayer player, PbEnemy enemy)
		{
			Player = player;
			Enemy = enemy;
			BattleActionQueue = new List<PbBattleAction>();
		}

		public void ResetBattle()
		{
			Player.ResetHp();
			Enemy.ResetHp();
			BattleActionQueue = new List<PbBattleAction>();
		}

		public bool CanBattleContinue()
		{
			return Player.IsDead() || Enemy.IsDead();
		}

		public void InputPlayerAction(string abilityName)
		{
			PbAbility ability = Player.Abilities.Find(x => x.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
			InputPlayerAction(ability);
		}

		public void InputPlayerAction(PbAbility abilityUsed)
		{
			//int playerfinalOutput = 0;

			//playerfinalOutput += (int)Math.Ceiling(Player.GetAttackTotal() * abilityUsed.Stats.AttackRatio);
			//playerfinalOutput += (int)Math.Ceiling(Player.GetMagicAttackTotal() * abilityUsed.Stats.MagicAttackRatio);

			//int playerFinalSpeed = 0;
			//playerFinalSpeed += (int)Math.Ceiling(Player.GetSpeedTotal() * abilityUsed.Stats.SpeedRatio);

			//int enemyfinalOutput = 0;

			//enemyfinalOutput += (int)Math.Ceiling(Enemy.GetAttackTotal() * Enemy.Abilities[0].Stats.AttackRatio);
			//enemyfinalOutput += (int)Math.Ceiling(Enemy.GetMagicAttackTotal() * Enemy.Abilities[0].Stats.MagicAttackRatio);

			//int enemyFinalSpeed = 0;
			//enemyFinalSpeed += (int)Math.Ceiling(Player.GetSpeedTotal() * Enemy.Abilities[0].Stats.SpeedRatio);

			//if (abilityUsed.AbilityActionType == PbTypes.ABILITY_ACTION_TYPE.DAMAGE)
			//{

			//}
			//else if (abilityUsed.AbilityActionType == PbTypes.ABILITY_ACTION_TYPE.HEAL)
			//{

			//}

			PrepareAction(abilityUsed, Enemy.Abilities[0]);
			RunBattleTurn();
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

		public void RunBattleTurn()
		{
			foreach (PbBattleAction action in BattleActionQueue)
			{
				action.RunAction();
			}
			BattleActionQueue.Clear();
		}
	}
}
