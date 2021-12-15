namespace DF21.Blazor.Models
{
    public class CommentResponse
    {
        public Guid TalkKey { get; set; }

        public string Title { get; set; }

        public string CommentText { get; set; }

        public string Device { get; set; }
    }
}
