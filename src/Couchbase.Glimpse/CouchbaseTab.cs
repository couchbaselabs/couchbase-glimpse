/**
 * Copyright (c) 2012 Couchbase, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

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
			var data = new List<object[]> { new[] { "Level", "Timestamp", "Source", "Message", "Exception", "Thread" } };

			Action<Dictionary<string, List<GlimpseLogRow>>> addData = (d) =>
				{
					foreach (var key in d.Keys)
					{
						d[key].ForEach(a =>
						{
							var exCol = new List<object> { };
							if (a.Exception != null)
							{
								exCol.Add(new object[] { "Message", "StackTrace" });
								exCol.Add(new object[] { a.Exception.Message, a.Exception.StackTrace });
							}
							data.Add(new object[] { a.Level, a.Timestamp, a.Source, a.Message, exCol, a.ThreadId });
						});
					}
				};

			addData(GlimpseLog.PreHttpContextRows);
			addData(GlimpseLog.Rows);
			GlimpseLog.PreHttpContextRows.Clear();
			return data;
		}

		public override string Name
		{
			get { return "Couchbase"; }
		}

	}
}
