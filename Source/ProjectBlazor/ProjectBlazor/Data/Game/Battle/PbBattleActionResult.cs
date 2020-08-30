using static ProjectBlazor.Data.Game.General.PbTypes;

namespace ProjectBlazor.Data.Game.Battle
{
	public class PbBattleActionResult
	{
		public IPbBattleReady Source { get; set; }
		public IPbBattleReady Target { get; set; }
		public ABILITY_ACTION_TYPE AbilityActionType { get; set; }
		public int Output { get; set; }

		//public PbBattleActionResult(IPbBattleReady source, IPbBattleReady target, ABILITY_ACTION_TYPE abilityActionType, int output)
		//{
		//	Source = source;
		//	Target = target;
		//	AbilityActionType = abilityActionType;
		//	Output = output;
		//}
	}
}
