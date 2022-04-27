using RuleEngine.Domain.Exceptions;
using RuleEngine.Domain.Extensions;

namespace RuleEngine.Domain
{
    public class Segment
    {
        public Segment(string segmentPattern)
        {
            var splitedSegmentPattern = segmentPattern.SplitSegmentPattern();

            LeftHandSide = new LeftHandSide(splitedSegmentPattern[0]);
            Operator = splitedSegmentPattern[1];
            RightHandSide = RightHandSide.Factor.NewFromSegmentPattern(splitedSegmentPattern[2]);
        }

        public Segment(LeftHandSide leftHandSide, string @operator, RightHandSide rightHandSide)
        {
            LeftHandSide = leftHandSide;
            Operator = @operator;
            RightHandSide = rightHandSide;
        }

        public LeftHandSide LeftHandSide { get; private set; }
        public string Operator { get; private set; }
        public RightHandSide RightHandSide { get; private set; }

        public string Build()
        {
            if (!IsValid())
                throw new InvalidSegmentException(this);

            return ToString();
        }

        public bool IsValid() => LeftHandSide.HasValue() && RightHandSide.HasValue();
        public override string ToString() => $"({LeftHandSide} {Operator} {RightHandSide})";
    }
}