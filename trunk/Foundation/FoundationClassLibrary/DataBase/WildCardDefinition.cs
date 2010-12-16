using System;
using FoundationClassLibrary.Data;

namespace FoundationClassLibrary.DataBase
{
	public class WildCardDefinition : Base
	{
		public WildCardDefinition(string fieldname, EWildCardType type, EWildCardFieldType fieldType)
		{
			FieldName = fieldname;
			WildCardType = type;
			WildCardFieldType = fieldType;
		}

		public WildCardDefinition(string fieldName, string wildCardType, EWildCardFieldType fieldType)
		{
			FieldName = fieldName;
			try
			{
				WildCardType = (EWildCardType)EnumFormatter.ToEnum(wildCardType, WildCardType.GetType());
			}
			catch
			{
				throw new Exception("Unable to resolve WildCardType or improper type passed.");
			}
			WildCardFieldType = fieldType;
		}

		public WildCardDefinition(string fieldName, string wildCardType, string wildCardFieldType)
		{
			FieldName = fieldName;
			try
			{
				WildCardType = (EWildCardType)EnumFormatter.ToEnum(wildCardType, WildCardType.GetType());
			}
			catch
			{
				throw new Exception("Unable to resolve WildCardType or improper type passed.");
			}
			try
			{
				WildCardFieldType = (EWildCardFieldType)EnumFormatter.ToEnum(wildCardFieldType, WildCardFieldType.GetType());
			}
			catch
			{
				throw new Exception("Unable to resolve WildCardFieldType or improper type passed.");
			}
		}

		public string FieldName { get; set; }
		public EWildCardType WildCardType { get; set; }
		public EWildCardFieldType WildCardFieldType { get; set; }
	}
}
