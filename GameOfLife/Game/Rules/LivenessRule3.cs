namespace Game.Rules
{
    public class LivenessRule3 : ILivenessRule
    {
        // Rule 3: Any live cell with two or three live neighbours lives on to the next generation
        public LivenessRuleResult Apply(Cell cell, int neighboursCount)
        {
            if (cell.IsAlive && (neighboursCount == 2 || neighboursCount == 3))
            {
                return LivenessRuleResult.AppliedWithResult(true);
            }

            return LivenessRuleResult.NotApplied();
        }
    }
}