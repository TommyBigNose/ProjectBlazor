using ProjectBlazor.Data.Game.Stats;

namespace ProjectBlazor.Data.Game.General
{
	public class PbEnemy : PbObject, IPbBattleStats
	{
		private int _hpCurrent;
		public int Level { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }

		public PbEnemy()
		{

		}

		public void ResetHp()
		{
			_hpCurrent = GetHpTotal();
		}

		public bool IsDead()
		{
			return _hpCurrent <= 0;
		}

		public int GetHpCurrent()
		{
			return _hpCurrent;
		}

		public int GetHpTotal()
		{
			return Stats.Hp;
		}

		public int GetAttackTotal()
		{
			return Stats.Attack;
		}

		public int GetDefenseTotal()
		{
			return Stats.Defense;
		}

		public int GetMagicAttackTotal()
		{
			return Stats.MagicAttack;
		}

		public int GetMagicDefenseTotal()
		{
			return Stats.MagicDefense;
		}

		public int GetSpeedTotal()
		{
			return Stats.Speed;
		}
	}
}
