using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbEncounter : PbObject, IPbEncounter
	{
		public IPbBattleReady Player { get; set; }
		public int RecommendedLevel { get; set; }
		public List<PbDecision> Decisions { get; set; }

		public List<PbDecision> GetDecisions()
		{
			return Decisions;
		}

		public int GetRecommendedLevel()
		{
			return RecommendedLevel;
		}

		public bool DoesPlayerHaveRequiredStat(PbDecision decision)
		{
			int requiredStat = 0;

			if (decision.RequiredStat == 0) return true;

			if (decision.RequiredStat == PbTypes.STAT_ATTRIBUTE.ATTACK) requiredStat = Player.GetAttackTotal();
			else if (decision.RequiredStat == PbTypes.STAT_ATTRIBUTE.DEFENSE) requiredStat = Player.GetDefenseTotal();
			else if (decision.RequiredStat == PbTypes.STAT_ATTRIBUTE.ATTACK_MAGIC) requiredStat = Player.GetMagicAttackTotal();
			else if (decision.RequiredStat == PbTypes.STAT_ATTRIBUTE.DEFENSE_MAGIC) requiredStat = Player.GetMagicDefenseTotal();
			else if (decision.RequiredStat == PbTypes.STAT_ATTRIBUTE.SPEED) requiredStat = Player.GetSpeedTotal();

			return requiredStat >= decision.RequiredStatValue;
		}
	}
}
