using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using FoundationClassLibrary.Data.Collection;

namespace FoundationClassLibrary.Data.Import
{
	public class FixedWidthDataImporter : Base
	{
		#region constructors
		public FixedWidthDataImporter()
		{
			RowDelimiters = new StringCollection();
			Columns = new FixedWidthColumnCollection();
			TableName = "ImportedTable";
		}
		#endregion

		#region properties
		public StringCollection RowDelimiters { get; private set; }
		public FixedWidthColumnCollection Columns { get; private set; }
		public string TableName { get; set; }
		#endregion
		
		#region public methods
		/// <summary>
		/// This turns a properly formed delimeted string into a dataset. The method expects the first row to be column names. Each successive line should be data until EOF.
		/// </summary>
		/// <param name="rawContents"></param>
		/// <returns></returns>
		public virtual DataSet ImportData(string rawContents)
		{
			if (string.IsNullOrEmpty(rawContents))
				throw new ArgumentNullException(rawContents);

			//Prepare result
			DataSet result = new DataSet();
			try
			{
				result.Tables.Add(TableName);

				//split file into lines
				string[] dataRowsArray = rawContents.Split(RowDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

				////////////////////////////////////////////////
				//create DataSet out of file data

				//Headings
				foreach (FixedWidthColumn col in Columns)
				{
					result.Tables[TableName].Columns.Add(col.Name);
				}

				//determine max line length we are going to parse
				int maxLineLength = Columns[Columns.Count - 1].BeginningCharacter + Columns[Columns.Count - 1].FieldLength;

				//Import data
				foreach (string fileRow in dataRowsArray)
				{
					string fileRowFixed = fileRow;
					if (fileRowFixed.Length < maxLineLength)
						fileRowFixed = fileRowFixed.PadRight(maxLineLength, ' ');

					DataRow newRow = result.Tables[0].NewRow();

					foreach (FixedWidthColumn col in Columns)
					{
						string rawString = fileRowFixed.Substring(col.BeginningCharacter, col.FieldLength);
						rawString = StringFormatter.RemoveInvisibleCharacters(rawString);
						rawString = rawString.Trim();
						newRow[col.Name] = rawString;
					}

					result.Tables[0].Rows.Add(newRow);
				}
			}
			catch
			{
				result.Dispose();
				throw;
			}

			return result;
		}
		#endregion
	}

	public class FixedWidthColumnCollection : Collection<FixedWidthColumn>
	{
		public FixedWidthColumnCollection()
			: base(new List<FixedWidthColumn>())
		{
			
		}
	}
}
