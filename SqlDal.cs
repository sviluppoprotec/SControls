using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace O_Control
{
	/// <summary>
	/// Descrizione di riepilogo per Class1.
	/// </summary>
	public sealed class SqlDal
	{
		private string ConnectionString="";
		private SqlConnection Cnn;

		static object syncObject = new object();
		static volatile SqlDal singletonWithVolatile = null;
		public static SqlDal GetIstance()
		{
			if (singletonWithVolatile  == null)
			{
				lock (syncObject)
				{
					if (singletonWithVolatile == null)
						singletonWithVolatile = new SqlDal();
					//System.Threading.Thread.MemoryBarrier(); 

				}
			}
			return (singletonWithVolatile);
		}

//		public static readonly SqlDal Instance = new SqlDal();
		
		/// <summary>
		/// Costruttore Privato prechè la classe viene generata con GetIstance
		/// quindi inaccessibile con new
		/// </summary>
		private SqlDal()
		{
			AppSettingsReader reader1 = new AppSettingsReader();
			this.ConnectionString =  reader1.GetValue("ConnectionString", typeof(string)).ToString();
			Cnn=new SqlConnection(ConnectionString);
		}
		
		/// <summary>
		/// Esegue una Query Sql in formato stringa e restituisce un DataTable
		/// </summary>
		/// <param name="CommandText">Query Sql da eseguire</param>
		/// <param name="dt">DataTable che viene passato e valorizzato</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable</returns>
		public int GetData(string CommandText,ref DataTable dt)
		{
			SqlDataAdapter da = new SqlDataAdapter(CommandText, Cnn);
			int result =da.Fill(dt);
			return result;
		}
		/// <summary>
		/// Esegue una Query Sql in formato stringa e restituisce un DataSet
		/// </summary>
		/// <param name="CommandText">Query Sql da eseguire</param>
		/// <param name="dt">DataTable che viene passatoe valorizzato</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable</returns>
		public int GetData(string CommandText,ref DataSet ds,bool ShowRowCount)
		{
			SqlDataAdapter da=new SqlDataAdapter(CommandText,Cnn);
			int result =da.Fill(ds);
			return result;
		}
		/// <summary>
		/// Esegue una StoreProcedure e resituisce un DataTable
		/// </summary>
		/// <param name="CommandText">Nome della StoreProcedure</param>
		/// <param name="dt">DataTable che viene passato e valorizzato</param>
		/// <param name="param">Parametri della store Procedure in Array</param>
		/// /// <param name="ShowRowCount">Indica se includere nei Parametri il Parametro ReturnValue</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable o se valorizzato ShowRowCount a true ritorna il valore del parametro ReturnValue</returns>
		public int GetData(string CommandText,ref DataTable dt, SqlParameter[] param,bool ShowRowCount)
		{
			SqlDataAdapter da=new SqlDataAdapter(CommandText,Cnn);
			da.SelectCommand.CommandType =CommandType.StoredProcedure;
			this.CopyParameter(param,da.SelectCommand); 
			int result =da.Fill(dt);
			return result;
		}
		/// <summary>
		/// Esegue una StoreProcedure e resituisce un DataTable
		/// </summary>
		/// <param name="CommandText">Nome della StoreProcedure</param>
		/// <param name="dt">DataTable che viene passato e valorizzato</param>
		/// <param name="collection">Parametri della store Procedure in una Collezione</param>
		/// /// <param name="ShowRowCount">Indica se includere nei Parametri il Parametro ReturnValue</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable o se valorizzato ShowRowCount a true ritorna il valore del parametro ReturnValue</returns>
		public int GetData(string CommandText,ref DataTable dt, SqlDalCollectionParameter collection,bool ShowRowCount)
		{
			SqlDataAdapter da=new SqlDataAdapter(CommandText,Cnn);
			da.SelectCommand.CommandType =CommandType.StoredProcedure;
			this.CopyParameter(collection,da.SelectCommand); 
			if (ShowRowCount) 
				da.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue",SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;	
			int result =da.Fill(dt);
			if (ShowRowCount) 
				result=Convert.ToInt32(da.SelectCommand.Parameters["ReturnValue"].Value);
			return result;

		}
		/// <summary>
		/// Esegue una StoreProcedure e resituisce un DataSet
		/// </summary>
		/// <param name="CommandText">Nome della StoreProcedure</param>
		/// <param name="dt">DataTable che viene passato e valorizzato</param>
		/// <param name="collection">Parametri della store Procedure in una Collezione</param>
		/// /// <param name="ShowRowCount">Indica se includere nei Parametri il Parametro ReturnValue</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable o se valorizzato ShowRowCount a true ritorna il valore del parametro ReturnValue</returns>
		public int GetData(string CommandText,ref DataSet ds, SqlDalCollectionParameter collection,bool ShowRowCount)
		{
			SqlDataAdapter da=new SqlDataAdapter(CommandText,Cnn);
			da.SelectCommand.CommandType =CommandType.StoredProcedure;
			this.CopyParameter(collection,da.SelectCommand); 
			if (ShowRowCount) 
				da.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue",SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;	
			int result =da.Fill(ds);
			if (ShowRowCount) 
				result=Convert.ToInt32(da.SelectCommand.Parameters["ReturnValue"].Value);
			return result;
		}

		/// <summary>
		/// Esegue una StoreProcedure e resituisce un DataSet
		/// </summary>
		/// <param name="CommandText">Nome della StoreProcedure</param>
		/// <param name="dt">DataTable che viene passato e valorizzato</param>
		/// <param name="param">Parametri della store Procedure in Array</param>
		/// /// <param name="ShowRowCount">Indica se includere nei Parametri il Parametro ReturnValue</param>
		/// <returns>Ritorna il numero di righe interessate nel DataTable o se valorizzato ShowRowCount a true ritorna il valore del parametro ReturnValue</returns>
		public int GetData(string CommandText,ref DataSet ds, SqlParameter[] param,bool ShowRowCount)
		{
			SqlDataAdapter da=new SqlDataAdapter(CommandText,Cnn);
			da.SelectCommand.CommandType =CommandType.StoredProcedure;
			this.CopyParameter(param,da.SelectCommand); 
			if (ShowRowCount) 
				da.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue",SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;	
			int result =da.Fill(ds);
			if (ShowRowCount) 
				result=Convert.ToInt32(da.SelectCommand.Parameters["ReturnValue"].Value);
			return result;

		}
		[MethodImpl(MethodImplOptions.Synchronized)]   
		public int Execute(string CommandText,SqlDalCollectionParameter collection)
		{
			
				SqlCommand cmd=new SqlCommand(CommandText,Cnn);
				cmd.CommandType=CommandType.StoredProcedure;
				this.CopyParameter(collection,cmd); 
				try
				{
					if(Cnn.State==ConnectionState.Closed) Cnn.Open();
					int Result=cmd.ExecuteNonQuery();
					Result=GetParameterOutput(cmd);
					return Result;
				}
				catch(Exception ex)
				{
					throw (ex);
				}
				finally
				{
					if(Cnn.State==ConnectionState.Open) Cnn.Close();
				}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]   
		public int Execute(string CommandText,SqlParameter[] param)
		{
			lock (syncObject)
			{
				SqlCommand cmd=new SqlCommand(CommandText,Cnn);
				cmd.CommandType=CommandType.StoredProcedure;
				this.CopyParameter(param,cmd);
		
				try
				{
					if(Cnn.State==ConnectionState.Closed) Cnn.Open();
					int Result=cmd.ExecuteNonQuery();
					Result=GetParameterOutput(cmd);
					return Result;
				}
				catch(Exception ex)
				{
					throw new Exception(ex.Message);
				}
				finally
				{
					if(Cnn.State==ConnectionState.Open) Cnn.Close();
				}
			}
		}
		private int GetParameterOutput(SqlCommand cmd)
		{
			foreach(SqlParameter par in cmd.Parameters)
			{
				if(par.Direction==ParameterDirection.Output)
					return Convert.ToInt32(par.Value); 
				if(par.Direction==ParameterDirection.ReturnValue)
					return (int)par.Value; 
			}
			return 0;
		}
		private void CopyParameter(SqlParameter[] _parameters, SqlCommand cmd)
		{
			for (int i = 0; i < _parameters.Length -1; i++)
			{
				cmd.Parameters.Add(_parameters[i]);
			}
		}
		private void CopyParameter(SqlDalCollectionParameter collection, SqlCommand cmd)
		{
			foreach(SqlParameter par in collection)
			{
				cmd.Parameters.Add(par);
			}
		}
	}
}
