using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbEncounter : PbObject, IPbEncounter
	{
		public int RecommendedLevel { get; set; }
		public List<PbDecision> Decisions { get; set; }

		public string GetName()
		{
			return Name;
		}

		public string GetDescription()
		{
			return Description;
		}

		public int GetRecommendedLevel()
		{
			return RecommendedLevel;
		}

		public List<PbDecision> GetDecisions()
		{
			return Decisions;
		}
	}
}
