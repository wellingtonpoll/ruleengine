namespace RuleEngine.Domain.Parsers
{
    public class GuidParser : DataTypeParser
    {
        public override string Parse(object value)
        {
            return $"\"{((Guid)value).ToString().ToUpper()}\"";
        }
    }
}