using System;

namespace LanMsg.Controls
{
	/// <summary>
	/// ClassMsg 的摘要说明。
	/// </summary>
	/// []
	[Serializable]
	public class ClassMsg
	{
		public string ID="";//发送消息的用户ID
        public int MsgInfoClass=0;//发送的消息类别(1为登录;2为更改在线状态;3.
        public byte[] MsgContent=null;//发送消息转化成字节后的数据
		public string AssemblyVersion= "1.0.0.1" ;

		public ClassMsg(int msgInfoClass,string id,byte[] msgContent)
		{
		   this.ID=id;
		   this.MsgInfoClass=msgInfoClass;
		   this.MsgContent=msgContent;
		   
		}

 	}
}
