using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace LanMsg.Controls
{
	/// <summary>
	/// filesSend 的摘要说明。
	/// </summary>
	public class filesSend : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabelCancel;
		private System.Windows.Forms.Label labOr;
		private System.Windows.Forms.LinkLabel linkReceive;
		private System.Windows.Forms.LinkLabel linkSaveAs;
		private LanMsg.Controls.SockUDP sockUDP1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelProgress;
		public System.Windows.Forms.Label labFileName;

		[Serializable]
		private class sendFileInfo
		{
			public int MsgInfoClass=0;//文件发送消息类别
			public long fileSize=0;//文件尺寸
			public int pSendPos=0;//标记上次发送的位置
			public byte[] FileBlock=null;//当前发送的文件块

			public sendFileInfo( )
			{
				//
				// TODO: 在此处添加构造函数逻辑
				//
			}

			public sendFileInfo(int msgInfoClass,long FileSize,int PSendPos,byte[] fileBlock )
			{
				MsgInfoClass=msgInfoClass;
				fileSize=FileSize;
				pSendPos=PSendPos;
				FileBlock=fileBlock;
			}
		}

		public filesSend()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try
			{
				this.fStream.Close();//关闭打开的文件资源
			}
			catch(Exception e){}
			try
			{
				if((this.IsSendState && !this.sendOver) || !IsCancel)//如果文件正在传输中且没有成功便被用户关闭程序以强行终止，则给对方发送"取消文件传输"
			    this.sendData(new sendFileInfo(0,0,0,null));
			}
			catch(Exception e){}
			try
			{
				this.sockUDP1.CloseSock();//关闭sockUDP1端口，清楚占用的资源 
			}
			catch(Exception e){	}

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(filesSend));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.labFileName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabelCancel = new System.Windows.Forms.LinkLabel();
			this.labOr = new System.Windows.Forms.Label();
			this.linkSaveAs = new System.Windows.Forms.LinkLabel();
			this.linkReceive = new System.Windows.Forms.LinkLabel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labelState = new System.Windows.Forms.Label();
			this.sockUDP1 = new LanMsg.Controls.SockUDP(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelProgress = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.labelState);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(384, 184);
			this.panel1.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.labFileName);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 69);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(384, 115);
			this.panel6.TabIndex = 10;
			// 
			// labFileName
			// 
			this.labFileName.AutoSize = true;
			this.labFileName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labFileName.ForeColor = System.Drawing.Color.Purple;
			this.labFileName.Location = new System.Drawing.Point(54, 0);
			this.labFileName.Name = "labFileName";
			this.labFileName.Size = new System.Drawing.Size(42, 17);
			this.labFileName.TabIndex = 1;
			this.labFileName.Text = "文件名";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.ForeColor = System.Drawing.Color.Purple;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "文件名：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.linkLabelCancel);
			this.panel5.Controls.Add(this.labOr);
			this.panel5.Controls.Add(this.linkSaveAs);
			this.panel5.Controls.Add(this.linkReceive);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 45);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(384, 24);
			this.panel5.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.ForeColor = System.Drawing.Color.Purple;
			this.label4.Location = new System.Drawing.Point(154, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 17);
			this.label4.TabIndex = 22;
			this.label4.Text = "传输";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.label4.Visible = false;
			// 
			// linkLabelCancel
			// 
			this.linkLabelCancel.AutoSize = true;
			this.linkLabelCancel.Dock = System.Windows.Forms.DockStyle.Left;
			this.linkLabelCancel.ForeColor = System.Drawing.Color.Purple;
			this.linkLabelCancel.LinkColor = System.Drawing.Color.DarkOliveGreen;
			this.linkLabelCancel.Location = new System.Drawing.Point(100, 0);
			this.linkLabelCancel.Name = "linkLabelCancel";
			this.linkLabelCancel.Size = new System.Drawing.Size(54, 17);
			this.linkLabelCancel.TabIndex = 21;
			this.linkLabelCancel.TabStop = true;
			this.linkLabelCancel.Text = "取消传输";
			this.linkLabelCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.linkLabelCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCancel_LinkClicked);
			// 
			// labOr
			// 
			this.labOr.AutoSize = true;
			this.labOr.Dock = System.Windows.Forms.DockStyle.Left;
			this.labOr.ForeColor = System.Drawing.Color.Purple;
			this.labOr.Location = new System.Drawing.Point(83, 0);
			this.labOr.Name = "labOr";
			this.labOr.Size = new System.Drawing.Size(17, 17);
			this.labOr.TabIndex = 20;
			this.labOr.Text = "或";
			this.labOr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// linkSaveAs
			// 
			this.linkSaveAs.AutoSize = true;
			this.linkSaveAs.Dock = System.Windows.Forms.DockStyle.Left;
			this.linkSaveAs.ForeColor = System.Drawing.Color.Purple;
			this.linkSaveAs.LinkColor = System.Drawing.Color.DarkOliveGreen;
			this.linkSaveAs.Location = new System.Drawing.Point(29, 0);
			this.linkSaveAs.Name = "linkSaveAs";
			this.linkSaveAs.Size = new System.Drawing.Size(54, 17);
			this.linkSaveAs.TabIndex = 17;
			this.linkSaveAs.TabStop = true;
			this.linkSaveAs.Text = "接收文件";
			this.linkSaveAs.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.linkSaveAs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSaveAs_LinkClicked);
			// 
			// linkReceive
			// 
			this.linkReceive.AutoSize = true;
			this.linkReceive.Dock = System.Windows.Forms.DockStyle.Left;
			this.linkReceive.ForeColor = System.Drawing.Color.Purple;
			this.linkReceive.LinkColor = System.Drawing.Color.DarkOliveGreen;
			this.linkReceive.Location = new System.Drawing.Point(0, 0);
			this.linkReceive.Name = "linkReceive";
			this.linkReceive.Size = new System.Drawing.Size(29, 17);
			this.linkReceive.TabIndex = 16;
			this.linkReceive.TabStop = true;
			this.linkReceive.Text = "接收";
			this.linkReceive.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.linkReceive.Visible = false;
			this.linkReceive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReceive_LinkClicked);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.labelProgress);
			this.panel4.Controls.Add(this.progressBar1);
			this.panel4.Controls.Add(this.panel3);
			this.panel4.Controls.Add(this.panel2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 17);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(384, 28);
			this.panel4.TabIndex = 8;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(376, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(8, 28);
			this.panel3.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(8, 28);
			this.panel2.TabIndex = 2;
			// 
			// labelState
			// 
			this.labelState.AutoSize = true;
			this.labelState.BackColor = System.Drawing.Color.Transparent;
			this.labelState.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelState.ForeColor = System.Drawing.Color.Purple;
			this.labelState.Location = new System.Drawing.Point(0, 0);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(122, 17);
			this.labelState.TabIndex = 0;
			this.labelState.Text = "等待对方接收文件...";
			this.labelState.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// sockUDP1
			// 
			this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));
			this.sockUDP1.DataArrival += new LanMsg.Controls.SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBar1.Location = new System.Drawing.Point(8, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(368, 12);
			this.progressBar1.TabIndex = 6;
			// 
			// labelProgress
			// 
			this.labelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProgress.Location = new System.Drawing.Point(8, 12);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new System.Drawing.Size(368, 16);
			this.labelProgress.TabIndex = 7;
			this.labelProgress.Text = "(0/0)";
			this.labelProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// filesSend
			// 
			this.BackColor = System.Drawing.Color.Cyan;
			this.Controls.Add(this.panel1);
			this.Name = "filesSend";
			this.Size = new System.Drawing.Size(384, 184);
			this.panel1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region  文件传输事件
	
		public delegate void fileSendEndEventHandler(object sender,bool isSelf);//文件传输结束事件
			public  event fileSendEndEventHandler fileSendEnd; 

			public delegate void fileSendCancelEventHandler(object sender,bool isSelf);//取消文件传输事件
			public  event fileSendCancelEventHandler fileSendCancel; 
	    
		#endregion


		public string FileName=Application.StartupPath + @"\ReceiveFiles\";//发送或接收文件所保存的位置
		
		private System.Net.IPAddress serverIp=System.Net.IPAddress.Parse("127.0.0.1");//对方ip地址 

		private int serverPort=0;//对方Ip端口

		private long FileSize=0;//文件尺寸
	
		private string Extension="";//文件扩展名

		private bool IsSendState=false;//标记文件是否在发送过程中

		private int  pSendPos=0;//标记上次发送的位置

        private int buf=8000;//标记一次传输文件数据块的大小

		private System.IO.FileStream fStream ;//文件操作流

		private bool userCancelSend=false;//记录对方是否取消文件传输

		private bool sendOver=false;//标记文件是否传输完成
       
		private bool IsSend=false;//标识当前用户是发送文件还是接收文件

		private bool IsCancel=false;//标识文件传输是点击“取消”而取消的

		private int  OutTime=0;//发送数据块超时读数器

		public void SetParameter(bool isSend,string LabFileName,string fileName,long fileSize,System.Net.IPAddress ServerIP,int ServerPort,string fileExtension)
		{
			//文件传输前建立双方连接的参数设置函数
			this.IsSend=isSend;
			this.FileSize=fileSize;
			this.serverIp=ServerIP;
			this.serverPort=ServerPort;
			this.Extension =fileExtension;
			this.labFileName.Text =LabFileName;//文件名称
			this.Listen();
            this.timer1.Enabled=true;//保持UDP端口在外网上的映射
            this.labelProgress.Text="(0/"+ this.FileSize.ToString() +")";
			if(IsSend)
			{
			   this.FileName=fileName;//文件的绝对路径
			   this.linkReceive.Visible=false;
			   this.linkSaveAs.Visible=false;
			   this.labOr.Visible=false;
			   this.labelState.Text="等待对方接收文件...";
			}
			else
			{
				this.labelState.Text="对方正等待您接收文件...";
				this.sockUDP1.Send(this.serverIp,this.serverPort,new ClassSerializers().SerializeBinary(new sendFileInfo(100,0,0,null)).ToArray());
			}
		}

		public string GetSizeStr(long fileSize)//获得传输文件的尺寸字符串
		{
           if(Convert.ToInt32(fileSize/1024)==0)
			   return fileSize.ToString() +"字节";
           if(Convert.ToInt32(fileSize/1024)>0 && Convert.ToInt32(fileSize/(1024*1024))==0)
			   return Convert.ToInt32(fileSize/1024).ToString() +"KB";
           if(Convert.ToInt32(fileSize/(1024*1024))>0 && Convert.ToInt32(fileSize/(1024*1024*1024))==0)    
			  return Convert.ToInt32(fileSize/(1024*1024)).ToString() +"MB";
			if(Convert.ToInt32(fileSize/(1024*1024*1024))>0)    
				return Convert.ToInt32(fileSize/(1024*1024*1024)).ToString() +"GB";

		   return "未知大小";
		}

		private void linkLabelCancel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if(MessageBox.Show("确定要终止文件的传输吗？","提示",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes )
			{
				if(!this.IsSendState)//如果当前还没有开始传输，则要发消息给对方，告诉对方已经取消文件传输
				IsCancel=true;//取消为真
				this.sendData(new sendFileInfo(0,0,0,null));//给对方发送“取消文件传输”消息
     			fileSendCancel(this,true);//触发“文件取消发送事件”(自己取消的)
			}
		}

		private void linkSaveAs_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Windows.Forms.SaveFileDialog fd=new SaveFileDialog ();
			fd.Filter="文档(*"+ this.Extension +")|*"+ this.Extension;
			fd.FileName=this.labFileName.Text;
			if(fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
				this.linkSaveAs.Visible=false;
				this.labOr.Visible=false;
				this.Refresh();

              this.FileName=fd.FileName;
			  this.sendData (new sendFileInfo(1,0,0,null));//当用户单击接收文件时，发送消息给对方，要求对方开始发送文件数据块
			}
		}

		private void linkReceive_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			this.sendData (new sendFileInfo(1,0,0,null));//当用户单击接收文件时，发送消息给对方，要求对方开始发送文件数据块
		}

		public void Listen()//UDP开始侦听来自外部的消息.
		{
			xx:
			System.Random i =new Random();
			int j= i.Next(2000,6000);
			try
			{
				this.sockUDP1.Listen (j);
			}
			catch(Exception e)
			{goto xx;}
		}

		private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port); 
		private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) 
		{ 
			try
			{
				sendFileInfo  msg=new  ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as sendFileInfo ;
				serverIp=Ip;
				this.serverPort=Port;
                
				switch(msg.MsgInfoClass)
				{
					case 0://对方已经取消了文件传输
						userCancelSendFile();//对方“取消了文件传输”
						break;
					case 1://对方发送“发送文件请求”过来，要求发送文件过去
						ReadySendFile();//准备发送文件给对方
						break;
					case 2://对方发送文件数据过来,保存数据到文件
						ReceivedFileBlock(msg);
						break;
					case 3://对方发送消息告诉已经收到上一次发送的文件数据块
						ReceivedFileMsg(msg.pSendPos);
						break;
				}
			}
			catch(Exception e)
			{}
		}

		private void ReceivedFileMsg(int CurrPos)//对方发送文件数据过来
		{
             this.pSendPos=CurrPos;
		}
		private void ReceivedFileBlock(sendFileInfo  msg)//当对方发送文件数据块过来
		{
            if(this.pSendPos!=msg.pSendPos)return;

			this.labelState.Text="正在接收文件...";

			this.progressBar1.Maximum=(int)msg.fileSize;
			this.progressBar1.Value=this.progressBar1.Value + msg.FileBlock.Length;
			this.labelProgress.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";//显示文件传输(接收)进度
//            this.xpProgressBar1.PositionMax=(int)msg.fileSize;
//			this.xpProgressBar1.Position=this.progressBar1.Value + msg.FileBlock.Length;
//            this.xpProgressBar1.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
          
			this.pSendPos=(msg.pSendPos + msg.FileBlock.Length);//记录文件发送方当前发送文件块的起点位置
           
			if(!IsSendState)//如果当前没有接收文件，则打开文件并保存数据块，如果当前文件是处于接收状态，则文件已经打开，不需要再执行打开操作
			  fStream =new System.IO.FileStream(FileName , FileMode.Create, FileAccess.Write, FileShare.Read);
		
			fStream.Write(msg.FileBlock,0,msg.FileBlock.Length );//将收到的文件块存于文件中
			fStream.Flush();

			IsSendState=true;//标识当前正在传输文件

			this.sendData(new sendFileInfo(3,0,this.progressBar1.Value,null));//发送消息通知文件发送方已经收到数据并保存，可以继续发送下一文件块数据

			if(this.progressBar1.Value>=this.FileSize)//如果文件传输已经完成
			{
				IsSendState=false;//文件传输状态设置为否，表示文件没有在传输中
				this.sendOver=true;//文件发送完成值设为真
				fStream.Close(); //关闭打开的文件
				this.sockUDP1.CloseSock();
				IsCancel=true;//取消为真
				fileSendEnd(this,false);//触发文件传输结束事件
			}
		}

		private void ReadySendFile()//准备发送文件给对方
		{
			System.IO.FileInfo f=new FileInfo(this.FileName);
			if(!f.Exists)return;
			this.FileSize=f.Length;
			System.Threading.Thread RThread = new System.Threading.Thread( new System.Threading.ThreadStart(sendFileData)); 
			RThread.Start(); //开始发送文件
		}

		private void sendFileData()//发送文件
		{
			try
			{
				this.labelState.Text="正在发送文件...";
				this.progressBar1.Maximum=Convert.ToInt32(this.FileSize) ;
//                this.xpProgressBar1.PositionMax=Convert.ToInt32(this.FileSize);
				byte[] buffer = new byte[buf];

                int i=0;//记录当前读取文件所获得的字节数
                int currSendPos=0;//设置当前发送的文件块的终点位置
				this.fStream  =new System.IO.FileStream(this.FileName , FileMode.Open, FileAccess.Read, FileShare.Read);//打开文件，准备发送数据
			
				this.IsSendState=true;//设置文件发送状态为真，表示文件正在发送中

				while(currSendPos<this.FileSize && !userCancelSend)//当前已发送文件的终点位置小于文件尺寸并且对方没有取消文件传输时执行发送文件下一区块数据 
				{
					if(currSendPos==this.pSendPos)//当对方收到的文件块终点位置等于前一次发送的文件块终点位置时才发送一下区块数据，确保文件发送的完整性
					{
						if((currSendPos+this.buf)>this.FileSize)//如果上次发送的数据位置加上缓冲区最大数BUF大于文件尺寸，则只发送最后一部分数据
						{
							buffer = new byte[Convert.ToInt32(this.FileSize-currSendPos)];
						}

						i=fStream.Read(buffer,0,buffer.Length);//将要发送的文件块数据存入发送缓冲区

						if(i!=0)//如果缓冲区中的数据不为空，则将数据发送给对方
						{
							this.sendData(new sendFileInfo(2,this.FileSize,currSendPos,buffer));//发送已读取的文件数据给对方
							currSendPos +=i;//上一次发送终点位置更改为这一次发送的终点位置
							this.progressBar1.Value= currSendPos;//更新进度条进度显示
							this.labelProgress.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
//							this.xpProgressBar1.Position =currSendPos;
//							this.xpProgressBar1.Text ="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
						    
						}
					}
				}

				//程序执行到这里表示文件已经结束或是对方取消了文件传输
				fStream.Close(); //关闭打开的文件
                this.sockUDP1.CloseSock();//关闭通信端口
                IsSendState=false;//文件传输状态设置为否，表示文件没有在传输中
				IsCancel=true;//取消为真

				if(!userCancelSend)//如果对方没有取消文件传输而文件是正常传输结束，则标识
				{
					this.sendOver=true;
					fileSendEnd(this,true) ;//触发文件正常传输结束事件 
				}
			}
			catch(Exception e)
			{	
				//MessageBox.Show(e.Message );
			}
		}

		private void userCancelSendFile()//当对方“取消了文件传输”
		{
			IsCancel=true;//取消为真
            fileSendCancel(this,false);//触发“文件取消发送事件”(对方取消的)
		}












		private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
		{
			DataArrivaldelegate outdelegate = new DataArrivaldelegate( DataArrival); 
			this.BeginInvoke (outdelegate, new object[]{ Data,Ip,Port}); 
		}


		private void sendData(sendFileInfo fInfo)
		{
			this.sockUDP1.Send(serverIp,this.serverPort,new  ClassSerializers().SerializeBinary(fInfo).ToArray());
		}

		public void SendData(System.Net.IPAddress Ip,int Port,byte[] MsgContent)
		{
           this.sockUDP1.Send (Ip,Port,MsgContent);
		}

		private void timer1_Tick(object sender, System.EventArgs e)//保持UDP端口在外网上的映射
		{
		    this.sockUDP1.Send(this.serverIp ,this.serverPort,new  ClassSerializers().SerializeBinary(new sendFileInfo(100,0,0,null)).ToArray());
		}
	}
}
