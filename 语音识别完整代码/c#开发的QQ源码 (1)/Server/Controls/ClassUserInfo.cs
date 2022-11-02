using System;
using System.ComponentModel;
using System.Net;

namespace LanMsg
{
	/// <summary>
	/// ClassUserInfo 的摘要说明。
	/// </summary>
	[Serializable] 
	public class ClassUserInfo
	{

		public ClassUserInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		[NonSerialized]
		public bool SendIsSuccess=false;//标识发送给此联系人的数据是否成功

		[NonSerialized]
		private System.Windows.Forms.TreeNode node;
		public System.Windows.Forms.TreeNode Node
		{
			get{return node;}
			set{node=value;}
		}

        private string assemblyVersion="1.0.0.1";
		public string AssemblyVersion
		{
			get{return assemblyVersion;}
			set{assemblyVersion=value;}
		}

		private string userName="";
		public string UserName
		{
			get{return userName;}
			set{userName=value;}
		}


		private IPAddress Ip=IPAddress.Parse("127.0.0.1");
		public IPAddress IP
		{
			get{return Ip;}
			set{Ip=value;}
		}

		private int port=0;
		public int Port
		{
			get{return port;}
			set{port=value;}
		}

		private string ComputerName="";
		public string ID
		{
			get{return ComputerName;}
			set{ComputerName=value;}
		}


		[NonSerialized]
		private string stateInfo ="(脱机)";
		public string StateInfo
		{
			get{return stateInfo;}
		}

		private int state=0;
		public int State
		{
			get{return state;}
			set
			{
				state=value;
				switch(state)
				{
					case 0:
						stateInfo ="(脱机)";
						break;
					case 1:
						stateInfo ="(联机)";
						break;
					case 2:
						stateInfo ="(忙碌)";
						break;
					case 3:
						stateInfo ="(离开)";
						break;
					case 4:
						stateInfo ="(接听电话)";
						break;
					case 5:
						stateInfo ="(外出就餐)";
						break;
				}
			}
		}

		private int dep=10;
		public int Dep  
		{
			get{return dep;}
			set
			{
				dep=value;
				switch(dep)
				{
					case 0:
						depInfo ="部门";
						break;
					case 1:
						depInfo ="部门";
						break;
					case 2:
						depInfo ="部门";
						break;
					case 3:
						depInfo ="部门";
						break;
					case 4:
						depInfo ="部门";
						break;
					case 5:
						depInfo ="部门";
						break;
					case 6:
						depInfo ="部门";
						break;
					case 7:
						depInfo ="部门";
						break;
					case 8:
						depInfo ="部门";
						break;
					case 9:
						depInfo ="部门";
						break;
					case 10:
						depInfo ="未知";
						break;
				}
			}
		}

		[NonSerialized]
		private string depInfo="";
		public string DepInfo  
		{
			get{return depInfo;}
		}
		

		//		[NonSerialized]
		//		private int old=0;
		//     	public int 年龄  
		//		{
		//			get{return old;}
		//			set{old=value;}
		//		}
		//
		//		[NonSerialized]
		//		private string business="";
		//		public string 职务  
		//		{
		//			get{return business;}
		//			set{business=value;}
		//		}
		//
		//		[NonSerialized]
		//		private string sex="";
		//		public string 性别  
		//		{
		//			get{return sex;}
		//			set{sex=value;}
		//		}

	}
}
