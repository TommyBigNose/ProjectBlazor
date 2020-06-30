using ProjectBlazor.Data.DataSource;
using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.General
{
	public class PbGame
	{
		public IPbDataSource DataSource { get; set; }
		public PbPlayer Player { get; set; }
		public List<PbEquipment> Equipment { get; set; }
		public List<PbAbility> Abilities { get; set; }
		public List<PbRace> Races { get; set; }
		public List<PbClass> Classes { get; set; }
		public PbBattle Battle { get; set; }

		public PbGame(IPbDataSource dataSource)
		{
			Equipment = dataSource.GetEquipment();
			Abilities = dataSource.GetAbilities();
			Races = dataSource.GetRaces();
			Classes = dataSource.GetClasses();

			Player = InitPlayer();
			Battle = InitBattle();
		}

		public void ResetBattle()
		{
			Battle = InitBattle();
		}

		public PbEquipment GetPlayerEquippedItem(PbTypes.EQUIPMENT_TYPE equipmentType)
		{
			PbEquipment equipment;

			if (equipmentType == EQUIPMENT_TYPE.WEAPON)
			{
				equipment = Player.Weapon;
			}
			else if (equipmentType == EQUIPMENT_TYPE.ARMOR)
			{
				equipment = Player.Armor;
			}
			else if (equipmentType == EQUIPMENT_TYPE.BARRIER)
			{
				equipment = Player.Barrier;
			}
			else
			{
				throw new ArgumentException("No such equipment type on player");
			}

			return equipment;
		}

		public void EquipItem(PbTypes.EQUIPMENT_TYPE equipmentType, string name)
		{
			PbEquipment itemToEquip = Equipment.Find(x => x.EquipmentType == equipmentType && x.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

			if (equipmentType == EQUIPMENT_TYPE.WEAPON)
			{
				Player.Weapon = itemToEquip;
			}
			else if (equipmentType == EQUIPMENT_TYPE.ARMOR)
			{
				Player.Armor = itemToEquip;
			}
			else if (equipmentType == EQUIPMENT_TYPE.BARRIER)
			{
				Player.Barrier = itemToEquip;
			}
		}

		public void EquipRace(string name)
		{
			PbRace race = Races.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

			Player.Race = race;
		}

		public void EquipClass(string name)
		{
			PbClass pbClass = Classes.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

			Player.Class = pbClass;
		}

		public void RewardPlayer(PbBattleReward reward)
		{
			Player.AddExp(reward.Exp);
			Player.Credits += reward.Credits;
		}

		/// <summary>
		/// This will eventually initialize/load from a source
		/// </summary>
		/// <returns></returns>
		private PbPlayer InitPlayer()
		{
			PbPlayer player = new PbPlayer()
			{
				Level = 1,
				Credits = 100,
				Exp = 0,
				LevelPoints = 5,
				Stats = new PbStats() { Hp = 10, Attack = 1, Defense = 1, MagicAttack = 1, MagicDefense = 1, Speed = 1, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 },
				EquipmentUnlocked = Equipment,
				Abilities = Abilities,
				Race = Races.First(x => x.Name.Equals("Human", StringComparison.OrdinalIgnoreCase)),
				Class = Classes.First(x => x.Name.Equals("Hunter", StringComparison.OrdinalIgnoreCase)),
				Weapon = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.WEAPON),
				Armor = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.ARMOR),
				Barrier = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.BARRIER)
			};

			return player;
		}

		private PbEnemy GenerateEnemy(int level)
		{
			PbEnemy enemy = new PbEnemy()
			{
				Level = level,
				Credits = 10 * level,
				Exp = 10 * level,
				Abilities = Abilities,
				Stats = new PbStats() { Hp = 10 + (3 * level), Attack = 1 + (level), Defense = 1 + (level), MagicAttack = 1 + (level), MagicDefense = 1 + (level), Speed = 1 + (level), ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 }
			};

			return enemy;
		}

		private PbBattle InitBattle()
		{
			PbEnemy enemy = GenerateEnemy(Player.Level);

			Player.ResetHp();
			enemy.ResetHp();

			PbBattle battle = new PbBattle(Player, enemy);

			return battle;
		}

	}
}
