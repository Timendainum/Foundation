using System;
using FoundationClassLibrary.Log;

namespace FoundationClassLibrary
{
	/// <summary>
	/// This is the Base class for all classes.
	/// </summary>
	[Serializable]
	public abstract class Base : object, IDisposable
	{
		public override string ToString()
		{
			Type t = GetType();
			return t.FullName;
		}

		#region disposal
		public virtual void Dispose()
		{
			Logger.Debug("Base Dispose() start", ToString());
			// tell the GC that the Finalize process no longer needs
			// to be run for this object.
			GC.SuppressFinalize(this);
			Logger.Debug("Base Dispose() end", ToString());
		}
		#endregion
	}
}