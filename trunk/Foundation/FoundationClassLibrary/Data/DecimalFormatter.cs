namespace FoundationClassLibrary.Data
{
	public static class DecimalFormatter
	{
		#region value mapping, turn DateTime into other values safely.
		/// <summary>
		/// Converts decimal to a string safely.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns>Returns string.Empty on failure.</returns>
		public static string ToString(decimal value, string format)
		{
			if (value == decimal.MinValue)
				return string.Empty;
			else
				return value.ToString(format);
		}
		/// <summary>
		/// Converts decimal to a string safely.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <param name="nullText"></param>
		/// <returns>Returns null value on failure.</returns>
		public static string ToString(decimal value, string format, string nullText)
		{
			string ret = ToString(value, format);
			if (string.IsNullOrEmpty(ret))
				return nullText;
			else
				return ret;
		}
		#endregion
	}
}
