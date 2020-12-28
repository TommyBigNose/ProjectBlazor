using ProjectBlazor.Data.Game.Ability;
using ProjectBlazor.Data.Game.General;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbAbilityActionBar
	{
		public PbAbility Ability { get; set; }
		public double ActionBar { get; set; }

		public bool IsReady()
		{
			return ActionBar >= PbConstants.Battle.BattleTimerMax;
		}

		public void IncrementActionBar(double increment)
		{
			ActionBar += increment;
			if (ActionBar >= PbConstants.Battle.BattleTimerMax) ActionBar = PbConstants.Battle.BattleTimerMax;
		}

		public void ResetActionBar()
		{
			ActionBar = 0.0;
		}
	}
}
