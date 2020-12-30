using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.General
{
	public class PbEnemy : PbObject, IPbBattleReady
	{
		private int _hpCurrent;
		private int _apCurrent;
		public int Level { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }
		public List<PbAbility> Abilities { get; set; }

		public PbEnemy()
		{

		}

		public BATTLE_PARTICIPANT GetBattleParticipant()
		{
			return BATTLE_PARTICIPANT.ENEMY;
		}

		public void Reset()
		{
			_hpCurrent = GetHpTotal();
			_apCurrent = GetApTotal();
		}

		public bool IsDead()
		{
			return _hpCurrent <= 0;
		}

		public void TakeDamage(int damage)
		{
			if (_hpCurrent - damage <= 0) _hpCurrent = 0;
			else _hpCurrent -= damage;
		}

		public void TakeHeal(int heal)
		{
			if (_hpCurrent + heal >= GetHpTotal()) _hpCurrent = GetHpTotal();
			else _hpCurrent += heal;
		}

		public void UseAp(int apUse)
		{
			if (_apCurrent - apUse <= 0) _apCurrent = 0;
			else _apCurrent -= apUse;
		}

		public void RecoverAp(int apRecovered)
		{
			if (_apCurrent + apRecovered >= GetApTotal()) _apCurrent = GetApTotal();
			else _apCurrent += apRecovered;
		}

		public void ApplyStatusEffects()
		{

		}

		public int GetHpCurrent()
		{
			return _hpCurrent;
		}

		public int GetHpTotal()
		{
			return Stats.Hp;
		}

		public int GetApCurrent()
		{
			return _apCurrent;
		}

		public int GetApTotal()
		{
			return Stats.Ap;
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

		public int GetAffinityFireTotal()
		{
			return Stats.AffinityFire;
		}

		public int GetAffinityIceTotal()
		{
			return Stats.AffinityIce;
		}

		public int GetAffinityLightningTotal()
		{
			return Stats.AffinityLightning;
		}

		public int GetAffinityEarthTotal()
		{
			return Stats.AffinityEarth;
		}

		public int GetAffinityLightTotal()
		{
			return Stats.AffinityLight;
		}

		public int GetAffinityDarkTotal()
		{
			return Stats.AffinityDark;
		}

		public double GetAppropriateResistance(ELEMENT element)
		{
			double resistance = 0.0;

			if (element == ELEMENT.FIRE) resistance = (double)GetAffinityFireTotal() / 100.00;
			else if (element == ELEMENT.ICE) resistance = (double)GetAffinityIceTotal() / 100.00;
			else if (element == ELEMENT.LIGHTNING) resistance = (double)GetAffinityLightningTotal() / 100.00;
			else if (element == ELEMENT.EARTH) resistance = (double)GetAffinityEarthTotal() / 100.00;
			else if (element == ELEMENT.LIGHT) resistance = (double)GetAffinityLightTotal() / 100.00;
			else if (element == ELEMENT.DARK) resistance = (double)GetAffinityDarkTotal() / 100.00;

			return resistance;
		}
	}
}
