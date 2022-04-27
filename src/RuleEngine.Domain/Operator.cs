namespace RuleEngine.Domain
{
    public static class Operator
    {
        public static string[] LogicalOperators = new string[] { Equal, GraterThan, LessThan, NotEqual, IN, Grater, Less };

        public const string Equal =  "==";
        public const string Grater =  ">";
        public const string GraterThan =  ">=";
        public const string Less =  "<";
        public const string LessThan =  "<=";
        public const string NotEqual =  "<>";
        public const string IN =  "IN";
        public const string AND = "AND";
    }
}