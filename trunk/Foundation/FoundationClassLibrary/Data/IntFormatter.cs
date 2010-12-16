namespace FoundationClassLibrary.Data
{
	public class IntFormatter
	{
		#region value mapping, turn other values into strings safely.
		/// <summary>
		/// Converts int to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToString(int value)
		{
			return ToString(value, "d");
		}

		/// <summary>
		/// Converts int? to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToString(int? value)
		{
			if (value == null)
				return string.Empty;
			else
				return ToString((int)value, "d");
		}
		
		
		/// <summary>
		/// Converts int to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format">Standard .Net format string</param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static string ToString(int value, string format)
		{
			if (value == int.MinValue)
				return string.Empty;
			else
				return value.ToString(format);
		}

		/// <summary>
		/// Converts int? to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format">Standard .Net format string</param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static string ToString(int? value, string format)
		{
			if (value == null)
				return string.Empty;
			else
				return ToString((int)value, format);
		}
		
		/// <summary>
		/// Converts int to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format">Standard .Net format string</param>
		/// <param name="nullText"></param>
		/// <returns>Returns nullText on failure.</returns>
		public static string ToString(int value, string format, string nullText)
		{
			string ret = ToString(value, format);
			if (string.IsNullOrEmpty(ret))
				return nullText;
			else
				return ret;
		}

		/// <summary>
		/// Converts int? to a null safe string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format">Standard .Net format string</param>
		/// <param name="nullText"></param>
		/// <returns>Returns nullText on failure.</returns>
		public static string ToString(int? value, string format, string nullText)
		{
			string ret = ToString(value, format);
			if (string.IsNullOrEmpty(ret))
				return nullText;
			else
				return ret;
		}

		#endregion

		#region null/min safing methods
		public static int NullsafeZero(int value)
		{
			if (value == int.MinValue)
				value = 0;
			return value;
		}

		public static int? NullsafeZero(int? value)
		{
			if (value == null)
				value = 0;
			return value;
		}
		#endregion
	}
}
