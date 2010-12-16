using System;
using System.Configuration;
using FoundationClassLibrary.Log;
using FoundationClassLibrary.Persistence;
using InterSystems.Data.CacheClient;

namespace FoundationCacheClassLibrary.Persistence
{
	public class ConnectionManagerCache : ConnectionManagerBase, IDisposable
	{
		#region constructor/deconstructor/dispose
		public ConnectionManagerCache()
		{
			DefaultConnectionString = ConfigurationManager.AppSettings["DefaultCacheConnectionString"];
			if (!string.IsNullOrEmpty(DefaultCacheConnectionString))
				ConnectionString = ConfigurationManager.ConnectionStrings[DefaultCacheConnectionString].ConnectionString;
		}

		public ConnectionManagerCache(string defaultCacheConnectionString)
		{
			DefaultCacheConnectionString = defaultCacheConnectionString;
			ConnectionString = ConfigurationManager.ConnectionStrings[DefaultCacheConnectionString].ConnectionString;
		}
		#region disposal
		public override void Dispose()
		{
			Logger.Debug("Dispose() start", ToString());

			base.Dispose();

			if (DataAdapter != null)
				DataAdapter.Dispose();
			if (Connection != null)
				Connection.Dispose();

			Logger.Debug("Dispose() end", ToString());
		}
		#endregion
		#endregion
		#region properties
		public string DefaultCacheConnectionString { get; set; }
		public CacheConnection Connection { get; set; }
		public CacheDataAdapter DataAdapter { get; set; }
		#endregion
		#region init methods
		public override void InitConnection()
		{
			Logger.Debug("InitConnection() start", ToString());
			try
			{
				//Open connection may exist
				if (Connection != null)
				{
					if (Connection.State == System.Data.ConnectionState.Closed || Connection.State == System.Data.ConnectionState.Broken)
					{
						Logger.Debug("InitConnection() Reopening existing connection", ToString());
						Connection.AppNamespace = Properties.Resources.AppNamespace;
						Connection.Open();
					}
					else
						Logger.Debug("InitConnection() existing open connection exists", ToString());
				}
				//No open connection
				else
				{
					Logger.Debug("InitConnection() opening new connection", ToString());
					Connection = new CacheConnection(ConnectionString);
					Connection.AppNamespace = Properties.Resources.AppNamespace;
					Connection.Open();
				}
				
			}
			catch (Exception ex)
			{
				Logger.Log(String.Format("InitConnection() threw an exception: {0}", ex.Message), ToString(), EType.Error, ESeverity.Critical, ELoggerDataAccessType.TextFile);
				throw;
			}
			Logger.Debug("InitConnection() end", ToString());
		}

		public override void InitDataAdapter()
		{
			Logger.Debug("InitDataAdapter() start", ToString());
			try
			{
				if (DataAdapter != null)
					DataAdapter.Dispose();

				DataAdapter = new CacheDataAdapter();
			}
			catch (Exception ex)
			{
				Logger.Log(String.Format("InitDataAdapter() threw an exception: {0}", ex.Message), ToString(), EType.Error, ESeverity.Critical, ELoggerDataAccessType.TextFile);
				throw;
			}
			Logger.Debug("InitDataAdapter() end", ToString());
		}
		#endregion
		#region close methods
		public override void CloseConnection()
		{
			Logger.Debug("CloseConnection() start", ToString());
			try
			{
				//Open connection may exist
				if (Connection != null)
				{
					if (Connection.State != System.Data.ConnectionState.Closed || Connection.State != System.Data.ConnectionState.Broken)
					{
						Logger.Debug("CloseConnection() connection already closed or broken", ToString());
					}
					else
					{
						Logger.Debug("InitConnection() existing open connection exists, closing connection", ToString());
						Connection.Close();
					}
				}
				//No open connection
				else
				{
					Logger.Debug("CloseConnection() no connection to close", ToString());
				}

			}
			catch (Exception ex)
			{
				Logger.Log(String.Format("CloseConnection() threw an exception: {0}", ex.Message), ToString(), EType.Error, ESeverity.Critical, ELoggerDataAccessType.TextFile);
				throw;
			}
			Logger.Debug("CloseConnection() end", ToString());
		}
		#endregion
	}
}
