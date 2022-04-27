using RuleEngine.Domain.Enums;

namespace RuleEngine.Domain.Parsers
{
    public abstract class DataTypeParser : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual string Parse(object value)
        {
            return value.ToString();
        }

        public static class Factor
        {
            public static DataTypeParser New(DataType dataType)
            {
                switch (dataType)
                {
                    case DataType.Unknow:
                        return new DefaultDataTypeParser();
                    case DataType.Text:
                        return new StringParser();
                    case DataType.Integer:
                        return new IntegerParser();
                    case DataType.Decimal:
                        return new DecimalParser();
                    case DataType.DateTime:
                        return new DateTimeParser();
                    case DataType.Guid:
                        return new GuidParser();
                    case DataType.StringArray:
                        return new StringArrayParser();
                    case DataType.IntegerArray:
                        return new IntegerArrayParser();
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}