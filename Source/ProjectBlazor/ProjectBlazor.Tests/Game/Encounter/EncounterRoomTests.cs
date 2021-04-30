using Moq;
using NUnit.Framework;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Encounter;
using ProjectBlazor.Tests.Mocks;
using System.Collections.Generic;

namespace ProjectBlazor.Tests.Game.Encounter
{
	[Category("Unit")]
	public class EncounterRoomTests
	{
		PbEncounterRoom _sut;
		Mock<IPbBattleReady> _mockPlayer;
		Mock<IPbEncounter> _mockEncounter;

		[SetUp]
		public void Setup()
		{
			_mockPlayer = new Mock<IPbBattleReady>();
			_mockEncounter = new Mock<IPbEncounter>();

		}

		[TearDown]
		public void TearDown()
		{
			_mockPlayer = null;
			_mockEncounter = null;
			_sut = null;
		}

		[Test]
		public void Test_EncounterRecommendedLevel()
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();
			_mockEncounter = MockEncounter.GetBasicEncounter();
			_sut = new PbEncounterRoom(_mockPlayer.Object, _mockEncounter.Object);

			// Act

			// Assert
			Assert.IsTrue(_sut.GetRecommendedLevel() > 0);
		}

		[Test]
		public void Test_EncounterDoesPlayerHaveRequiredStat()
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();
			_mockEncounter = MockEncounter.GetBasicEncounter();
			List<PbDecision> decisions = _mockEncounter.Object.GetDecisions();
			_sut = new PbEncounterRoom(_mockPlayer.Object, _mockEncounter.Object);

			// Act

			// Assert
			Assert.IsTrue(_sut.DoesPlayerHaveRequiredStat(decisions[0]));
			Assert.IsTrue(_sut.DoesPlayerHaveRequiredStat(decisions[1]));
			Assert.IsFalse(_sut.DoesPlayerHaveRequiredStat(decisions[2]));
		}

		[TestCase("Fight", true)]
		[TestCase("Search nearby bush", true)]
		[TestCase("Dodge", false)]
		public void Test_EncounterDoesPlayerHaveRequiredStat(string decisionName, bool expectedValue)
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();
			_mockEncounter = MockEncounter.GetBasicEncounter();
			_sut = new PbEncounterRoom(_mockPlayer.Object, _mockEncounter.Object);

			// Act

			// Assert
			Assert.IsTrue(_sut.DoesPlayerHaveRequiredStat(decisionName) == expectedValue);
		}
	}
}
