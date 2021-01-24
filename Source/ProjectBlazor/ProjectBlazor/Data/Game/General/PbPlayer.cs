using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.General
{
	public class PbPlayer : IPbBattleReady
	{
		private int _hpCurrent;
		private int _apCurrent;
		public int Level { get; set; }
		public int LevelPoints { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }
		public List<PbAbility> Abilities { get; set; }
		public PbRace Race { get; set; }
		public PbClass Class { get; set; }
		public List<PbEquipment> EquipmentUnlocked { get; set; }
		public PbEquipment Weapon { get; set; }
		public PbEquipment Armor { get; set; }
		public PbEquipment Barrier { get; set; }

		public PbPlayer()
		{

		}

		public void LevelUp()
		{
			Level++;
			LevelPoints++;
			Stats.Hp += 3 + Race.Stats.Hp + Class.Stats.Hp;
			Stats.Ap += 3 + Race.Stats.Ap + Class.Stats.Ap;
			Stats.Attack += 1 + Race.Stats.Attack + Class.Stats.Attack;
			Stats.Defense += 1 + Race.Stats.Defense + Class.Stats.Defense;
			Stats.MagicAttack += 1 + Race.Stats.MagicAttack + Class.Stats.MagicAttack;
			Stats.MagicDefense += 1 + Race.Stats.MagicDefense + Class.Stats.MagicDefense;
			Stats.Speed += 1 + Race.Stats.Speed + Class.Stats.Speed;
		}

		public void AddExp(int exp)
		{
			Exp += exp;
			if (Exp >= 100)
			{
				Exp -= 100;
				LevelUp();
			}
		}

		public BATTLE_PARTICIPANT GetBattleParticipant()
		{
			return BATTLE_PARTICIPANT.PLAYER;
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

		public List<PbAbility> GetAbilities()
		{
			return Abilities;
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
			return Stats.Hp +
				Weapon.Stats.Hp +
				Armor.Stats.Hp +
				Barrier.Stats.Hp +
				Race.Stats.Hp +
				Class.Stats.Hp;
		}

		public int GetApCurrent()
		{
			return _apCurrent;
		}

		public int GetApTotal()
		{
			return Stats.Ap +
				Weapon.Stats.Ap +
				Armor.Stats.Ap +
				Barrier.Stats.Ap +
				Race.Stats.Ap +
				Class.Stats.Ap;
		}

		public int GetAttackTotal()
		{
			return Stats.Attack +
				Weapon.Stats.Attack +
				Armor.Stats.Attack +
				Barrier.Stats.Attack +
				Race.Stats.Attack +
				Class.Stats.Attack;
		}

		public int GetDefenseTotal()
		{
			return Stats.Defense +
				Weapon.Stats.Defense +
				Armor.Stats.Defense +
				Barrier.Stats.Defense +
				Race.Stats.Defense +
				Class.Stats.Defense;
		}

		public int GetMagicAttackTotal()
		{
			return Stats.MagicAttack +
				Weapon.Stats.MagicAttack +
				Armor.Stats.MagicAttack +
				Barrier.Stats.MagicAttack +
				Race.Stats.MagicAttack +
				Class.Stats.MagicAttack;
		}

		public int GetMagicDefenseTotal()
		{
			return Stats.MagicDefense +
				Weapon.Stats.MagicDefense +
				Armor.Stats.MagicDefense +
				Barrier.Stats.MagicDefense +
				Race.Stats.MagicDefense +
				Class.Stats.MagicDefense;
		}

		public int GetSpeedTotal()
		{
			return Stats.Speed +
				Weapon.Stats.Speed +
				Armor.Stats.Speed +
				Barrier.Stats.Speed +
				Race.Stats.Speed +
				Class.Stats.Speed;
		}

		public int GetAffinityFireTotal()
		{
			return Stats.AffinityFire +
				Weapon.Stats.AffinityFire +
				Armor.Stats.AffinityFire +
				Barrier.Stats.AffinityFire +
				Race.Stats.AffinityFire +
				Class.Stats.AffinityFire;
		}

		public int GetAffinityIceTotal()
		{
			return Stats.AffinityIce +
				Weapon.Stats.AffinityIce +
				Armor.Stats.AffinityIce +
				Barrier.Stats.AffinityIce +
				Race.Stats.AffinityIce +
				Class.Stats.AffinityIce;
		}

		public int GetAffinityLightningTotal()
		{
			return Stats.AffinityLightning +
				Weapon.Stats.AffinityLightning +
				Armor.Stats.AffinityLightning +
				Barrier.Stats.AffinityLightning +
				Race.Stats.AffinityLightning +
				Class.Stats.AffinityLightning;
		}

		public int GetAffinityEarthTotal()
		{
			return Stats.AffinityEarth +
				Weapon.Stats.AffinityEarth +
				Armor.Stats.AffinityEarth +
				Barrier.Stats.AffinityEarth +
				Race.Stats.AffinityEarth +
				Class.Stats.AffinityEarth;
		}

		public int GetAffinityLightTotal()
		{
			return Stats.AffinityLight +
				Weapon.Stats.AffinityLight +
				Armor.Stats.AffinityLight +
				Barrier.Stats.AffinityLight +
				Race.Stats.AffinityLight +
				Class.Stats.AffinityLight;
		}

		public int GetAffinityDarkTotal()
		{
			return Stats.AffinityDark +
				Weapon.Stats.AffinityDark +
				Armor.Stats.AffinityDark +
				Barrier.Stats.AffinityDark +
				Race.Stats.AffinityDark +
				Class.Stats.AffinityDark;
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

		public int GetExp()
		{
			return Exp;
		}

		public int GetCredits()
		{
			return Credits;
		}
	}
}
