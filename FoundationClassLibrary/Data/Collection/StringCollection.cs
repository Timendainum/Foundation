using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

namespace FoundationClassLibrary.Data.Collection
{
	public class StringCollection : Collection<string>, IEnumerable
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

		public new virtual IEnumerator GetEnumerator()
		{
			List<string> items = (List<string>)Items;
			return items.GetEnumerator();
		}
	}

}
