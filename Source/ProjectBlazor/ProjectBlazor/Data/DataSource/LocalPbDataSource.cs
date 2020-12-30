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
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 2, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 0, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 0, AffinityDark = 0 }
				},
				new PbEquipment
				{
					Name = "Blaster",
					Description = "A simple, mass produced, energy handgun given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 1, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 0, AffinityDark = 0 }
				},
				new PbEquipment
				{
					Name = "Cane",
					Description = "A simple, mass produced, energy wand given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.WEAPON,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 0, Defense = 0, MagicAttack = 2, MagicDefense = 0, Speed = 0, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 0, AffinityDark = 0 }
				},
				new PbEquipment
				{
					Name = "Frame",
					Description = "A simple, mass produced, armor given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 0, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 0, AffinityDark = 0  }
				},
				new PbEquipment
				{
					Name = "Armor",
					Description = "A tough, mass produced, armor given out to new recruits",
					Value = 20,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 0, Defense = 2, MagicAttack = 0, MagicDefense = 0, Speed = 0, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 0, AffinityDark = 0  }
				},
				new PbEquipment
				{
					Name = "Barrier",
					Description = "A simple, mass produced, barrier given out to new recruits",
					Value = 10,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 0, Defense = 0, MagicAttack = 0, MagicDefense = 1, Speed = 0, AffinityFire = 5, AffinityIce = 5, AffinityLightning = 5, AffinityEarth = 5, AffinityLight = 0, AffinityDark = 0  }
				},
				new PbEquipment
				{
					Name = "Shield",
					Description = "A tough, mass produced, barrier given out to new recruits",
					Value = 20,
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Ap = 0, Attack = 0, Defense = 0, MagicAttack = 0, MagicDefense = 2, Speed = 0, AffinityFire = 5, AffinityIce = 5, AffinityLightning = 5, AffinityEarth = 5, AffinityLight = 0, AffinityDark = 0  }
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
					Stats = new PbAbilityStats() { ApUse = 0, AbilityPower = 1, ActionBarRatio = 1.0, AttackRatio = 1.0, DefenseRatio = 1.0, MagicAttackRatio = 0.0, MagicDefenseRatio = 1.0, SpeedRatio = 1.0 }
				},
				new PbAbility
				{
					Name = "Flamethrower Palm",
					Description = "No equipment required, throw flames everywhere.",
					Element = ELEMENT.FIRE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK_MAGIC,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { ApUse = 1, AbilityPower = 3, ActionBarRatio = 0.9, AttackRatio = 0.33, DefenseRatio = 1.0, MagicAttackRatio = 1.25, MagicDefenseRatio = 1.0, SpeedRatio = 0.8 }
				},
				new PbAbility
				{
					Name = "Glacial Charge",
					Description = "Become one with a glacier and charge the enemy...",
					Element = ELEMENT.ICE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { ApUse = 1, AbilityPower = 1, ActionBarRatio = 0.75, AttackRatio = 1.25, DefenseRatio = 1.25, MagicAttackRatio = 1.25, MagicDefenseRatio = 1.25, SpeedRatio = 0.75 }
				},
				new PbAbility
				{
					Name = "Lightning Dash",
					Description = "Harness the power and speed of lightning to attack quickly.",
					Element = ELEMENT.LIGHTNING,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK_MAGIC,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { ApUse = 1, AbilityPower = 2, ActionBarRatio = 0.33, AttackRatio = 0.33, DefenseRatio = 1.0, MagicAttackRatio = 0.33, MagicDefenseRatio = 1, SpeedRatio = 3.0 }
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
					Stats = new PbStats() {  Hp = 0, Ap = 0, Attack = 1, Defense = 0, MagicAttack = 1, MagicDefense = 0, Speed = 0, AffinityFire = -10, AffinityIce = 10, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = 10, AffinityDark = -10 }
				},
				new PbRace
				{
					Name = "Cyborg",
					Description = "When tech becomes too integrated",
					Stats = new PbStats() {  Hp = 0, Ap = 0, Attack = 1, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0, AffinityFire = 0, AffinityIce = -10, AffinityLightning = -10, AffinityEarth = 10, AffinityLight = 0, AffinityDark = 10 }
				},
				new PbRace
				{
					Name = "Mutant",
					Description = "When magic becomes too integrated",
					Stats = new PbStats() {  Hp = 0, Ap = 0, Attack = 0, Defense = 0, MagicAttack = 1, MagicDefense = 1, Speed = 0, AffinityFire = -10, AffinityIce = 0, AffinityLightning = 10, AffinityEarth = 0, AffinityLight = -10, AffinityDark = 10 }
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
					Stats = new PbStats() {  Hp = 1, Ap = 1, Attack = 1, Defense = 1, MagicAttack = 1, MagicDefense = 1, Speed = 1, AffinityFire = 5, AffinityIce = 5, AffinityLightning = 5, AffinityEarth = 5, AffinityLight = 5, AffinityDark = 5 }
				},
				new PbClass
				{
					Name = "Champion",
					Description = "",
					Stats = new PbStats() {  Hp = 1, Ap = 1, Attack = 3, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 1, AffinityFire = 10, AffinityIce = 10, AffinityLightning = -10, AffinityEarth = -10, AffinityLight = 0, AffinityDark = 10 }
				},
				new PbClass
				{
					Name = "Ranger",
					Description = "",
					Stats = new PbStats() {  Hp = 1, Ap = 1, Attack = 1, Defense = 0, MagicAttack = 1, MagicDefense = 0, Speed = 3, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 5, AffinityEarth = 5, AffinityLight = 5, AffinityDark = 15 }
				},
				new PbClass
				{
					Name = "Assassin",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Ap = 1, Attack = 3, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 3, AffinityFire = 0, AffinityIce = 0, AffinityLightning = 0, AffinityEarth = 0, AffinityLight = -50, AffinityDark = 50 }
				},
				new PbClass
				{
					Name = "Vanguard",
					Description = "",
					Stats = new PbStats() {  Hp = 2, Ap = 1, Attack = 0, Defense = 2, MagicAttack = 0, MagicDefense = 2, Speed = 0, AffinityFire = 10, AffinityIce = 10, AffinityLightning = 10, AffinityEarth = 10, AffinityLight = 0, AffinityDark = 0 }
				},
				new PbClass
				{
					Name = "Sorcerer",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Ap = 1, Attack = 0, Defense = 0, MagicAttack = 3, MagicDefense = 3, Speed = 0, AffinityFire = 10, AffinityIce = 10, AffinityLightning = 10, AffinityEarth = 10, AffinityLight = 10, AffinityDark = 10 }
				},
				new PbClass
				{
					Name = "Technician",
					Description = "",
					Stats = new PbStats() {  Hp = 0, Ap = 1, Attack = 0, Defense = 1, MagicAttack = 2, MagicDefense = 1, Speed = 2, AffinityFire = 5, AffinityIce = -5, AffinityLightning = -5, AffinityEarth = 15, AffinityLight = 5, AffinityDark = 0 }
				}
			};

			return classes;
		}
	}
}
