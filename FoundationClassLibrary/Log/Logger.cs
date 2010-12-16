using System;
using System.Configuration;
using FoundationClassLibrary.Data;

namespace FoundationClassLibrary.Log
{
	public class Logger
	{
		#region use methods
		public static void Log(string message, string source, EType type, ESeverity severity, ELoggerDataAccessType dataAccessType)
		{
			bool debug = StringFormatter.ToBool(ConfigurationManager.AppSettings["debug"]);

			if (severity != ESeverity.Debug || debug)
			{
				switch (dataAccessType)
				{
					case ELoggerDataAccessType.TextFile:
						LoggerDataAccessTextFile.LogMessage(message, source, type, severity);
						break;
					case ELoggerDataAccessType.ApplicationEventLog:
						throw new NotImplementedException();
				}
			}
		}

		public static void Log(string message)
		{
			Log(message, "none", EType.Information, ESeverity.Normal, ELoggerDataAccessType.TextFile);
		}

		public static void Log(string message, string source)
		{
			Log(message, source, EType.Information, ESeverity.Normal, ELoggerDataAccessType.TextFile);
		}

		public static void Debug(string message, string source)
		{
			Logger.Log(message, source, EType.Information, ESeverity.Debug, ELoggerDataAccessType.TextFile);
		}

		public static void Exception(string message, string source, Exception ex)
		{
			message += String.Format(" Exception message: {0}", ex.Message);
			if (ex.InnerException != null)
				message += String.Format(" Inner Exception: {0}", ex.InnerException.Message);
	
			Logger.Log(message, source, EType.Error, ESeverity.Critical, ELoggerDataAccessType.TextFile);
		}
		#endregion
	}
}
