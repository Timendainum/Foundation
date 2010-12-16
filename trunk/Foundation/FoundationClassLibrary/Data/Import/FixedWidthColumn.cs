
namespace FoundationClassLibrary.Data.Import
{
	public class FixedWidthColumn : Column
	{
		public FixedWidthColumn(string name, int beginningCharacter, int fieldLength)
		{
			Name = name;
			BeginningCharacter = beginningCharacter;
			FieldLength = fieldLength;
		}

		/// <summary>
		/// Beginning character 0 indexed.
		/// </summary>
		public int BeginningCharacter { get; set; }

		/// <summary>
		/// Number of characters in the field
		/// </summary>
		public int FieldLength { get; set; }
	}
}
