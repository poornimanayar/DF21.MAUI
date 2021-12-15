using System;

namespace DF21.MAUI.App.Models
{
	public class TalkResponse
	{
		
		public Guid Key { get; set; }

		
		public string Room { get; set; }

		
		public string Speaker { get; set; }

		
		public string TalkDescription { get; set; }

		
		public DateTime Time { get; set; }

		
		public string Title { get; set; }
	}
}
