using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LanMsg 
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private LanMsg.Controls.SockUDP sockUDP1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.MenuItem menuItemControl;
		private System.Windows.Forms.MenuItem menuItemControlServer;
		private System.Windows.Forms.MenuItem menuItemControlExit;
		private System.Windows.Forms.StatusBar statusBar1;
		internal System.Windows.Forms.TreeView TreeView1;
		internal System.Windows.Forms.Splitter Splitter1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		internal System.Windows.Forms.Timer TimerCheckOnlineSta;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal System.Windows.Forms.ListView LV_OnlineUser;
		internal System.Windows.Forms.ColumnHeader ID;
		internal System.Windows.Forms.ColumnHeader IP地址;
		internal System.Windows.Forms.ColumnHeader 端口;
		internal System.Windows.Forms.ColumnHeader 状态;
		internal System.Windows.Forms.ColumnHeader 部门;
		internal System.Windows.Forms.ColumnHeader 姓名;
		private System.Windows.Forms.ColumnHeader Version;
		internal System.Windows.Forms.ListView LV_SysUser;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.ColumnHeader ColumnHeader3;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.ComponentModel.IContainer components;

		public FormMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
			this.sockUDP1 = new LanMsg.Controls.SockUDP(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemControl = new System.Windows.Forms.MenuItem();
			this.menuItemControlServer = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemControlExit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.TreeView1 = new System.Windows.Forms.TreeView();
			this.Splitter1 = new System.Windows.Forms.Splitter();
			this.TimerCheckOnlineSta = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.LV_SysUser = new System.Windows.Forms.ListView();
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.LV_OnlineUser = new System.Windows.Forms.ListView();
			this.ID = new System.Windows.Forms.ColumnHeader();
			this.IP地址 = new System.Windows.Forms.ColumnHeader();
			this.端口 = new System.Windows.Forms.ColumnHeader();
			this.状态 = new System.Windows.Forms.ColumnHeader();
			this.部门 = new System.Windows.Forms.ColumnHeader();
			this.姓名 = new System.Windows.Forms.ColumnHeader();
			this.Version = new System.Windows.Forms.ColumnHeader();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// sockUDP1
			// 
			this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));
			this.sockUDP1.DataArrival += new LanMsg.Controls.SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemControl,
																					  this.menuItem1});
			// 
			// menuItemControl
			// 
			this.menuItemControl.Index = 0;
			this.menuItemControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemControlServer,
																							this.menuItem3,
																							this.menuItemControlExit});
			this.menuItemControl.Text = "控件台(&C)";
			this.menuItemControl.Click += new System.EventHandler(this.menuItemControl_Click);
			// 
			// menuItemControlServer
			// 
			this.menuItemControlServer.Index = 0;
			this.menuItemControlServer.Text = "开始服务(&B)";
			this.menuItemControlServer.Click += new System.EventHandler(this.menuItemControlServer_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuItemControlExit
			// 
			this.menuItemControlExit.Index = 2;
			this.menuItemControlExit.Text = "退出(&E)";
			this.menuItemControlExit.Click += new System.EventHandler(this.menuItemControlExit_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "帮助(&H)";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "关于(&C)";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(632, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.Visible = false;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 371);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(632, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// TreeView1
			// 
			this.TreeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.TreeView1.ImageIndex = -1;
			this.TreeView1.ItemHeight = 14;
			this.TreeView1.Location = new System.Drawing.Point(0, 28);
			this.TreeView1.Name = "TreeView1";
			this.TreeView1.SelectedImageIndex = -1;
			this.TreeView1.Size = new System.Drawing.Size(121, 343);
			this.TreeView1.TabIndex = 6;
			this.TreeView1.Visible = false;
			// 
			// Splitter1
			// 
			this.Splitter1.Location = new System.Drawing.Point(121, 28);
			this.Splitter1.Name = "Splitter1";
			this.Splitter1.Size = new System.Drawing.Size(4, 343);
			this.Splitter1.TabIndex = 7;
			this.Splitter1.TabStop = false;
			this.Splitter1.Visible = false;
			// 
			// TimerCheckOnlineSta
			// 
			this.TimerCheckOnlineSta.Enabled = true;
			this.TimerCheckOnlineSta.Interval = 60000;
			this.TimerCheckOnlineSta.Tick += new System.EventHandler(this.TimerCheckOnlineSta_Tick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(125, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(507, 343);
			this.panel1.TabIndex = 8;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(503, 339);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.LV_SysUser);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(495, 314);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "系统用户";
			// 
			// LV_SysUser
			// 
			this.LV_SysUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.ColumnHeader1,
																						 this.ColumnHeader2,
																						 this.ColumnHeader3,
																						 this.ColumnHeader4,
																						 this.ColumnHeader5,
																						 this.ColumnHeader6,
																						 this.columnHeader7});
			this.LV_SysUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LV_SysUser.FullRowSelect = true;
			this.LV_SysUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LV_SysUser.Location = new System.Drawing.Point(0, 0);
			this.LV_SysUser.Name = "LV_SysUser";
			this.LV_SysUser.Size = new System.Drawing.Size(495, 314);
			this.LV_SysUser.TabIndex = 14;
			this.LV_SysUser.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Text = "ID";
			this.ColumnHeader1.Width = 72;
			// 
			// ColumnHeader2
			// 
			this.ColumnHeader2.Text = "IP地址";
			this.ColumnHeader2.Width = 122;
			// 
			// ColumnHeader3
			// 
			this.ColumnHeader3.Text = "端口";
			// 
			// ColumnHeader4
			// 
			this.ColumnHeader4.Text = "状态";
			this.ColumnHeader4.Width = 44;
			// 
			// ColumnHeader5
			// 
			this.ColumnHeader5.Text = "部门";
			this.ColumnHeader5.Width = 40;
			// 
			// ColumnHeader6
			// 
			this.ColumnHeader6.Text = "姓名";
			this.ColumnHeader6.Width = 90;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Version";
			this.columnHeader7.Width = 120;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.LV_OnlineUser);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(495, 314);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "在线用户";
			// 
			// LV_OnlineUser
			// 
			this.LV_OnlineUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.ID,
																							this.IP地址,
																							this.端口,
																							this.状态,
																							this.部门,
																							this.姓名,
																							this.Version});
			this.LV_OnlineUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LV_OnlineUser.FullRowSelect = true;
			this.LV_OnlineUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LV_OnlineUser.Location = new System.Drawing.Point(0, 0);
			this.LV_OnlineUser.Name = "LV_OnlineUser";
			this.LV_OnlineUser.Size = new System.Drawing.Size(495, 314);
			this.LV_OnlineUser.TabIndex = 13;
			this.LV_OnlineUser.View = System.Windows.Forms.View.Details;
			// 
			// ID
			// 
			this.ID.Text = "ID";
			this.ID.Width = 72;
			// 
			// IP地址
			// 
			this.IP地址.Text = "IP地址";
			this.IP地址.Width = 122;
			// 
			// 端口
			// 
			this.端口.Text = "端口";
			// 
			// 状态
			// 
			this.状态.Text = "状态";
			this.状态.Width = 44;
			// 
			// 部门
			// 
			this.部门.Text = "部门";
			this.部门.Width = 40;
			// 
			// 姓名
			// 
			this.姓名.Text = "姓名";
			this.姓名.Width = 90;
			// 
			// Version
			// 
			this.Version.Text = "Version";
			this.Version.Width = 120;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "LanMsg服务";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 393);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Splitter1);
			this.Controls.Add(this.TreeView1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Menu = this.mainMenu1;
			this.Name = "FormMain";
			this.Text = "LanMsg服务";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Resize += new System.EventHandler(this.FormMain_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
// 	          GetAllUserInfo();
		}

		private void Server(bool IsServer)//开始或停止服务
		{
			if(IsServer)
				this.sockUDP1.Listen(3211);
			else
				this.sockUDP1.CloseSock();
		}

		private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)//当有数据到达后调用新的处理进程
		{
			DataArrivaldelegate outdelegate = new DataArrivaldelegate( DataArrival); 
			this.BeginInvoke (outdelegate, new object[]{ Data,Ip,Port}); 
		}

		private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port); 

		private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
		{ 
			try
			{
				LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as LanMsg.Controls.ClassMsg;
			
				switch(msg.MsgInfoClass)
				{
					case 1://处理用户登录过程
						NewUserLogin(msg,Ip,Port);
						break;
					case 2://用户询问自己是否在线,并更改其在线状态
						updateUserState(msg,Ip,  Port);//更新用户状态信息
						break;
				}
			}
			catch(Exception e)
			{}

		}

		private void updateUserState(Controls.ClassMsg msg, System.Net.IPAddress Ip, int Port)//更新用户状态信息
		{
			try
			{
				//this.textBox1.AppendText ("用户"+ msg.ID +"状态更新\n");

				string state=System.Text.Encoding.Unicode.GetString((msg.MsgContent ));

				System.Windows.Forms.ListViewItem item=FindUser(msg.ID ,this.LV_OnlineUser );
				if(item!=null)
				{
					item.SubItems[3].Text =state;
					if(state=="0")
						this.LV_OnlineUser.Items.Remove(item);
				}

				item=FindUser(msg.ID ,this.LV_SysUser  );
				if(item!=null)
				{
					item.SubItems[3].Text =state;
					if(state=="0" && item.SubItems[4].Text =="10") 
						this.LV_SysUser.Items.Remove(item);
				}

				this.SendMsgToOne(Ip,Port,new Controls.ClassMsg( 2,"",null));//告诉用户在线
			}
			catch(Exception e){}
		}

		private void NewUserLogin(Controls.ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理用户登录过程
		{
			try
			{
				//			this.textBox1.AppendText ("用户"+ msg.ID +"登录\n");

				ClassUserInfo selfInfo=new ClassUserInfo();//准备添加新用户的资料
				selfInfo.ID=msg.ID;
				selfInfo.UserName =msg.ID;
				selfInfo.IP=Ip;
				selfInfo.Port=Port;
				selfInfo.State =1;
				selfInfo.Dep =10;
				selfInfo.AssemblyVersion=System.Text.Encoding.Unicode.GetString(msg.MsgContent);

				System.Windows.Forms.ListViewItem item=FindUser(msg.ID ,this.LV_SysUser);
				if(item!=null)//如果此用户是sysuser，那么更改其上线信息，并把他的所有联系人的信息发送给它
				{
					item.SubItems[1].Text=Ip.ToString();
					item.SubItems[2].Text=Port.ToString();
					item.SubItems[3].Text="1";//1表示用户在线状态为联机
					item.SubItems[6].Text =selfInfo.AssemblyVersion;//更新其版本号
					selfInfo.UserName =item.SubItems[5].Text;
					selfInfo.Dep =Convert.ToInt32(item.SubItems[4].Text);
					//在在线用户表中查找此用户是否存在，如果不存在则添加，如果存在就不做任何操作
					System.Windows.Forms.ListViewItem items=FindUser(msg.ID ,this.LV_OnlineUser );
					if(items!=null)//如果用户不在在线用户列表里面，则添加
					{
						items.SubItems[1].Text=Ip.ToString();
						items.SubItems[2].Text=Port.ToString();
						items.SubItems[3].Text="1";//1表示用户在线状态为联机
						items.SubItems[6].Text =selfInfo.AssemblyVersion;//更新其版本号
					}
					else//如果是用户不在在线列表中，则添加
					{
						System.Windows.Forms.ListViewItem NewItem=new ListViewItem();
						NewItem=item.Clone() as ListViewItem;
						this.LV_OnlineUser.Items.Add(NewItem);
					}

				}
				else//如果此用户不是sysuser，那么将其添加入系统用户列表与在线用户列表并更改其上线信息，并把他的所有联系人的信息发送给它
				{
					System.Windows.Forms.ListViewItem NewItem=new ListViewItem();
					NewItem.Text=msg.ID;
					NewItem.SubItems.Add(Ip.ToString());
					NewItem.SubItems.Add(Port.ToString());
					NewItem.SubItems.Add("1");//1表示用户在线状态为联机
					NewItem.SubItems.Add("10");//10表示用户为未知组用户
					NewItem.SubItems.Add(msg.ID);// 未知组用户的姓名均为ID
					NewItem.SubItems.Add(selfInfo.AssemblyVersion);//表示用户软件版本号
					this.LV_SysUser.Items.Add (NewItem);				  
					this.LV_OnlineUser.Items.Add(NewItem.Clone() as ListViewItem);
				}
            
				//发送消息告诉用户已经登录到服务器,并将其服务器上的个人资料发回
				LanMsg.Controls.ClassMsg ToOneMsg =new LanMsg.Controls.ClassMsg(1,"",new Controls.ClassSerializers().SerializeBinary(selfInfo).ToArray() );
				this.SendMsgToOne(Ip,Port,ToOneMsg);
				//			this.textBox1.AppendText ("将其服务器上的个人资料发回"+ Ip.ToString() + Port.ToString() +msg.ID +"\n");
            
				System.Threading.Thread.Sleep(100);
			
				//发回此用户所有联系人的资料
				LanMsg.Controls.ClassUsers allUsers=Users();//返回所有用户联系人的资料
				System.Threading.Thread.Sleep(100);
				ToOneMsg =new LanMsg.Controls.ClassMsg(4,"",new Controls.ClassSerializers().SerializeBinary(allUsers).ToArray());
				this.SendMsgToOne(Ip,Port,ToOneMsg);
				//			this.textBox1.AppendText ("返回所有用户联系人的资料"+ msg.ID +"\n");
             
				//将登录用户资料发送给其全部联系人，告之用户登录
				System.Threading.Thread.Sleep(100);
				ToOneMsg =new LanMsg.Controls.ClassMsg(3,"",new Controls.ClassSerializers().SerializeBinary(selfInfo).ToArray());
				this.SendMsgToAll( ToOneMsg);
				//			this.textBox1.AppendText ("告之用户登录"+ msg.ID +"\n");
			}
			catch(Exception e){}

		}

		private LanMsg.Controls.ClassUsers Users()//返回所有用户联系人的资料
		{
			try
			{
				LanMsg.Controls.ClassUsers  allUsers=new LanMsg.Controls.ClassUsers();
				foreach(System.Windows.Forms.ListViewItem item in this.LV_SysUser.Items )
				{
					ClassUserInfo userInfo=new ClassUserInfo();
					userInfo.ID=item.Text;
					userInfo.IP=System.Net.IPAddress.Parse(item.SubItems[1].Text);
					userInfo.Port =Convert.ToInt32(item.SubItems[2].Text) ;
					userInfo.State  =Convert.ToInt32(item.SubItems[3].Text) ;
					userInfo.Dep  =Convert.ToInt32(item.SubItems[4].Text) ;
					userInfo.UserName = item.SubItems[5].Text;
					userInfo.AssemblyVersion= item.SubItems[6].Text;
					allUsers.add(userInfo);
				}
				return allUsers;
			}
			catch(Exception e){return null;}
		}
		
		private System.Windows.Forms.ListViewItem FindUser(string UserID,System.Windows.Forms.ListView LV)//在相应的ListView里查找用户
		{
			try
			{
				foreach(System.Windows.Forms.ListViewItem item in  LV.Items)
					if(item.Text.ToLower()==UserID.ToLower())//找到用户，说明是系统用户,返回它的值
						return item;
				return null;
			}
			catch(Exception e){return null;}
		}

		private void menuItemControlExit_Click(object sender, System.EventArgs e)
		{
			FormMain_Closing(sender,null);
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(menuItemControlServer.Text=="停止服务(&S)")
			if(MessageBox.Show("确定要关闭服务并退出程序吗？","提示",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) ==System.Windows.Forms.DialogResult.Yes)
			{
				this.sockUDP1.CloseSock();
				Application.Exit();
			}
		}

		private void menuItemControlServer_Click(object sender, System.EventArgs e)
		{
			if (menuItemControlServer.Text=="开始服务(&B)")
			{
				menuItemControlServer.Text="停止服务(&S)";
				Server(true);//开始服务
				this.statusBar1.Text="服务已经启动";
			}
			else
			{
				menuItemControlServer.Text="开始服务(&B)";
				Server(false);//停止服务
				this.statusBar1.Text="服务已经关闭";
			}

		}

		private void TimerCheckOnlineSta_Tick(object sender, System.EventArgs e)
		{
			CheckOnlineSta();//系统每隔一分钟检查一次用户在线状态，不在线的则删除并通知其联系人
		}

		private void  CheckOnlineSta()//系统每隔一分钟检查一次用户在线状态，不在线的则删除并通知其联系人
		{
			try
			{
				foreach(System.Windows.Forms.ListViewItem item in this.LV_OnlineUser.Items)
				{
					if(item.SubItems[3].Text=="0")//如果用户已经脱机，则删除并通知其全部联系人
					{
						System.Windows.Forms.ListViewItem TempItem=FindUser(item.Text,this.LV_SysUser);//在系统用户表中查找此用户的信息
						if(TempItem!=null)
						{
							if(item.SubItems[4].Text=="10")//如果部门为未知，则在系统用户表中删除此用户
								this.LV_SysUser.Items.Remove(TempItem);
							else//如果是本系统用户则更新状态
								TempItem.SubItems[3].Text="0";//更新系统用户的在线状态
						}
						LanMsg.Controls.ClassMsg msg =new LanMsg.Controls.ClassMsg(0,item.Text, null);
						SendMsgToAll(msg);//发送消息给所有此用户的联系人,告之用户掉线
						this.LV_OnlineUser.Items.Remove(item);//在在线用户列表中删除此用户信息
					} 
					else
					{
						item.SubItems[3].Text ="0";//假设此用户已经掉线
					}
				}
			}
			catch(Exception e){}

		}

		private void SendMsgToOne(System.Net.IPAddress ip,int port,Controls.ClassMsg msg)//发送消息给一个用户
		{
			try
			{
				System.IO.MemoryStream stream= new Controls.ClassSerializers().SerializeBinary(msg);
				LanMsg.Controls.SockUDP udp=new LanMsg.Controls.SockUDP();
				udp.Send(ip,port,stream.ToArray());
			}
			catch(Exception e){}

		}

		private void SendMsgToAll(Controls.ClassMsg msg)//发送消息给所有用户
		{
			try
			{
				foreach(System.Windows.Forms.ListViewItem item in this.LV_OnlineUser.Items)
				{
					System.Net.IPAddress ip=System.Net.IPAddress.Parse(item.SubItems[1].Text);
					int port=Convert.ToInt32 (item.SubItems[2].Text);
					System.IO.MemoryStream stream= new Controls.ClassSerializers().SerializeBinary(msg);
					LanMsg.Controls.SockUDP udp=new LanMsg.Controls.SockUDP();
					udp.Send(ip,port,stream.ToArray());
				}
			}
			catch(Exception e){}

		}

		private void GetAllUserInfo() //读取数据库中所有用户数据到列表中
		{ 
			try
			{
				System.Data.OleDb.OleDbDataReader dr;
				string  SQLstr= "select Sys_Users.UserName as computer,Mp_EmpLoyee.DepID as Dept,Mp_EmpLoyee.EmpName as UserName from Sys_Users,Mp_EmpLoyee where Mp_EmpLoyee.EmpID=Sys_Users.EmpID and (Sys_Users.IsWork is null or Sys_Users.IsWork>0)";
				dr=new ClassOptionData().ExSQLReDr(SQLstr);
				while(dr.Read())
				{
					AllOneUserInfoToLV(LV_SysUser, Convert.ToString(dr["computer"]), "127.0.0.1", "0", "0",Convert.ToString(dr["dept"]), Convert.ToString(dr["UserName"]));
				}
				dr.Close();

			}
			catch(Exception e){}

		}

		private void AllOneUserInfoToLV( System.Windows.Forms.ListView LV, string  Computer, string  IpAddress,string  port, string  OnlineSta, string  Dept, string  UserName )//'处理新登录用户的信息数据)
		{
			try
			{
				System.Windows.Forms.ListViewItem   NewItem =new  ListViewItem();
				NewItem.Text  = Computer.Trim().ToLower(); //      '添加用户计算机名与端口号信息
				NewItem.SubItems.Add(IpAddress); //'添加用户IP地址信息
				NewItem.SubItems.Add(port); //  '添加用户端口信息
				NewItem.SubItems.Add(OnlineSta);// '在线状态
				NewItem.SubItems.Add(getDept(Dept));//'设置用户部门为未知
				NewItem.SubItems.Add(UserName.Trim());//'添加用户姓名信息
				NewItem.SubItems.Add("");//'添加用户姓名信息
				LV.Items.Add(NewItem);// '添加此登录用户的所有信息到系统列表中 
			}
			catch(Exception e){}

		}

		private string getDept(string Dept)
	{
			switch(Dept)
			{
				case  "12":
					return "0";//院领导 
                    break;
				case  "8":
				    return "1";//院领导					   
                    break;
				case  "13":
					return "1";//院领导 
                    break;
				case  "14":
					return "1";//院领导 
                    break;
				case  "15":
					return "1";//综合部 
                    break;
				case  "3":
					return "2";//财务部 
                    break;
				case  "5":
					return "3";//市场部 
                    break;
				case  "2":
					return "3";//市场部 
                    break;
				case  "11":
					return "4";//设备所
                    break;
				case  "9":
					return "5";//传输所
                    break;
				case  "10":
					return "6";//计算机所 
                    break;
				case  "4":
					return "7";//规划所
                    break;
				case  "16":
					return "8";//无线所
                    break;
                case "6": 
				    return "9";//建筑分院 
					break;
			}
			return "10";
		}

		private void menuItemControl_Click(object sender, System.EventArgs e)
		{
		
		}

		private void notifyIcon1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.WindowState=System.Windows.Forms.FormWindowState.Maximized ;
			this.Show();
			this.Activate();
		}

		private void FormMain_Resize(object sender, System.EventArgs e)
		{
			if(this.WindowState==System.Windows.Forms.FormWindowState.Minimized)
				this.Hide();
		}
	}
}	
