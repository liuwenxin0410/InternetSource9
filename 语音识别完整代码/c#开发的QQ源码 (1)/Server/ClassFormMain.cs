using System;

namespace LanMsg
{
	/// <summary>
	/// ClassMain 的摘要说明。
	/// </summary>
	public class ClassFormMain 
	{
		private	static FormMain f=null;

		public  ClassFormMain()
		{
		}

		public FormMain formMain
		{
			get{return f;}
			set{f=value;}
		}
	}
}
