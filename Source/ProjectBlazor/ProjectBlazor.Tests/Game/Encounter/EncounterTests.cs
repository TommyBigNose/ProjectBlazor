using Moq;
using NUnit.Framework;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.Encounter;
using ProjectBlazor.Tests.Mocks;
using System.Collections.Generic;

namespace ProjectBlazor.Tests.Game.Encounter
{
	[Category("Unit")]
	public class EncounterTests
	{
		IPbEncounter _sut;
		Mock<IPbBattleReady> _mockPlayer;

		[SetUp]
		public void Setup()
		{
			_mockPlayer = new Mock<IPbBattleReady>();


		}

		[TearDown]
		public void TearDown()
		{
			_mockPlayer = null;
			_sut = null;
		}

		[Test]
		public void Test_EncounterRecommendedLevel()
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();
			List<PbDecision> decisions = new List<PbDecision>();
			_sut = new PbEncounter(_mockPlayer.Object, 1, decisions);

			// Act

			// Assert
			Assert.IsTrue(_sut.GetRecommendedLevel() > 0);
		}
	}
}
