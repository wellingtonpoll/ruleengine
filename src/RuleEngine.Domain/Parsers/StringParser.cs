namespace RuleEngine.Domain.Parsers
{
    public class StringParser : DataTypeParser
    {
        public override string Parse(object value)
        {
            return $"\"{value}\"";
        }
    }
}