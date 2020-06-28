using ProjectBlazor.Data.Game.General;
using ProjectBlazor.Data.Game.Stats;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Equipment
{
	public class PbEquipment : PbObject
	{
		public int Value { get; set; }
		public PbStats Stats { get; set; }
		public EQUIPMENT_TYPE EquipmentType { get; set; }
	}
}
