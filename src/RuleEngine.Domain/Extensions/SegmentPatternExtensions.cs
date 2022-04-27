namespace RuleEngine.Domain.Extensions
{
    public static class SegmentPatternExtensions
    {
        public static string[] SplitSegmentPattern(this string segmentPattern)
        {
            var @operator = string.Empty;
            var splitedSegmentPattern = new string[0];

            var index = 0;
            while (splitedSegmentPattern.Length != 2)
            {
                segmentPattern = segmentPattern.Clear();
                splitedSegmentPattern = segmentPattern.Split(Operator.LogicalOperators[index]);
                @operator = Operator.LogicalOperators[index];
                index++;
            }

            if (splitedSegmentPattern.Length != 2)
                throw new ArgumentException($"Segment pattern is in a invalid format: {segmentPattern}");

            var leftHandSide = splitedSegmentPattern[0].TrimStart().TrimEnd();
            var rightHandSide = @operator != Operator.IN 
                ? splitedSegmentPattern[1].TrimStart().TrimEnd()
                : $"({splitedSegmentPattern[1].TrimStart().TrimEnd()})";

            return new string[3] { leftHandSide, @operator, rightHandSide };
        }

        public static string Clear(this string segmentPattern)
        {
            return segmentPattern
                .Replace("(", "")
                .Replace(")", "")
                .Replace("\"","")
                .TrimStart()
                .TrimEnd();
        }
    }
}