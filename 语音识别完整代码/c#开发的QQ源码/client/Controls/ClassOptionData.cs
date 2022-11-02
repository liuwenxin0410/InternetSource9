using System;
using System.Data.OleDb ;
using System.Data;
using System.ComponentModel;

namespace LanMsg
{
	/// <summary>
	/// ClassOptionData 的摘要说明。
	/// </summary>
	public class ClassOptionData  
	{
    	private string ConStr="";//Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ Application.StartupPath +"\\db.mdb;Persist Security Info=False

		public ClassOptionData(string conStr)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
          ConStr= conStr;
		}
		public int ExSQL(string SQLStr)//执行任何SQL语句，返回所影响的行数
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				int i =0;
				i=cmd.ExecuteNonQuery();
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return i;
			}
			catch(Exception e){return 0;}

		}

		public int ExSQLLengData(object Data,string par,string SQLStr)//执行任何SQL语句，返回所影响的行数
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				int i =0;
				cmd.Parameters.Add(par, System.Data.OleDb.OleDbType.Binary);
				i=cmd.ExecuteNonQuery();
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return i;
			}
			catch(Exception e){return 0;}

		}

		public int ExSQLR(string SQLStr)//执行任何SQL查询语句，返回所影响的行数
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				int i =0;
				dr=cmd.ExecuteReader();
				while(dr.Read())
				{i++;}
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();
				return i;
			}
			catch(Exception e){return 0;}

		}

		public object ExSQLReField(string field ,string SQLStr)//执行任何SQL查询语句，返回一个字段值
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				object fieldValue=null;
				dr=cmd.ExecuteReader();
				if(dr.Read())
				{fieldValue=dr[field];}
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return fieldValue;
			}
			catch(Exception e){return null;}

		}

		public OleDbDataReader ExSQLReDr(string SQLStr)//执行任何SQL查询语句，返回一个OleDbDataReader
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				dr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
				return dr;
			}
			catch(Exception e){return null;}
		}

	}
}
