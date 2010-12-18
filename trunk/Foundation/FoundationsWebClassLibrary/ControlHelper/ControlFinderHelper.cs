using System.Web.UI;
using System;

namespace FoundationWebClassLibrary.ControlHelper
{
	public static class ControlFinderHelper
	{
		public static Control FindControlRecursive(Control root, string id)
		{
			if (root == null)
				throw new ArgumentNullException("root");
			if (string.IsNullOrEmpty(id))
				throw new ArgumentNullException("id");
			
			if (root.ID == id)
			{
				return root;
			}

			foreach (Control c in root.Controls)
			{
				Control t = FindControlRecursive(c, id);
				if (t != null)
				{
					return t;
				}
			}

			return null;
		} 
	}
}
