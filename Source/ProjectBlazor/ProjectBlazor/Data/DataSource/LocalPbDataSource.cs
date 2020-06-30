using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.General;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.DataSource
{
	public class LocalPbDataSource : IPbDataSource
	{
		public List<PbEquipment> GetEquipment()
		{
			List<PbEquipment> equipment = new List<PbEquipment>
			{
				new PbEquipment
				{
					Name = "Saber",
					Description = "A simple, mass produced, energy blade given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Attack = 2, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 }
				},
				new PbEquipment
				{
					Name = "Blaster",
					Description = "A simple, mass produced, energy handgun given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 1, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 }
				},
				new PbEquipment
				{
					Name = "Cane",
					Description = "A simple, mass produced, energy wand given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 0, MagicAttack = 2, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0 }
				},
				new PbEquipment
				{
					Name = "Frame",
					Description = "A simple, mass produced, armor given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0  }
				},
				new PbEquipment
				{
					Name = "Armor",
					Description = "A tough, mass produced, armor given out to new recruits",
					Value = 20,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 2, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = 0, ResistDark = 0  }
				},
				new PbEquipment
				{
					Name = "Barrier",
					Description = "A simple, mass produced, barrier given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 0, MagicAttack = 0, MagicDefense = 1, Speed = 0, ResistFire = 5, ResistIce = 5, ResistLightning = 5, ResistEarth = 5, ResistLight = 0, ResistDark = 0  }
				},
				new PbEquipment
				{
					Name = "Shield",
					Description = "A tough, mass produced, barrier given out to new recruits",
					Value = 20,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 0, MagicAttack = 0, MagicDefense = 2, Speed = 0, ResistFire = 5, ResistIce = 5, ResistLightning = 5, ResistEarth = 5, ResistLight = 0, ResistDark = 0  }
				}
			};

			return equipment;
		}

		public List<PbAbility> GetAbilities()
		{
			List<PbAbility> abilities = new List<PbAbility>
			{
				new PbAbility
				{
					Name = "Standard Attack",
					Description = "Use your weapon as defined by its instruction manual.",
					Element = ELEMENT.NONE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { AttackRatio = 1, DefenseRatio = 1, MagicAttackRatio = 0, MagicDefenseRatio = 1, SpeedRatio = 1 }
				},
				new PbAbility
				{
					Name = "Flamethrower Palm",
					Description = "No equipment required, throw flames everywhere.",
					Element = ELEMENT.FIRE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK_MAGIC,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { AttackRatio = 0, DefenseRatio = 1, MagicAttackRatio = 1.25, MagicDefenseRatio = 1, SpeedRatio = 0.8 }
				},
				new PbAbility
				{
					Name = "Glacial Charge",
					Description = "Become one with a glacier and charge the enemy...",
					Element = ELEMENT.ICE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { AttackRatio = 1.25, DefenseRatio = 1.25, MagicAttackRatio = 1.25, MagicDefenseRatio = 1.25, SpeedRatio = 0.25 }
				},
				new PbAbility
				{
					Name = "Lightning Dash",
					Description = "Harness the power and speed of lightning to attack quickly.",
					Element = ELEMENT.LIGHTNING,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK_MAGIC,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { AttackRatio = 0.33, DefenseRatio = 1, MagicAttackRatio = 0.33, MagicDefenseRatio = 1, SpeedRatio = 3 }
				}
			};

			return abilities;
		}

		public List<PbRace> GetRaces()
		{
			List<PbRace> races = new List<PbRace>
			{
				new PbRace
				{
					Name = "Human",
					Description = "Precursor species.",
					Stats = new PbStats() {  Hp = 0, Attack = 1, Defense = 0, MagicAttack = 1, MagicDefense = 0, Speed = 0, ResistFire = -10, ResistIce = 10, ResistLightning = 0, ResistEarth = 0, ResistLight = 10, ResistDark = -10 }
				},
				new PbRace
				{
					Name = "Cyborg",
					Description = "When tech becomes too integrated",
					Stats = new PbStats() {  Hp = 0, Attack = 1, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0, ResistFire = 0, ResistIce = -10, ResistLightning = -10, ResistEarth = 10, ResistLight = 0, ResistDark = 10 }
				},
				new PbRace
				{
					Name = "Mutant",
					Description = "When magic becomes too integrated",
					Stats = new PbStats() {  Hp = 0, Attack = 0, Defense = 0, MagicAttack = 1, MagicDefense = 1, Speed = 0, ResistFire = -10, ResistIce = 0, ResistLightning = 10, ResistEarth = 0, ResistLight = -10, ResistDark = 10 }
				}
			};

			return races;
		}

		public List<PbClass> GetClasses()
		{
			List<PbClass> classes = new List<PbClass>
			{
				new PbClass
				{
					Name = "Hunter",
					Description = "",
					Stats = new PbStats() {  Hp = 1, Attack = 1, Defense = 1, MagicAttack = 1, MagicDefense = 1, Speed = 1, ResistFire = 5, ResistIce = 5, ResistLightning = 5, ResistEarth = 5, ResistLight = 5, ResistDark = 5 }
				},
				new PbClass
				{
					Name = "Champion",
					Description = "",
					Stats = new PbStats() {  Hp = 1, Attack = 3, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 1, ResistFire = 10, ResistIce = 10, ResistLightning = -10, ResistEarth = -10, ResistLight = 0, ResistDark = 10 }
				},
				new PbClass
				{
					Name = "Ranger",
					Description = "",
					Stats = new PbStats() {  Hp = 1, Attack = 1, Defense = 0, MagicAttack = 1, MagicDefense = 0, Speed = 3, ResistFire = 0, ResistIce = 0, ResistLightning = 5, ResistEarth = 5, ResistLight = 5, ResistDark = 15 }
				},
				new PbClass
				{
					Name = "Assassin",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Attack = 3, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 3, ResistFire = 0, ResistIce = 0, ResistLightning = 0, ResistEarth = 0, ResistLight = -50, ResistDark = 50 }
				},
				new PbClass
				{
					Name = "Vanguard",
					Description = "",
					Stats = new PbStats() {  Hp = 2, Attack = 0, Defense = 2, MagicAttack = 0, MagicDefense = 2, Speed = 0, ResistFire = 10, ResistIce = 10, ResistLightning = 10, ResistEarth = 10, ResistLight = 0, ResistDark = 0 }
				},
				new PbClass
				{
					Name = "Sorcerer",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Attack = 0, Defense = 0, MagicAttack = 3, MagicDefense = 3, Speed = 0, ResistFire = 10, ResistIce = 10, ResistLightning = 10, ResistEarth = 10, ResistLight = 10, ResistDark = 10 }
				},
				new PbClass
				{
					Name = "Technician",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Attack = 0, Defense = 1, MagicAttack = 2, MagicDefense = 1, Speed = 2, ResistFire = 5, ResistIce = -5, ResistLightning = -5, ResistEarth = 15, ResistLight = 5, ResistDark = 0 }
				}
			};

			return classes;
		}
	}
}
