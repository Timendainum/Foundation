using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FoundationClassLibrary.Data.Collection;

/// <summary>
/// This class contains methods to help with strings.
/// </summary>
namespace FoundationClassLibrary.Data
{
    /// <summary>
    /// This class contains many methods for general string manipulation and formating.
    /// </summary>
    public static class StringFormatter
    {
        #region declarations
        private static string[] specialCharacters =
		{ 
			@"`",
			@"-", 
			@"=", 
			@"[", 
			@"]", 
			@"\", 
			@";", 
			@"'", 
			"\"",
			@",", 
			@"/", 
			@"~", 
			@"!", 
			@"@", 
			@"#",
			@"$",
			@"%", 
			@"^",
			@"&",
			@"*", 
			@"(", 
			@")", 
			@"+", 
			@"{", 
			@"}", 
			@"|", 
			@":", 
			@"<", 
			@">", 
			@"?"
		};

        private static string replaceChar = @"_";
        private static string doubleReplaceChar = replaceChar + replaceChar;
        #endregion

        #region base string manipulation
        /// <summary>
        /// Returns the specified number of characters from the left side of the string.
        /// </summary>
        /// <param name="value">String to parse.</param>
        /// <param name="length">Number of characters to return.</param>
        /// <returns>Lefted string.</returns>
        public static string Left(string value, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = string.Empty;
            value = NullSafe(value);
            if (value.Length > length)
                result = value.Substring(0, length);
            else
                result = value;
            return result;
        }

        /// <summary>
        /// Returns the specified number of characters from the left side of the string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(string value, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = string.Empty;
            value = NullSafe(value);
            if (value.Length > length)
                result = value.Substring(value.Length - length, length);
            else
                result = value;
            return result;
        }

