using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.Data.Import
{
	public class ColumnsCollection : Collection<Column>
	{
		#region constructors
		public ColumnsCollection()
			: base(new List<Column>())
		{

		}
		#endregion
	}
}
