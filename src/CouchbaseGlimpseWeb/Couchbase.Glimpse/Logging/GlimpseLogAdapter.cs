using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;

namespace Couchbase.Glimpse.Logging
{
	public class GlimpseLogAdapter : ILog
	{
		public void Debug(object message, Exception exception)
		{
			return;
		}

		public void Debug(object message)
		{
			GlimpseLogger.Debug(message.ToString());
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			return;
		}

		public void DebugFormat(string format, params object[] args)
		{
			return;
		}

		public void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			return;
		}

		public void DebugFormat(string format, object arg0, object arg1)
		{
			return;
		}

		public void DebugFormat(string format, object arg0)
		{
			return;
		}

		public void Error(object message, Exception exception)
		{
			return;
		}

		public void Error(object message)
		{
			return;
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			return;
		}

		public void ErrorFormat(string format, params object[] args)
		{
			return;
		}

		public void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			return;
		}

		public void ErrorFormat(string format, object arg0, object arg1)
		{
			return;
		}

		public void ErrorFormat(string format, object arg0)
		{
			return;
		}

		public void Fatal(object message, Exception exception)
		{
			return;
		}

		public void Fatal(object message)
		{
			return;
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			return;
		}

		public void FatalFormat(string format, params object[] args)
		{
			return;
		}

		public void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			return;
		}

		public void FatalFormat(string format, object arg0, object arg1)
		{
			return;
		}

		public void FatalFormat(string format, object arg0)
		{
			return;
		}

		public void Info(object message, Exception exception)
		{
			return;
		}

		public void Info(object message)
		{
			return;
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			return;
		}

		public void InfoFormat(string format, params object[] args)
		{
			return;
		}

		public void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			return;
		}

		public void InfoFormat(string format, object arg0, object arg1)
		{
			return;
		}

		public void InfoFormat(string format, object arg0)
		{
			return;
		}

		public bool IsDebugEnabled
		{
			get { return true; }
		}

		public bool IsErrorEnabled
		{
			get { return false; }
		}

		public bool IsFatalEnabled
		{
			get { return false; }
		}

		public bool IsInfoEnabled
		{
			get { return false; }
		}

		public bool IsWarnEnabled
		{
			get { return false; }
		}

		public void Warn(object message, Exception exception)
		{
			return;
		}

		public void Warn(object message)
		{
			return;
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			return;
		}

		public void WarnFormat(string format, params object[] args)
		{
			return;
		}

		public void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			return;
		}

		public void WarnFormat(string format, object arg0, object arg1)
		{
			return;
		}

		public void WarnFormat(string format, object arg0)
		{
			return;
		}
	}
}
