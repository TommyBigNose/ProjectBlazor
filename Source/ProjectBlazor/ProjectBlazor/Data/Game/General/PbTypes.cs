namespace ProjectBlazor.Data.Game.General
{
	public static class PbTypes
	{
		public enum ELEMENT
		{
			NONE,
			FIRE,
			ICE,
			LIGHTNING,
			EARTH,
			LIGHT,
			DARK
		};

		public enum EQUIPMENT_TYPE
		{
			WEAPON,
			ARMOR,
			BARRIER,
		};

		public enum STAT_ATTRIBUTE
		{
			HP,
			ATTACK,
			DEFENSE,
			ATTACK_MAGIC,
			DEFENSE_MAGIC,
			SPEED
		}

		public enum ABILITY_ACTION_TYPE
		{
			DAMAGE,
			HEAL,
			STATUS
		}

		public enum GAME_SCENE
		{
			MAIN,
			BATTLE,
			EQUIPMENT
		}

		public enum BATTLE_RESULT
		{
			VICTORY,
			LOSS,
			ONGOING
		}
		public enum BATTLE_PARTICIPANT
		{
			PLAYER,
			ENEMY
		}
	}
}
