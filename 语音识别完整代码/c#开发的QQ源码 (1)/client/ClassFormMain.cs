using System;

namespace LanMsg
{
	/// <summary>
	/// ClassMain 的摘要说明。
	/// </summary>
	public class ClassFormMain 
	{
		private	static FormMain f=null;
        private static FormLogin login=null;

		public  ClassFormMain()
		{
		}

		private static string conStr="";
		public string ConStr 
		{
			get{return conStr;}
			set{conStr=value;}
		}		

		public FormMain formMain
		{
			get{return f;}
			set{f=value;}
		}

		public FormLogin formLogin
		{
			get{return login;}
			set{login=value;}
		}
	}
}
