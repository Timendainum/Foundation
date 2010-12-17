using System;
using System.Data.Common;

namespace FoundationClassLibrary.Database
{
	public static class SortingHelper
	{
		public static void AddSortingClause(DbCommand sqlCommand, string sortBy)
		{
			//validate params
			if (sqlCommand == null)
				throw new ArgumentNullException("sqlCommand");
			if (string.IsNullOrEmpty(sortBy))
				throw new ArgumentNullException("sortBy");
	
			string sql = sqlCommand.CommandText;
			sql += String.Format(" ORDER BY {0}", sortBy);
			sqlCommand.CommandText = sql;
		}
	}
}
