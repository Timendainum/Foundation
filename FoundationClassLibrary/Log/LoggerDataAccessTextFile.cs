using System;
using System.Configuration;
using System.IO;
using FoundationClassLibrary.Data;

namespace FoundationClassLibrary.Log
{
	static class LoggerDataAccessTextFile
	{
		#region ILoggerDataAccess Members

		public static void LogMessage(string message, string source, EType type, ESeverity severity)
		{
			string logPath = ConfigurationManager.AppSettings["LogPath"];
			string logFileName = StringFormatter.SafeFileName(String.Format("{0}.txt", DateTime.Now.ToShortDateString()));

			StreamWriter writer = null;

			//Open stream writer depending on if this is a new file or not
			try
			{
				if (!File.Exists(logPath + logFileName))
				{
					writer = File.CreateText(logPath + logFileName);
				}
				else
					writer = File.AppendText(logPath + logFileName);

				//write log entry
				string logEntry = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + ControlCharacters.Tab + EnumFormatter.ToString(type) + ControlCharacters.Tab + EnumFormatter.ToString(severity) + ControlCharacters.Tab + source + ControlCharacters.Tab + StringFormatter.RemoveInvisibleCharacters(message);
				writer.WriteLine(logEntry);
			}
			catch
			{
				throw;
			}
			finally
			{
				writer.Close();
			}
		}

		#endregion
	}
}
