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
	/// gif ��ժҪ˵����
	/// </summary>
	public class gif : System.Windows.Forms.PictureBox
	{
		private System.ComponentModel.IContainer components;

		public gif()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
			this.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			play();//����GIF
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

		private string fileName=@"C:\Documents and Settings\admin\����\page_cr14.gif";
		public string FileName
		{
			set{fileName=value;}
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

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
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
