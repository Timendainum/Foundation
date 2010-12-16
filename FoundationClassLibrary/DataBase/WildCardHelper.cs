using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.DataBase
{
	public static class WildCardHelper
	{
		public static string ParseWildCard(string fieldName, string fieldValue, WildCardDefinitionCollection wildCardDefinitions)
		{
			string result = string.Empty;
			WildCardDefinition wildCardDefinition = wildCardDefinitions.Find(delegate(WildCardDefinition wcd) { return wcd.FieldName == fieldName; });
			if (wildCardDefinition != null)
			{
				result = ParseWildCard(fieldValue, wildCardDefinition.WildCardType, wildCardDefinition.WildCardFieldType);
			}
			else
				result = fieldValue;

			return result;
		}

		public static string ParseWildCard(string fieldValue, EWildCardType type, EWildCardFieldType fieldType)
		{
			string result = string.Empty;
			switch (fieldType)
			{
				case EWildCardFieldType.Bool:
				case EWildCardFieldType.DateTime:
				case EWildCardFieldType.Float:
				case EWildCardFieldType.Int:
					return fieldValue;
				case EWildCardFieldType.String:
					switch (type)
					{
						case EWildCardType.After:
							result = String.Format("{0}%", fieldValue);
							break;
						case EWildCardType.Before:
							result = String.Format("%{0}", fieldValue);
							break;
						case EWildCardType.Both:
							result = String.Format("%{0}%", fieldValue);
							break;
						case EWildCardType.None:
							result = fieldValue;
							break;
					}
					break;
			}
			return result;
		}

		public static string ParseOperator(string fieldName, WildCardDefinitionCollection wildCardDefinitions)
		{
			string result = string.Empty;
			WildCardDefinition wildCardDefinition = wildCardDefinitions.Find(delegate(WildCardDefinition wdc) { return wdc.FieldName == fieldName; });
			if (wildCardDefinition != null)
			{
				result = ParseOperator(wildCardDefinition.WildCardType, wildCardDefinition.WildCardFieldType);
			}
			else
				result = " = ";

			return result;
		}

		public static string ParseOperator(EWildCardType type, EWildCardFieldType fieldType)
		{
			string result = string.Empty;
			switch (fieldType)
			{
				case EWildCardFieldType.Bool:
				case EWildCardFieldType.DateTime:
				case EWildCardFieldType.Float:
				case EWildCardFieldType.Int:
					switch (type)
					{
						case EWildCardType.After:
							result = " > ";
							break;
						case EWildCardType.Before:
							result = " < ";
							break;
						case EWildCardType.Both:
							result = " <> ";
							break;
						case EWildCardType.None:
							result = " = ";
							break;
					}
					break;
				case EWildCardFieldType.String:
					switch (type)
					{
						case EWildCardType.After:
						case EWildCardType.Before:
						case EWildCardType.Both:
							result = " LIKE ";
							break;
						case EWildCardType.None:
							result = " = ";
							break;
					}
					break;
			}
			return result;
		}
	}
}
