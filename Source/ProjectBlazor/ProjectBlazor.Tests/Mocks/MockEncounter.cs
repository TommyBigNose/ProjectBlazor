using Moq;
using ProjectBlazor.Data.Game.Encounter;
using System.Collections.Generic;

namespace ProjectBlazor.Tests.Mocks
{
	public static class MockEncounter
	{
		public static Mock<IPbEncounter> GetBasicEncounter()
		{
			Mock<IPbEncounter> mockEncounter = new Mock<IPbEncounter>();

			mockEncounter.Setup(x => x.GetRecommendedLevel())
				.Returns(1);

			mockEncounter.Setup(x => x.GetDecisions())
				.Returns(GetBasicDecisions());

			return mockEncounter;
		}

		public static List<PbDecision> GetBasicDecisions()
		{
			List<PbDecision> decisions = new List<PbDecision>();

			decisions = new List<PbDecision>()
			{
				new PbDecision
				{
					Id = 1,
					Name = "Fight",
					Description = "You stare down a generic look orc"
				},
				new PbDecision
				{
					Id = 2,
					Name = "Search nearby bush",
					Description = "There is something funny about that bush",
					RequiredStat = Data.Game.General.PbTypes.STAT_ATTRIBUTE.ATTACK,
					RequiredStatValue = 3
				},
				new PbDecision
				{
					Id = 3,
					Name = "Dodge",
					RequiredStat = Data.Game.General.PbTypes.STAT_ATTRIBUTE.SPEED,
					RequiredStatValue = 10
				}
			};

			return decisions;
		}
	}
}
