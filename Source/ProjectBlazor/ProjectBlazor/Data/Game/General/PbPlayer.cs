using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.General
{
	public class PbPlayer : IPbBattleStats//, IPbBattleReady
	{
		private int _hpCurrent;
		public int Level { get; set; }
		public int LevelPoints { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }
		public List<PbAbility> Abilities { get; set; }
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
			Stats.Hp += 3;
			Stats.Attack += 1;
			Stats.Defense += 1;
			Stats.MagicAttack += 1;
			Stats.MagicDefense += 1;
			Stats.Speed += 1;
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
			return Stats.Hp +
				Weapon.Stats.Hp +
				Armor.Stats.Hp +
				Barrier.Stats.Hp;
		}

		public int GetAttackTotal()
		{
			return Stats.Attack +
				Weapon.Stats.Attack +
				Armor.Stats.Attack +
				Barrier.Stats.Attack;
		}

		public int GetDefenseTotal()
		{
			return Stats.Defense +
				Weapon.Stats.Defense +
				Armor.Stats.Defense +
				Barrier.Stats.Defense;
		}

		public int GetMagicAttackTotal()
		{
			return Stats.MagicAttack +
				Weapon.Stats.MagicAttack +
				Armor.Stats.MagicAttack +
				Barrier.Stats.MagicAttack;
		}

		public int GetMagicDefenseTotal()
		{
			return Stats.MagicDefense +
				Weapon.Stats.MagicDefense +
				Armor.Stats.MagicDefense +
				Barrier.Stats.MagicDefense;
		}

		public int GetSpeedTotal()
		{
			return Stats.Speed +
				Weapon.Stats.Speed +
				Armor.Stats.Speed +
				Barrier.Stats.Speed;
		}
	}
}
