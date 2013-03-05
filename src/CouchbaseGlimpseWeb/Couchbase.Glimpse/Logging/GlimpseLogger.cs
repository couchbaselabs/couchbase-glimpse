using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Couchbase.Glimpse.Logging
{
	public static class GlimpseLogger
	{
		public static IList<string> DebugMesages
		{
			get { return debugMessages; }
		}

		public static void Debug(string message)
		{
			if (HttpContext.Current == null) return;
			debugMessages.Add(message);
		}

		private static IList<string> debugMessages
		{ 
			get
			{
				return getMessages("Debug");
			}
		}

		private static List<string> getMessages(string level)
		{
			var key = "CB::" + level;
			var messages = HttpContext.Current.Items[key] as List<string>;
			if (messages == null)
			{
				messages = new List<string>();
				HttpContext.Current.Items[key] = messages;
			}

			return messages;
		}


	}
}
