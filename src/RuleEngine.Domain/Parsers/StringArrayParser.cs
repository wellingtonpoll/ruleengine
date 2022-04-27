namespace RuleEngine.Domain.Parsers
{
    public class StringArrayParser : DataTypeParser
    {
        public override string Parse(object value)
        {
            var array = string.Join(",", ((string[])value).Select(item => $"\"{item}\""));
            return $"({array})";
        }
    }
}