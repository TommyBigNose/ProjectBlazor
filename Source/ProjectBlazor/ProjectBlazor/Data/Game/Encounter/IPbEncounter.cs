using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public interface IPbEncounter
	{
		string GetName();
		string GetDescription();
		int GetRecommendedLevel();
		List<PbDecision> GetDecisions();
	}
}
