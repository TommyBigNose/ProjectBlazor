namespace ProjectBlazor.Data.Game.Battle
{
	public interface IPbBattleReady
	{
		public int TakeDamage();
		public int TakeHeal();
		public int ApplyStatusEffects();
	}
}
