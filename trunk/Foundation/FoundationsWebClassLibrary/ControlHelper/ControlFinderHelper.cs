﻿using System.Web.UI;

namespace FoundationWebClassLibrary.ControlHelper
{
	public class ControlFinderHelper
	{
		public static Control FindControlRecursive(Control root, string id)
		{
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
