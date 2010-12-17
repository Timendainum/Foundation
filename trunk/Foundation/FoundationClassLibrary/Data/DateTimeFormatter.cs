using System;
using System.Globalization;

namespace FoundationClassLibrary.Data
{
	public static class DateTimeFormatter
	{
		#region value mapping, turn DateTime into other values safely.
		/// <summary>
		/// Converts passed date to a null safe string that is formatted by format.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static string ToString(DateTime value, string format)
		{
			if (value == DateTime.MinValue)
				return string.Empty;
			else
				return value.ToString(format);
		}

		/// <summary>
		/// Converts passed date to a null safe string that is formatted by format.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static string ToString(DateTime? value, string format)
		{
			DateTime newValue;
			if (value == null)
				newValue = DateTime.MinValue;
			else
				newValue = (DateTime)value;

			return ToString(newValue, format);
		}

		/// <summary>
		/// Converts passed date to a null safe string that is formatted by format.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <param name="nullText"></param>
		/// <returns>Returns nullText argument on failure.</returns>
		public static string ToString(DateTime value, string format, string nullText)
		{
			string result = ToString(value, format);
			if (string.IsNullOrEmpty(result))
				return nullText;
			else
				return result;
		}

		/// <summary>
		/// Converts passed date to a null safe string that is formatted by format.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <param name="nullText"></param>
		/// <returns>Returns nullText argument on failure.</returns>
		public static string ToString(DateTime? value, string format, string nullText)
		{
			DateTime newValue;
			if (value == null)
				newValue = DateTime.MinValue;
			else
				newValue = (DateTime)value;

			return ToString(newValue, format, nullText);
		}

		#region ODBC format
		public static string ToOdbcDate(DateTime value)
		{
			return ToString(value, "yyyy-MM-dd", string.Empty);
		}

		public static string ToOdbcDate(DateTime value, string nullText)
		{
			return ToString(value, "yyyy-MM-dd", nullText);
		}
		public static string ToOdbcDateTime(DateTime value)
		{
			return ToString(value, "yyyy-MM-dd hh:mm:ss", string.Empty);
		}

		public static string ToOdbcDateTime(DateTime value, string nullText)
		{
			return ToString(value, "yyyy-MM-dd hh:mm:ss", nullText);
		}
		#endregion


		#region iso/sharepoint format
		public static string ToSharePointString(DateTime value)
		{
			
			if (value == DateTime.MinValue)
				return string.Empty;
			else
				return value.ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
		}

		public static string ToSharePointString(DateTime? value)
		{
			DateTime newValue;
			if (value == null)
				newValue = DateTime.MinValue;
			else
				newValue = (DateTime)value;

			return ToSharePointString(newValue);
		}
		#endregion
		#endregion
	}
}
