using System.Collections.Generic;

namespace DF21.MAUI.App.Models
{
    public class TalkWithComments
    {
        public TalkResponse TalkDetails { get; set; }

        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}
