using System;

namespace DF21.MAUI.App.Models
{
    public class CommentRequest
    {
        public Guid TalkKey { get; set; }

        public string Title { get; set; }

        public string CommentText { get; set; }

        public string Device { get; set; }
    }
}
