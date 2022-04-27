namespace RuleEngine.Domain.Parsers
{
    public class DateTimeParser : DataTypeParser
    {
        public override string Parse(object value)
        {
            return $"\"{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}\"";
        }
    }
}