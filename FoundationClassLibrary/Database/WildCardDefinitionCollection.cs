using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FoundationClassLibrary.DataBase
{
	public class WildCardDefinitionCollection : Collection<WildCardDefinition>
	{
		#region constructors
		public WildCardDefinitionCollection()
			: base(new List<WildCardDefinition>())
		{

		}
		#endregion

		public WildCardDefinition Find(Predicate<WildCardDefinition> match)
		{
			List<WildCardDefinition> items = (List<WildCardDefinition>)Items;
			return items.Find(match);
		}
	}
}
