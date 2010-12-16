using System.Collections.Generic;

using InterSystems.Data.CacheTypes;

namespace FoundationCacheClassLibrary
{
	public class CacheCollectionFormatter
	{
		#region CacheListOfStrings
		/// <summary>
		/// This method populates a List<string> with the contents of a CacheListOfStrings
		/// </summary>
		/// <param name="cachelist">The list to get values from.</param>
		/// <returns>A populated List<string></returns>
		public static List<string> CacheListOfStringsToList(CacheListOfStrings cachelist)
		{
			List<string> list = new List<string>();

			try
			{
				foreach (string value in cachelist)
				{
					list.Add(value);
				}
			}
			catch
			{
				throw;
			}

			return list;
		}

		/// <summary>
		/// This method populates a CacheListOfStrings with the contents of a List<string>
		/// </summary>
		/// <param name="list">The list of strings to populate the Cache construct with.</param>
		/// <param name="cacheList">The Cache list to be populated.</param>
		/// <param name="appendToList">Flag to either append or overwrite the CacheListOfStrings.</param>
		public static void ListToCacheListOfStrings(List<string> list, CacheListOfStrings cacheList, bool appendToList)
		{
			try
			{
				if (!appendToList)
					cacheList.Clear();

				foreach (string value in list)
				{
					cacheList.Add(value);
				}
			}
			catch
			{
				throw;
			}
		}
		
		#endregion
	}
}
