using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Stats
{
	public class PbAbilityStats
	{
		public ELEMENT Element { get; set; }
		public double AttackRatio { get; set; }
		public double DefenseRatio { get; set; }
		public double MagicAttackRatio { get; set; }
		public double MagicDefenseRatio { get; set; }
		public double SpeedRatio { get; set; }
	}
}
