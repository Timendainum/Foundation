using System;
using System.Collections.Generic;
using System.Data;
using FoundationClassLibrary.Log;
using FoundationClassLibrary.Persistence;
using InterSystems.Data.CacheClient;
using System.Diagnostics.CodeAnalysis;

namespace FoundationCacheClassLibrary.Persistence
{
	public class SqlExecutorCache : SqlExecutorBase
	{
		#region constructor/deconstructor/dispose
		public SqlExecutorCache()
		{
			ConnectionManager = new ConnectionManagerCache();
			//Parameters = new CacheParameterCollection();
		}
		#region disposal
		public void Dispose()
		{
			Sql = string.Empty;
			Parameters.Clear();
			if (Command != null && Command.Connection.State != ConnectionState.Closed)
				Command.Dispose();
			if (ConnectionManager != null)
				ConnectionManager.Dispose();
		}
		#endregion
		#endregion
		#region properties
		public string Sql { get; set; }
		public CacheCommand Command { get; set; }
		public CacheParameterCollection Parameters { get; set; }
		
		#endregion
		#region query running methods
		/// <summary>
		/// Executes a SQL query and returns a CacheDataReader.
		/// </summary>
		/// <returns>CacheDataReader</returns>
		public CacheDataReader ExecuteDataReader()
		{
			Logger.Debug("ExecuteDataReader() start", ToString());
			CacheDataReader result = null;

			try
			{
				Logger.Debug("Establishing connection...", ToString());
				InitConnection();
				Command = new CacheCommand(Sql, Connection);

				//Add parameters
				Logger.Debug("Adding parameters...", ToString());
				foreach (CacheParameter parameter in Parameters)
				{
					Command.Parameters.Add(parameter);
				}

				Logger.Debug("Executing datareader...", ToString());
				result = Command.ExecuteReader();
			}
			catch (Exception)
			{
				throw;
			}
			Logger.Debug("ExecuteDataReader() end", ToString());
			return result;
		}


		/// <summary>
		/// Executes a SQL query and returns a data set.
		/// </summary>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")] //this is here because he code anaylizer doesn't find where I fix this problem
		public DataSet ExecuteDataSet()
		{
			Logger.Debug("ExecuteDataSet() start", ToString());
			DataSet dataSet = new DataSet();

			try
			{
				//configure adapter
				Logger.Debug("Configuring adapter...", ToString());
				InitConnection();
				InitDataAdapter();
				DataAdapter.SelectCommand = Connection.CreateCommand();
				DataAdapter.SelectCommand.CommandText = Sql;
				DataAdapter.SelectCommand.CommandTimeout = 240;

				//Add parameters
				Logger.Debug("Adding parameters...", ToString());
				foreach (CacheParameter parameter in Parameters)
				{
					DataAdapter.SelectCommand.Parameters.Add(parameter);
				}

				//Fill dataset
				Logger.Debug("Calling DataAdapter.Fill()...", ToString());
				DataAdapter.Fill(dataSet, "CacheDataSet");
			}
			catch (Exception ex)
			{
				Logger.Log(String.Format("An exception was thrown in LoadDataSet(): {0}", ex.Message), ToString(), EType.Error, ESeverity.Critical, ELoggerDataAccessType.TextFile);
				dataSet.Dispose();
				throw;
			}
			finally
			{
				Logger.Debug("Closing Connection...", ToString());
				Connection.Close();
			}
			Logger.Debug("ExecuteDataSet() end", ToString());
			return dataSet;
		}

		/// <summary>
		/// Executes a query with no tangible results.
		/// </summary>
		/// <returns>Return the number of record affected.</returns>
		public int ExecuteNonQuery()
		{
			Logger.Debug("ExecuteNonQuery() start", ToString());
			int result = 0;
			try
			{
				InitConnection();
				Command = new CacheCommand(Sql, Connection);

				//Add parameters
				foreach (CacheParameter parameter in Parameters)
				{
					Command.Parameters.Add(parameter);
				}

				result = Command.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				Connection.Close();
			}
			Logger.Debug("ExecuteNonQuery() end", ToString());
			return result;
		}

		/// <summary>
		/// Executes a scalar query.
		/// </summary>
		/// <returns></returns>
		public object ExecuteScalar()
		{
			Logger.Debug("ExecuteScalar() start", ToString());
			object result = null;
			try
			{
				InitConnection();
				Command = new CacheCommand(Sql, Connection);

				//Add parameters
				foreach (CacheParameter parameter in Parameters)
				{
					Command.Parameters.Add(parameter);
				}

				result = Command.ExecuteScalar();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				Connection.Close();
			}
			Logger.Debug("ExecuteScalar() end", ToString());
			return result;
		}
		#endregion
		#region ConnectionManager
		public ConnectionManagerCache ConnectionManager { get; set; }
		public CacheConnection Connection
		{
			get
			{
				return ConnectionManager.Connection;
			}
		}
		public CacheDataAdapter DataAdapter
		{
			get
			{
				return ConnectionManager.DataAdapter;
			}
		}

		public void InitConnection()
		{
			ConnectionManager.InitConnection();
		}

		public void InitDataAdapter()
		{
			ConnectionManager.InitDataAdapter();
		}
		#endregion
	}
}
