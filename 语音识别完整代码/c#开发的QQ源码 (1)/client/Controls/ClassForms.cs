using System;

namespace LanMsg.Controls
{
	/// <summary>
	/// ClassForms 的摘要说明。
	/// </summary>
	public class ClassForms : System.Collections.CollectionBase 
	{
		public ClassForms()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void add(System.Windows.Forms.Form f)
		{
			base.InnerList.Add(f);	
		}

		public void Romove(System.Windows.Forms.Form f)
		{
			base.InnerList.Remove (f);
		}
	}


}
