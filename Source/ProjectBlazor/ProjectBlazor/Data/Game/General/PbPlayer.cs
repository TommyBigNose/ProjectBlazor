using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.General
{
	public class PbPlayer
	{
		public int Level { get; set; }
		public int LevelPoints { get; set; }
		public int Exp { get; set; }
		public int Credits { get; set; }
		public PbStats Stats { get; set; }
		public List<PbEquipment> EquipmentUnlocked { get; set; }
		public PbEquipment Weapon { get; set; }
		public PbEquipment Armor { get; set; }
		public PbEquipment Barrier { get; set; }

		public PbPlayer()
		{

		}
	}
}
