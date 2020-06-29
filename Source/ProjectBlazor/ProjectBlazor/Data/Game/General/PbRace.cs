using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Stats;

namespace ProjectBlazor.Data.Game.General
{
	public class PbRace : PbObject
	{
		public PbStats Stats { get; set; }
		public PbAbility DefaultAbility { get; set; }
	}
}
