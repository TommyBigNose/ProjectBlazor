﻿using ProjectBlazor.Data.Game.Battle;
using ProjectBlazor.Data.Game.General;
using System.Collections.Generic;

namespace ProjectBlazor.Data.Game.Encounter
{
	public class PbEncounter : PbObject, IPbEncounter
	{
		public IPbBattleReady Player { get; set; }
		public int RecommendedLevel { get; set; }
		public List<PbDecision> Decisions { get; set; }

		public PbEncounter(IPbBattleReady player, int recommendedLevel, List<PbDecision> decisions)
		{
			Player = player;
			RecommendedLevel = recommendedLevel;
			Decisions = decisions;
		}

		public List<PbDecision> GetDecisions()
		{
			return Decisions;
		}

		public int GetRecommendedLevel()
		{
			return RecommendedLevel;
		}
	}
}
