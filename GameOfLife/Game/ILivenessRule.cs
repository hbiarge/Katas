namespace Game
{
    public interface ILivenessRule
    {
        LivenessRuleResult Apply(Cell cell, int neighboursCount);
    }
}