using System;
using FoundationClassLibrary.Log;

namespace FoundationClassLibrary.Persistence
{
    public abstract class ConnectionManagerBase : Base
    {
		#region disposal
		public void Dispose()
		{
			ConnectionString = null;
			DefaultConnectionString = null;
		}
		#endregion

		#region Properties
		public string ConnectionString { get; set; }
		public string DefaultConnectionString { get; set; }
		#endregion

		#region abstracts
		public abstract void InitConnection();
		public abstract void InitDataAdapter();
		public abstract void CloseConnection();
		#endregion
	}
}
