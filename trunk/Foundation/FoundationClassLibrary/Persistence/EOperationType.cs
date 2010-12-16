using System.ComponentModel;

namespace FoundationClassLibrary.Persistence
{
	public enum EOperationType
	{
		[DescriptionAttribute("load")]
		Load,
		[DescriptionAttribute("update")]
		Update,
		[DescriptionAttribute("insert")]
		Insert,
		[DescriptionAttribute("delete")]
		Delete,
		[DescriptionAttribute("select")]
		Select,
		[DescriptionAttribute("unknown")]
		Unknown
	}
}
