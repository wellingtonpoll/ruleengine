namespace RuleEngine.Domain.Extensions
{
    public static class SegmentExtensions
    {
        public static IEnumerable<string> Build(this IEnumerable<Segment> segments)
        {
            return segments.Select(segment => segment.Build());
        }
    }
}