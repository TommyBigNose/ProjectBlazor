using ProjectBlazor.Data.Game.Ability;
using System.Collections.Generic;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Battle
{
	public interface IPbBattleReady
	{
		BATTLE_PARTICIPANT GetBattleParticipant();
		void Reset();
		bool IsDead();
		List<PbAbility> GetAbilities();
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
		int GetAffinityFireTotal();
		int GetAffinityIceTotal();
		int GetAffinityLightningTotal();
		int GetAffinityEarthTotal();
		int GetAffinityLightTotal();
		int GetAffinityDarkTotal();
		double GetAppropriateResistance(ELEMENT element);
		int GetExp();
		int GetCredits();
	}
}
