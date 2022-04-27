namespace RuleEngine.Domain
{
    public class Pattern
    {
        public Pattern()
        {
            Value = string.Empty;
        }

        public Pattern(Expression expression, IEnumerable<string> segmentsExpressions)
        {
            var and = $" {Operator.AND} ";
            Value = $"({string.Join(and, segmentsExpressions)})";
        }

        public string[] SplitByAndOperator()
        {
            return Value.Split(Operator.AND);
        }

        public string Value { get; private set; }

        public override string ToString() => Value;
    }
}