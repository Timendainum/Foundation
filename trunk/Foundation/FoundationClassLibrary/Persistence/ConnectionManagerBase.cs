using System;
using System.Configuration;
using FoundationClassLibrary.Log;

namespace FoundationClassLibrary.Persistence
{
    public abstract class ConnectionManagerBase : Base, IDisposable
    {
		#region disposal
		public override void Dispose()
		{
			Logger.Debug("Dispose() start", ToString());

			ConnectionString = null;
			DefaultConnectionString = null;

			Logger.Debug("Dispose() end", ToString());
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
