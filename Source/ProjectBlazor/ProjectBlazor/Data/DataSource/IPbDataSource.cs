using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Encounter;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Data.DataSource
{
	public interface IPbDataSource
	{
		List<PbEquipment> GetEquipment();
		List<PbAbility> GetAbilities();
		List<PbRace> GetRaces();
		List<PbClass> GetClasses();
		List<PbEncounter> GetEncounters();
	}
}
