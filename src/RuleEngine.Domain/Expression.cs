using RuleEngine.Domain.Extensions;

namespace RuleEngine.Domain
{
    public class Expression
    {   
        public Expression(Segment segment)
        {
            Segments = new List<Segment>();
            Concat(segment);
        }

        public ICollection<Segment> Segments { get; private set; }
        public Pattern Pattern { get; private set; }

        public Expression Concat(Segment segment)
        {
            Segments.Add(segment);
            Build();
            return this;
        }

        private void Build()
        {
            var segmentsExpressions = Segments.Build();
            Pattern = new Pattern(this, segmentsExpressions);
        }

        public override string ToString()
        {
            return Pattern.Value;
        }

        public static class Factor
        {
            public static Expression NewFromSegment(Segment segment)
            {
                return new Expression(segment);
            }

            public static Expression NewFromPattern(Pattern pattern)
            {
                var segmentsPattern = pattern.SplitByAndOperator();

                // Create Segment Factor
                var segments = segmentsPattern.Select(segmentPattern => new Segment(segmentPattern)).ToArray();

                // Create extension method
                Expression expression = null;
                for (int i = 0; i < segments.Length; i++)
                {
                    expression = i > 0 ? expression.Concat(segments[i]) : NewFromSegment(segments[i]);
                }

                return expression;
            }
        }
    }
}