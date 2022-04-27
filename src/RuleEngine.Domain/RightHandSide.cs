using RuleEngine.Domain.Enums;
using RuleEngine.Domain.Extensions;
using RuleEngine.Domain.Parsers;

namespace RuleEngine.Domain
{
    public class RightHandSide
    {
        private readonly DataTypeParser _dataTypeParser;
        public RightHandSide(object value, DataType dataType)
        {
            Value = value;
            DataType = dataType;
            _dataTypeParser = DataTypeParser.Factor.New(DataType);
        }

        public object Value { get; private set; }
        public DataType DataType { get; private set; }

        public bool HasValue()
        {
            return Value != null && !string.IsNullOrWhiteSpace(Value.ToString());
        }

        public override string ToString() => _dataTypeParser.Parse(Value);

        public static class Factor
        {
            public static RightHandSide NewText(string text) => new RightHandSide(text, DataType.Text);
            public static RightHandSide NewInteger(int integer) => new RightHandSide(integer, DataType.Integer);
            public static RightHandSide NewDecimal(decimal @decimal) => new RightHandSide(@decimal, DataType.Decimal);
            public static RightHandSide NewDateTime(DateTime dateTime) => new RightHandSide(dateTime, DataType.DateTime);
            public static RightHandSide NewGuid(Guid guid) => new RightHandSide(guid, DataType.Guid);
            public static RightHandSide NewStringArray(string[] stringArray) => new RightHandSide(stringArray, DataType.StringArray);
            public static RightHandSide NewIntegerArray(int[] integerArray) => new RightHandSide(integerArray, DataType.IntegerArray);
            public static RightHandSide NewAnotherField(string fieldName) => new RightHandSide(fieldName, DataType.Unknow);
            public static RightHandSide NewFromSegmentPattern(string splitedSegmentPattern)
            {
                RightHandSide rightHandSide;

                if (Guid.TryParse(splitedSegmentPattern, out Guid guid))
                    rightHandSide = NewGuid(guid);

                else if (decimal.TryParse(splitedSegmentPattern, out decimal @decimal) && splitedSegmentPattern.Contains('.'))
                    rightHandSide = NewDecimal(@decimal);

                else if (int.TryParse(splitedSegmentPattern, out int integer))
                    rightHandSide = NewInteger(integer);

                else if (DateTime.TryParse(splitedSegmentPattern, out DateTime dateTime))
                    rightHandSide = NewDateTime(dateTime);

                else if (splitedSegmentPattern.Contains("input"))
                    rightHandSide = NewAnotherField(splitedSegmentPattern);

                else if (splitedSegmentPattern.Contains('(') && splitedSegmentPattern.Contains(')'))
                {
                    var array = splitedSegmentPattern.Clear();
                    var splitedArray = array.Split(',');

                    if (splitedArray.All(item => int.TryParse(item, out _)))
                        rightHandSide = NewIntegerArray(splitedArray.Select(item => int.Parse(item)).ToArray());
                    else
                        rightHandSide = NewStringArray(splitedArray);
                }
                
                else
                    rightHandSide = NewText(splitedSegmentPattern);

                return rightHandSide;
            }
        }
    }
}