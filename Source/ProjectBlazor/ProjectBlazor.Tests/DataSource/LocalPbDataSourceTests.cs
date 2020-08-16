using NUnit.Framework;
using ProjectBlazor.Data.DataSource;
using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.Equipment;
using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Tests.DataSource
{
	[Category("Unit")]
	public class LocalPbDataSourceTests
	{
		IPbDataSource _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new LocalPbDataSource();
		}

		[TearDown]
		public void TearDown()
		{
			_sut = null;
		}

		[Test]
		public void GetEquipment_ReturnsEquipment()
		{
			// Arrange

			// Act
			List<PbEquipment> result = _sut.GetEquipment();

			// Asert
			Assert.IsTrue(result.Count > 0);
		}

		[Test]
		public void GetAbilities_ReturnsAbilities()
		{
			// Arrange

			// Act
			List<PbAbility> result = _sut.GetAbilities();

			// Asert
			Assert.IsTrue(result.Count > 0);
		}

		[Test]
		public void GetRaces_ReturnsRaces()
		{
			// Arrange

			// Act
			List<PbRace> result = _sut.GetRaces();

			// Asert
			Assert.IsTrue(result.Count > 0);
		}

		[Test]
		public void GetClasses_ReturnsClasses()
		{
			// Arrange

			// Act
			List<PbClass> result = _sut.GetClasses();

			// Asert
			Assert.IsTrue(result.Count > 0);
		}
	}
}
