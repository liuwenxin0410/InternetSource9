using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using LanMsg.Gif.Components;

namespace LanMsg.gif
{
	/// <summary>
	/// gif 的摘要说明。
	/// </summary>
	public class gif : System.Windows.Forms.PictureBox
	{
		private System.ComponentModel.IContainer components;

		public gif()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			this.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			play();//播放GIF
			// TODO: 在 InitializeComponent 调用后添加任何初始化

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

		private string fileName=@"C:\Documents and Settings\admin\桌面\page_cr14.gif";
		public string FileName
		{
			set{fileName=value;}
			get{return fileName;}
		}

		private int FrameCount=0;

		public void play()//播放GIF
		{
			System.Threading.Thread RThread = new System.Threading.Thread( new System.Threading.ThreadStart(player)); 
			RThread.Start(); //开始发送文件
		}

		private void player()
		{
			if(fileName=="")return;
			GifDecoder gifDecoder = new GifDecoder();
			gifDecoder.Read(fileName);
			//gifDecoder.Read(fileName);
		    this.Refresh();
			FrameCount = gifDecoder.GetFrameCount();

			int i=0;
			while(fileName!="")
			{  
 				if(i==this.FrameCount)i=0;
				this.Image  = gifDecoder.GetFrame(i);  // frame i
//				this.Refresh();
				System.Threading.Thread.Sleep(gifDecoder.GetDelay(i));
				i++;
			}
			
		}

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// gif
			// 
			this.Size = new System.Drawing.Size(104, 88);

		}
		#endregion
	}
}
