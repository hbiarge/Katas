namespace Game.Rules
{
    public class LivenessRule4 : ILivenessRule
    {
        // Rule 4: Any dead cell with exactly three live neighbours becomes a live cell
        public LivenessRuleResult Apply(Cell cell, int neighboursCount)
        {
            if (cell.IsAlive == false && neighboursCount == 3)
            {
                return LivenessRuleResult.AppliedWithResult(true);
            }

            return LivenessRuleResult.NotApplied();
        }
    }
}