namespace RuleEngine.Domain.Exceptions
{
    public class InvalidSegmentException : Exception
    {
        public Segment Segment { get; private set; }

        public InvalidSegmentException(Segment segment)
            : base("Segment is in an invalid format")
        {
            Segment = segment;
        }
    }
}