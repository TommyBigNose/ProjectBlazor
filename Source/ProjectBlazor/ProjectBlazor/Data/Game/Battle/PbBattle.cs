using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.General;
using System;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattle
	{
		public PbPlayer Player { get; set; }
		public PbEnemy Enemy { get; set; }

		public PbBattle(PbPlayer player, PbEnemy enemy)
		{
			Player = player;
			Enemy = enemy;
		}

		public void ResetBattle()
		{
			Player.ResetHp();
			Enemy.ResetHp();
		}

		public void InputPlayerAction(string abilityName)
		{
			PbAbility ability = Player.Abilities.Find(x => x.Name.Equals(abilityName, System.StringComparison.OrdinalIgnoreCase));
			InputPlayerAction(ability);
		}

		public void InputPlayerAction(PbAbility abilityUsed)
		{
			int finalOutput = 0;

			finalOutput += (int)Math.Ceiling(Player.GetAttackTotal() * abilityUsed.Stats.AttackRatio);
			finalOutput += (int)Math.Ceiling(Player.GetMagicAttackTotal() * abilityUsed.Stats.MagicAttackRatio);

			if (abilityUsed.AbilityActionType == PbTypes.ABILITY_ACTION_TYPE.DAMAGE)
			{

			}
			else if (abilityUsed.AbilityActionType == PbTypes.ABILITY_ACTION_TYPE.HEAL)
			{

			}
		}
	}
}
