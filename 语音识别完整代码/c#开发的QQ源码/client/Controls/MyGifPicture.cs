using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LanMsg 
{
	/// <summary> 
	/// MyPicture 的摘要说明。
	/// </summary>
	public class MyPicture : System.Windows.Forms.PictureBox
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyPicture()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
//            this.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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

		private string filename="";//GIF图片文件的绝对路径
		public string FileName
		{
			set{filename=value;}
			get{return filename;}
		}

		public bool IsSent=false;//标识此图片是否需要发送到对方,默认不发送

		public void playGif()
		{
			System.Drawing.ImageAnimator.Animate(this.Image,new System.EventHandler(this.OnFrameChanged));
		}
 
		private void OnFrameChanged(object sender, EventArgs e) 
		{

			//Force a call to the Paint event handler.
			 this.Invalidate();
			//this.Refresh();
		}

	}
}
