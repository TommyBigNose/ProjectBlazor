namespace ProjectBlazor.Data.Game.Stats
{
	public interface IPbBattleStats
	{
		void ResetHp();
		bool IsDead();
		int GetHpCurrent();
		int GetHpTotal();
		int GetAttackTotal();
		int GetDefenseTotal();
		int GetMagicAttackTotal();
		int GetMagicDefenseTotal();
		int GetSpeedTotal();
	}
}
