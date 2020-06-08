using ProjectBlazor.Data.Game.General;
using ProjectBlazor.Data.Game.Stats;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Ability
{
	public class PbAbility : PbObject
	{
		public ELEMENT Element { get; set; }
		public STAT_ATTRIBUTE OutputStatAttribute { get; set; }
		public ABILITY_ACTION_TYPE AbilityActionType { get; set; }
		public PbAbilityStats Stats { get; set; }
	}
}
