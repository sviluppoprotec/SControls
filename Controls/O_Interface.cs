using System;
using System.Data;

namespace O_Control
{
	/// <summary>
	/// Descrizione di riepilogo per O_Interface.
	/// </summary>
	
	public interface IOControl
	{
	
		Int32 DBSize
		{
			get;
			set;
		}

		string DBParameterName
		{
			get;
			set;
		}

		ParameterDirection DBDirection
		{
			get;
			set;
		}

		object DBDefaultValue
		{
			get;
			set;
		}

		SqlDbType DBSqlType
		{
			get;
			set;
		}

//		object DBValues
//		{
//			get;
//		}
	}
	
}
