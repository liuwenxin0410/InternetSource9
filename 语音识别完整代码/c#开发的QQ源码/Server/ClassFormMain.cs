using System;

namespace LanMsg
{
	/// <summary>
	/// ClassMain ��ժҪ˵����
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
