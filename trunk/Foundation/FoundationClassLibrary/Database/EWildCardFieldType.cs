using System.ComponentModel;

namespace FoundationClassLibrary.DataBase
{
	public enum EWildCardFieldType
	{
		[DescriptionAttribute("bool")]
		Bool,
		[DescriptionAttribute("DateTime")]
		DateTime,
		[DescriptionAttribute("float")]
		Float,
		[DescriptionAttribute("int")]
		Int,
		[DescriptionAttribute("string")]
		String
	}
}