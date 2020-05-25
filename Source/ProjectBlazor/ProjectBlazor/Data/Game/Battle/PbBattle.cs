using ProjectBlazor.Data.Game.General;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattle
	{
		public PbPlayer Player { get; set; }
		public PbEnemy Enemy { get; set; }

		public PbBattle(PbPlayer player, PbEnemy enemy)
		{
			Player = player;
			Enemy = enemy;
		}

		public void ResetBattle()
		{
			Player.ResetHp();
			Enemy.ResetHp();
		}
	}
}
