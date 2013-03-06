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
using System.Web;

namespace Couchbase.Glimpse.Logging
{
	public static class GlimpseLog
	{
		private static Dictionary<string, List<GlimpseLogRow>> _preHttpContextRows= new Dictionary<string, List<GlimpseLogRow>>();

		public static Dictionary<string, List<GlimpseLogRow>> Rows
		{
			get { return getRows(); }
		}

		public static Dictionary<string, List<GlimpseLogRow>> PreHttpContextRows
		{
			get { return _preHttpContextRows; }
		}

		public static void AddRow(GlimpseLogRow row)
		{
			//Condition when client is created in a constructor
			if (HttpContext.Current == null)
			{
				if (!_preHttpContextRows.ContainsKey(row.Level))
				{
					_preHttpContextRows[row.Level] = new List<GlimpseLogRow>();
				}
				_preHttpContextRows[row.Level].Add(row);
				return;
			}

			var rows = getRows();
			if (! rows.ContainsKey(row.Level)) 
			{
				rows[row.Level] = new List<GlimpseLogRow>();
			}
			rows[row.Level].Add(row);
		}
		
		private static Dictionary<string, List<GlimpseLogRow>> getRows()
		{
			var rows = HttpContext.Current.Items["CB:Messages"] as Dictionary<string, List<GlimpseLogRow>>;
			if (rows == null)
			{
				rows = new Dictionary<string, List<GlimpseLogRow>>();
				HttpContext.Current.Items["CB:Messages"] = rows;
			}
			return rows;
		}


	}
}
