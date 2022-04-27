namespace RuleEngine.Domain
{
    public class LeftHandSide
    {
        public LeftHandSide(string title)
        {
            Title = title.TrimStart().TrimEnd();
        }

        public string Title { get; private set; }

        public bool HasValue()
        {
            return Title != null && !string.IsNullOrWhiteSpace(Title.ToString());
        }

        public override string ToString()
        {
            return Title;
        }
    }
}