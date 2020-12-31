using Moq;
using NUnit.Framework;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Tests.Mocks;
using System.Threading.Tasks;

namespace ProjectBlazor.Tests.Game.Battle
{
	[Category("Unit")]
	public class BattleTests
	{
		PbBattle _sut;
		Mock<IPbBattleReady> _mockPlayer;
		Mock<IPbBattleReady> _mockEnemy;

		[SetUp]
		public void Setup()
		{
			//_player = new PbPlayer();
			//_enemy = new PbEnemy();

			_mockPlayer = new Mock<IPbBattleReady>();
			_mockEnemy = new Mock<IPbBattleReady>();
		}

		[TearDown]
		public void TearDown()
		{
			_sut = null;
		}

		[Test]
		public async Task Test_BattleBegins()
		{
			// Arrange
			_mockPlayer = MockBattleReady.GetBasicBattleReadyMember();
			_mockEnemy = MockBattleReady.GetBasicBattleReadyMember();

			_sut = new PbBattle(_mockPlayer.Object, _mockEnemy.Object);
			_sut.ResetBattle();

			// Act
			_sut.StartBattle();
			await Task.Delay(150);

			// Assert
			Assert.IsTrue(_sut.PlayerActionBar >= 10);
			Assert.IsTrue(_sut.EnemyActionBar >= 10);
			_sut.ResetBattle();
		}
	}
}
