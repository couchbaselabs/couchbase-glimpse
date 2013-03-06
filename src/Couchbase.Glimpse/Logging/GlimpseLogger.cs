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
using Enyim.Caching;
using System.Threading;

namespace Couchbase.Glimpse.Logging
{
	public class GlimpseLogger : ILog
	{
		public enum LogLevel { Debug, Info, Warn, Error, Fatal }

		private static GlimpseLogConfiguration _configuration = new GlimpseLogConfiguration();
		private readonly string _type;

		public GlimpseLogger(string type)
		{
			_type = type;
		}

		public static void Configure(GlimpseLogConfiguration configuration)
		{
			_configuration = configuration;
		}

		#region Debug
		public void Debug(object message, Exception exception)
		{
			addRow(LogLevel.Debug, message, ex: exception);
		}

		public void Debug(object message)
		{
			addRow(LogLevel.Debug, message);
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			DebugFormat(format, args);
		}

		public void DebugFormat(string format, params object[] args)
		{
			addRow(LogLevel.Debug, format, args: args);
		}

		public void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			addRow(LogLevel.Debug, format, args: new object[] { arg0, arg1, arg2 });
		}

		public void DebugFormat(string format, object arg0, object arg1)
		{
			addRow(LogLevel.Debug, format, args: new object[] { arg0, arg1 });
		}

		public void DebugFormat(string format, object arg0)
		{
			addRow(LogLevel.Debug, format, args: new object[] { arg0 });
		}
		#endregion

		public void Error(object message, Exception exception)
		{
			addRow(LogLevel.Error, message, ex: exception);
		}

		public void Error(object message)
		{
			addRow(LogLevel.Error, message);
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			ErrorFormat(format, args);
		}

		public void ErrorFormat(string format, params object[] args)
		{
			addRow(LogLevel.Error, format, args: args);
		}

		public void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			addRow(LogLevel.Error, format, args: new object[] { arg0, arg1, arg2 });
		}

		public void ErrorFormat(string format, object arg0, object arg1)
		{
			addRow(LogLevel.Error, format, args: new object[] { arg0, arg1 });
		}

		public void ErrorFormat(string format, object arg0)
		{
			addRow(LogLevel.Error, format, args: new object[] { arg0 });
		}

		public void Fatal(object message, Exception exception)
		{
			addRow(LogLevel.Fatal, message, ex: exception );
		}

		public void Fatal(object message)
		{
			addRow(LogLevel.Fatal, message);
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			FatalFormat(format, args);
		}

		public void FatalFormat(string format, params object[] args)
		{
			addRow(LogLevel.Fatal, format, args: args);
		}

		public void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			addRow(LogLevel.Fatal, format, args: new object[] { arg0, arg1, arg2 });
		}

		public void FatalFormat(string format, object arg0, object arg1)
		{
			addRow(LogLevel.Fatal, format, args: new object[] { arg0, arg1 });
		}

		public void FatalFormat(string format, object arg0)
		{
			addRow(LogLevel.Fatal, format, args: new object[] { arg0 });
		}

		public void Info(object message, Exception exception)
		{
			addRow(LogLevel.Info, message, ex: exception);
		}

		public void Info(object message)
		{
			addRow(LogLevel.Info, message);
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			InfoFormat(format, args);
		}

		public void InfoFormat(string format, params object[] args)
		{
			addRow(LogLevel.Info, format, args: args);
		}

		public void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			addRow(LogLevel.Info, format, args: new object[] { arg0, arg1, arg2 });
		}

		public void InfoFormat(string format, object arg0, object arg1)
		{
			addRow(LogLevel.Info, format, args: new object[] { arg0, arg1 });
		}

		public void InfoFormat(string format, object arg0)
		{
			addRow(LogLevel.Info, format, args: new object[] { arg0 });
		}

		public bool IsDebugEnabled
		{
			get { return _configuration.IsDebugEnabled; }
		}

		public bool IsErrorEnabled
		{
			get { return _configuration.IsErrorEnabled || _configuration.IsWarnEnabled; }
		}

		public bool IsFatalEnabled
		{
			get { return _configuration.IsFatalEnabled || _configuration.IsErrorEnabled; }
		}

		public bool IsInfoEnabled
		{
			get { return _configuration.IsInfoEnabled || _configuration.IsDebugEnabled; }
		}

		public bool IsWarnEnabled
		{
			get { return _configuration.IsWarnEnabled || _configuration.IsInfoEnabled; }
		}

		public void Warn(object message, Exception exception)
		{
			addRow(LogLevel.Warn, message, ex: exception);
		}

		public void Warn(object message)
		{
			addRow(LogLevel.Warn, message);
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			WarnFormat(format);
		}

		public void WarnFormat(string format, params object[] args)
		{
			addRow(LogLevel.Warn, format, args: args);
		}

		public void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			addRow(LogLevel.Warn, format, args: new object[] { arg0, arg1, arg2 });
		}

		public void WarnFormat(string format, object arg0, object arg1)
		{
			addRow(LogLevel.Warn, format, args: new object[] { arg0, arg1 });
		}

		public void WarnFormat(string format, object arg0)
		{
			addRow(LogLevel.Warn, format, args: new object[] { arg0 });
		}

		private void addRow(LogLevel level, object message, Exception ex = null, object[] args = null)
		{
			if (_configuration.SourceWhiteList.Count > 0 && ! _configuration.SourceWhiteList.Contains(_type))
			{
				return;
			}

			var row = new GlimpseLogRow
			{
				Level = Enum.GetName(typeof(LogLevel), level).ToUpper(),
				Message = args == null ? message as string : string.Format(message as string, args),
				Timestamp = DateTime.Now,
				Exception = ex,
				Source = _type,
				ThreadId = Thread.CurrentThread.ManagedThreadId
			};

			GlimpseLog.AddRow(row);
		}
	}
}
