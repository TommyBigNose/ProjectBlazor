﻿using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using System.Linq;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.General
{
	public class PbGame
	{
		public PbPlayer Player { get; set; }
		public List<PbEquipment> Equipment { get; set; }
		public List<PbAbility> Abilities { get; set; }
		public PbBattle Battle { get; set; }

		public PbGame()
		{
			Equipment = InitEquipment();
			Abilities = InitAbilities();
			Player = InitPlayer();
			Battle = InitBattle();
		}

		/// <summary>
		/// This will eventually initialize/load from a source
		/// </summary>
		/// <returns></returns>
		private List<PbEquipment> InitEquipment()
		{
			List<PbEquipment> equipment = new List<PbEquipment>
			{
				new PbEquipment
				{
					Name = "Saber",
					Description = "A simple, mass produced, energy blade given out to new recruits",
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 }
				},
				new PbEquipment
				{
					Name = "Armor",
					Description = "A simple, mass produced, armor given out to new recruits",
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0  }
				},
				new PbEquipment
				{
					Name = "Barrier",
					Description = "A simple, mass produced, barrier given out to new recruits",
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 1, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0  }
				}
			};

			return equipment;
		}

		/// <summary>
		/// This will eventually initialize/load from a source
		/// </summary>
		/// <returns></returns>
		private List<PbAbility> InitAbilities()
		{
			List<PbAbility> abilities = new List<PbAbility>
			{
				new PbAbility
				{
					Name = "Standard Attack",
					Description = "Use your weapon as defined by its instruction manual.",
					Stats = new PbAbilityStats() { Element = ELEMENT.NONE, AttackRatio = 1, DefenseRatio = 1, MagicAttackRatio = 0, MagicDefenseRatio = 1, SpeedRatio = 1 }
				},
				new PbAbility
				{
					Name = "Flamethrower Palm",
					Description = "No equipment required, throw flames everywhere.",
					Stats = new PbAbilityStats() { Element = ELEMENT.FIRE, AttackRatio = 0, DefenseRatio = 1, MagicAttackRatio = 1.25, MagicDefenseRatio = 1, SpeedRatio = 0.8 }
				},
				new PbAbility
				{
					Name = "Glacial Charge",
					Description = "Become one with a glacier and charge the enemy...",
					Stats = new PbAbilityStats() { Element = ELEMENT.ICE, AttackRatio = 1.25, DefenseRatio = 1.25, MagicAttackRatio = 1.25, MagicDefenseRatio = 1.25, SpeedRatio = 0.25 }
				},
				new PbAbility
				{
					Name = "Lightning Dash",
					Description = "Harness the power and speed of lightning to attack quickly.",
					Stats = new PbAbilityStats() { Element = ELEMENT.LIGHTNING, AttackRatio = 0.35, DefenseRatio = 1, MagicAttackRatio = 0, MagicDefenseRatio = 1, SpeedRatio = 3 }
				}
			};

			return abilities;
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
