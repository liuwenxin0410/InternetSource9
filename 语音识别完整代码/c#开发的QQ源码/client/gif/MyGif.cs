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
	/// MyGif 的摘要说明。
	/// </summary>
	public class MyGif : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyGif()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			intImages();
           
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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
        private bool IsPlay=false;
		private pic[] pics;

		private class pic
		{
			public System.Drawing.Image image;
			public int Delay=100;
			public  pic()
			{
			}
		}

		private string fileName=@"C:\Documents and Settings\admin\桌面\page_cr14.gif";
		public string FileName
		{
			set{
				fileName=value;
				IsPlay=false;
				intImages();
			}
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

			int i=0;
			while(IsPlay)
			{  
				if(i==FrameCount )i=0;
				this.BackgroundImage   =this.pics[i].image ;  // frame i
			    this.Refresh();
				System.Threading.Thread.Sleep(this.pics[i].Delay );
				i++;
			}
			
		}

		private void intImages()
		{
			if(fileName=="")return;
			if(new System.IO.FileInfo(fileName).Exists)
			{
				System.Drawing.Image image=System.Drawing.Image.FromFile(fileName);
				this.Size=image.Size ;
				image.Dispose();
				GifDecoder gifDecoder = new GifDecoder();
				gifDecoder.Read(fileName);
				FrameCount= gifDecoder.GetFrameCount(); 
				pics= new pic[FrameCount];
				for(int i=0;  i < FrameCount;i++)
				{
					pics[i].image = gifDecoder.GetFrame(i);  // frame i
					pics[i].Delay = gifDecoder.GetDelay(i);  // frame i
				}
			}
			IsPlay=true;
		    play();//播放GIF
		}


	}
}
