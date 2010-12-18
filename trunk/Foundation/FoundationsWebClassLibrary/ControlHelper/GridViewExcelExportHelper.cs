using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace FoundationWebClassLibrary.ControlHelper
{
	/// <summary>
	/// 
	/// </summary>
	public static class GridViewExcelExportHelper
	{
		/// <summary>
		/// Exports passed gridview to XLS under a ASP.Net page
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="gridView"></param>
		/// <param name="numberOfRows">-1 is all rows, 0 is current page, other number is number of rows</param>
		public static void Export(string fileName, GridView gridView, int numberOfRows)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");
			if (gridView == null)
				throw new ArgumentNullException("gridView");
			if (numberOfRows < -1)
				throw new ArgumentOutOfRangeException("numberOfRows");

			//Set up paging on gridview
			if (numberOfRows == -1)
			{
				gridView.AllowPaging = false;
				gridView.DataBind();
			}
			else if (numberOfRows > 0)
			{
				gridView.PageSize = numberOfRows;
				gridView.DataBind();
			}

			// Handle export
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
			HttpContext.Current.Response.ContentType = "application/ms-excel";

			using (StringWriter sw = new StringWriter())
			{
				using (HtmlTextWriter htw = new HtmlTextWriter(sw))
				{
					//  Create a table to contain the grid
					using (Table table = new Table())
					{
						//  include the gridline settings
						table.GridLines = gridView.GridLines;
						//  add the header row to the table
						if (gridView.HeaderRow != null)
						{
							GridViewExcelExportHelper.PrepareControlForExport(gridView.HeaderRow);
							table.Rows.Add(gridView.HeaderRow);
						}
						//  add each of the data rows to the table
						foreach (GridViewRow row in gridView.Rows)
						{
							GridViewExcelExportHelper.PrepareControlForExport(row);
							table.Rows.Add(row);
						}
						//  add the footer row to the table
						if (gridView.FooterRow != null)
						{
							GridViewExcelExportHelper.PrepareControlForExport(gridView.FooterRow);
							table.Rows.Add(gridView.FooterRow);
						}
						//  render the table into the htmlwriter
						table.RenderControl(htw);
					}

					//  render the htmlwriter into the response
					HttpContext.Current.Response.Write(sw.ToString());
					HttpContext.Current.Response.End();
				}
			}
		}

		/// <summary>
		/// Replace any of the contained controls with literals
		/// </summary>
		/// <param name="control"></param>
		private static void PrepareControlForExport(Control control)
		{
			for (int i = 0; i < control.Controls.Count; i++)
			{
				Control current = control.Controls[i];
				if (current is LinkButton)
				{
					control.Controls.Remove(current);
					control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
				}
				else if (current is ImageButton)
				{
					control.Controls.Remove(current);
					control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
				}
				else if (current is HyperLink)
				{
					control.Controls.Remove(current);
					control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
				}
				else if (current is DropDownList)
				{
					control.Controls.Remove(current);
					control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
				}
				else if (current is CheckBox)
				{
					control.Controls.Remove(current);
					control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
				}
				else if (current is GridView)
				{
					control.Controls.Remove(current);
				}
				if (current.HasControls())
				{
					GridViewExcelExportHelper.PrepareControlForExport(current);
				}
			}
		}
	}
}