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
	/// MyGif ��ժҪ˵����
	/// </summary>
	public class MyGif : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyGif()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
			intImages();
           
			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��

		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
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

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
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

		private string fileName=@"C:\Documents and Settings\admin\����\page_cr14.gif";
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

		public void play()//����GIF
		{
			System.Threading.Thread RThread = new System.Threading.Thread( new System.Threading.ThreadStart(player)); 
			RThread.Start(); //��ʼ�����ļ�
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
		    play();//����GIF
		}


	}
}
