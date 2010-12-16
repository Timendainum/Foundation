namespace FoundationClassLibrary.Log
{
	interface ILoggerDataAccess
	{
		void LogMessage(string message, string source, EType type, ESeverity severity);
	}
}
