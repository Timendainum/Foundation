using System.ComponentModel;

namespace FoundationClassLibrary.DataBase
{
	public enum EWildCardType
	{
		[DescriptionAttribute("before")] //before, less than
		Before,
		[DescriptionAttribute("after")] //after, greater than
		After,
		[DescriptionAttribute("both")] //both, not equal too
		Both,
		[DescriptionAttribute("none")] //none, equal
		None
	}
}
