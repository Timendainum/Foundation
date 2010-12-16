using System;
using System.Collections.Generic;

namespace FoundationClassLibrary.Data
{
	public class MonthFormatter
	{
		/// <summary>
		/// Converts month int to 3 character month abbreviation.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static string MonthIntToThreeCharacterMonth(int month)
		{
			string month3 = string.Empty;

			switch (month)
			{
				case 1:
					month3 = "Jan";
					break;
				case 2:
					month3 = "Feb";
					break;
				case 3:
					month3 = "Mar";
					break;
				case 4:
					month3 = "Apr";
					break;
				case 5:
					month3 = "May";
					break;
				case 6:
					month3 = "Jun";
					break;
				case 7:
					month3 = "Jul";
					break;
				case 8:
					month3 = "Aug";
					break;
				case 9:
					month3 = "Sep";
					break;
				case 10:
					month3 = "Oct";
					break;
				case 11:
					month3 = "Nov";
					break;
				case 12:
					month3 = "Dec";
					break;
				default:
					throw new Exception("The month int that was provided was out of range.");
					break;
			}

			return month3;
		}

		/// <summary>
		/// Converts 3 character month name to month int.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static int ThreeCharacterMonthToMonthInt(string month)
		{
			int monthInt = 0;
			string month3 = month.ToLower();

			switch (month3)
			{
				case "jan":
					monthInt = 1;
					break;
				case "feb":
					monthInt = 2;
					break;
				case "mar":
					monthInt = 3;
					break;
				case "apr":
					monthInt = 4;
					break;
				case "may":
					monthInt = 5;
					break;
				case "jun":
					monthInt = 6;
					break;
				case "jul":
					monthInt = 7;
					break;
				case "aug":
					monthInt = 8;
					break;
				case "sep":
					monthInt = 9;
					break;
				case "oct":
					monthInt = 10;
					break;
				case "nov":
					monthInt = 11;
					break;
				case "dec":
					monthInt = 12;
					break;
				default:
					throw new Exception("The month abbreviation supplied was not valid.");
					break;
			}

			return monthInt;
		}

		/// <summary>
		/// Returns a list of month ints that represent the months YTD based on specified month int.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static List<int> MonthIntToMonthYtdIntList(int month)
		{
			if (month < 1 || month > 12)
			{
				throw new Exception("The month int given was out of range.");
			}
			
			List<int> monthList = new List<int>();
			for (int i = 0; i <= month ; i++)
			{
				monthList.Add(i);
			}

			return monthList;
		}

		/// <summary>
		/// Returns a list of 3 character month names that represent the months YTD based on specified month int.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static List<string> MonthIntToThreeCharacterMonthYtdList(int month)
		{
			List<int> monthIntList = MonthIntToMonthYtdIntList(month);
			List<string> threeCharacterMonthYtdList = MonthIntListToThreeCharacterMonthList(monthIntList);
			return threeCharacterMonthYtdList;
		}

		/// <summary>
		/// Returns a list of month ints that represent the months YTD based on specified month int.
		/// </summary>
		/// <param name="month3"></param>
		/// <returns></returns>
		public static List<int> ThreeCharacterMonthToMonthYtdIntList(string month3)
		{
			int month = ThreeCharacterMonthToMonthInt(month3);
			List<int> monthIntList = MonthIntToMonthYtdIntList(month);
			return monthIntList;
		}

		/// <summary>
		/// Takes a 3 character month name and returns a list of 3 character month names YTD based on specified month.
		/// </summary>
		/// <param name="month3"></param>
		/// <returns></returns>
		public static List<string> ThreeCharacterMonthToThreeCharacterMonthYtdList(string month3)
		{
			List<int> monthIntList = ThreeCharacterMonthToMonthYtdIntList(month3);
			List<string> threeCharacterMonthList = MonthIntListToThreeCharacterMonthList(monthIntList);
			return threeCharacterMonthList;
		}

		/// <summary>
		/// Converts a month int list to a month string list.
		/// </summary>
		/// <param name="monthList"></param>
		/// <returns></returns>
		public static List<string> MonthIntListToThreeCharacterMonthList(List<int> monthList)
		{
			List<string> threeCharacterMonthList = new List<string>();
			foreach (int month in monthList)
			{
				threeCharacterMonthList.Add(MonthIntToThreeCharacterMonth(month));
			}

			return threeCharacterMonthList;
		}

		/// <summary>
		/// Converts a 3 character month string list to a month int list.
		/// </summary>
		/// <param name="monthList"></param>
		/// <returns></returns>
		public static List<int> ThreeCharacterMonthListToMonthIntList(List<string> threeCharacterMonthList)
		{
			List<int> monthList = new List<int>();
			foreach (string month in threeCharacterMonthList)
			{
				monthList.Add(ThreeCharacterMonthToMonthInt(month));
			}

			return monthList;
		}
	}
}
