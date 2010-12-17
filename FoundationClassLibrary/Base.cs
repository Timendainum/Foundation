using System;
using FoundationClassLibrary.Log;

namespace FoundationClassLibrary
{
	/// <summary>
	/// This is the Base class for all classes.
	/// </summary>
	[Serializable]
	public abstract class Base : object
	{
		public override string ToString()
		{
			Type t = GetType();
			return t.FullName;
		}
	}
}