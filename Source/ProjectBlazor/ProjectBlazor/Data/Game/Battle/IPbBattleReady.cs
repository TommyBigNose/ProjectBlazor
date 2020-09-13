using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Battle
{
	public interface IPbBattleReady
	{
		BATTLE_PARTICIPANT GetBattleParticipant();
		void Reset();
		bool IsDead();
		void TakeDamage(int damage);
		void TakeHeal(int heal);
		void UseAp(int apUse);
		void RecoverAp(int apRecovered);
		void ApplyStatusEffects();
		int GetHpCurrent();
		int GetHpTotal();
		int GetApCurrent();
		int GetApTotal();
		int GetAttackTotal();
		int GetDefenseTotal();
		int GetMagicAttackTotal();
		int GetMagicDefenseTotal();
		int GetSpeedTotal();
		int GetResistFireTotal();
		int GetResistIceTotal();
		int GetResistLightningTotal();
		int GetResistEarthTotal();
		int GetResistLightTotal();
		int GetResistDarkTotal();
		double GetAppropriateResistance(ELEMENT element);
	}
}
