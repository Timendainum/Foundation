using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.Data.Import
{
	public class DelimitedDataImporter : Base
	{
		#region constructors
		public DelimitedDataImporter()
		{
			FieldDelimiters = new List<string>();
			RowDelimiters = new List<string>();
			Columns = new List<Column>();
			TableName = "ImportedTable";
			FirstRowContainsColumnNames = true;
		}
		#endregion

		#region properties
		public List<string> FieldDelimiters { get; set; }
		public List<string> RowDelimiters { get; set; }
		public List<Column> Columns { get; set; }
		public string TableName { get; set; }
		public bool FirstRowContainsColumnNames { get; set; }
		#endregion
		
		#region public methods
		/// <summary>
		/// This turns a properly formed delimited string into a dataset. The method expects the first row to be column names. Each successive line should be data until EOF.
		/// </summary>
		/// <param name="rawContents"></param>
		/// <returns></returns>
		public virtual DataSet ImportData(string rawContents)
		{
			//Prepare result
			DataSet result = new DataSet();
			result.Tables.Add(TableName);
			
			//split file into lines
			string[] dataRowsArray = rawContents.Split(RowDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			
			//Create generic list from string array
			List<string> dataRows = new List<string>();
			foreach (string row in dataRowsArray)
			{
				dataRows.Add(row);
			}

			////////////////////////////////////////////////
			//create DataSet out of file data

			//Headings
			//First row has column names
			if (FirstRowContainsColumnNames)
			{
				//Create columns with headings from first row
				string[] columns = dataRows[0].Split(FieldDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
				foreach (string columnName in columns)
				{
					result.Tables[TableName].Columns.Add(columnName);
				}
				//Remove header row from dataRows list
				dataRows.RemoveAt(0);
			}
			//Column names in Columns property
			else if (Columns.Count > 0)
			{
				int numberOfDataColumns = dataRows[0].Split(FieldDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Length;
				if (Columns.Count != numberOfDataColumns)
					throw new Exception("Number of columns defined in Columns is not the same as the number of columns in the rawContents.");
				foreach (Column col in Columns)
				{
					result.Tables[TableName].Columns.Add(col.Name);
				}
			}
			//No column names defined
			else
			{
				//Create columns
				string[] columns = dataRows[0].Split(FieldDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
				int rowCounter = 1;
				foreach (string columnName in columns)
				{
					result.Tables[TableName].Columns.Add("column" + rowCounter.ToString());
					rowCounter++;
				}
			}

			//Import data
			foreach (string fileRow in dataRows)
			{
				//Populate Data
				result.Tables[TableName].Rows.Add(fileRow.Split(FieldDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries));
			}

			return result;
		}
		#endregion
	}
}
