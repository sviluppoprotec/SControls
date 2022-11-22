using System;
using System.Data;
using System.Data.SqlClient;

namespace O_Control
{
	/// <summary>
	/// Descrizione di riepilogo per SqlDalParameter.
	/// </summary>
	public class SqlDalParameter: SqlParameter  
	{
		
//		public SqlDalParameter()
//		{
//			
//		}
//		public SqlDalParameter(string name, SqlDbType sqlType)
//		{
//			this.ParameterName = name;
//			this._DalSqlType = sqlType ;
//		}
//		public SqlDalParameter(string name, object value)
//		{
//			this.ParameterName = name;
//			this.Value = value;
//		}
//		public SqlDalParameter(string name, SqlDbType sqlType, int size)
//		{
//			this.ParameterName = name;
//			this._DalSqlType   = sqlType ;
//			this.Size = size;
//		}	
//		
//		public SqlDalParameter(string name, SqlDbType sqlType,  ParameterDirection direction)
//		{
//			this.ParameterName = name;
//			this.sqlType  = sqlType;
//			this.Direction = direction;
//		}
//
//		public SqlDalParameter(string name, SqlDbType sqlType, int size,  ParameterDirection direction, object value)
//		{
//			this.ParameterName = name;
//			this.sqlType  = sqlType;
//			this.Size = size;
//			this.Direction = direction;
//			this.Value = value;
//		}
//		
//		private object _value;
//		private int _size;
//		private string _parameterName;
//        private SqlDbType  _DalSqlType;
//		private ParameterDirection _direction;
//
// 
//
//		public SqlDbType sqlType
//		{
//			get
//			{
//				return _DalSqlType;
//			}
//			set
//			{
//				_DalSqlType=value;
//			}
//		}
//		public object Value
//		{
//			get
//			{
//				return this._value;
//			}
//			set
//			{
//				this._value = value;
//			}
//		}
//
//		public int Size
//		{
//			get
//			{
//				return this._size;
//			}
//			set
//			{
//				if (this._size != value)
//				{
//					if (value < 0)
//					{
//						throw  new Exception ("invalid size");
//					}
//					this._size = value;
//				}
//			}
//		}
//
//		public string ParameterName
//		{
//			get
//			{
//				string text1 = this._parameterName;
//				if (text1 == null)
//				{
//					return string.Empty;
//				}
//				return text1;
//			}
//			set
//			{
//				if (this._parameterName != value)
//				{
//					this._parameterName = value;
//				}
//			}
//		}
//
//		public ParameterDirection Direction
//		{
//			get
//			{
//				ParameterDirection direction1 = this._direction;
//				if (direction1 == ((ParameterDirection) 0))
//				{
//					return ParameterDirection.Input;
//				}
//				return direction1;
//			}
//			set
//			{
//				if (this._direction != value)
//				{
//					switch (value)
//					{
//						case ParameterDirection.Input:
//						case ParameterDirection.Output:
//						case ParameterDirection.InputOutput:
//						case ParameterDirection.ReturnValue:
//						{
//							this._direction = value;
//							return;
//						}
//					}
//					throw new Exception("InvalidParameterDirection");
//				}
//			}
//		}

	}
}
