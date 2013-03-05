using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Extensibility;
using Couchbase.Glimpse.Logging;

namespace Couchbase.Glimpse
{
	public class CouchbaseTab : TabBase
	{
		public override object GetData(ITabContext context)
		{
			var data = new List<object[]> { new[] { "Key", "Value" } };

			foreach (var debug in GlimpseLogger.DebugMesages)
			{
				data.Add(new object[] { "Debug", debug });
			}

			return data;
		}

		public override string Name
		{
			get { return "Couchbase"; }
		}
	}
}
