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
	/// Form1 ��ժҪ˵����
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
		//�û�����
		private bool isconnecting=false;
		private bool isconnected=false;
		private bool isclient=false;
		private const string infDisconn="######DISCONNECT######";
		//������Ϣ�߳�
		private Thread th ;
		//���������ź��߳�
		private Thread wait ;
		private setPortForm portform;
		static public TcpListener tcp1;
		static public int port;
		//�ͻ���
		private TcpClient tcpc  ;
		//��������
		private TcpClient tcps  ;
		//�ͻ���
		private NetworkStream nsc ;
		//��������
		private NetworkStream nss ;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.groupBox1.Text = "��Ϣ��ʾ";
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
			this.send.Text = "�� ��(Ctrl+Enter)";
			this.send.Click += new System.EventHandler(this.send_Click);
			// 
			// disconn
			// 
			this.disconn.Location = new System.Drawing.Point(400, 328);
			this.disconn.Name = "disconn";
			this.disconn.Size = new System.Drawing.Size(128, 23);
			this.disconn.TabIndex = 3;
			this.disconn.Text = " �� �� �� ��  ";
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
			this.label1.Text = "�� ��";
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
			this.label3.Text = "�˿�";
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
			this.conn.Text = "�� ��";
			this.conn.Click += new System.EventHandler(this.conn_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(400, 280);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = " �� �� �� Ļ ";
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
			this.Text = "��Ե�����";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		//��ʼ������
		private void Form1_Load(object sender, System.EventArgs e)
		{
		 //��������ʱ��ʼ�����ؼ�����˿�����
		 portform=new setPortForm();
		 portform.ShowDialog();
		 this.send.Enabled=false;
		 this.disconn.Enabled=false;
		 this.Text="P2P����(���ڵȴ�����..)";
		 //����tcplistner
		 tcp1.Start();
		 //�����ȴ������߳�
		 wait=new Thread(new ThreadStart(waitconn));
		 wait.Start();
		}
        //�ȴ����Ӻ���
		private void waitconn()
		{
		    //��ʼ�����������Ӷ˿�
			tcps=tcp1.AcceptTcpClient();
			nss=tcps.GetStream();
			//�������ӶԻ���
			string str="�û���������,����?";
			string cmd="��������";
			this.Text="P2P����(��"+this.uid.Text+"�Ự������)";
			DialogResult diares=MessageBox.Show(str,cmd,MessageBoxButtons.YesNo);
			//�����Ӧ2���м����
			string strresp;
			byte[] byteresp;
			if(diares==DialogResult.Yes)
			{
				strresp="#";
				byteresp=System.Text.Encoding.ASCII.GetBytes(strresp.ToCharArray());
				//������д����
				nss.Write(byteresp,0,byteresp.Length);
				//�ı���Ʊ���
				isconnecting=true;
				isconnected=true;
				isclient=false;
				//�ı䰴ť״̬
				this.conn.Enabled=false;
				this.disconn.Enabled=true;
				this.send.Enabled=true;
				//����������Ϣ�߳�
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
		//���Ӵ���ť
		private void conn_Click(object sender, System.EventArgs e)
		{
			//����TCP����
			if(this.uip.Text.Length==0||this.portnum.Text.Length==1)
			{
				string str="��������ȷ��IP��ַ�Ͷ˿ں�";
				string cmd="����";
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
				string str="��������Ч�Ķ˿ں�";
				string cmd="����";
				MessageBox.Show(str,cmd);
				return;
			}
			catch(SocketException)
			{
				string str="�Ҳ����Է�,������ȷ�϶Է����������";
				string cmd="����";
				MessageBox.Show(str,cmd);
				return;
			}
			//��ȡ������
			nsc=tcpc.GetStream();
			//���浽��ȡ���ݵ�����
			byte[] read=new byte[2];
			//��ȡ�ֽ���
			int bytes=nsc.Read(read,0,read.Length);
			//���ݶ������ֽ������ж϶Է��������ֻ�Ӧ,1��ʾ��������,2��ʾ�ܾ�
			if(bytes==1)
			{
			 string str="�Ѿ���������!";
			 string cmd="���";
			 MessageBox.Show(str,cmd);
			 isconnecting=true;
		     isconnected=true;
		     isclient=true;
			 this.conn.Enabled=false;
			 this.disconn.Enabled=true;
			 this.send.Enabled=true;
			 //����������Ϣ�߳�
			 th=new Thread(new ThreadStart(acceptmsg));
			 th.Start();
			}
		}

		//������Ϣ������
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

		//������Ϣ���ĺ���
		private void acceptmsg(TcpClient tcpc,NetworkStream ns)
		{
		  byte[] read=new byte[1024];
		  ns=tcpc.GetStream();
		  ns.Read(read,0,read.Length);
		  string strout=System.Text.Encoding.Unicode.GetString(read);
			if(string.Compare(strout,infDisconn)==0)
			{
			  string str="�û��Ѿ��Ͽ�������";
			  string cmd="�����ѶϿ�";
			  MessageBox.Show(str,cmd);
			  this.richTextBox1.AppendText(str+"\n");
			  this.Text="P2P����(�ȴ�����)";
			  ns.Close();
			  tcpc.Close();
			  disconnect();
			}else
			{
				this.Text="P2P����(�Ự������)";
				DateTime now=DateTime.Now;
				string strline=now.ToShortDateString()+"  "+now.ToLongTimeString();
				string strmsgline=strline+"  ";
				this.richTextBox1.AppendText(strmsgline);
				this.richTextBox1.AppendText(strout);
				this.richTextBox1.AppendText("\n");
			}
		 }
		//������Ϣ����
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
		//������Ϣ������
		private void sendmsg(NetworkStream ns)
		{
		 string msg=this.uid.Text+"˵:\n"+this.richTextBox2.Text;
		 this.richTextBox2.Text=null;
		 byte[] write=new byte[1024];
		 write=System.Text.Encoding.Unicode.GetBytes(msg.ToCharArray());
		 ns.Write(write,0,write.Length);
			if(string.Compare(msg,infDisconn)!=0)
			{
				DateTime now=DateTime.Now;
				string date=now.ToShortDateString()+" "+now.ToLongTimeString();
				string msgline=date+"  "+"��˵:\n";
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
		//�Ͽ����Ӵ�����
		private void disconnect()
		{
			this.conn.Enabled=true;
			this.disconn.Enabled=false;
			this.send.Enabled=false;
			isconnecting=false;
			//�����ȴ������߳�
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
		//���غ���
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
