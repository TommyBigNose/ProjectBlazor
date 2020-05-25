using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.General
{
	public class PbGame
	{
		public PbPlayer Player { get; set; }
		public List<PbEquipment> Equipment { get; set; }

		public PbGame()
		{
			Player = InitPlayer();
			Equipment = InitEquipment();
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
				Stats = new PbStats() { Hp = 10, Attack = 1, Defense = 1, MagicAttack = 1, MagicDefense = 1, Speed = 1 }
			};

			return player;
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
					Stats = new PbStats() { Hp = 0, Attack = 1, Defense = 1, MagicAttack = 0, MagicDefense = 0, Speed = 0 }
				}
			};

			return equipment;
		}

	}
}
