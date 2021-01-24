using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public interface IPbEncounter
	{
		int GetRecommendedLevel();
		List<PbDecision> GetDecisions();
	}
}
