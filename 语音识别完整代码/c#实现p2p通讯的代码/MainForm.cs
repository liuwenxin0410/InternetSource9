using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PtoP
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.Button send;
		private System.Windows.Forms.Button disconn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox uid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox uip;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button conn;
		private System.Windows.Forms.TextBox portnum;
		//用户定义
		private bool isconnecting=false;
		private bool isconnected=false;
		private bool isclient=false;
		private const string infDisconn="######DISCONNECT######";
		//接受信息线程
		private Thread th ;
		//监听连接信号线程
		private Thread wait ;
		private setPortForm portform;
		static public TcpListener tcp1;
		static public int port;
		//客户端
		private TcpClient tcpc  ;
		//服务器端
		private TcpClient tcps  ;
		//客户端
		private NetworkStream nsc ;
		//服务器端
		private NetworkStream nss ;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.send = new System.Windows.Forms.Button();
			this.disconn = new System.Windows.Forms.Button();
			this.uid = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uip = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.portnum = new System.Windows.Forms.TextBox();
			this.conn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Location = new System.Drawing.Point(16, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(512, 184);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "信息显示";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(16, 24);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(480, 144);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(32, 232);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(344, 120);
			this.richTextBox2.TabIndex = 1;
			this.richTextBox2.Text = "";
			this.richTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox2_KeyDown);
			// 
			// send
			// 
			this.send.Location = new System.Drawing.Point(400, 232);
			this.send.Name = "send";
			this.send.Size = new System.Drawing.Size(128, 23);
			this.send.TabIndex = 2;
			this.send.Text = "发 送(Ctrl+Enter)";
			this.send.Click += new System.EventHandler(this.send_Click);
			// 
			// disconn
			// 
			this.disconn.Location = new System.Drawing.Point(400, 328);
			this.disconn.Name = "disconn";
			this.disconn.Size = new System.Drawing.Size(128, 23);
			this.disconn.TabIndex = 3;
			this.disconn.Text = " 断 开 连 接  ";
			this.disconn.Click += new System.EventHandler(this.disconn_Click);
			// 
			// uid
			// 
			this.uid.Location = new System.Drawing.Point(64, 376);
			this.uid.Name = "uid";
			this.uid.Size = new System.Drawing.Size(72, 21);
			this.uid.TabIndex = 4;
			this.uid.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 376);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "姓 名";
			// 
			// uip
			// 
			this.uip.Location = new System.Drawing.Point(192, 376);
			this.uip.Name = "uip";
			this.uip.Size = new System.Drawing.Size(152, 21);
			this.uip.TabIndex = 6;
			this.uip.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 376);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "I P";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(352, 376);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "端口";
			// 
			// portnum
			// 
			this.portnum.Location = new System.Drawing.Point(392, 376);
			this.portnum.Name = "portnum";
			this.portnum.Size = new System.Drawing.Size(40, 21);
			this.portnum.TabIndex = 9;
			this.portnum.Text = "";
			// 
			// conn
			// 
			this.conn.Location = new System.Drawing.Point(456, 376);
			this.conn.Name = "conn";
			this.conn.TabIndex = 10;
			this.conn.Text = "连 接";
			this.conn.Click += new System.EventHandler(this.conn_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(400, 280);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = " 清 除 屏 幕 ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AcceptButton = this.conn;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(546, 432);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.conn);
			this.Controls.Add(this.portnum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.uip);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.uid);
			this.Controls.Add(this.disconn);
			this.Controls.Add(this.send);
			this.Controls.Add(this.richTextBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "点对点聊天";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		//初始化程序
		private void Form1_Load(object sender, System.EventArgs e)
		{
		 //程序运行时初始化本地计算机端口配置
		 portform=new setPortForm();
		 portform.ShowDialog();
		 this.send.Enabled=false;
		 this.disconn.Enabled=false;
		 this.Text="P2P聊天(正在等待连接..)";
		 //启动tcplistner
		 tcp1.Start();
		 //启动等待连接线程
		 wait=new Thread(new ThreadStart(waitconn));
		 wait.Start();
		}
        //等待连接函数
		private void waitconn()
		{
		    //开始监听本地连接端口
			tcps=tcp1.AcceptTcpClient();
			nss=tcps.GetStream();
			//弹出连接对话筐
			string str="用户请求连接,接受?";
			string cmd="连接请求";
			this.Text="P2P聊天(与"+this.uid.Text+"会话进行中)";
			DialogResult diares=MessageBox.Show(str,cmd,MessageBoxButtons.YesNo);
			//处理回应2个中间变量
			string strresp;
			byte[] byteresp;
			if(diares==DialogResult.Yes)
			{
				strresp="#";
				byteresp=System.Text.Encoding.ASCII.GetBytes(strresp.ToCharArray());
				//将数据写入流
				nss.Write(byteresp,0,byteresp.Length);
				//改变控制变量
				isconnecting=true;
				isconnected=true;
				isclient=false;
				//改变按钮状态
				this.conn.Enabled=false;
				this.disconn.Enabled=true;
				this.send.Enabled=true;
				//启动接受信息线程
				th=new Thread(new ThreadStart(acceptmsg));
				th.Start();

			}
			else if(diares==DialogResult.No)
			{
			    strresp="##";
                byteresp=System.Text.Encoding.ASCII.GetBytes(strresp.ToCharArray());
				nss.Write(byteresp,0,byteresp.Length);
				nss.Close();
				tcps.Close();
				disconnect();
			}
		}
		//连接处理按钮
		private void conn_Click(object sender, System.EventArgs e)
		{
			//建立TCP连接
			if(this.uip.Text.Length==0||this.portnum.Text.Length==1)
			{
				string str="请输入正确的IP地址和端口号";
				string cmd="错误";
				MessageBox.Show(str,cmd);
			    return;
			}
            tcpc=new TcpClient();
			string ip=this.uip.Text;
			int pnum=System.Convert.ToInt32(this.portnum.Text,10);
			try
			{
				tcpc.Connect(ip,pnum);
			}
			catch(ArgumentOutOfRangeException)
			{
				string str="请输入有效的端口号";
				string cmd="错误";
				MessageBox.Show(str,cmd);
				return;
			}
			catch(SocketException)
			{
				string str="找不到对方,请重新确认对方的网络参数";
				string cmd="错误";
				MessageBox.Show(str,cmd);
				return;
			}
			//获取网络流
			nsc=tcpc.GetStream();
			//保存到读取数据的数组
			byte[] read=new byte[2];
			//读取字节数
			int bytes=nsc.Read(read,0,read.Length);
			//根据读到的字节数来判断对方作出何种回应,1表示允许连接,2表示拒绝
			if(bytes==1)
			{
			 string str="已经建立连接!";
			 string cmd="完成";
			 MessageBox.Show(str,cmd);
			 isconnecting=true;
		     isconnected=true;
		     isclient=true;
			 this.conn.Enabled=false;
			 this.disconn.Enabled=true;
			 this.send.Enabled=true;
			 //创建接受信息线程
			 th=new Thread(new ThreadStart(acceptmsg));
			 th.Start();
			}
		}

		//接受信息处理函数
		private void acceptmsg()
		{
			while(isconnecting)
			{
				if(isclient)
				{
				 acceptmsg(tcpc,nsc);
				}
				else
				{
				 acceptmsg(tcps,nss);
				}
			}
		}

		//接受信息核心函数
		private void acceptmsg(TcpClient tcpc,NetworkStream ns)
		{
		  byte[] read=new byte[1024];
		  ns=tcpc.GetStream();
		  ns.Read(read,0,read.Length);
		  string strout=System.Text.Encoding.Unicode.GetString(read);
			if(string.Compare(strout,infDisconn)==0)
			{
			  string str="用户已经断开了连接";
			  string cmd="连接已断开";
			  MessageBox.Show(str,cmd);
			  this.richTextBox1.AppendText(str+"\n");
			  this.Text="P2P聊天(等待连接)";
			  ns.Close();
			  tcpc.Close();
			  disconnect();
			}else
			{
				this.Text="P2P聊天(会话进行中)";
				DateTime now=DateTime.Now;
				string strline=now.ToShortDateString()+"  "+now.ToLongTimeString();
				string strmsgline=strline+"  ";
				this.richTextBox1.AppendText(strmsgline);
				this.richTextBox1.AppendText(strout);
				this.richTextBox1.AppendText("\n");
			}
		 }
		//发送信息动作
		private void send_Click(object sender, System.EventArgs e)
		{
			if(isclient)
			{
				sendmsg(nsc);
			}
			else
			{
			   sendmsg(nss);
			}
		}
		//发送信息处理函数
		private void sendmsg(NetworkStream ns)
		{
		 string msg=this.uid.Text+"说:\n"+this.richTextBox2.Text;
		 this.richTextBox2.Text=null;
		 byte[] write=new byte[1024];
		 write=System.Text.Encoding.Unicode.GetBytes(msg.ToCharArray());
		 ns.Write(write,0,write.Length);
			if(string.Compare(msg,infDisconn)!=0)
			{
				DateTime now=DateTime.Now;
				string date=now.ToShortDateString()+" "+now.ToLongTimeString();
				string msgline=date+"  "+"我说:\n";
				this.richTextBox1.AppendText(msgline);
				this.richTextBox1.AppendText(msg);
				this.richTextBox1.AppendText("\n\n");
				this.richTextBox2.Focus();
			}
		 }

		private void disconn_Click(object sender, System.EventArgs e)
		{
			if(isclient)
			{
				disconnect(tcpc,nsc);
			}
			else
			{
			    disconnect(tcps,nss);
			}
		}
		//断开连接处理函数
		private void disconnect()
		{
			this.conn.Enabled=true;
			this.disconn.Enabled=false;
			this.send.Enabled=false;
			isconnecting=false;
			//启动等待连接线程
			wait=new Thread(new ThreadStart(waitconn));
			wait.Start();
		}
		private void disconnect(TcpClient tcpc,NetworkStream ns)
		{
		    byte[] write=new byte[64];
			write=System.Text.Encoding.Unicode.GetBytes(infDisconn.ToCharArray());
			ns.Write(write,0,write.Length);
			ns.Close();
			tcpc.Close();
			disconnect();
		}
		//重载函数
		protected override void OnClosed(EventArgs e)
		{
			if(isconnecting)
			{
				if(isclient)
				{
				 disconnect(tcpc,nsc);
				}
				else
				{
				 disconnect(tcps,nss);
				}
			}
			tcp1.Stop();
			wait.Abort();
		}

		private void richTextBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control)
			{
				if(e.KeyCode==Keys.Enter)
				{
					send_Click(this,e);
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.richTextBox1.Text=null;
		}

	}
}
