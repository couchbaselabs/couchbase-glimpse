using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Glimpse.Core.Extensibility;

namespace CouchbaseGlimpse
{
	public class CouchbaseGlimpseTab : TabBase
	{
		public override string Name
		{
			get { return "Couchbase"; }
		}

		public override object GetData(ITabContext context)
		{
			var data = new List<object[]> { new[] { "Key", "Value" } };

			data.Add(new object[] { "Hello", "World" });
			data.Add(new object[] { "Hola", "Mundo" });
			data.Add(new object[] { "Hallo", "Welt" });

			return data; 
		}
	}
}

