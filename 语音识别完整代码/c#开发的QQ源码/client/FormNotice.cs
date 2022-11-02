using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LanMsg
{
	/// <summary>
	/// FormNotice 的摘要说明。
	/// </summary>
	public class FormNotice: DevComponents.DotNetBar.Office2007RibbonForm 
	{
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private DevComponents.DotNetBar.Bar bar1;
		private DevComponents.DotNetBar.RibbonControl ribbonControl1;
		private DevComponents.DotNetBar.ButtonItem buttonItem1;
		public LanMsg.MyExtRichTextBox RTBNoticeContent;
		private DevComponents.DotNetBar.LabelItem labelItem1;
		private System.ComponentModel.IContainer components;
		private DevComponents.DotNetBar.ButtonItem buttonItemRecord;
		private DevComponents.DotNetBar.ButtonItem buttonItem2;
		private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
		private DevComponents.DotNetBar.DockSite barLeftDockSite;
		private DevComponents.DotNetBar.DockSite barRightDockSite;
		private DevComponents.DotNetBar.DockSite barTopDockSite;
		private DevComponents.DotNetBar.DockSite barBottomDockSite;

		private ClassFormMain formMain=new ClassFormMain();

		public FormNotice()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormNotice));
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bar1 = new DevComponents.DotNetBar.Bar();
			this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
			this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItemRecord = new DevComponents.DotNetBar.ButtonItem();
			this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
			this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
			this.RTBNoticeContent = new LanMsg.MyExtRichTextBox();
			this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
			this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
			this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
			this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
			this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
			((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(10, 315);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(480, 8);
			this.panel4.TabIndex = 58;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(480, 8);
			this.panel3.TabIndex = 57;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(490, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(8, 299);
			this.panel2.TabIndex = 56;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(2, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(8, 299);
			this.panel1.TabIndex = 55;
			// 
			// bar1
			// 
			this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
			this.bar1.AccessibleName = "DotNetBar Bar";
			this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
			this.bar1.AntiAlias = true;
			this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
			this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																				this.labelItem1,
																				this.buttonItem2,
																				this.buttonItemRecord});
			this.bar1.ItemSpacing = 2;
			this.bar1.Location = new System.Drawing.Point(2, 323);
			this.bar1.Name = "bar1";
			this.bar1.Size = new System.Drawing.Size(496, 25);
			this.bar1.Stretch = true;
			this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar1.TabIndex = 54;
			this.bar1.TabStop = false;
			this.bar1.Text = "barStatus";
			this.bar1.Click += new System.EventHandler(this.bar1_Click);
			// 
			// labelItem1
			// 
			this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.None;
			this.labelItem1.Name = "labelItem1";
			// 
			// buttonItem2
			// 
			this.buttonItem2.Icon = ((System.Drawing.Icon)(resources.GetObject("buttonItem2.Icon")));
			this.buttonItem2.Name = "buttonItem2";
			// 
			// buttonItemRecord
			// 
			this.buttonItemRecord.Name = "buttonItemRecord";
			this.buttonItemRecord.Text = "查看历史记录";
			this.buttonItemRecord.Click += new System.EventHandler(this.buttonItemRecord_Click);
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.BackColor = System.Drawing.SystemColors.Control;
			this.ribbonControl1.CaptionVisible = true;
			this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ribbonControl1.DockPadding.Bottom = 2;
			this.ribbonControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ribbonControl1.Location = new System.Drawing.Point(2, 2);
			this.ribbonControl1.MdiSystemItemVisible = false;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																									  this.buttonItem1});
			this.ribbonControl1.RibbonStripIndent = 55;
			this.ribbonControl1.Size = new System.Drawing.Size(496, 22);
			this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.ribbonControl1.TabGroupHeight = 15;
			this.ribbonControl1.TabIndex = 53;
			// 
			// buttonItem1
			// 
			this.buttonItem1.Icon = ((System.Drawing.Icon)(resources.GetObject("buttonItem1.Icon")));
			this.buttonItem1.Name = "buttonItem1";
			// 
			// RTBNoticeContent
			// 
			this.RTBNoticeContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(201)), ((System.Byte)(235)));
			this.dotNetBarManager1.SetContextMenuEx(this.RTBNoticeContent, "ButtonItem1");
			this.RTBNoticeContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTBNoticeContent.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.RTBNoticeContent.HiglightColor = LanMsg.RtfColor.White;
			this.RTBNoticeContent.Location = new System.Drawing.Point(10, 32);
			this.RTBNoticeContent.MaxLength = 1000;
			this.RTBNoticeContent.Name = "RTBNoticeContent";
			this.RTBNoticeContent.ReadOnly = true;
			this.RTBNoticeContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.RTBNoticeContent.Size = new System.Drawing.Size(480, 283);
			this.RTBNoticeContent.TabIndex = 59;
			this.RTBNoticeContent.Text = "";
			this.RTBNoticeContent.TextColor = LanMsg.RtfColor.Black;
			this.RTBNoticeContent.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RTBNoticeContent_LinkClicked);
			// 
			// dotNetBarManager1
			// 
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
			this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
			this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
			this.dotNetBarManager1.DefinitionName = "FormNotice.dotNetBarManager1.xml";
			this.dotNetBarManager1.EnableFullSizeDock = false;
			this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
			this.dotNetBarManager1.ParentForm = this;
			this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
			this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
			this.dotNetBarManager1.ThemeAware = false;
			this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
			this.dotNetBarManager1.ItemClick += new System.EventHandler(this.dotNetBarManager1_ItemClick);
			// 
			// barBottomDockSite
			// 
			this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barBottomDockSite.Location = new System.Drawing.Point(2, 348);
			this.barBottomDockSite.Name = "barBottomDockSite";
			this.barBottomDockSite.NeedsLayout = false;
			this.barBottomDockSite.Size = new System.Drawing.Size(496, 0);
			this.barBottomDockSite.TabIndex = 63;
			this.barBottomDockSite.TabStop = false;
			// 
			// barLeftDockSite
			// 
			this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
			this.barLeftDockSite.Location = new System.Drawing.Point(2, 2);
			this.barLeftDockSite.Name = "barLeftDockSite";
			this.barLeftDockSite.NeedsLayout = false;
			this.barLeftDockSite.Size = new System.Drawing.Size(0, 346);
			this.barLeftDockSite.TabIndex = 60;
			this.barLeftDockSite.TabStop = false;
			// 
			// barRightDockSite
			// 
			this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
			this.barRightDockSite.Location = new System.Drawing.Point(498, 2);
			this.barRightDockSite.Name = "barRightDockSite";
			this.barRightDockSite.NeedsLayout = false;
			this.barRightDockSite.Size = new System.Drawing.Size(0, 346);
			this.barRightDockSite.TabIndex = 61;
			this.barRightDockSite.TabStop = false;
			// 
			// barTopDockSite
			// 
			this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
			this.barTopDockSite.Location = new System.Drawing.Point(2, 2);
			this.barTopDockSite.Name = "barTopDockSite";
			this.barTopDockSite.NeedsLayout = false;
			this.barTopDockSite.Size = new System.Drawing.Size(496, 0);
			this.barTopDockSite.TabIndex = 62;
			this.barTopDockSite.TabStop = false;
			// 
			// FormNotice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(500, 350);
			this.Controls.Add(this.RTBNoticeContent);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.bar1);
			this.Controls.Add(this.ribbonControl1);
			this.Controls.Add(this.barLeftDockSite);
			this.Controls.Add(this.barRightDockSite);
			this.Controls.Add(this.barTopDockSite);
			this.Controls.Add(this.barBottomDockSite);
			this.DockPadding.Bottom = 2;
			this.DockPadding.Left = 2;
			this.DockPadding.Right = 2;
			this.DockPadding.Top = 2;
			this.MinimumSize = new System.Drawing.Size(500, 350);
			this.Name = "FormNotice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "通知-消息";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RTBNoticeContent_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(e.LinkText);
			}
			catch 
			{
				MessageBox.Show("无法打开链接。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

		}

		private void bar1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void buttonItemRecord_Click(object sender, System.EventArgs e)
		{
		   this.formMain.formMain.OpenMsgMis("Notice");
		}

		private void dotNetBarManager1_ItemClick(object sender, System.EventArgs e)
		{
			switch((sender as DevComponents.DotNetBar.ButtonItem ).Name )
			{
				case "复制"	:
					if(this.RTBNoticeContent.Focus())
						this.RTBNoticeContent.Copy (); 
					break;
				case "全选"	:
					if(this.RTBNoticeContent.Focus())
						this.RTBNoticeContent.SelectAll (); 
					break;
			}
		}
	}
}
