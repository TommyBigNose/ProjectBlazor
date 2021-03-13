using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.General;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbEncounterRoom : PbObject
	{
		public IPbBattleReady Player { get; set; }
		public IPbEncounter Encounter { get; set; }

		public PbEncounterRoom(IPbBattleReady player, IPbEncounter encounter)
		{
			Player = player;
			Encounter = encounter;
		}

		public string GetEncounterName()
		{
			return Encounter.GetName();
		}

		public string GetEncounterDescription()
		{
			return Encounter.GetDescription();
		}

		public int GetRecommendedLevel()
		{
			return Encounter.GetRecommendedLevel();
		}

		public bool DoesPlayerHaveRequiredStat(string decisionName)
		{
			PbDecision decision = Encounter.GetDecisions().Find(x => x.Name.Equals(decisionName, System.StringComparison.CurrentCultureIgnoreCase));

			return DoesPlayerHaveRequiredStat(decision);
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
