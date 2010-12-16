using System;
using System.Data.SqlTypes;


namespace FoundationClassLibrary.DataBase
{
	/// <summary>
	/// This class transforms values into safe formats for sending to and recovering from databases.
	/// </summary>
	public class DatabaseFormatter
	{
		#region NullSafe
		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(string value)
		{
			if (string.IsNullOrEmpty(value))
				return SqlString.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(int value)
		{
			if (value == Int32.MinValue)
				return SqlInt32.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(int? value)
		{
			if (value == Int32.MinValue || value == null)
				return SqlInt32.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(float value)
		{
			if (value == float.MinValue)
				return SqlDecimal.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(float? value)
		{
			if (value == float.MinValue || value == null)
				return SqlDecimal.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(decimal value)
		{
			if (value == decimal.MinValue)
				return SqlDecimal.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(decimal? value)
		{
			if (value == decimal.MinValue || value == null)
				return SqlDecimal.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(DateTime value)
		{
			DateTime startDate = new DateTime(1753, 1, 1);
			DateTime endDate = new DateTime(9999, 12, 31);

			if (value == DateTime.MinValue || (value < startDate || value > endDate))
				return SqlDateTime.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>database null or value</returns>
		public static object NullSafe(DateTime? value)
		{
			DateTime startDate = new DateTime(1753, 1, 1);
			DateTime endDate = new DateTime(9999, 12, 31);

			if (value == DateTime.MinValue || value == null || (value < startDate || value > endDate))
				return SqlDateTime.Null;
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object NullSafe(bool value)
		{
			return value;
		}

		/// <summary>
		/// Converts passed value to a null safe value for passing to a database
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object NullSafe(bool? value)
		{
			if (value == null)
				return SqlBoolean.Null;
			return value;
		}
		#endregion

		#region conversion
		/// <summary>
		/// Converts a boolean value to a db "flag" value. A flag is a CHAR that is either Y or N
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>"Y" or "N"</returns>
		public static object BoolToFlag(bool value)
		{
			if (value)
				return "Y";
			else
				return "N";
		}
		#endregion

		#region Format
		/// <summary>
		/// Wraps the passed string with single quotes and returns it.
		/// </summary>
		/// <param name="value">The string to wrap.</param>
		/// <returns>The string wrapped in single quotes.</returns>
		public static string SingleQuote(string value)
		{
			return String.Format("'{0}'", value);
		}

		public static string SingleQuoteAndWildCard(string value)
		{
			return String.Format("'%{0}%'", value);
		}
		#endregion

	}
}
