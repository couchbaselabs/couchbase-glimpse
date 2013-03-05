using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;

namespace Couchbase.Glimpse.Logging
{
	public class GlimpseLogFactory : ILogFactory
	{
		public ILog GetLogger(Type type)
		{
			return new GlimpseLogAdapter();
		}

		public ILog GetLogger(string name)
		{
			return new GlimpseLogAdapter();
		}
	}
}
