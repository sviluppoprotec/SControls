using System;
using System.Collections;
using System.Reflection;
using O_Control;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace O_Control
{
	/// <summary>
	/// Descrizione di riepilogo per SqlDalCollectionParameter.
	/// </summary>
	public class SqlDalCollectionParameter:CollectionBase
	{
		public SqlDalCollectionParameter()
		{
		}
		private void AddControl(IOControl c,System.Web.UI.Control Ctr)
		{

				SqlParameter p=new SqlParameter();
				p.ParameterName=c.DBParameterName;
				p.SqlDbType =    (SqlDbType)c.DBSqlType;
				p.Size=c.DBSize;
						
				if(Ctr is TextBox) 
					if(((TextBox)Ctr).Text=="" && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((TextBox)Ctr).Text;

				if(Ctr is RadioButton) 
					if(((RadioButton)Ctr).Checked==false && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((RadioButton)Ctr).Checked;

				if(Ctr is ListBox) 
					if(((ListBox)Ctr).SelectedItem==null && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						foreach(ListItem item in ((ListBox)Ctr).Items)
							if(p.Value!=null)
								p.Value+="," + item.Value;
							else
								p.Value=item.Value;

				if(Ctr is LinkButton) 
					if(((LinkButton)Ctr).Text=="" && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((LinkButton)Ctr).Text;

				if(Ctr is Label) 
					if(((Label)Ctr).Text=="" && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((Label)Ctr).Text;

				if(Ctr is HyperLink) 
					if(((HyperLink)Ctr).Text=="" && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((HyperLink)Ctr).Text;

				if(Ctr is DropDownList) 
					if (((DropDownList)Ctr).SelectedValue != null && ((DropDownList)Ctr).SelectedValue != string.Empty)
						p.Value=((DropDownList)Ctr).SelectedValue;
					else
						p.Value=c.DBDefaultValue;

				if(Ctr is CheckBox) 
					if(((CheckBox)Ctr).Checked==false && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((CheckBox)Ctr).Checked;

				if(Ctr is Button) 
					if(((Button)Ctr).Text=="" && c.DBDefaultValue!=null)
						p.Value=c.DBDefaultValue;
					else
						p.Value=((Button)Ctr).Text;

				List.Add(p);
			}
				public void AddSingleControl(System.Web.UI.Control Ctr)
				{
					if(Ctr is IOControl)
					{ 
						IOControl c=(IOControl)Ctr;
						AddControl(c,Ctr);
					}
				}
				public void Add(System.Web.UI.ControlCollection  control)
				{
					foreach(System.Web.UI.Control Ctr in control)
					{
						if(Ctr.Controls.Count>0) Add(Ctr.Controls);
						if(Ctr is IOControl)
						{ 
							IOControl c=(IOControl)Ctr;
							if(c.DBParameterName=="") continue;
							AddControl(c,Ctr);
						}
					}
				}

				public void Add(System.Web.UI.Control Ctr)
				{
						if(Ctr.Controls.Count>0) Add(Ctr.Controls);
						if(Ctr is IOControl)
						{ 
							IOControl c=(IOControl)Ctr;
							if(c.DBParameterName=="") return;
							AddControl(c,Ctr);
						}
				}
		

//		public void Add(System.Web.UI.Control control)
//		{
//			foreach(System.Web.UI.Control Ctr in control.Controls)
//			{
//				if(Ctr.Controls.Count>0) Add(Ctr);
//				if(Ctr is IOControl)
//				{ 
//					IOControl c=(IOControl)Ctr;
//					if(c.DBParameterName=="") continue;
//					AddControl(c,Ctr);
//				}
//			}
//		}
		
		
		public void Add(SqlParameter _SqlDalParameter)
		{
			List.Add(_SqlDalParameter);
		}
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
		
				 throw new Exception("Index not valid!");
			else
				List.RemoveAt(index); 
		}
		public SqlParameter Item(int Index)
		{
			return (SqlParameter) List[Index];
		}

	}
}
