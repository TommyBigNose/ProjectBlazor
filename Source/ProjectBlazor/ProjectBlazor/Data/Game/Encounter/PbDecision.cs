using ProjectBlazor.Data.Game.General;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbDecision : PbObject
	{
		public STAT_ATTRIBUTE RequiredStat { get; set; }
		public int RequiredStatValue { get; set; }
		public DECISION_TYPE DecisionType { get; set; }
	}
}
