using Moq;
using NUnit.Framework;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Tests.Mocks;
using System.Threading.Tasks;

namespace ProjectBlazor.Tests.Game.Encounter
{
	[Category("Unit")]
	public class EncounterTests
	{

		Mock<IPbBattleReady> _mockPlayer;
		[SetUp]
		public void Setup()
		{
			_mockPlayer = new Mock<IPbBattleReady>();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public async Task Test_EncounterRecommendedLevel()
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();

			// Act

			// Assert
			Assert.IsTrue(!_mockPlayer.Object.IsDead());
		}
	}
}
