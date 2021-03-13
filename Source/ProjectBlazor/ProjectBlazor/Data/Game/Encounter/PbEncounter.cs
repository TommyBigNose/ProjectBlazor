using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbEncounter : PbObject, IPbEncounter
	{
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
	}
}
