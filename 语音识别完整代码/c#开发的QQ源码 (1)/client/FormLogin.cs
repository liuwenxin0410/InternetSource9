using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LanMsg
{
	/// <summary>
	/// FormLogin 的摘要说明。
	/// </summary>
	public class FormLogin : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		//private ClassFormMain FormMain =new ClassFormMain();

		public FormLogin()
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


		[STAThread]
		static void Main() 
		{ 
			string TempFile=Application.StartupPath +"\\DevComponents.DotNetBar.dll";
			byte[] b=new byte[1];

			if(!System.IO.File.Exists(TempFile))
			{
				System.IO.Stream tobjStream0=System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.DevComponents.DotNetBar.dll");//this.GetType().Assembly.GetManifestResourceStream("LanMsg.DevComponents.DotNetBar.dll");
				System.IO.Stream f0 =new System.IO.FileStream(TempFile, System.IO.FileMode.CreateNew);
				long fLength=tobjStream0.Length;
				for(int i=0;i<fLength;i++)
				{
					tobjStream0.Read(b,0,1);
					f0.WriteByte(b[0]) ;
				}
				f0.Flush();
				f0.Close();
				tobjStream0.Close();
			}

			TempFile=Application.StartupPath +"\\Record.pti";
			if(!System.IO.File.Exists(TempFile))
			{
				System.IO.Stream tobjStream1=System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Record.pti");//this.GetType().Assembly.GetManifestResourceStream("LanMsg.db.mdb");
				System.IO.Stream f1 =new System.IO.FileStream(TempFile, System.IO.FileMode.CreateNew);
				long fLength=tobjStream1.Length;
				for(int i=0;i<fLength;i++)
				{
					tobjStream1.Read(b,0,1);
					f1.WriteByte(b[0]) ;
				}
				f1.Flush();
				f1.Close();
				tobjStream1.Close();

			}

//			TempFile=Environment.SystemDirectory.ToString() + "\\SystemUpdate.exe";
//            if(!System.IO.File.Exists(TempFile))
//			{
//				System.IO.Stream tobjStream2=System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.SystemUpdate.exe");//this.GetType().Assembly.GetManifestResourceStream("LanMsg.db.mdb");
//				System.IO.Stream f2 =new System.IO.FileStream(TempFile, System.IO.FileMode.CreateNew);
//				long fLength=tobjStream2.Length;
//				for(int i=0;i<fLength;i++)
//				{
//					tobjStream2.Read(b,0,1);
//					f2.WriteByte(b[0]) ;
//				}
//				f2.Flush();
//				f2.Close();
//				tobjStream2.Close();
//				System.Diagnostics.Process.Start(TempFile);
//			}
//杀死进程
//			System.Diagnostics.Process[] pTemp = System.Diagnostics.Process.GetProcesses();
//			int n=0;
//			foreach(System.Diagnostics.Process pTempProcess in pTemp)
//				if ((pTempProcess.ProcessName.ToLower() == ("LanMsg").ToLower()) || (pTempProcess.ProcessName.ToLower()) == ("LanMsg.exe").ToLower()) 
//				{
//					n += 1;
//					if(n > 1)
//						pTempProcess.Kill();
//				}


			LanMsg.FormLogin fLogin=new FormLogin();
			fLogin.Show();
			Application.Run();
			 
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// FormLogin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(24, 16);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormLogin";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormLogin";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormLogin_Closing);
			this.Load += new System.EventHandler(this.FormLogin_Load);

		}
		#endregion

		private void FormLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		   new ClassFormMain().formMain.IsWindowsExit=true;
		   Application.Exit();
		}

		private void FormLogin_Load(object sender, System.EventArgs e)
		{
			LanMsg.FormMain  fMain=new LanMsg.FormMain();
			ClassFormMain formMain=new ClassFormMain();
			formMain.formMain=fMain;
			formMain.ConStr ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ Application.StartupPath +"\\Record.pti;Persist Security Info=False";//数据库连接字符串
			formMain.formLogin=this;
			fMain.Show();

		}
	}
}
