﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using FoundationClassLibrary.Data.Collection;

namespace FoundationClassLibrary.Data
{
	public static class EnumFormatter
	{
		public static string ToString(Enum value)
		{
			//Validate params
			if (value == null)
				throw new ArgumentNullException("value");
			
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes.Length > 0)
			{
				return attributes[0].Description;
			}
			else
			{
				return value.ToString();
			}
		}

		public static object ToEnum(string value, System.Type enumType)
		{
			//validate params
			if (value == null)
				throw new ArgumentNullException("value");
			

			string[] names = Enum.GetNames(enumType);
			foreach (string name in names)
			{
				string enumValue = ToString((Enum)Enum.Parse(enumType, name)).ToUpper();
				if (enumValue.Equals(value.ToUpper()))
				{
					return Enum.Parse(enumType, name);
				}
			}

			throw new ArgumentException("The string is not a description or value of the specified enum.");
		}

		public static int ToInt(Enum value)
		{
			return Convert.ToInt32(value);
		}

		/// <summary>
		/// Gets a list of key/value pairs for an enum, using the description attribute as value
		/// </summary>
		/// <param name="enumType">>typeof(your enum type)
		/// <returns>A list of KeyValuePairs with enum values and descriptions</returns>
		public static KeyValuePairIntStringCollection GetValuesAndDescription(System.Type enumType)
		{
			KeyValuePairIntStringCollection kvPairList = new KeyValuePairIntStringCollection();

			foreach (Enum enumValue in Enum.GetValues(enumType))
			{
				kvPairList.Add(new KeyValuePair<int, string>(ToInt(enumValue), ToString(enumValue)));
			}

			return kvPairList;
		}
	}
}
