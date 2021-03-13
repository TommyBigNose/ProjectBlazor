using Moq;
using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Stats;
using System.Collections.Generic;
using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Tests.Mocks
{
	public static class MockBattleReady
	{
		public static Mock<IPbBattleReady> GetBasicBattleReadyMember()
		{
			Mock<IPbBattleReady> mockBattleReady = new Mock<IPbBattleReady>();

			mockBattleReady.Setup(x => x.Reset())
				.Verifiable();

			mockBattleReady.Setup(x => x.IsDead())
				.Returns(false);

			mockBattleReady.Setup(x => x.GetAbilities())
				.Returns(GetBasicAbilities());

			mockBattleReady.Setup(x => x.TakeDamage(It.IsAny<int>()))
				.Verifiable();

			mockBattleReady.Setup(x => x.TakeHeal(It.IsAny<int>()))
				.Verifiable();

			mockBattleReady.Setup(x => x.UseAp(It.IsAny<int>()))
				.Verifiable();

			mockBattleReady.Setup(x => x.RecoverAp(It.IsAny<int>()))
				.Verifiable();

			mockBattleReady.Setup(x => x.ApplyStatusEffects())
				.Verifiable();

			mockBattleReady.Setup(x => x.GetHpCurrent())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetHpTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetApCurrent())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetApTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAttackTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetDefenseTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetMagicAttackTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetMagicDefenseTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetSpeedTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityFireTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityIceTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityLightningTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityEarthTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityLightTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAffinityDarkTotal())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetAppropriateResistance(It.IsAny<ELEMENT>()))
				.Returns(10.0);

			mockBattleReady.Setup(x => x.GetExp())
				.Returns(3);

			mockBattleReady.Setup(x => x.GetCredits())
				.Returns(3);

			return mockBattleReady;
		}

		public static List<PbAbility> GetBasicAbilities()
		{
			List<PbAbility> abilities = new List<PbAbility>()
			{
				new PbAbility
				{
					Name = "TEST Standard Attack",
					Description = "TEST Use your weapon as defined by its instruction manual.",
					Element = ELEMENT.NONE,
					OutputStatAttribute = STAT_ATTRIBUTE.ATTACK,
					AbilityActionType = ABILITY_ACTION_TYPE.DAMAGE,
					Stats = new PbAbilityStats() { ApUse = 0, AbilityPower = 1, ActionBarRatio = 1.0, AttackRatio = 1.0, DefenseRatio = 1.0, MagicAttackRatio = 0.0, MagicDefenseRatio = 1.0, SpeedRatio = 1.0 }
				}
			};

			return abilities;
		}
	}
}
