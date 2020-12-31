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
		public static Mock<IPbBattleReady> _mockBattleReady;

		public static Mock<IPbBattleReady> GetBasicBattleReadyMember()
		{
			_mockBattleReady = new Mock<IPbBattleReady>();

			_mockBattleReady.Setup(x => x.Reset())
				.Verifiable();

			_mockBattleReady.Setup(x => x.IsDead())
				.Returns(false);

			_mockBattleReady.Setup(x => x.GetAbilities())
				.Returns(GetBasicAbilities());

			_mockBattleReady.Setup(x => x.TakeDamage(It.IsAny<int>()))
				.Verifiable();

			_mockBattleReady.Setup(x => x.TakeHeal(It.IsAny<int>()))
				.Verifiable();

			_mockBattleReady.Setup(x => x.UseAp(It.IsAny<int>()))
				.Verifiable();

			_mockBattleReady.Setup(x => x.RecoverAp(It.IsAny<int>()))
				.Verifiable();

			_mockBattleReady.Setup(x => x.ApplyStatusEffects())
				.Verifiable();

			_mockBattleReady.Setup(x => x.GetHpCurrent())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetHpTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetApCurrent())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetApTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAttackTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetDefenseTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetMagicAttackTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetMagicDefenseTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetSpeedTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityFireTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityIceTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityLightningTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityEarthTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityLightTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAffinityDarkTotal())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetAppropriateResistance(It.IsAny<ELEMENT>()))
				.Returns(It.IsAny<double>);

			_mockBattleReady.Setup(x => x.GetExp())
				.Returns(It.IsAny<int>);

			_mockBattleReady.Setup(x => x.GetCredits())
				.Returns(It.IsAny<int>);

			return _mockBattleReady;
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
