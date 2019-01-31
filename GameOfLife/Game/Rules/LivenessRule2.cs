namespace Game.Rules
{
    public class LivenessRule2 : ILivenessRule
    {
        // Rule 2: Any live cell with more than three live neighbours dies, as if by overcrowding
        public LivenessRuleResult Apply(Cell cell, int neighboursCount)
        {
            if (cell.IsAlive && neighboursCount > 3)
            {
                return LivenessRuleResult.AppliedWithResult(false);
            }

            return LivenessRuleResult.NotApplied();
        }
    }
}