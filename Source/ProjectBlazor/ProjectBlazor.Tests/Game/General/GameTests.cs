﻿using NUnit.Framework;
using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.General;

namespace ProjectBlazor.Tests.Game.General
{
	[Category("Unit")]
	public class GameTests
	{
		PbBattle _sut;
		PbPlayer _player;
		PbEnemy _enemy;

		[SetUp]
		public void Setup()
		{
			_player = new PbPlayer();
			_enemy = new PbEnemy();

			_sut = new PbBattle(_player, _enemy);
		}

		[TearDown]
		public void TearDown()
		{
			_sut = null;
		}


	}
}
