using ProjectBlazor.Data.Game.Stats;

namespace ProjectBlazor.Data.Game.General
{
	public class PbPlayer
	{
		public int Level { get; set; }
		public int LevelPoints { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }

		public PbPlayer()
		{

		}
	}
}