        /// <summary>
        /// Returns a part of a string starting at the index specified. Returns number of characters specified in length.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Mid(string value, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = string.Empty;
            value = NullSafe(value);
            if (value.Length > length)
                result = value.Substring(startIndex, length);
            return result;
        }

        /// <summary>
        /// Returns a part of a string starting at the start index.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string Mid(string value, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = string.Empty;
            value = NullSafe(value);
            if (value.Length > startIndex)
                result = value.Substring(startIndex);
            return result;
        }
        #endregion

        #region safen strings
        /// <summary>
        /// This returns an empty string if the passed string is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NullSafe(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            else
                return value;
        }

        /// <summary>
        /// This method replaces special characters with underscores then removes excess 
        /// to create a safe filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SafeFileName(string fileName)
        {
            string processedFileName = NullSafe(fileName);

            //Replace special characters
            foreach (string character in specialCharacters)
            {
                processedFileName = processedFileName.Replace(character, replaceChar);
            }

            //Get rid of double underscores
            while (processedFileName.Contains(doubleReplaceChar))
            {
                processedFileName = processedFileName.Replace(doubleReplaceChar, replaceChar);
            }

            return processedFileName;
        }
        #endregion

        #region value mapping, turn string into other values safely.
        /// <summary>
        /// This returns the best match int for given string.
        /// </summary>
		/// <param name="value"></param>
        /// <returns>Returns int.MinValue on failure.</returns>
        public static int ToInt(string value)
        {
            int result;
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out result))
                result = int.MinValue;
            return result;
        }

		/// <summary>
		/// This returns the best match int for given string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="defaultValue"></param>
		/// <returns>Returns int.MinValue on failure.</returns>
		public static int ToInt(string value, int defaultValue)
		{
			int result;
			if (string.IsNullOrEmpty(value) || !int.TryParse(value, out result))
				result = defaultValue;
			return result;
		}

		public static decimal ToDecimal(string value)
		{
			decimal result;
			if (string.IsNullOrEmpty(value) || !decimal.TryParse(value, out result))
				result = decimal.MinValue;
			return result;
		}

		public static decimal ToDecimal(string value, decimal defaultValue)
		{
			decimal result;
			if (string.IsNullOrEmpty(value) || !decimal.TryParse(value, out result))
				result = defaultValue;
			return result;
		}

		public static float ToFloat(string value)
		{
			float result;
			if (string.IsNullOrEmpty(value) || !float.TryParse(value, out result))
				result = float.MinValue;
			return result;
		}

		public static float ToFloat(string value, float defaultValue)
		{
			float result;
			if (string.IsNullOrEmpty(value) || !float.TryParse(value, out result))
				result = defaultValue;
			return result;
		}

        /// <summary>
        /// This returns the best match DateTime for the given string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns DateTime.MinValue on failure.</returns>
        public static DateTime ToDateTime(string value)
        {
            DateTime result;
            if (string.IsNullOrEmpty(value) || !DateTime.TryParse(value, out result))
                result = DateTime.MinValue;
            return result;
        }

		/// <summary>
		/// This returns the best match DateTime for the given string.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="defaultValue"></param>
		/// <returns>Returns DateTime.MinValue on failure.</returns>
		public static DateTime ToDateTime(string value, DateTime defaultValue)
		{
			DateTime result = ToDateTime(value);
			if (result == DateTime.MinValue)
				return defaultValue;
			else
				return result;
		}

		/// <summary>
		/// Returns a boolean value based on string passed.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
        public static bool ToBool(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            else
            {
                string val = value.ToLower();
                if (val.Equals("true") || val.Equals("y") || val.Equals("yes") || val.Equals("1"))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Converts a string array (string[]) to a generic list
        /// </summary>
        /// <param name="stringArray">String array to convert.</param>
        /// <returns>Generic list of strings.</returns>
        public static StringCollection ToGenericList(string[] stringArray)
        {
			if (stringArray == null)
				throw new ArgumentNullException("stringArray");
			if (stringArray.GetLength(0) < 1)
				throw new ArgumentOutOfRangeException("stringArray");
			
			StringCollection result = new StringCollection();
            for (int x = 0; x < stringArray.Length; x++)
            {
                result.Add(stringArray[x]);
            }
            return result;
        }
        #endregion

		#region complex parsing
		/// <summary>
		/// Converts a delimited string to a generic list of trimmed strings.
		/// </summary>
		/// <param name="value">A delimited string.</param>
		/// <param name="delimiter">The delimiter in the delimited string.</param>
		/// <returns>A generic list of strings: StringCollection</returns>
		public static StringCollection DelimitedStringToStringList(string value, char delimiter)
		{
			//validate params
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("value");

			StringCollection result = new StringCollection();
			string[] valueArray = value.Split(delimiter);
			foreach (string val in valueArray)
				result.Add(val.Trim());

			return result;
		}

		/// <summary>
		/// Converts a comma delimited string to a generic list of trimmed strings.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static StringCollection DelimitedStringToStringList(string value)
		{
			return DelimitedStringToStringList(value, ',');
		}

		/// <summary>
		/// Converts a delimited string to a generic list of ints.
		/// </summary>
		/// <param name="value">A delimited string.</param>
		/// <param name="delimiter">The delimiter in the delimited string.</param>
		/// <returns>A generic list of strings: StringCollection</returns>
		public static IntCollection DelimitedStringToIntList(string value, char delimiter)
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("value");

			IntCollection result = new IntCollection();
			string[] valueArray = value.Split(delimiter);
			foreach (string val in valueArray)
				result.Add(ToInt(val));

			return result;
		}

		/// <summary>
		/// Converts a StringCollection into a comma delimited string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ListToDelimitedString(StringCollection value)
		{
			return ListToDelimitedString(value, ',');
		}

		/// <summary>
		/// Converts a StringCollection into a delimited string
		/// </summary>
		/// <param name="value"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static string ListToDelimitedString(StringCollection value, char delimiter)
		{
			//validate params
			if (value == null)
				throw new ArgumentNullException("value");
			else if (value.Count < 1)
				throw new ArgumentOutOfRangeException("value");
	
			string result = string.Join(delimiter.ToString(), value.ToArray());
			return result;
		}

		/// <summary>
		/// Returns 0 indexed value from the type indicated from the passed delimited string.
		/// </summary>
		/// <param name="index">Index of value to return, 0 indexed.</param>
		/// <param name="value">Delimited string to find value in.</param>
		/// <param name="delimiter">Character to delimit string by.</param>
		/// <returns></returns>
		public static string GetValueFromDelimitedString(int index, string value, char delimiter)
		{
			StringCollection list = DelimitedStringToStringList(value, delimiter);
			return list[index];
		}

		/// <summary>
		/// Converts a comma delimited string to a generic list of ints.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static IntCollection DelimitedStringToIntList(string value)
		{
			return DelimitedStringToIntList(value, ',');
		}

		public static string AddHtmlBreaksToText(string value)
		{
			//validate params
			if (value == null)
				value = string.Empty;

			return value.Replace(ControlCharacters.CRLF, "<br />");
		}

		public static string AddHtmlBreaksToTextDouble(string value)
		{
			//validate params
			if (value == null)
				value = string.Empty;

			return value.Replace(ControlCharacters.CRLF + ControlCharacters.CRLF, "<br /><br />");
		}

		public static string RemoveDomainFromUserName(string value)
		{
			string user = Regex.Replace(value, ".*\\\\(.*)", "$1", RegexOptions.None);
			return user;
		}
		#endregion

		#region cleaning
		public static string RemoveInvisibleCharacters(string value)
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("value");
			
			string result = value;
			//clean out invisible chars
			result = result.Replace(ControlCharacters.NullChar, string.Empty);

			result = result.Replace(ControlCharacters.CR, string.Empty);

			result = result.Replace(ControlCharacters.LF, string.Empty);

			return result;
		}

		/// <summary>
		/// Removes the HTML.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static string RemoveHtml(string value)
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("value");

			return Regex.Replace(value, @"<(.|\n)*?>", string.Empty);
		}
		#endregion
	}
}