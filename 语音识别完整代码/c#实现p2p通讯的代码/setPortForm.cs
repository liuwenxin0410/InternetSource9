using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PtoP
{
	/// <summary>
	/// setPortForm 的摘要说明。
	/// </summary>
	public class setPortForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.TextBox portnum;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public setPortForm()
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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(setPortForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ok = new System.Windows.Forms.Button();
			this.portnum = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ok);
			this.groupBox1.Controls.Add(this.portnum);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "端口号";
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(48, 80);
			this.ok.Name = "ok";
			this.ok.TabIndex = 1;
			this.ok.Text = "确认配置";
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// portnum
			// 
			this.portnum.Location = new System.Drawing.Point(32, 40);
			this.portnum.Name = "portnum";
			this.portnum.TabIndex = 0;
			this.portnum.Text = "";
			this.portnum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portnum_KeyDown);
			// 
			// setPortForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(192, 158);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "setPortForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "配置本机端口";
			this.Load += new System.EventHandler(this.setPortForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
		 //配置本地计算机端口
			if(this.portnum.Text.Length==0){
			string str="请输入端口号";
			string cmd="错误";
			MessageBox.Show(str,cmd);
			}
			else{
				try
				{
					Form1.port=System.Convert.ToInt32(this.portnum.Text,10);
					Form1.tcp1=new TcpListener(Form1.port);
				}
				catch
				{
					string str="请输入正确的端口号";
					string cmd="错误";
					MessageBox.Show(str,cmd);
					return;
				}
				// 初始化成功关闭窗口
				this.Close();
			}
		}

		private void setPortForm_Load(object sender, System.EventArgs e)
		{
		
		}

		private void portnum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			 ok_Click(this,e);
			}
		}
	}
}
