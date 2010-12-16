using System;

namespace FoundationClassLibrary.Data
{
	/// <summary>
	/// This class is used for transforming a generic object to a properly casted value in a null safe fashion.
	/// </summary>
	public class ObjectFormatter
	{
		/// <summary>
		/// Transforms passed object into a DateTime.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns DateTime.MinValue if null.</returns>
		public static DateTime ToDate(object o)
		{
			try
			{

				if (o == DBNull.Value)
					return DateTime.MinValue;
				else
					return Convert.ToDateTime(o);
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
		public static DateTime ToDate(object o, DateTime defaultValue)
		{
			DateTime value = ToDate(o);
			if (value == DateTime.MinValue)
				return defaultValue;
			else
				return value;
		}

		/// <summary>
		/// Transformed passed object to an int.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns Int32.MinValue on failure.</returns>
		public static int ToInt(object o)
		{
			if (o != null)
				return StringFormatter.ToInt(o.ToString());
			else
				return int.MinValue;
		}

		/// <summary>
		/// Transformed passed object to an int.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value to return.</param>
		/// <returns>Returns Int32.MinValue on failure.</returns>
		public static int ToInt(object o, int defaultValue)
		{
			int value = ToInt(o);
			if (value == int.MinValue)
				return defaultValue;
			else
				return value;
		}

		/// <summary>
		/// Transforms passed object to a string.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static String ToString(object o)
		{
			if (o == DBNull.Value)
				return String.Empty;
			else
				return Convert.ToString(o);
		}
		/// <summary>
		/// Transforms passed object to a float.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns float.MinValue on failure.</returns>
		public static float ToFloat(Object o)
		{
			if (o == DBNull.Value)
				return float.MinValue;
			else
			{
				try
				{
					return Convert.ToSingle(o);
				}
				catch(Exception)
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
		public static float ToFloat(Object o, float defaultValue)
		{
			float value = ToFloat(o);
			if (value == float.MinValue)
				return defaultValue;
			else
				return value;
		}

		/// <summary>
		/// Transforms passed object to a bool.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns false on failure.</returns>
		public static bool ToBool(object o)
		{
			if (o == DBNull.Value)
				return false;
			else if (o is string)
			{
				string val = (o as string).ToLower();
				if (val.Equals("true") || val.Equals("y") || val.Equals("yes"))
					return true;
				else
					return false;
			}
			else
				return (bool)Convert.ToBoolean(o);
		}
		/// <summary>
		/// Transforms passed object to a decimal.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <returns>Returns decimal.MinValue on failure.</returns>
		public static decimal ToDecimal(object o)
		{
			if (o == DBNull.Value)
				return decimal.MinValue;
			else
				return Convert.ToDecimal(o);
		}

		/// <summary>
		/// Transforms passed object to a decimal.
		/// </summary>
		/// <param name="value">Object to be transformed.</param>
		/// <param name="defaultValue">Default value to return.</param>
		/// <returns>Returns defaultValue on failure.</returns>
		public static decimal ToDecimal(object o, decimal defaultValue)
		{
			decimal value = ToDecimal(o);
			if (value == decimal.MinValue)
				return defaultValue;
			else
				return value;
		}
	}
}