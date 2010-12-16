using System.ComponentModel;

namespace FoundationClassLibrary.Log
{
	public enum EType
	{
		[DescriptionAttribute("information")]
		Information,
		[DescriptionAttribute("warning")]
		Warning,
		[DescriptionAttribute("error")]
		Error
	}
}
