using System;
using System.Configuration;
using System.Web.UI.WebControls;


namespace FoundationWebClassLibrary.ControlHelper
{
	public static class GridViewSortHelper
	{
		// This is used to flip the sorting arrow up/down
		// Base Css class is 'sort', the Ascending Css Class is 'up' and Descending is 'down'
		//I won't need this with Telerik
		public static void GridViewSortArrows(object sender, GridViewSortEventArgs e)
		{
			if (e == null)
				throw new ArgumentNullException("e");

			// call on sort and sets the sorted field to the proper Css Class, while setting all others to the base class
			string cssClassBase = ConfigurationManager.AppSettings["GridViewSortClassBase"];
			string cssClassAcending = ConfigurationManager.AppSettings["GridViewSortClassAsc"];
			string cssClassDecending = ConfigurationManager.AppSettings["GridViewSortClassDesc"];

			GridView gridView = (GridView)sender;
			for (int i = 0; i < gridView.Columns.Count; i++)
			{
				var column = gridView.Columns[i];
				column.HeaderStyle.CssClass = cssClassBase;
				if (column.SortExpression.Equals(e.SortExpression))
				{
					if (e.SortDirection == SortDirection.Ascending)
						column.HeaderStyle.CssClass = cssClassAcending;
					else if (e.SortDirection == SortDirection.Descending)
						column.HeaderStyle.CssClass = cssClassDecending;
				}
			}
		} 
	}
}
