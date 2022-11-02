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
	/// filesSend ��ժҪ˵����
	/// </summary>
	public class P2pSendImage : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components;
		private LanMsg.Controls.SockUDP sockUDP1;
		private System.Windows.Forms.Timer timer1;

		[Serializable]
			private class sendFileInfo
		{
			public int MsgInfoClass=0;//�ļ�������Ϣ���
			public long fileSize=0;//�ļ��ߴ�
			public int pSendPos=0;//����ϴη��͵�λ��
			public byte[] FileBlock=null;//��ǰ���͵��ļ���

			public sendFileInfo( )
			{
				//
				// TODO: �ڴ˴���ӹ��캯���߼�
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

		public P2pSendImage()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try
			{
				this.fStream.Close();//�رմ򿪵��ļ���Դ
			}
			catch(Exception e){}
			try
			{
				if((this.IsSendState && !this.sendOver) || !IsCancel)//����ļ����ڴ�������û�гɹ��㱻�û��رճ�����ǿ����ֹ������Է�����"ȡ���ļ�����"
					this.sendData(new sendFileInfo(0,0,0,null));
			}
			catch(Exception e){}
			try
			{
				this.sockUDP1.CloseSock();//�ر�sockUDP1�˿ڣ����ռ�õ���Դ 
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


		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.sockUDP1 = new LanMsg.Controls.SockUDP(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(24, 24);
			this.panel1.TabIndex = 0;
			// 
			// sockUDP1
			// 
			this.sockUDP1.Server = null;
			this.sockUDP1.DataArrival += new LanMsg.Controls.SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// P2pSendImage
			// 
			this.BackColor = System.Drawing.Color.Cyan;
			this.Controls.Add(this.panel1);
			this.Name = "P2pSendImage";
			this.Size = new System.Drawing.Size(24, 24);
			this.ResumeLayout(false);

		}
		#endregion

		#region  �ļ������¼�
	
		public delegate void fileSendEndEventHandler(object sender,bool isSelf);//�ļ���������¼�
		public  event fileSendEndEventHandler fileSendEnd; 

		public delegate void fileSendCancelEventHandler(object sender,bool isSelf);//ȡ���ļ������¼�
		public  event fileSendCancelEventHandler fileSendCancel; 
	    
		#endregion


		public string FileName=Application.StartupPath + @"\ReceiveFiles\";//���ͻ�����ļ��������λ��
		
		private System.Net.IPAddress serverIp=System.Net.IPAddress.Parse("127.0.0.1");//�Է�ip��ַ 

		private int serverPort=0;//�Է�Ip�˿�

		private long FileSize=0;//�ļ��ߴ�
	
		private string Extension="";//�ļ���չ��

		private bool IsSendState=false;//����ļ��Ƿ��ڷ��͹�����

		private int  pSendPos=0;//����ϴη��͵�λ��

		private int buf=8000;//���һ�δ����ļ����ݿ�Ĵ�С

		private System.IO.FileStream fStream ;//�ļ�������

		private bool userCancelSend=false;//��¼�Է��Ƿ�ȡ���ļ�����

		private bool sendOver=false;//����ļ��Ƿ������
       
		private bool IsSend=false;//��ʶ��ǰ�û��Ƿ����ļ����ǽ����ļ�

		private bool IsCancel=false;//��ʶ�ļ������ǵ����ȡ������ȡ����

		private int  OutTime=0;//�������ݿ鳬ʱ������

		public void SetParameter(bool isSend,string LabFileName,string fileName,long fileSize,System.Net.IPAddress ServerIP,int ServerPort,string fileExtension)
		{
			//�ļ�����ǰ����˫�����ӵĲ������ú���
			this.IsSend=isSend;
			this.FileSize=fileSize;
			this.serverIp=ServerIP;
			this.serverPort=ServerPort;
			this.Extension =fileExtension;
			this.labFileName.Text =LabFileName;//�ļ�����
			this.Listen();
			this.timer1.Enabled=true;//����UDP�˿��������ϵ�ӳ��
			this.labelProgress.Text="(0/"+ this.FileSize.ToString() +")";
			if(IsSend)
			{
				this.FileName=fileName;//�ļ��ľ���·��
				this.linkReceive.Visible=false;
				this.linkSaveAs.Visible=false;
				this.labOr.Visible=false;
				this.labelState.Text="�ȴ��Է������ļ�...";
			}
			else
			{
				this.labelState.Text="�Է����ȴ��������ļ�...";
				this.sockUDP1.Send(this.serverIp,this.serverPort,new Controls.ClassSerializers().SerializeBinary(new sendFileInfo(100,0,0,null)).ToArray());
			}
		}

		public string GetSizeStr(long fileSize)//��ô����ļ��ĳߴ��ַ���
		{
			if(Convert.ToInt32(fileSize/1024)==0)
				return fileSize.ToString() +"�ֽ�";
			if(Convert.ToInt32(fileSize/1024)>0 && Convert.ToInt32(fileSize/(1024*1024))==0)
				return Convert.ToInt32(fileSize/1024).ToString() +"KB";
			if(Convert.ToInt32(fileSize/(1024*1024))>0 && Convert.ToInt32(fileSize/(1024*1024*1024))==0)    
				return Convert.ToInt32(fileSize/(1024*1024)).ToString() +"MB";
			if(Convert.ToInt32(fileSize/(1024*1024*1024))>0)    
				return Convert.ToInt32(fileSize/(1024*1024*1024)).ToString() +"GB";

			return "δ֪��С";
		}

		private void linkLabelCancel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if(MessageBox.Show("ȷ��Ҫ��ֹ�ļ��Ĵ�����","��ʾ",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes )
			{
				if(!this.IsSendState)//�����ǰ��û�п�ʼ���䣬��Ҫ����Ϣ���Է������߶Է��Ѿ�ȡ���ļ�����
					IsCancel=true;//ȡ��Ϊ��
				this.sendData(new sendFileInfo(0,0,0,null));//���Է����͡�ȡ���ļ����䡱��Ϣ
				fileSendCancel(this,true);//�������ļ�ȡ�������¼���(�Լ�ȡ����)
			}
		}

		private void linkSaveAs_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Windows.Forms.SaveFileDialog fd=new SaveFileDialog ();
			fd.Filter="�ĵ�(*"+ this.Extension +")|*"+ this.Extension;
			fd.FileName=this.labFileName.Text;
			if(fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
				this.linkSaveAs.Visible=false;
				this.labOr.Visible=false;
				this.Refresh();

				this.FileName=fd.FileName;
				this.sendData (new sendFileInfo(1,0,0,null));//���û����������ļ�ʱ��������Ϣ���Է���Ҫ��Է���ʼ�����ļ����ݿ�
			}
		}

		private void linkReceive_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			this.sendData (new sendFileInfo(1,0,0,null));//���û����������ļ�ʱ��������Ϣ���Է���Ҫ��Է���ʼ�����ļ����ݿ�
		}

		public void Listen()//UDP��ʼ���������ⲿ����Ϣ.
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
				sendFileInfo  msg=new LanMsg.Controls.ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as sendFileInfo ;
				serverIp=Ip;
				this.serverPort=Port;
                
				switch(msg.MsgInfoClass)
				{
					case 0://�Է��Ѿ�ȡ�����ļ�����
						userCancelSendFile();//�Է���ȡ�����ļ����䡱
						break;
					case 1://�Է����͡������ļ����󡱹�����Ҫ�����ļ���ȥ
						ReadySendFile();//׼�������ļ����Է�
						break;
					case 2://�Է������ļ����ݹ���,�������ݵ��ļ�
						ReceivedFileBlock(msg);
						break;
					case 3://�Է�������Ϣ�����Ѿ��յ���һ�η��͵��ļ����ݿ�
						ReceivedFileMsg(msg.pSendPos);
						break;
				}
			}
			catch(Exception e)
			{}
		}

		private void ReceivedFileMsg(int CurrPos)//�Է������ļ����ݹ���
		{
			this.pSendPos=CurrPos;
		}
		private void ReceivedFileBlock(sendFileInfo  msg)//���Է������ļ����ݿ����
		{
			if(this.pSendPos!=msg.pSendPos)return;

			this.labelState.Text="���ڽ����ļ�...";

			this.progressBar1.Maximum=(int)msg.fileSize;
			this.progressBar1.Value=this.progressBar1.Value + msg.FileBlock.Length;
			this.labelProgress.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";//��ʾ�ļ�����(����)����
			//            this.xpProgressBar1.PositionMax=(int)msg.fileSize;
			//			this.xpProgressBar1.Position=this.progressBar1.Value + msg.FileBlock.Length;
			//            this.xpProgressBar1.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
          
			this.pSendPos=(msg.pSendPos + msg.FileBlock.Length);//��¼�ļ����ͷ���ǰ�����ļ�������λ��
           
			if(!IsSendState)//�����ǰû�н����ļ�������ļ����������ݿ飬�����ǰ�ļ��Ǵ��ڽ���״̬�����ļ��Ѿ��򿪣�����Ҫ��ִ�д򿪲���
				fStream =new System.IO.FileStream(FileName , FileMode.Create, FileAccess.Write, FileShare.Read);
		
			fStream.Write(msg.FileBlock,0,msg.FileBlock.Length );//���յ����ļ�������ļ���
			fStream.Flush();

			IsSendState=true;//��ʶ��ǰ���ڴ����ļ�

			this.sendData(new sendFileInfo(3,0,this.progressBar1.Value,null));//������Ϣ֪ͨ�ļ����ͷ��Ѿ��յ����ݲ����棬���Լ���������һ�ļ�������

			if(this.progressBar1.Value>=this.FileSize)//����ļ������Ѿ����
			{
				IsSendState=false;//�ļ�����״̬����Ϊ�񣬱�ʾ�ļ�û���ڴ�����
				this.sendOver=true;//�ļ��������ֵ��Ϊ��
				fStream.Close(); //�رմ򿪵��ļ�
				this.sockUDP1.CloseSock();
				IsCancel=true;//ȡ��Ϊ��
				fileSendEnd(this,false);//�����ļ���������¼�
			}
		}

		private void ReadySendFile()//׼�������ļ����Է�
		{
			System.IO.FileInfo f=new FileInfo(this.FileName);
			if(!f.Exists)return;
			this.FileSize=f.Length;
			System.Threading.Thread RThread = new System.Threading.Thread( new System.Threading.ThreadStart(sendFileData)); 
			RThread.Start(); //��ʼ�����ļ�
		}

		private void sendFileData()//�����ļ�
		{
			try
			{
				this.labelState.Text="���ڷ����ļ�...";
				this.progressBar1.Maximum=Convert.ToInt32(this.FileSize) ;
				//                this.xpProgressBar1.PositionMax=Convert.ToInt32(this.FileSize);
				byte[] buffer = new byte[buf];

				int i=0;//��¼��ǰ��ȡ�ļ�����õ��ֽ���
				int currSendPos=0;//���õ�ǰ���͵��ļ�����յ�λ��
				this.fStream  =new System.IO.FileStream(this.FileName , FileMode.Open, FileAccess.Read, FileShare.Read);//���ļ���׼����������
			
				this.IsSendState=true;//�����ļ�����״̬Ϊ�棬��ʾ�ļ����ڷ�����

				while(currSendPos<this.FileSize && !userCancelSend)//��ǰ�ѷ����ļ����յ�λ��С���ļ��ߴ粢�ҶԷ�û��ȡ���ļ�����ʱִ�з����ļ���һ�������� 
				{
					if(currSendPos==this.pSendPos)//���Է��յ����ļ����յ�λ�õ���ǰһ�η��͵��ļ����յ�λ��ʱ�ŷ���һ���������ݣ�ȷ���ļ����͵�������
					{
						if((currSendPos+this.buf)>this.FileSize)//����ϴη��͵�����λ�ü��ϻ����������BUF�����ļ��ߴ磬��ֻ�������һ��������
						{
							buffer = new byte[Convert.ToInt32(this.FileSize-currSendPos)];
						}

						i=fStream.Read(buffer,0,buffer.Length);//��Ҫ���͵��ļ������ݴ��뷢�ͻ�����

						if(i!=0)//����������е����ݲ�Ϊ�գ������ݷ��͸��Է�
						{
							this.sendData(new sendFileInfo(2,this.FileSize,currSendPos,buffer));//�����Ѷ�ȡ���ļ����ݸ��Է�
							currSendPos +=i;//��һ�η����յ�λ�ø���Ϊ��һ�η��͵��յ�λ��
							this.progressBar1.Value= currSendPos;//���½�����������ʾ
							this.labelProgress.Text="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
							//							this.xpProgressBar1.Position =currSendPos;
							//							this.xpProgressBar1.Text ="("+ this.progressBar1.Value.ToString()+"/"+ this.progressBar1.Maximum.ToString()+")";
						    
						}
					}
				}

				//����ִ�е������ʾ�ļ��Ѿ��������ǶԷ�ȡ�����ļ�����
				fStream.Close(); //�رմ򿪵��ļ�
				this.sockUDP1.CloseSock();//�ر�ͨ�Ŷ˿�
				IsSendState=false;//�ļ�����״̬����Ϊ�񣬱�ʾ�ļ�û���ڴ�����
				IsCancel=true;//ȡ��Ϊ��

				if(!userCancelSend)//����Է�û��ȡ���ļ�������ļ�������������������ʶ
				{
					this.sendOver=true;
					fileSendEnd(this,true) ;//�����ļ�������������¼� 
				}
			}
			catch(Exception e)
			{	
				//MessageBox.Show(e.Message );
			}
		}

		private void userCancelSendFile()//���Է���ȡ�����ļ����䡱
		{
			IsCancel=true;//ȡ��Ϊ��
			fileSendCancel(this,false);//�������ļ�ȡ�������¼���(�Է�ȡ����)
		}






		private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
		{
			DataArrivaldelegate outdelegate = new DataArrivaldelegate( DataArrival); 
			this.BeginInvoke (outdelegate, new object[]{ Data,Ip,Port}); 
		}


		private void sendData(sendFileInfo fInfo)
		{
			this.sockUDP1.Send(serverIp,this.serverPort,new Controls.ClassSerializers().SerializeBinary(fInfo).ToArray());
		}

		public void SendData(System.Net.IPAddress Ip,int Port,byte[] MsgContent)
		{
			this.sockUDP1.Send (Ip,Port,MsgContent);
		}

		private void timer1_Tick(object sender, System.EventArgs e)//����UDP�˿��������ϵ�ӳ��
		{
			this.sockUDP1.Send(this.serverIp ,this.serverPort,new Controls.ClassSerializers().SerializeBinary(new sendFileInfo(100,0,0,null)).ToArray());
		}
	}
}
