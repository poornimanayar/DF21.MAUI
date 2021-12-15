namespace DF21.Blazor.Models
{
    public class TalkWithComments
    {
        public TalkResponse TalkDetails { get; set; }

        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}
