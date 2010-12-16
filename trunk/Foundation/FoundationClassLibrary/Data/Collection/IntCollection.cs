using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.Data.Collection
{
	public class IntCollection : Collection<int>
	{
		#region constructors
		public IntCollection()
			: base(new List<int>())
		{

		}
		#endregion

		public int[] ToArray()
		{
			List<int> items = (List<int>)Items;
			return items.ToArray();
		}
	}
}
