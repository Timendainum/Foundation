using System;

namespace FoundationClassLibrary.Data
{
	/// <summary>
	/// This class is used for transforming a generic object to a properly casted value in a null safe fashion.
	/// </summary>
	public static class ObjectFormatter
	{
		/// <summary>
		/// Transforms passed object into a DateTime.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns DateTime.MinValue if null.</returns>
		public static DateTime ToDate(object value)
		{
			try
			{

				if (value == DBNull.Value)
					return DateTime.MinValue;
				else
					return Convert.ToDateTime(value);
			}
			catch (FormatException)
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>
		/// Transforms passed object into a DateTime.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value.</param>
		/// <returns>Returns default value if null.</returns>
		public static DateTime ToDate(object value, DateTime defaultValue)
		{
			DateTime result = ToDate(value);
			if (result == DateTime.MinValue)
				return defaultValue;
			else
				return result;
		}

		/// <summary>
		/// Transformed passed object to an int.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns Int32.MinValue on failure.</returns>
		public static int ToInt(object value)
		{
			if (value != null)
				return StringFormatter.ToInt(value.ToString());
			else
				return int.MinValue;
		}

		/// <summary>
		/// Transformed passed object to an int.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value to return.</param>
		/// <returns>Returns Int32.MinValue on failure.</returns>
		public static int ToInt(object value, int defaultValue)
		{
			int result = ToInt(value);
			if (result == int.MinValue)
				return defaultValue;
			else
				return result;
		}

		/// <summary>
		/// Transforms passed object to a string.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static String ToString(object value)
		{
			if (value == DBNull.Value)
				return String.Empty;
			else
				return Convert.ToString(value);
		}
		/// <summary>
		/// Transforms passed object to a float.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns float.MinValue on failure.</returns>
		public static float ToFloat(object value)
		{
			if (value == DBNull.Value)
				return float.MinValue;
			else
			{
				try
				{
					return Convert.ToSingle(value);
				}
				catch(InvalidCastException)
				{
					return float.MinValue;
				}
			}
		}

		/// <summary>
		/// Transforms passed object to a float.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value on conversion failure.</param>
		/// <returns>Returns defaultValue on failure.</returns>
		public static float ToFloat(object value, float defaultValue)
		{
			float result = ToFloat(value);
			if (result == float.MinValue)
				return defaultValue;
			else
				return result;
		}

		/// <summary>
		/// Transforms passed object to a bool.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns false on failure.</returns>
		public static bool ToBool(object value)
		{
			if (value == DBNull.Value)
				return false;
			else if (value is string)
			{
				string val = (value as string).ToLower();
				if (val.Equals("true") || val.Equals("y") || val.Equals("yes"))
					return true;
				else
					return false;
			}
			else
				return (bool)Convert.ToBoolean(value);
		}
		/// <summary>
		/// Transforms passed object to a decimal.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns decimal.MinValue on failure.</returns>
		public static decimal ToDecimal(object value)
		{
			if (value == DBNull.Value)
				return decimal.MinValue;
			else
				return Convert.ToDecimal(value);
		}

		/// <summary>
		/// Transforms passed object to a decimal.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value to return.</param>
		/// <returns>Returns defaultValue on failure.</returns>
		public static decimal ToDecimal(object value, decimal defaultValue)
		{
			decimal result = ToDecimal(value);
			if (result == decimal.MinValue)
				return defaultValue;
			else
				return result;
		}
	}
}