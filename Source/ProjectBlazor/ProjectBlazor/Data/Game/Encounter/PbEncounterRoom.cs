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

		public int GetRecommendedLevel()
		{
			return Encounter.GetRecommendedLevel();
		}
	}
}
