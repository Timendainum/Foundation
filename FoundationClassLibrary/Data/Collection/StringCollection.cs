using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.Data.Collection
{
	public class StringCollection : Collection<string>
	{
		#region constructors
		public StringCollection()
			: base(new List<string>())
		{

		}
		#endregion

		public string[] ToArray()
		{
			List<string> items = (List<string>)Items;
			return items.ToArray();
		}
	}
}
