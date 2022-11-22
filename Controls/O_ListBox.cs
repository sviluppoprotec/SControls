using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;

namespace O_Control
{
	/// <summary>
	/// Descrizione di riepilogo per OraListBox.
	/// </summary>
	[ToolboxData("<{0}:O_ListBox runat=server></{0}:O_ListBox>")]
	public class O_ListBox:System.Web.UI.WebControls.ListBox
	{
		#region Membri di IOControl

		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Dimensione Parametro")]
		public Int32 DBSize
		{
			get
			{
				// TODO: aggiungere l'implementazione per il richiamo di O_TextBox.Size
				return (ViewState["Size"]!=null)?(Int32)ViewState["Size"]:new Int32();
			}
			set
			{
				ViewState.Add("Size" , value);
			}
		}
		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Nome Parametro")]
		public string DBParameterName
		{
			get
			{
				return (ViewState["ParameterName"]!=null)?(string)ViewState["ParameterName"]:string.Empty;
			}
			set
			{
				ViewState.Add("ParameterName" , value);
			}
		}
		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Direzione del Parametro")]
		public System.Data.ParameterDirection DBDirection
		{
			get
			{
				return (ViewState["Direction"]!=null)?(ParameterDirection)ViewState["Direction"]:System.Data.ParameterDirection.Input;
			}
			set
			{
				ViewState.Add("Direction" , value);
			}
		}
		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Valore di Default")]
		public object  DBDefaultValue
		{
			get
			{
				if (IsDBNull==true)
					return DBDefaultValue=DBNull.Value;
				else
					return (ViewState["DefaultValue"]!=null)?(object)ViewState["DefaultValue"]:null;
			}
			set
			{
				ViewState.Add("DefaultValue" , value);
			}
		}

		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Tipo di Dato")]
		public SqlDbType  DBSqlType 
		{
			get
			{
				return (ViewState["DBSqlType"]!=null)?(SqlDbType)ViewState["DBSqlType"]:SqlDbType.VarChar;
			}
			set
			{
				ViewState.Add("DBSqlType" , value);
			}
		}

		[Browsable(true),Category("Data"),NotifyParentProperty(true),Description("Imposta alla proprietà DBDefaultValue DBNull. Impostazione di Datult a true.")]
		public bool  IsDBNull 
		{
			get
			{
				return (ViewState["IsDBNull"]!=null)?(bool)ViewState["IsDBNull"]:true;
			}
			set
			{
				ViewState.Add("IsDBNull" , value);
				
			}
		}
		#endregion
	}
}
