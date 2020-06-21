using ProjectBlazor.Data.Game.Ability;
using System;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattleAction
	{
		public IPbBattleReady Source { get; set; }
		public IPbBattleReady Target { get; set; }
		public PbAbility SourceAbilityUsed { get; set; }
		public PbAbility TargetAbilityUsed { get; set; }

		public int GetSourceOutput()
		{
			int output = 0;

			output += (int)Math.Ceiling(Source.GetAttackTotal() * SourceAbilityUsed.Stats.AttackRatio);
			output += (int)Math.Ceiling(Source.GetMagicAttackTotal() * SourceAbilityUsed.Stats.MagicAttackRatio);

			return output;
		}

		public int GetSourceSpeed()
		{
			int speed = 0;
			speed += (int)Math.Ceiling(Source.GetSpeedTotal() * SourceAbilityUsed.Stats.SpeedRatio);

			return speed;
		}

		public int GetTargetDefenseOutput()
		{
			int output = 0;

			output += (int)Math.Ceiling(Target.GetDefenseTotal() * TargetAbilityUsed.Stats.DefenseRatio);

			return output;
		}

		public int GetTargetMagicDefenseOutput()
		{
			int output = 0;

			output += (int)Math.Ceiling(Target.GetMagicDefenseTotal() * TargetAbilityUsed.Stats.MagicDefenseRatio);

			return output;
		}

		public void RunAction()
		{
			if (SourceAbilityUsed.AbilityActionType == General.PbTypes.ABILITY_ACTION_TYPE.DAMAGE)
			{
				if (SourceAbilityUsed.OutputStatAttribute == General.PbTypes.STAT_ATTRIBUTE.ATTACK)
				{
					int totalDamage = Math.Max(GetSourceOutput() - GetTargetDefenseOutput(), 0);
					Target.TakeDamage(totalDamage);
				}

				if (SourceAbilityUsed.OutputStatAttribute == General.PbTypes.STAT_ATTRIBUTE.ATTACK_MAGIC)
				{
					int totalDamage = Math.Max(GetSourceOutput() - GetTargetMagicDefenseOutput(), 0);

					double damangeResistance = (1.00 - Target.GetAppropriateResistance(SourceAbilityUsed.Element));

					totalDamage = (int)Math.Ceiling(totalDamage * damangeResistance);

					Target.TakeDamage(totalDamage);
				}

			}
		}
	}
}
