namespace Game
{
    public class LivenessRuleResult
    {
        private LivenessRuleResult(bool ruleApplied, bool cellWillBeAlive)
        {
            RuleApplied = ruleApplied;
            CellWillBeAlive = cellWillBeAlive;
        }

        public bool RuleApplied { get; }

        public bool CellWillBeAlive { get; }

        public static LivenessRuleResult AppliedWithResult(bool result)
        {
            return new LivenessRuleResult(ruleApplied: true, cellWillBeAlive: result);
        }

        public static LivenessRuleResult NotApplied()
        {
            return new LivenessRuleResult(ruleApplied: false, cellWillBeAlive: false);
        }
    }
}