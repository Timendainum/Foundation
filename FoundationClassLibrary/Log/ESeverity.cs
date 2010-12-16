using System.ComponentModel;

namespace FoundationClassLibrary.Log
{
	public enum ESeverity
	{
		[DescriptionAttribute("debug")]
		Debug,
		[DescriptionAttribute("minor")]
		Minor,
		[DescriptionAttribute("normal")]
		Normal,
		[DescriptionAttribute("critical")]
		Critical
	}
}
