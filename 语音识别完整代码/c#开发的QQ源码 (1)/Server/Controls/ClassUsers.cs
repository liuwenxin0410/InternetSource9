using System;

namespace LanMsg.Controls
{
	/// <summary>
	/// ClassUser 的摘要说明。
	/// </summary>
	[Serializable] 
	public class ClassUsers: System.Collections.CollectionBase 
	{
		public ClassUsers()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void add(ClassUserInfo userInfo)
		{
			base.InnerList.Add(userInfo);	
		}

		public void Romove(ClassUserInfo userInfo)
		{
			base.InnerList.Remove (userInfo);
		}
	}
}
