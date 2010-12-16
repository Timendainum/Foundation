using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.Data.Collection
{
	public class KeyValuePairIntStringCollection : Collection<KeyValuePair<int, string>>
	{
		/// <summary>
		/// Initializes a new instance of the KeyValuePairCollection class.
		/// </summary>
		public KeyValuePairIntStringCollection()
			: base(new List<KeyValuePair<int, string>>())
		{
			
		}

	}
}
