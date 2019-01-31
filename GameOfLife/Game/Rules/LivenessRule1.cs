namespace Game.Rules
{
    public class LivenessRule1 : ILivenessRule
    {
        // Rule 1: Any live cell with fewer than two live neighbours dies, as if caused by underpopulation
        public LivenessRuleResult Apply(Cell cell, int neighboursCount)
        {
            if (cell.IsAlive && neighboursCount < 2)
            {
                return LivenessRuleResult.AppliedWithResult(false);
            }

            return LivenessRuleResult.NotApplied();
        }
    }
}