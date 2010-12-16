using System;
using FoundationClassLibrary.Data;
using System.Data.Common;


namespace FoundationClassLibrary.DataBase
{
	public static class SortingHelper
	{
		public static void AddSortingClause(DbCommand sqlCommand, string sortBy)
		{
			if (StringFormatter.NullSafe(sortBy) != string.Empty)
			{
				string sql = sqlCommand.CommandText;
				sql += String.Format(" ORDER BY {0}", sortBy);
				sqlCommand.CommandText = sql;
			}
		}
	}
}
