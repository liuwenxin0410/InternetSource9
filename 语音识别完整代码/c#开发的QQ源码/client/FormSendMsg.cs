#region using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace LanMsg
{
	/// <summary>
	/// FormSendMsg 的摘要说明。
	/// </summary>

	public class FormSendMsg : DevComponents.DotNetBar.Office2007RibbonForm //System.Windows.Forms.Form  // 
	{
		#region 对像变量区

		private DevComponents.DotNetBar.RibbonControl ribbonControl1;
		private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup1;
		private DevComponents.DotNetBar.ItemContainer itemContainer9;
		private DevComponents.DotNetBar.ButtonItem buttonItem14;
		private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
		private DevComponents.DotNetBar.LabelItem labelStatus;
		internal DevComponents.DotNetBar.LabelItem labelPosition;
		private DevComponents.DotNetBar.Bar bar1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private DevComponents.DotNetBar.PanelEx panelEx2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private DevComponents.DotNetBar.ButtonX butClose;
		private DevComponents.DotNetBar.ButtonX butSend;
		private DevComponents.DotNetBar.ButtonX butRecordshow;
		private DevComponents.DotNetBar.Bar bar2;
		private System.Windows.Forms.Panel panel10;
		private DevComponents.DotNetBar.Bar bar3;
		private DevComponents.DotNetBar.ButtonItem buttonItem2;
		private System.Windows.Forms.Panel panelSendFile;
		private DevComponents.DotNetBar.ButtonItem trtFontSet;
		private DevComponents.DotNetBar.ButtonItem trtFaceSet;
		private DevComponents.DotNetBar.ButtonItem butFontColor;
		private DevComponents.DotNetBar.ButtonItem buttonItem4;
		private System.ComponentModel.IContainer components;
		private DevComponents.DotNetBar.ButtonItem butSendPicture;
		private DevComponents.DotNetBar.ButtonItem butEnterSend;
		private DevComponents.DotNetBar.ButtonItem butEnterCtrlSend;
		private System.Windows.Forms.Timer timerCheckSendIsSuccess;
		private ClassFormMain FormMain =new ClassFormMain();
		private ClassUserInfo currUserInfo=null;
		private DevComponents.DotNetBar.BalloonTip balloonTip1;
		private DevComponents.DotNetBar.ButtonItem butOpenShared;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Panel panel13;
		public LanMsg.MyExtRichTextBox RTBRecord;

		private DevComponents.DotNetBar.ButtonItem butSendFile;
		private DevComponents.DotNetBar.TabControl tabCsendFile;
		private System.Windows.Forms.Panel panel14;
		private DevComponents.DotNetBar.Bar bar4;
		private DevComponents.DotNetBar.LabelItem labelItem1;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.Panel panel17;
		private int OutTime=0;
		private System.Windows.Forms.Panel panelSend;
		private DevComponents.DotNetBar.PanelEx panelButSend;
		private DevComponents.DotNetBar.ButtonItem buttonItemNotice;
		private DevComponents.DotNetBar.ButtonItem buttonItemFormIco;
		private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
		private DevComponents.DotNetBar.DockSite barLeftDockSite;
		private DevComponents.DotNetBar.DockSite barRightDockSite;
		private DevComponents.DotNetBar.DockSite barTopDockSite;
		private DevComponents.DotNetBar.DockSite barBottomDockSite;
		public LanMsg.MyExtRichTextBox RTBSend;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label1;
		private DevComponents.DotNetBar.ButtonItem butCapture;
		private System.Windows.Forms.Panel panelRightNotice;
		private System.Windows.Forms.Panel panelRiht;//发送消息秒记数器
		private ClassGifs SendGifs=new ClassGifs();
		private ClassGifs ArrivalGifs=new ClassGifs();
        
		private LanMsg.ClassTextMsg SendTextMsg=new ClassTextMsg();

		

		#region 当前用户自行添加的图片集合类ClassGifs
		private class ClassGifs: System.Collections.CollectionBase 
		{
			public ClassGifs()
			{
				//
				// TODO: 在此处添加构造函数逻辑
				//
			}
			public void add(LanMsg.MyPicture tempGif)
			{
				base.InnerList.Add(tempGif);	
			}

			public void Romove(LanMsg.MyPicture tempGif)
			{
				base.InnerList.Remove (tempGif);
			}
		}

		#endregion


		public FormSendMsg()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.RTBRecord.LinkClicked  +=new LinkClickedEventHandler(RTBRecord_LinkClicked);
			this.RTBSend.LinkClicked +=new LinkClickedEventHandler(RTBRecord_LinkClicked);
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing)
		{
			FormMain.formMain.forms.Romove(this);
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSendMsg));
			this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
			this.buttonItemFormIco = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
			this.ribbonTabItemGroup1 = new DevComponents.DotNetBar.RibbonTabItemGroup();
			this.itemContainer9 = new DevComponents.DotNetBar.ItemContainer();
			this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
			this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
			this.labelStatus = new DevComponents.DotNetBar.LabelItem();
			this.labelPosition = new DevComponents.DotNetBar.LabelItem();
			this.bar1 = new DevComponents.DotNetBar.Bar();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelRiht = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panelRightNotice = new System.Windows.Forms.Panel();
			this.panel14 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel17 = new System.Windows.Forms.Panel();
			this.panel16 = new System.Windows.Forms.Panel();
			this.panel15 = new System.Windows.Forms.Panel();
			this.bar4 = new DevComponents.DotNetBar.Bar();
			this.buttonItemNotice = new DevComponents.DotNetBar.ButtonItem();
			this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
			this.tabCsendFile = new DevComponents.DotNetBar.TabControl();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panelSend = new System.Windows.Forms.Panel();
			this.RTBSend = new LanMsg.MyExtRichTextBox();
			this.panel12 = new System.Windows.Forms.Panel();
			this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
			this.bar2 = new DevComponents.DotNetBar.Bar();
			this.trtFontSet = new DevComponents.DotNetBar.ButtonItem();
			this.butFontColor = new DevComponents.DotNetBar.ButtonItem();
			this.trtFaceSet = new DevComponents.DotNetBar.ButtonItem();
			this.butSendPicture = new DevComponents.DotNetBar.ButtonItem();
			this.butCapture = new DevComponents.DotNetBar.ButtonItem();
			this.butSendFile = new DevComponents.DotNetBar.ButtonItem();
			this.panelButSend = new DevComponents.DotNetBar.PanelEx();
			this.panel8 = new System.Windows.Forms.Panel();
			this.butRecordshow = new DevComponents.DotNetBar.ButtonX();
			this.panel9 = new System.Windows.Forms.Panel();
			this.butSend = new DevComponents.DotNetBar.ButtonX();
			this.butEnterSend = new DevComponents.DotNetBar.ButtonItem();
			this.butEnterCtrlSend = new DevComponents.DotNetBar.ButtonItem();
			this.butClose = new DevComponents.DotNetBar.ButtonX();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel10 = new System.Windows.Forms.Panel();
			this.bar3 = new DevComponents.DotNetBar.Bar();
			this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
			this.butOpenShared = new DevComponents.DotNetBar.ButtonItem();
			this.panelSendFile = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.timerCheckSendIsSuccess = new System.Windows.Forms.Timer(this.components);
			this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
			this.panel11 = new System.Windows.Forms.Panel();
			this.RTBRecord = new LanMsg.MyExtRichTextBox();
			this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
			this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
			this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
			this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
			this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
			((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
			this.panelRightNotice.SuspendLayout();
			this.panel14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bar4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabCsendFile)).BeginInit();
			this.panelSend.SuspendLayout();
			this.panelEx2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
			this.panelButSend.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
			this.panelSendFile.SuspendLayout();
			this.SuspendLayout();
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
																									  this.buttonItemFormIco});
			this.ribbonControl1.RibbonStripIndent = 55;
			this.ribbonControl1.Size = new System.Drawing.Size(484, 30);
			this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.ribbonControl1.TabGroupHeight = 15;
			this.ribbonControl1.TabIndex = 42;
			// 
			// buttonItemFormIco
			// 
			this.buttonItemFormIco.Icon = ((System.Drawing.Icon)(resources.GetObject("buttonItemFormIco.Icon")));
			this.buttonItemFormIco.Name = "buttonItemFormIco";
			this.buttonItemFormIco.Text = "buttonItem5";
			// 
			// buttonItem4
			// 
			this.buttonItem4.Name = "buttonItem4";
			this.buttonItem4.Text = "保存对话";
			// 
			// ribbonTabItemGroup1
			// 
			this.ribbonTabItemGroup1.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange;
			this.ribbonTabItemGroup1.GroupTitle = "Tab Group";
			// 
			// ribbonTabItemGroup1.Style
			// 
			this.ribbonTabItemGroup1.Style.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(158)), ((System.Byte)(159)));
			this.ribbonTabItemGroup1.Style.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(249)), ((System.Byte)(225)), ((System.Byte)(226)));
			this.ribbonTabItemGroup1.Style.BackColorGradientAngle = 90;
			this.ribbonTabItemGroup1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.ribbonTabItemGroup1.Style.BorderBottomWidth = 1;
			this.ribbonTabItemGroup1.Style.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(154)), ((System.Byte)(58)), ((System.Byte)(59)));
			this.ribbonTabItemGroup1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.ribbonTabItemGroup1.Style.BorderLeftWidth = 1;
			this.ribbonTabItemGroup1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.ribbonTabItemGroup1.Style.BorderRightWidth = 1;
			this.ribbonTabItemGroup1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.ribbonTabItemGroup1.Style.BorderTopWidth = 1;
			this.ribbonTabItemGroup1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
			this.ribbonTabItemGroup1.Style.TextColor = System.Drawing.Color.Black;
			this.ribbonTabItemGroup1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// itemContainer9
			// 
			this.itemContainer9.BeginGroup = true;
			this.itemContainer9.MinimumSize = new System.Drawing.Size(0, 0);
			this.itemContainer9.Name = "itemContainer9";
			// 
			// buttonItem14
			// 
			this.buttonItem14.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem14.Image")));
			this.buttonItem14.Name = "buttonItem14";
			this.buttonItem14.OptionGroup = "statusGroup";
			this.buttonItem14.Text = "Web Layout";
			this.buttonItem14.Tooltip = "Web Layout";
			// 
			// qatCustomizeItem1
			// 
			this.qatCustomizeItem1.Name = "qatCustomizeItem1";
			// 
			// labelStatus
			// 
			this.labelStatus.BorderType = DevComponents.DotNetBar.eBorderType.None;
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.PaddingLeft = 2;
			this.labelStatus.PaddingRight = 2;
			this.labelStatus.SingleLineColor = System.Drawing.Color.FromArgb(((System.Byte)(59)), ((System.Byte)(97)), ((System.Byte)(156)));
			this.labelStatus.Stretch = true;
			// 
			// labelPosition
			// 
			this.labelPosition.BorderType = DevComponents.DotNetBar.eBorderType.None;
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.PaddingLeft = 2;
			this.labelPosition.PaddingRight = 2;
			this.labelPosition.SingleLineColor = System.Drawing.Color.FromArgb(((System.Byte)(59)), ((System.Byte)(97)), ((System.Byte)(156)));
			this.labelPosition.Width = 100;
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
																				this.labelStatus,
																				this.labelPosition});
			this.bar1.ItemSpacing = 2;
			this.bar1.Location = new System.Drawing.Point(2, 426);
			this.bar1.Name = "bar1";
			this.bar1.Size = new System.Drawing.Size(484, 17);
			this.bar1.Stretch = true;
			this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar1.TabIndex = 14;
			this.bar1.TabStop = false;
			this.bar1.Text = "barStatus";
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(480, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(6, 394);
			this.panel2.TabIndex = 19;
			// 
			// panelRiht
			// 
			this.panelRiht.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRiht.Location = new System.Drawing.Point(334, 32);
			this.panelRiht.Name = "panelRiht";
			this.panelRiht.Size = new System.Drawing.Size(6, 394);
			this.panelRiht.TabIndex = 21;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(2, 32);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(6, 394);
			this.panel4.TabIndex = 22;
			// 
			// panel5
			// 
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(8, 32);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(326, 8);
			this.panel5.TabIndex = 23;
			// 
			// panelRightNotice
			// 
			this.panelRightNotice.BackColor = System.Drawing.Color.Cyan;
			this.panelRightNotice.Controls.Add(this.panel14);
			this.panelRightNotice.Controls.Add(this.tabCsendFile);
			this.panelRightNotice.Controls.Add(this.panel6);
			this.panelRightNotice.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRightNotice.Location = new System.Drawing.Point(340, 32);
			this.panelRightNotice.Name = "panelRightNotice";
			this.panelRightNotice.Size = new System.Drawing.Size(140, 394);
			this.panelRightNotice.TabIndex = 20;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.label1);
			this.panel14.Controls.Add(this.panel7);
			this.panel14.Controls.Add(this.panel17);
			this.panel14.Controls.Add(this.panel16);
			this.panel14.Controls.Add(this.panel15);
			this.panel14.Controls.Add(this.bar4);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel14.Location = new System.Drawing.Point(0, 248);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(140, 146);
			this.panel14.TabIndex = 26;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label1.Location = new System.Drawing.Point(4, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 109);
			this.label1.TabIndex = 46;
			this.label1.Text = "    LanMsg当前版本支持文件传输(可用于传输保密文件)，支持屏幕截图，支持GIF动画表情。";
			// 
			// panel7
			// 
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(4, 140);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(132, 6);
			this.panel7.TabIndex = 45;
			// 
			// panel17
			// 
			this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel17.Location = new System.Drawing.Point(136, 31);
			this.panel17.Name = "panel17";
			this.panel17.Size = new System.Drawing.Size(4, 115);
			this.panel17.TabIndex = 44;
			// 
			// panel16
			// 
			this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel16.Location = new System.Drawing.Point(0, 31);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(4, 115);
			this.panel16.TabIndex = 43;
			// 
			// panel15
			// 
			this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new System.Drawing.Point(0, 25);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(140, 6);
			this.panel15.TabIndex = 42;
			// 
			// bar4
			// 
			this.bar4.Dock = System.Windows.Forms.DockStyle.Top;
			this.bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document;
			this.bar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																				this.buttonItemNotice,
																				this.labelItem1});
			this.bar4.Location = new System.Drawing.Point(0, 0);
			this.bar4.Name = "bar4";
			this.bar4.Size = new System.Drawing.Size(140, 25);
			this.bar4.Stretch = true;
			this.bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar4.TabIndex = 41;
			this.bar4.TabStop = false;
			this.bar4.Text = "bar4";
			// 
			// buttonItemNotice
			// 
			this.buttonItemNotice.Icon = ((System.Drawing.Icon)(resources.GetObject("buttonItemNotice.Icon")));
			this.buttonItemNotice.Name = "buttonItemNotice";
			// 
			// labelItem1
			// 
			this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.None;
			this.labelItem1.Name = "labelItem1";
			this.labelItem1.Text = "公告";
			// 
			// tabCsendFile
			// 
			this.tabCsendFile.BackColor = System.Drawing.Color.Cyan;
			this.tabCsendFile.CanReorderTabs = true;
			this.tabCsendFile.ColorScheme.TabItemBorderDark = System.Drawing.Color.Cyan;
			this.tabCsendFile.ColorScheme.TabItemHotBackground2 = System.Drawing.Color.Cyan;
			this.tabCsendFile.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.Cyan;
			this.tabCsendFile.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.DarkGray;
			this.tabCsendFile.ColorScheme.TabPanelBorder = System.Drawing.SystemColors.Control;
			this.tabCsendFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabCsendFile.Location = new System.Drawing.Point(0, 8);
			this.tabCsendFile.Name = "tabCsendFile";
			this.tabCsendFile.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
			this.tabCsendFile.SelectedTabIndex = 0;
			this.tabCsendFile.Size = new System.Drawing.Size(140, 240);
			this.tabCsendFile.TabIndex = 25;
			this.tabCsendFile.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
			this.tabCsendFile.Text = "tabControl1";
			this.tabCsendFile.Visible = false;
			this.tabCsendFile.TabRemoved += new System.EventHandler(this.tabCsendFile_TabRemoved);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(201)), ((System.Byte)(235)));
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(140, 8);
			this.panel6.TabIndex = 24;
			// 
			// panelSend
			// 
			this.panelSend.Controls.Add(this.RTBSend);
			this.panelSend.Controls.Add(this.panel12);
			this.panelSend.Controls.Add(this.panelEx2);
			this.panelSend.Controls.Add(this.panelButSend);
			this.panelSend.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSend.Location = new System.Drawing.Point(8, 282);
			this.panelSend.Name = "panelSend";
			this.panelSend.Size = new System.Drawing.Size(326, 144);
			this.panelSend.TabIndex = 37;
			// 
			// RTBSend
			// 
			this.RTBSend.AllowDrop = true;
			this.RTBSend.AutoWordSelection = true;
			this.RTBSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dotNetBarManager1.SetContextMenuEx(this.RTBSend, "ButtonItem1");
			this.RTBSend.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTBSend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.RTBSend.HiglightColor = LanMsg.RtfColor.White;
			this.RTBSend.Location = new System.Drawing.Point(4, 24);
			this.RTBSend.MaxLength = 1000;
			this.RTBSend.Name = "RTBSend";
			this.RTBSend.Size = new System.Drawing.Size(322, 88);
			this.RTBSend.TabIndex = 50;
			this.RTBSend.Text = "";
			this.RTBSend.TextColor = LanMsg.RtfColor.Black;
			this.RTBSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTBSend_KeyDown);
			this.RTBSend.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RTBRecord_LinkClicked);
			// 
			// panel12
			// 
			this.panel12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel12.Location = new System.Drawing.Point(0, 24);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(4, 88);
			this.panel12.TabIndex = 37;
			// 
			// panelEx2
			// 
			this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelEx2.Controls.Add(this.bar2);
			this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelEx2.Location = new System.Drawing.Point(0, 0);
			this.panelEx2.Name = "panelEx2";
			this.panelEx2.Size = new System.Drawing.Size(326, 24);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.panelEx2.Style.GradientAngle = 90;
			this.panelEx2.TabIndex = 36;
			// 
			// bar2
			// 
			this.bar2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Top;
			this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																				this.trtFontSet,
																				this.butFontColor,
																				this.trtFaceSet,
																				this.butSendPicture,
																				this.butCapture,
																				this.butSendFile});
			this.bar2.Location = new System.Drawing.Point(0, 0);
			this.bar2.Name = "bar2";
			this.bar2.Size = new System.Drawing.Size(326, 24);
			this.bar2.Stretch = true;
			this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar2.TabIndex = 0;
			this.bar2.TabStop = false;
			this.bar2.Text = "bar2";
			// 
			// trtFontSet
			// 
			this.trtFontSet.Icon = ((System.Drawing.Icon)(resources.GetObject("trtFontSet.Icon")));
			this.trtFontSet.Name = "trtFontSet";
			this.trtFontSet.Tooltip = "设置字体";
			this.trtFontSet.Click += new System.EventHandler(this.trtFontSet_Click);
			// 
			// butFontColor
			// 
			this.butFontColor.Icon = ((System.Drawing.Icon)(resources.GetObject("butFontColor.Icon")));
			this.butFontColor.Name = "butFontColor";
			this.butFontColor.Tooltip = "设置字体颜色";
			this.butFontColor.Click += new System.EventHandler(this.butFontColor_Click);
			// 
			// trtFaceSet
			// 
			this.trtFaceSet.Icon = ((System.Drawing.Icon)(resources.GetObject("trtFaceSet.Icon")));
			this.trtFaceSet.Name = "trtFaceSet";
			this.trtFaceSet.Text = "buttonItem3";
			this.trtFaceSet.Tooltip = "发送表情";
			// 
			// butSendPicture
			// 
			this.butSendPicture.Icon = ((System.Drawing.Icon)(resources.GetObject("butSendPicture.Icon")));
			this.butSendPicture.Name = "butSendPicture";
			this.butSendPicture.Text = "buttonItem3";
			this.butSendPicture.Tooltip = "发送图片";
			this.butSendPicture.Click += new System.EventHandler(this.butSendPicture_Click);
			// 
			// butCapture
			// 
			this.butCapture.Image = ((System.Drawing.Image)(resources.GetObject("butCapture.Image")));
			this.butCapture.Name = "butCapture";
			this.butCapture.Text = "butCapture";
			this.butCapture.Tooltip = "发送“屏幕截图”";
			this.butCapture.Click += new System.EventHandler(this.butCapture_Click);
			// 
			// butSendFile
			// 
			this.butSendFile.Icon = ((System.Drawing.Icon)(resources.GetObject("butSendFile.Icon")));
			this.butSendFile.Name = "butSendFile";
			this.butSendFile.Text = "发送文件";
			this.butSendFile.Tooltip = "发送文件";
			this.butSendFile.Click += new System.EventHandler(this.butSendFile_Click);
			// 
			// panelButSend
			// 
			this.panelButSend.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelButSend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelButSend.Controls.Add(this.panel8);
			this.panelButSend.Controls.Add(this.panel9);
			this.panelButSend.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButSend.Location = new System.Drawing.Point(0, 112);
			this.panelButSend.Name = "panelButSend";
			this.panelButSend.Size = new System.Drawing.Size(326, 32);
			this.panelButSend.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelButSend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.panelButSend.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.panelButSend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.panelButSend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.panelButSend.Style.GradientAngle = 90;
			this.panelButSend.TabIndex = 34;
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(201)), ((System.Byte)(235)));
			this.panel8.Controls.Add(this.butRecordshow);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(174, 32);
			this.panel8.TabIndex = 2;
			// 
			// butRecordshow
			// 
			this.butRecordshow.ColorScheme.DockSiteBackColorGradientAngle = 0;
			this.butRecordshow.Location = new System.Drawing.Point(1, 5);
			this.butRecordshow.Name = "butRecordshow";
			this.butRecordshow.Size = new System.Drawing.Size(80, 24);
			this.butRecordshow.TabIndex = 1;
			this.butRecordshow.Text = "对话记录(&H)";
			this.butRecordshow.Click += new System.EventHandler(this.butRecordshow_Click);
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(201)), ((System.Byte)(235)));
			this.panel9.Controls.Add(this.butSend);
			this.panel9.Controls.Add(this.butClose);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel9.Location = new System.Drawing.Point(174, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(152, 32);
			this.panel9.TabIndex = 1;
			// 
			// butSend
			// 
			this.butSend.ColorScheme.DockSiteBackColorGradientAngle = 0;
			this.butSend.Location = new System.Drawing.Point(87, 4);
			this.butSend.Name = "butSend";
			this.butSend.Size = new System.Drawing.Size(64, 24);
			this.butSend.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																					  this.butEnterSend,
																					  this.butEnterCtrlSend});
			this.butSend.TabIndex = 2;
			this.butSend.Text = "发送(&S)";
			this.butSend.Click += new System.EventHandler(this.butSend_Click);
			// 
			// butEnterSend
			// 
			this.butEnterSend.Checked = true;
			this.butEnterSend.Name = "butEnterSend";
			this.butEnterSend.Text = "按Enter键发送消息";
			this.butEnterSend.Click += new System.EventHandler(this.butEnterSend_Click);
			// 
			// butEnterCtrlSend
			// 
			this.butEnterCtrlSend.Name = "butEnterCtrlSend";
			this.butEnterCtrlSend.Text = "按Ctrl + Enter 键发送消息";
			this.butEnterCtrlSend.Click += new System.EventHandler(this.butEnterCtrlSend_Click);
			// 
			// butClose
			// 
			this.butClose.ColorScheme.DockSiteBackColorGradientAngle = 0;
			this.butClose.Location = new System.Drawing.Point(17, 4);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(64, 24);
			this.butClose.TabIndex = 1;
			this.butClose.Text = "关闭(&C)";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(8, 281);
			this.splitter1.MinExtra = 100;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(326, 1);
			this.splitter1.TabIndex = 38;
			this.splitter1.TabStop = false;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.bar3);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(8, 40);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(326, 24);
			this.panel10.TabIndex = 39;
			// 
			// bar3
			// 
			this.bar3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bar3.DockSide = DevComponents.DotNetBar.eDockSide.Top;
			this.bar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																				this.buttonItem2,
																				this.butOpenShared});
			this.bar3.Location = new System.Drawing.Point(0, 0);
			this.bar3.Name = "bar3";
			this.bar3.Size = new System.Drawing.Size(326, 24);
			this.bar3.Stretch = true;
			this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar3.TabIndex = 40;
			this.bar3.TabStop = false;
			this.bar3.Text = "bar3";
			// 
			// buttonItem2
			// 
			this.buttonItem2.Name = "buttonItem2";
			// 
			// butOpenShared
			// 
			this.butOpenShared.FontUnderline = true;
			this.butOpenShared.Name = "butOpenShared";
			this.butOpenShared.Text = "打开共享";
			this.butOpenShared.Click += new System.EventHandler(this.butOpenShared_Click);
			// 
			// panelSendFile
			// 
			this.panelSendFile.Controls.Add(this.panel13);
			this.panelSendFile.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSendFile.Location = new System.Drawing.Point(8, 257);
			this.panelSendFile.Name = "panelSendFile";
			this.panelSendFile.Size = new System.Drawing.Size(326, 24);
			this.panelSendFile.TabIndex = 40;
			this.panelSendFile.Visible = false;
			// 
			// panel13
			// 
			this.panel13.BackColor = System.Drawing.Color.Transparent;
			this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel13.Location = new System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(326, 24);
			this.panel13.TabIndex = 33;
			// 
			// timerCheckSendIsSuccess
			// 
			this.timerCheckSendIsSuccess.Tick += new System.EventHandler(this.timerCheckSendIsSuccess_Tick);
			// 
			// balloonTip1
			// 
			this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
			this.balloonTip1.AutoCloseTimeOut = 3;
			this.balloonTip1.DefaultBalloonWidth = 400;
			this.balloonTip1.Enabled = false;
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel11.Location = new System.Drawing.Point(8, 64);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(4, 193);
			this.panel11.TabIndex = 43;
			// 
			// RTBRecord
			// 
			this.RTBRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dotNetBarManager1.SetContextMenuEx(this.RTBRecord, "ButtonItem1");
			this.RTBRecord.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTBRecord.HiglightColor = LanMsg.RtfColor.White;
			this.RTBRecord.Location = new System.Drawing.Point(12, 64);
			this.RTBRecord.Name = "RTBRecord";
			this.RTBRecord.ReadOnly = true;
			this.RTBRecord.Size = new System.Drawing.Size(322, 193);
			this.RTBRecord.TabIndex = 50;
			this.RTBRecord.Text = "";
			this.RTBRecord.TextColor = LanMsg.RtfColor.Black;
			this.RTBRecord.TextChanged += new System.EventHandler(this.RTBRecord_TextChanged);
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
			this.dotNetBarManager1.DefinitionName = "FormSendMsg.dotNetBarManager1.xml";
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
			this.barBottomDockSite.Location = new System.Drawing.Point(2, 443);
			this.barBottomDockSite.Name = "barBottomDockSite";
			this.barBottomDockSite.NeedsLayout = false;
			this.barBottomDockSite.Size = new System.Drawing.Size(484, 0);
			this.barBottomDockSite.TabIndex = 55;
			this.barBottomDockSite.TabStop = false;
			// 
			// barLeftDockSite
			// 
			this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
			this.barLeftDockSite.Location = new System.Drawing.Point(2, 2);
			this.barLeftDockSite.Name = "barLeftDockSite";
			this.barLeftDockSite.NeedsLayout = false;
			this.barLeftDockSite.Size = new System.Drawing.Size(0, 441);
			this.barLeftDockSite.TabIndex = 52;
			this.barLeftDockSite.TabStop = false;
			// 
			// barRightDockSite
			// 
			this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
			this.barRightDockSite.Location = new System.Drawing.Point(486, 2);
			this.barRightDockSite.Name = "barRightDockSite";
			this.barRightDockSite.NeedsLayout = false;
			this.barRightDockSite.Size = new System.Drawing.Size(0, 441);
			this.barRightDockSite.TabIndex = 53;
			this.barRightDockSite.TabStop = false;
			// 
			// barTopDockSite
			// 
			this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
			this.barTopDockSite.Location = new System.Drawing.Point(2, 2);
			this.barTopDockSite.Name = "barTopDockSite";
			this.barTopDockSite.NeedsLayout = false;
			this.barTopDockSite.Size = new System.Drawing.Size(484, 0);
			this.barTopDockSite.TabIndex = 54;
			this.barTopDockSite.TabStop = false;
			// 
			// FormSendMsg
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(488, 445);
			this.Controls.Add(this.RTBRecord);
			this.Controls.Add(this.panel11);
			this.Controls.Add(this.panelSendFile);
			this.Controls.Add(this.panel10);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelSend);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panelRiht);
			this.Controls.Add(this.panelRightNotice);
			this.Controls.Add(this.panel2);
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
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(488, 445);
			this.Name = "FormSendMsg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "与某某对话";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSendMsg_Closing);
			this.Load += new System.EventHandler(this.FormSendMsg_Load);
			((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
			this.panelRightNotice.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bar4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabCsendFile)).EndInit();
			this.panelSend.ResumeLayout(false);
			this.panelEx2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
			this.panelButSend.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
			this.panelSendFile.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 窗体加载、窗体关闭、关闭按钮、字体、颜色按钮事件
		private void FormSendMsg_Load(object sender, System.EventArgs e)
		{
			IniFace();
		}
		
		private void butClose_Click(object sender, System.EventArgs e)
		{
             this.Close();
		}

		private void trtFontSet_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.FontDialog fd=new FontDialog();
			if (fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				this.RTBSend.Font=fd.Font;
		}

		private void butFontColor_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.ColorDialog cd=new ColorDialog();
			if ( cd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				this.RTBSend.ForeColor =cd.Color;
		}

		private void FormSendMsg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.tabCsendFile.Tabs.Count>0)
				if(MessageBox.Show("您还有"+this.tabCsendFile.Tabs.Count.ToString()+"个文件在传输任务中，确定要关闭对话框并终止文件传输吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.No )
					e.Cancel=true;
		}
		#endregion

		#region 发送图片 按钮事件
		private void butSendPicture_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog  fd=new OpenFileDialog();
			fd.Filter ="图像文件|*.*;*.jpg;*.jpeg;*.gif;*.ico"; 
			if (fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
				System.IO.FileInfo fInfo=new System.IO.FileInfo(fd.FileName);
				if(fInfo.Length/(1024*70)>0)
				{
					MessageBox.Show("当前版本不支持发送大于70K的图片，请使用发送文件功能来发送。","提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information );
					return;
				}
				else
				{
					LanMsg.MyPicture pic =new MyPicture ();
					pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
					pic.BackColor=this.RTBSend.BackColor;
					pic.Image=System.Drawing.Image.FromFile(fd.FileName);
					System.Random R=new Random();
					pic.Tag=R.Next(200,2147483627);
					System.IO.DirectoryInfo dInfo=new System.IO.DirectoryInfo(Application.StartupPath +"\\sendImage");
					if(!dInfo.Exists)
						dInfo.Create();
					pic.Image.Save(Application.StartupPath +"\\sendImage\\"+ pic.Tag.ToString() +".gif",System.Drawing.Imaging.ImageFormat.Gif );
					this.RTBSend.InsertMyControl(pic);
					System.Drawing.ImageAnimator.Animate(pic.Image,new System.EventHandler(this.OnFrameChanged));
					this.SendGifs.add(pic);
				}
			}
		}
		#endregion 

		#region 发送消息 菜单事件
		private void butEnterSend_Click(object sender, System.EventArgs e)
		{
			this.butEnterSend.Checked=true;
			this.butEnterCtrlSend.Checked=!this.butEnterSend.Checked;
		}
		private void butEnterCtrlSend_Click(object sender, System.EventArgs e)
		{
			this.butEnterSend.Checked=false;
			this.butEnterCtrlSend.Checked=!this.butEnterSend.Checked;
		}
		private void RTBSend_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.butEnterSend.Checked  && e.KeyCode==System.Windows.Forms.Keys.Enter)
				this.butSend_Click(null,null);
			else if(this.butEnterCtrlSend.Checked  && e.Control  && e.KeyCode== System.Windows.Forms.Keys.Enter  )
				this.butSend_Click(null,null);
		}

        #endregion 

		#region 发送消息 按钮事件 与启用或禁用发送按钮函数
		private void butSend_Click(object sender, System.EventArgs e)
		{
			if(this.RTBSend.Text=="")
			{
				balloonTip1.SetBalloonCaption(this.RTBSend ,"提示");   
				balloonTip1.SetBalloonText(this.RTBSend,"不能发送空消息。");
				balloonTip1.ShowBalloon(this.RTBSend);
				//MessageBox.Show("不能发送空消息。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
 			currUserInfo=this.FormMain.formMain.findUser(this.Tag.ToString());
			if(currUserInfo!=null)
			{
				EnBut(false);//禁用发送功能
				currUserInfo.SendIsSuccess=false;//假设消息发送不成功
//				LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(5,"", System.Text.Encoding.Unicode.GetBytes(this.RTBSend.Rtf));

				LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(12,"",GetSendString());

				FormMain.formMain.sendMsgToOneUser(msg,currUserInfo.IP,currUserInfo.Port );
			}
		}
 
		private void EnBut(bool t)//启用或禁用发送功能
		{
			this.butSend.Enabled=t;
			this.RTBSend.ReadOnly=!t;
			OutTime=0;
			this.timerCheckSendIsSuccess.Enabled=!t;//开始检测消息是否发送成功
		}

		#endregion 

        #region 获得要发送的 文本消息 序列化后的字节数据
		private byte[] GetSendString()//获得要发送的序列化字串
		{
            this.SendTextMsg=GetSendTextMsg();
			return ( new LanMsg.ClassSerializers().SerializeBinary(this.SendTextMsg).ToArray()); 
		}
		#endregion 

		#region 检查 消息是否发送成功 timer事件
		private void timerCheckSendIsSuccess_Tick(object sender, System.EventArgs e)
		{   
			if(currUserInfo!=null)
			{
				OutTime++;
				if(OutTime==50 && !currUserInfo.SendIsSuccess)//如果消息没有发送成功
				{
					balloonTip1.SetBalloonCaption(this.butSend,"提示");   
					balloonTip1.SetBalloonText(this.butSend,"消息发送不成功(原因可能是对方已经脱机或要发送的消息数据量太大以及其它网络故障)。");
					balloonTip1.ShowBalloon(this.butSend);
					//MessageBox.Show("消息发送不成功(原因可能是对方已经脱机或网络出现故障)。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					EnBut(true);//启用发送功能
					this.RTBSend.Focus();
				}
				string title="";
				if(currUserInfo.SendIsSuccess)//如果消息发送成功 
				{
					if(this.RTBSend.Text!="")
					this.FormMain.formMain.MsgAddToDB(this.SendTextMsg.MsgContent,this.FormMain.formMain.selfInfo.ID,currUserInfo.ID,this.FormMain.formMain.selfInfo.AssemblyVersion,System.DateTime.Now.ToString(),this.SendTextMsg.ImageInfo,true);//将消息添加进数据库
				    title=this.FormMain.formMain.selfInfo.UserName  +"("+ System.DateTime.Now.ToString() +")";
//					this.newMsg(this.RTBSend.Rtf,title,new System.Drawing.Font("宋体",10),Color.Red);
                    this.newTextMsg(title,new System.Drawing.Font("宋体",10),Color.Red);
					this.sendSelfImage();//发送附加的自定义图片
					this.RTBSend.Clear();
					EnBut(true);//启用发送功能
				}
			}
		}
		#endregion

		#region //发送自定义的图片文件
		private void sendSelfImage()//发送图片文件
		{
			foreach(LanMsg.MyPicture pic in this.SendGifs)
			{
				if(pic.IsSent)
				{
				    currUserInfo=this.FormMain.formMain.findUser(this.Tag.ToString());
					if(currUserInfo!=null)
					{
						LanMsg.ClassSendImage sImage=new ClassSendImage();//要发送的图片文件类
						sImage.ID=Convert.ToUInt32(pic.Tag);
						sImage.Image=Image.FromFile(Application.StartupPath +"\\sendImage\\"+ pic.Tag.ToString() +".gif");

						LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(11,"",new ClassSerializers().SerializeBinary(sImage).ToArray());
						FormMain.formMain.sendMsgToOneUser(msg,currUserInfo.IP,currUserInfo.Port);
						System.Threading.Thread.Sleep(500);
					}
				}
			}
			this.SendGifs.Clear();
		}
		#endregion

		#region RichBox 关联 菜单事件
		private void dotNetBarManager1_ItemClick(object sender, System.EventArgs e)
		{
			switch((sender as DevComponents.DotNetBar.ButtonItem ).Name )
			{
				case "复制"	:
					if(this.RTBRecord.Focus())
						this.RTBRecord.Copy (); 
					if(this.RTBSend.Focus())
						this.RTBSend.Copy (); 
					break;
				case "粘贴"	:
					if(this.RTBRecord.Focus())
					{   }
					if(this.RTBSend.Focus())
						this.RTBSend.Paste (); 
					break;
				case "全选"	:
					if(this.RTBRecord.Focus())
						this.RTBRecord.SelectAll (); 
					if(this.RTBSend.Focus())
						this.RTBSend.SelectAll (); 
					break;
				case "剪切"	:
					if(this.RTBRecord.Focus())
					{} 
					if(this.RTBSend.Focus())
						this.RTBSend.Cut (); 
					break;

			}
		}

		#endregion

		#region RichBox 超链接 单击事件
		private void RTBRecord_LinkClicked(object sender, LinkClickedEventArgs e)
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
		#endregion

		#region 历史richbox 文本改变后 事件
		private void RTBRecord_TextChanged(object sender, System.EventArgs e)
		{
			this.RTBRecord.Focus();
			this.RTBRecord.Select(this.RTBRecord.Text.Length-1,0);
			this.RTBSend.Focus();
		}
		#endregion

		#region 打开共享 按钮单击事件
		private void butOpenShared_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sharedComputerName="\\\\"+ Convert.ToString(this.Tag);
				System.Diagnostics.Process.Start(sharedComputerName);
			}
			catch  
			{
				MessageBox.Show("无法打开对方("+ Convert.ToString(this.Tag) +")的共享文件夹(原因可能是对方没有开机或没有设置共享以及其它网络故障造成的)。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion
 
		#region 发送文件请求事件及其函数

		private void butSendFile_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog  fd=new OpenFileDialog();
			fd.Filter ="所有文件|*.*"; 
			if (fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
				sendFileRequest(fd.FileName );
			}
		}

		public void sendFileRequest(string fileName)//发送文件请求
		{
			//添加Tab
			DevComponents.DotNetBar.TabControlPanel pa =new DevComponents.DotNetBar.TabControlPanel();
			pa.Dock=System.Windows.Forms.DockStyle.Fill;
			tabCsendFile.Controls.Add(pa);
			DevComponents.DotNetBar.TabItem tabItem=new DevComponents.DotNetBar.TabItem(this.components);
			tabItem.AttachedControl=pa;
			tabItem.Text=Convert.ToString(this.tabCsendFile.Tabs.Count + 1) ;
			bool isF;
			for(int i=1;i<=this.tabCsendFile.Tabs.Count;i++) 
			{
				isF=false;
				foreach(DevComponents.DotNetBar.TabItem tItem in this.tabCsendFile.Tabs)
				{  
					if(tItem.Text==i.ToString())
						isF=true;
				}
				if(!isF)
				{
					tabItem.Text=i.ToString();goto xx;
				}

			}
			xx:
				tabCsendFile.Tabs.Add(tabItem);

			//添加filesSend控件
			LanMsg.Controls.filesSend fSend=new LanMsg.Controls.filesSend();
			pa.Controls.Add(fSend);
			System.IO.FileInfo f=new System.IO.FileInfo(fileName);
			fSend.SetParameter(true,f.Name,fileName,f.Length,System.Net.IPAddress.Parse("127.0.0.1"),0,f.Extension);
			fSend.fileSendCancel +=new LanMsg.Controls.filesSend.fileSendCancelEventHandler(fs_fileSendCancel);
			fSend.fileSendEnd +=new LanMsg.Controls.filesSend.fileSendEndEventHandler(fs_fileSendEnd); 
			string fileInfo=f.Name +"|"+ f.Extension +"|"+ f.Length.ToString();//初次请求发送文件时要先发送“控件参数”到对方，请求对方创建“文件发送控件”并建立连接
			fSend.Dock=System.Windows.Forms.DockStyle.Fill;
			LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(10,this.FormMain.formMain.selfInfo.ID,System.Text.Encoding.Unicode.GetBytes(fileInfo));
		
			//发送消息给对方，让对方接收文件
			currUserInfo=this.FormMain.formMain.findUser(this.Tag.ToString()); 
			if(currUserInfo!=null)
				fSend.SendData(currUserInfo.IP ,currUserInfo.Port, new  ClassSerializers().SerializeBinary(msg).ToArray());
			AppendSystemRtf("等待对方接收文件 "+ f.Name  +"("+ fSend.GetSizeStr(f.Length) +") 。请等待回应或取消文件传输");
		
			//显示tab控件
			this.tabCsendFile.Visible=true;
			this.tabCsendFile.SelectedTab=tabItem; 
			this.tabCsendFile.Refresh();
		}
		#endregion 

		#region 接收文件 函数
		public void ReceiveFileRequest(string fileName,string Extension,long FileSize,System.Net.IPAddress Ip,int Port)//接收文件请求
		{
			//添加Tab
			DevComponents.DotNetBar.TabControlPanel pa =new DevComponents.DotNetBar.TabControlPanel();
			pa.Dock=System.Windows.Forms.DockStyle.Fill;
			tabCsendFile.Controls.Add(pa);
			DevComponents.DotNetBar.TabItem tabItem=new DevComponents.DotNetBar.TabItem(this.components);
			tabItem.AttachedControl=pa;
			tabItem.Text=Convert.ToString(this.tabCsendFile.Tabs.Count + 1) ;
			bool isF;
			for(int i=1;i<=this.tabCsendFile.Tabs.Count;i++) 
			{
				isF=false;
				foreach(DevComponents.DotNetBar.TabItem tItem in this.tabCsendFile.Tabs)
				{  
					if(tItem.Text==i.ToString())
						isF=true;
				}
				if(!isF)
				{
					tabItem.Text=i.ToString();goto xx;
				}

			}
			xx:
				tabCsendFile.Tabs.Add(tabItem);

			//添加filesSend控件
			LanMsg.Controls.filesSend fSend=new LanMsg.Controls.filesSend();
			pa.Controls.Add(fSend);
			fSend.SetParameter(false,fileName,fileName,FileSize,Ip,Port,Extension);
			fSend.fileSendCancel +=new LanMsg.Controls.filesSend.fileSendCancelEventHandler(fs_fileSendCancel);
			fSend.fileSendEnd +=new LanMsg.Controls.filesSend.fileSendEndEventHandler(fs_fileSendEnd);
			fSend.Dock=System.Windows.Forms.DockStyle.Fill;
			AppendSystemRtf("对方要传文件 "+ fileName +"("+ fSend.GetSizeStr(FileSize) +")" +" 给您，请接收或取消文件传输");

			//显示tab控件
			this.tabCsendFile.Visible=true;
			this.tabCsendFile.SelectedTab=tabItem; 
			this.tabCsendFile.Refresh();
		}

		#endregion

		#region 文件发送取消、文件发送结束 事件
		private void fs_fileSendCancel(object sender, bool isSelf)
		{
			LanMsg.Controls.filesSend FileSend=(sender as LanMsg.Controls.filesSend);

			if(isSelf)
				AppendSystemRtf("您已经取消了文件 "+FileSend.labFileName.Text  +" 的传输");
			else
				AppendSystemRtf("对方已经取消了文件 "+FileSend.labFileName.Text  +" 的传输");

			delTabItem(FileSend);//删除文件传输Tab控件
		}

		private void fs_fileSendEnd(object sender, bool isSelf)
		{
			LanMsg.Controls.filesSend FileSend=(sender as LanMsg.Controls.filesSend);
			if(isSelf)
				AppendSystemRtf("文件 "+ FileSend.labFileName.Text  +" 已经传输完成");
			else
				AppendSystemRtf("文件 "+ FileSend.labFileName.Text  +" 已经传输完成,保存路径<file:\\\\"+ FileSend.FileName +">" );

			delTabItem(FileSend);//删除文件传输Tab控件
		}

		private void AppendSystemRtf(string str)
		{
			LanMsg.MyExtRichTextBox rich=new MyExtRichTextBox();
			rich.AppendText("\n  " );
			rich.InsertImage(this.FormMain.formMain.imageList1.Images[18]);
			rich.AppendText(" "+str);
			rich.ForeColor=Color.Brown;
			this.RTBRecord.AppendRtf (rich.Rtf);
			rich.Clear();
			rich.Dispose();
		}

		private void delTabItem(LanMsg.Controls.filesSend FileSend)//删除文件传输Tab控件
		{
			try
			{
				DevComponents.DotNetBar.TabControlPanel tPanel=(FileSend.Parent as DevComponents.DotNetBar.TabControlPanel);
				tPanel.Text="0" ;

				foreach(DevComponents.DotNetBar.TabItem tabItem in this.tabCsendFile.Tabs)
					if((tabItem.AttachedControl as DevComponents.DotNetBar.TabControlPanel).Text=="0")
					{ 
						this.tabCsendFile.Tabs.Remove(tabItem);
						FileSend.Dispose();
						tPanel.Dispose();
						tabItem.Dispose();
						this.tabCsendFile.Refresh();
						return;
					}
			}
			catch(Exception e)
			{
				
			}
		}

		private void tabCsendFile_TabRemoved(object sender, System.EventArgs e)
		{
			if(this.tabCsendFile.Tabs.Count==0)
				this.tabCsendFile.Visible=false;
		}

		#endregion

		#region 重新绘制 richbox 事件
		private void RTBRecordOnFrameChanged(object sender, EventArgs e) 
		{
			this.RTBRecord.Invalidate();
		}

		private void OnFrameChanged(object sender, EventArgs e) 
		{
			this.RTBSend.Invalidate();
		}
		#endregion

		# region 显示 对话历史 按钮事件
		private void butRecordshow_Click(object sender, System.EventArgs e)
		{
			this.currUserInfo=this.FormMain.formMain.findUser(this.Tag.ToString());
			if(this.currUserInfo!=null)
				this.FormMain.formMain.OpenMsgMis(this.currUserInfo.ID);
		}

		#endregion

		#region 当 文本消息 发送成功后将自己发送的消息加入历史RICHBOX 函数

		public void newTextMsg(string title,Font titleFont,Color titleColor)//将发送的消息加入历史rich
		{
			LanMsg.MyExtRichTextBox  rich =new  MyExtRichTextBox();
			rich.AppendText(title);
			rich.Font=titleFont;
			rich.ForeColor=titleColor;

			this.RTBRecord.AppendRtf(rich.Rtf);
			this.RTBRecord.AppendText("  ");
			LanMsg.ClassTextMsg textMsg=this.SendTextMsg;

			int iniPos=this.RTBRecord.TextLength;//获得当前记录richBox中最后的位置
			rich.Clear();
			rich.Dispose();

			if(textMsg.ImageInfo!="")//如果消息中有图片，则添加图片
			{
				string[] imagePos=textMsg.ImageInfo.Split('|');
				int addPos=0;//
				int currPos=0;//当前正要添加的文本位置
				int textPos=0;
				for(int i=0;i<imagePos.Length-1;i++)
				{
					string[] imageContent=imagePos[i].Split(',');//获得图片所在的位置、图片名称、图片宽、高

					currPos=Convert.ToInt32(imageContent[0]);
		
					this.RTBRecord.AppendText(textMsg.MsgContent.Substring(textPos,currPos-addPos));
					this.RTBRecord.SelectionStart=this.RTBRecord.TextLength;

					textPos += currPos-addPos ;
					addPos += currPos-addPos;
						
					LanMsg.MyPicture pic=new MyPicture();
					pic.BackColor=this.RTBRecord.BackColor;
					pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize; 
					if(Convert.ToUInt32(imageContent[1])<96)
						pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ imageContent[1] +".gif")) ; 
					else
					{
						pic.Tag=imageContent[1];
						pic.Image=this.findPic(imageContent[1],this.SendGifs).Image;
					}

					System.Drawing.ImageAnimator.Animate(pic.Image,new System.EventHandler(this.RTBRecordOnFrameChanged));
					this.RTBRecord.InsertMyControl(pic);

					addPos ++;
				}
				this.RTBRecord.AppendText(textMsg.MsgContent.Substring(textPos,textMsg.MsgContent.Length-textPos) +"\n");
			}
			else//如果消息中没有图片，则直接添加消息文本
			{
				this.RTBRecord.AppendText(textMsg.MsgContent +"\n");
			}

			this.RTBRecord.Focus();
			this.RTBRecord.Select(iniPos,this.RTBRecord.TextLength-iniPos);
			this.RTBRecord.SelectionFont=textMsg.font ;
			this.RTBRecord.Select(iniPos,this.RTBRecord.TextLength-iniPos);
			this.RTBRecord.SelectionColor=textMsg.color;
			this.RTBSend.Focus();
		}


		private LanMsg.ClassTextMsg GetSendTextMsg()//获得要发送的序列化字串
		{
			LanMsg.ClassTextMsg textMsg=new ClassTextMsg();
			LanMsg.MyExtRichTextBox rich=new MyExtRichTextBox();
			rich.Rtf=this.RTBSend.Rtf  ;
			textMsg.MsgContent =rich.Text;//获得消息内容
			textMsg.font=this.RTBSend.Font;//获得文本字体
			textMsg.color=this.RTBSend.ForeColor;//获得文本颜色
			REOBJECT reObject = new REOBJECT();
			LanMsg.MyPicture pic;

			for (int i=0 ; i<this.RTBSend.GetRichEditOleInterface().GetObjectCount();i++)
			{
				this.RTBSend.GetRichEditOleInterface().GetObject(i, reObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
				pic=this.findPic(reObject.dwUser.ToString(),this.SendGifs);
				if(pic!=null)
				{
					pic.IsSent=true;//发送此图片
					textMsg.ImageInfo += reObject.cp.ToString() +","+reObject.dwUser.ToString()+ ","+ pic.Image.Size.Width.ToString() +","+pic.Image.Size.Height.ToString() + "|";
				}
				else
				{
					textMsg.ImageInfo += reObject.cp.ToString() +","+reObject.dwUser.ToString()+ "|";
				}			
			}
			rich.Clear();
            rich.Dispose();
			return textMsg; 
		}

		#endregion

		#region 收到对方发送过来的 文本消息

		public void newTextMsg(byte[] content,string title,Font titleFont,Color titleColor)//收到对方发送过来文本消息
		{
			LanMsg.MyExtRichTextBox  rich =new  MyExtRichTextBox();
			rich.AppendText(title);
			rich.Font=titleFont;
			rich.ForeColor=titleColor;
			this.RTBRecord.AppendRtf(rich.Rtf);
			this.RTBRecord.AppendText("  ");

			LanMsg.ClassTextMsg textMsg=(new ClassSerializers().DeSerializeBinary(new System.IO.MemoryStream(content)) as ClassTextMsg);
			
			int iniPos=this.RTBRecord.TextLength;//获得当前记录richBox中最后的位置

			rich.Clear();
			rich.Dispose();

			if(textMsg.ImageInfo!="")//如果消息中有图片，则添加图片
			{
				string[] imagePos=textMsg.ImageInfo.Split('|');
				int addPos=0;//
				int currPos=0;//当前正要添加的文本位置
				int textPos=0;
				for(int i=0;i<imagePos.Length-1;i++)
				{
					string[] imageContent=imagePos[i].Split(',');//获得图片所在的位置、图片名称、图片宽、高

					currPos=Convert.ToInt32(imageContent[0]);
		
					this.RTBRecord.AppendText(textMsg.MsgContent.Substring(textPos,currPos-addPos));
					this.RTBRecord.SelectionStart=this.RTBRecord.TextLength;

					textPos += currPos-addPos ;
					addPos += currPos-addPos;
						

					LanMsg.MyPicture pic=new MyPicture();
					pic.BackColor=this.RTBRecord.BackColor; 

					if(Convert.ToUInt32(imageContent[1])<96)//如果发送的图片是自带的，则已知尺寸
					{
						pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ imageContent[1] +".gif")) ; 
						pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
					}
					else//如果发送的图片是自定义的，则需要知道尺寸
					{
						pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources.ErrorImage.GIF")) ;
						pic.Tag=imageContent[1];
						pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.Normal;
						pic.Size=new Size( Convert.ToInt32(imageContent[2]),Convert.ToInt32(imageContent[3]));
						this.ArrivalGifs.add(pic);
					}
					this.RTBRecord.InsertMyControl(pic);
					System.Drawing.ImageAnimator.Animate(pic.Image,new System.EventHandler(this.RTBRecordOnFrameChanged));

					addPos ++;
				}
				this.RTBRecord.AppendText(textMsg.MsgContent.Substring(textPos,textMsg.MsgContent.Length-textPos) +"\n");
			}
			else//如果消息中没有图片，则直接添加消息文本
			{
				this.RTBRecord.AppendText(textMsg.MsgContent +"\n");
			}

			this.RTBRecord.Focus();
			this.RTBRecord.Select(iniPos,this.RTBRecord.TextLength-iniPos);
			this.RTBRecord.SelectionFont=textMsg.font ;
			this.RTBRecord.Select(iniPos,this.RTBRecord.TextLength-iniPos);
			this.RTBRecord.SelectionColor=textMsg.color;
	      
			this.RTBSend.Focus();

			this.currUserInfo=this.FormMain.formMain.findUser(this.Tag.ToString());
			if(this.currUserInfo!=null)
			this.FormMain.formMain.sendMsgToOneUser(new LanMsg.Controls.ClassMsg(6,this.FormMain.formMain.selfInfo.ID,null),currUserInfo.IP,currUserInfo.Port );//告诉发消息的联系人已经收到发送的消息
		
			this.FormMain.formMain.MsgAddToDB(textMsg.MsgContent,this.Tag.ToString(),this.FormMain.formMain.selfInfo.ID,this.FormMain.formMain.selfInfo.AssemblyVersion,System.DateTime.Now.ToString(),textMsg.ImageInfo,true);//将消息添加进数据库
		}

		#endregion

		#region 在Gifs中查找图片控件
		private LanMsg.MyPicture findPic(string ID,ClassGifs gifs)
		{
            foreach(LanMsg.MyPicture pic in gifs)
				 if(Convert.ToString(pic.Tag)==ID)
					 return pic;
			return null;
		}
		#endregion 

		#region 收到对方发送来的自定义的GIF图片
		public void newMsg(byte[] content,string title,Font titleFont,Color titleColor)//收到对方发送过来的GIF图片
		{
			System.IO.MemoryStream Ms=new System.IO.MemoryStream(content);
            LanMsg.ClassSendImage sImage=(new ClassSerializers().DeSerializeBinary(Ms)) as ClassSendImage ;
            Ms.Close();
          
			LanMsg.MyPicture pic=this.findPic(Convert.ToString(sImage.ID),this.ArrivalGifs);
			if(pic!=null)
			{
				System.IO.DirectoryInfo dInfo=new System.IO.DirectoryInfo(Application.StartupPath +"\\ArrivalImage");
				if(!dInfo.Exists)
					dInfo.Create();

				pic.Image=sImage.Image;
				pic.Image.Save(Application.StartupPath +"\\ArrivalImage\\"+ pic.Tag.ToString() +".gif");
				pic.Size=pic.Image.Size;
				System.Drawing.ImageAnimator.Animate(pic.Image,new System.EventHandler(this.RTBRecordOnFrameChanged));
				pic.Refresh();
				pic.Invalidate();
				this.RTBRecord.Invalidate();
				this.RTBRecord.Refresh();
			}
		}
		#endregion

		#region 收到对方发送过来的 Rtf 消息
		public void newMsg(string rtfMsg,string title,Font titleFont,Color titleColor)
		{
			System.Windows.Forms.RichTextBox rich =new RichTextBox();
			rich.AppendText(title);
			rich.Font=titleFont;
			rich.ForeColor=titleColor;
			this.RTBRecord.AppendRtf(rich.Rtf);
			rich.Clear();
			rich.Dispose();
			this.RTBRecord.AppendTextAsRtf("    ");
			this.RTBRecord.AppendRtf(rtfMsg);
		}
		#endregion

		#region 屏幕截图 
		private void butCapture_Click(object sender, System.EventArgs e)
		{
			CaptureForm cf=new CaptureForm();
			cf.ShowDialog();
			if(cf.Image!=null)
			{
			    System.IO.MemoryStream Ms=new System.IO.MemoryStream();
                cf.Image.Save(Ms,System.Drawing.Imaging.ImageFormat.Gif);
				LanMsg.MyPicture pic =new MyPicture ();
				pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
				pic.BackColor=this.RTBSend.BackColor;
				pic.Image=System.Drawing.Image.FromStream(Ms); 
				Ms.Close();
				System.Random R=new Random();
				pic.Tag=R.Next(200,2147483627);

				System.IO.DirectoryInfo dInfo=new System.IO.DirectoryInfo(Application.StartupPath +"\\sendImage");
				if(!dInfo.Exists)
					dInfo.Create();

				cf.Image.Save(Application.StartupPath +"\\sendImage\\"+ pic.Tag.ToString() +".gif",System.Drawing.Imaging.ImageFormat.Gif );
				this.RTBSend.InsertMyControl(pic);
				this.SendGifs.add(pic);
			}
			cf.Dispose();
		}
		#endregion 

		#region 表情菜单 单击事件 
		private void item_Click(object sender, EventArgs e)//表情单击事件代码
		{
			//DevComponents.DotNetBar.ButtonItem faceItem=(sender as DevComponents.DotNetBar.ButtonItem );
			//this.RTBSend.InsertImage(faceItem.Image );

			LanMsg.MyPicture pic =new MyPicture ();
			pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pic.BackColor=this.RTBSend.BackColor;
			pic.Tag=(sender as DevComponents.DotNetBar.ButtonItem).Tag ;
			pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ (sender as DevComponents.DotNetBar.ButtonItem).Tag.ToString()  +".gif")) ; 

			this.RTBSend.InsertMyControl(pic);
			System.Drawing.ImageAnimator.Animate(pic.Image,new System.EventHandler(this.OnFrameChanged));

		}
		#endregion 

		#region 初始化表情菜单
		private void IniFace()
		{
			int j=0;
			DevComponents.DotNetBar.ItemContainer itemCon=null;
			for (int i=0;i<this.FormMain.formMain.imageListFace.Images.Count ;i++)
			{   
				DevComponents.DotNetBar.ButtonItem  item= new DevComponents.DotNetBar.ButtonItem() ;
				item.Tag=i; 
				item.Tooltip=i.ToString(); 
				item.Image=this.FormMain.formMain.imageListFace.Images[i];
				if(i % 15==0)
				{
					DevComponents.DotNetBar.ItemContainer itemC=new DevComponents.DotNetBar.ItemContainer();
					this.trtFaceSet.SubItems.Add(itemC,j);
					itemCon=itemC;
					itemCon.Name=j.ToString();
					itemCon.MinimumSize=new Size(0,0);
					j++; 
				}
				itemCon.SubItems.Add(item,i % 15);
				item.Click +=new EventHandler(item_Click);
			}
		}
		#endregion


	}
}
