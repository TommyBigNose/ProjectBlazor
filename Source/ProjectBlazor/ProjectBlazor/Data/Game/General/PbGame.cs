using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBlazor.Data.Game.General
{
	public class PbGame
	{
		public PbPlayer Player { get; set; }
		public List<PbEquipment> Equipment { get; set; }

		public PbGame()
		{
			Equipment = InitEquipment();
			Player = InitPlayer();

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
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 0, Speed = 0 }
				},
				new PbEquipment
				{
					Name = "Armor",
					Description = "A simple, mass produced, armor given out to new recruits",
					EquipmentType = PbTypes.EQUIPMENT_TYPE.ARMOR,
					Stats = new PbStats() { Hp = 0, Attack = 0, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0 }
				},
				new PbEquipment
				{
					Name = "Barrier",
					Description = "A simple, mass produced, barrier given out to new recruits",
					EquipmentType = PbTypes.EQUIPMENT_TYPE.BARRIER,
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 0, MagicAttack = 0, MagicDefense = 1, Speed = 0 }
				}
			};

			return equipment;
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
				Stats = new PbStats() { Hp = 10, Attack = 1, Defense = 1, MagicAttack = 1, MagicDefense = 1, Speed = 1 },
				EquipmentUnlocked = Equipment,
				Weapon = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.WEAPON),
				Armor = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.ARMOR),
				Barrier = Equipment.First(x => x.EquipmentType == PbTypes.EQUIPMENT_TYPE.BARRIER)
			};

			return player;
		}



	}
}
