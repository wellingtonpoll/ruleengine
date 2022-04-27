namespace RuleEngine.Domain.Parsers
{
    public class IntegerArrayParser : DataTypeParser
    {
        public override string Parse(object value)
        {
            var array = string.Join(",", ((int[])value).Select(item => item.ToString()));
            return $"({array})";
        }
    }
}