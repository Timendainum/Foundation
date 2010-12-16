using System.ComponentModel;

namespace FoundationClassLibrary.Log
{
	public enum ELoggerDataAccessType
	{
		[DescriptionAttribute("textfile")]
		TextFile,
		[DescriptionAttribute("applicationeventlog")]
		ApplicationEventLog
	}
}
