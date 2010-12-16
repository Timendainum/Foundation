namespace FoundationClassLibrary.Data
{
	/// <summary>
	/// Converts bools to other datatypes safely
	/// </summary>
	public static class BoolFormatter
	{
		/// <summary>
		/// Converts a boolean value to a string
		/// </summary>
		/// <param name="value">Boolean value</param>
		/// <returns>"true" or "false"</returns>
		public static string ToString(bool value)
		{
			if (value)
				return "true";
			else
				return "false";
		}

		/// <summary>
		/// Converts boolean value to an int
		/// </summary>
		/// <param name="value">Boolean value</param>
		/// <returns>1 or 0</returns>
		public static int ToInt(bool value)
		{
			if (value)
				return 1;
			else
				return 0;
		}

		/// <summary>
		/// convert a nullable boolean (bool?) into a regular boolean, assumes null is false.
		/// </summary>
		/// <param name="value">Nullable boolean value</param>
		/// <returns>boolean value</returns>
		public static bool ToNonNullable(bool? value)
		{
			if (value.HasValue)
			{
				if (value == true)
					return true;
				else
					return false;
			}
			else
				return false;
		}
	}
}
