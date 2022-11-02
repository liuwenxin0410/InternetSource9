using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using System.Net;
using LanMsg.CustomUIControls;

namespace LanMsg
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class FormMain :DevComponents.DotNetBar.Office2007RibbonForm //System.Windows.Forms.Form  
	{
		private DevComponents.DotNetBar.TabItem tabItem1;

		private DevComponents.DotNetBar.ItemContainer menuFileContainer;
		private DevComponents.DotNetBar.ItemContainer menuFileTwoColumnContainer;
		private DevComponents.DotNetBar.ItemContainer menuFileItems;
		private DevComponents.DotNetBar.ButtonItem buttonFileSaveAs;

		private DevComponents.DotNetBar.ItemContainer menuFileMRU;
		private DevComponents.DotNetBar.LabelItem labelItem8;
		private DevComponents.DotNetBar.ItemContainer menuFileBottomContainer;
		private DevComponents.DotNetBar.ButtonItem buttonOptions;
		private DevComponents.DotNetBar.ButtonItem buttonExit;
		private DevComponents.DotNetBar.Bar bar1;
		private DevComponents.DotNetBar.LabelItem labelStatus;
		internal DevComponents.DotNetBar.LabelItem labelPosition;
		private DevComponents.DotNetBar.RibbonControl ribbonControl1;
		private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup1;
		internal System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private DevComponents.DotNetBar.ButtonItem butMenuMain;
		private DevComponents.DotNetBar.ButtonItem butMeState;
		private DevComponents.DotNetBar.ButtonItem butMenuMainExit;
		private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.TreeView TvUsers;
		private DevComponents.DotNetBar.RibbonTabItem LabselfName;
		public ClassUserInfo selfInfo=new ClassUserInfo();
		internal System.Windows.Forms.ImageList imageListFace;
		private System.Windows.Forms.Timer timerCheckOnlinState;//保存用户自己的信息
		public Controls.ClassForms forms=new LanMsg.Controls.ClassForms(); 
		private IPAddress ServerIP=IPAddress.Parse("127.0.0.1");//服务器IP
		private int ServerPort=3211;//服务器端口
		private LanMsg.Controls.SockUDP sockUDP1;
		private DevComponents.DotNetBar.ButtonItem butMsgSendGourp;
		private System.Windows.Forms.NotifyIcon NotifyIcon;
		private DevComponents.DotNetBar.ButtonItem butMsgMis;


		public  Controls.ClassUsers MyUsers =new  Controls.ClassUsers();
		private DevComponents.DotNetBar.ButtonItem buttonItemState1;
		private DevComponents.DotNetBar.ButtonItem buttonItemState2;
		private DevComponents.DotNetBar.ButtonItem buttonItemState3;
		private DevComponents.DotNetBar.ButtonItem buttonItemState4;
		private DevComponents.DotNetBar.ButtonItem buttonItemState5;
		private DevComponents.DotNetBar.ButtonItem buttonItemState6;
		private DevComponents.DotNetBar.ButtonItem buttonItemClose;
		private DevComponents.DotNetBar.ButtonItem butForFormSetting;

		private LanMsg.ClassFormMain formmain=new ClassFormMain();

        public  bool IsWindowsExit=false;

		public  LanMsg.ClassOptionData optDB;
		private DevComponents.DotNetBar.ButtonItem butSendMsg;
		private DevComponents.DotNetBar.ButtonItem butOpenShared;
		private DevComponents.DotNetBar.ButtonItem butSendFile;
		private DevComponents.DotNetBar.ButtonItem ButAbout;

		public FormMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//DisableX(this);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			for(int i=0;i<96;i++)
				this.imageListFace.Images.Add(System.Drawing.Image.FromStream (System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ i.ToString()  +".gif")) );
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			this.sendMsgToServer(new LanMsg.Controls.ClassMsg(2,selfInfo.ID,System.Text.Encoding.Unicode.GetBytes("0")));
			this.sendMsgToAllUser(new LanMsg.Controls.ClassMsg(0,this.selfInfo.ID, null));
			this.sockUDP1.CloseSock();
			AppExit();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("部门(0/0)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("未知(0/0)");
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.menuFileContainer = new DevComponents.DotNetBar.ItemContainer();
            this.menuFileTwoColumnContainer = new DevComponents.DotNetBar.ItemContainer();
            this.menuFileItems = new DevComponents.DotNetBar.ItemContainer();
            this.menuFileMRU = new DevComponents.DotNetBar.ItemContainer();
            this.menuFileBottomContainer = new DevComponents.DotNetBar.ItemContainer();
            this.buttonOptions = new DevComponents.DotNetBar.ButtonItem();
            this.buttonExit = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFileSaveAs = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelStatus = new DevComponents.DotNetBar.LabelItem();
            this.labelPosition = new DevComponents.DotNetBar.LabelItem();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.LabselfName = new DevComponents.DotNetBar.RibbonTabItem();
            this.butMenuMain = new DevComponents.DotNetBar.ButtonItem();
            this.butSendMsg = new DevComponents.DotNetBar.ButtonItem();
            this.butSendFile = new DevComponents.DotNetBar.ButtonItem();
            this.butOpenShared = new DevComponents.DotNetBar.ButtonItem();
            this.butMeState = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemState6 = new DevComponents.DotNetBar.ButtonItem();
            this.butMsgSendGourp = new DevComponents.DotNetBar.ButtonItem();
            this.butMsgMis = new DevComponents.DotNetBar.ButtonItem();
            this.butForFormSetting = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemClose = new DevComponents.DotNetBar.ButtonItem();
            this.butMenuMainExit = new DevComponents.DotNetBar.ButtonItem();
            this.ButAbout = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItemGroup1 = new DevComponents.DotNetBar.RibbonTabItemGroup();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TvUsers = new System.Windows.Forms.TreeView();
            this.imageListFace = new System.Windows.Forms.ImageList(this.components);
            this.timerCheckOnlinState = new System.Windows.Forms.Timer(this.components);
            this.sockUDP1 = new LanMsg.Controls.SockUDP(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.ribbonControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // menuFileContainer
            // 
            this.menuFileContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.menuFileContainer.MinimumSize = new System.Drawing.Size(0, 0);
            this.menuFileContainer.Name = "menuFileContainer";
            this.menuFileContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.menuFileTwoColumnContainer,
            this.menuFileBottomContainer});
            // 
            // menuFileTwoColumnContainer
            // 
            // 
            // 
            // 
            this.menuFileTwoColumnContainer.BackgroundStyle.PaddingBottom = 2;
            this.menuFileTwoColumnContainer.BackgroundStyle.PaddingLeft = 2;
            this.menuFileTwoColumnContainer.BackgroundStyle.PaddingRight = 2;
            this.menuFileTwoColumnContainer.BackgroundStyle.PaddingTop = 2;
            this.menuFileTwoColumnContainer.ItemSpacing = 0;
            this.menuFileTwoColumnContainer.MinimumSize = new System.Drawing.Size(0, 0);
            this.menuFileTwoColumnContainer.Name = "menuFileTwoColumnContainer";
            this.menuFileTwoColumnContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.menuFileItems,
            this.menuFileMRU});
            // 
            // menuFileItems
            // 
            this.menuFileItems.MinimumSize = new System.Drawing.Size(0, 0);
            this.menuFileItems.Name = "menuFileItems";
            // 
            // menuFileMRU
            // 
            this.menuFileMRU.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.menuFileMRU.MinimumSize = new System.Drawing.Size(180, 0);
            this.menuFileMRU.Name = "menuFileMRU";
            // 
            // menuFileBottomContainer
            // 
            this.menuFileBottomContainer.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.menuFileBottomContainer.MinimumSize = new System.Drawing.Size(0, 0);
            this.menuFileBottomContainer.Name = "menuFileBottomContainer";
            this.menuFileBottomContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonOptions,
            this.buttonExit});
            // 
            // buttonOptions
            // 
            this.buttonOptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonOptions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptions.Image")));
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.SubItemsExpandWidth = 24;
            this.buttonOptions.Text = "RibbonPad Opt&ions";
            // 
            // buttonExit
            // 
            this.buttonExit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.SubItemsExpandWidth = 24;
            this.buttonExit.Text = "E&xit RibbonPad";
            // 
            // buttonFileSaveAs
            // 
            this.buttonFileSaveAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("buttonFileSaveAs.Image")));
            this.buttonFileSaveAs.Name = "buttonFileSaveAs";
            this.buttonFileSaveAs.SubItemsExpandWidth = 24;
            this.buttonFileSaveAs.Text = "&Save As...";
            // 
            // labelItem8
            // 
            this.labelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem8.BorderType = DevComponents.DotNetBar.eBorderType.Etched;
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.PaddingBottom = 2;
            this.labelItem8.PaddingTop = 2;
            this.labelItem8.Stretch = true;
            this.labelItem8.Text = "Recent Documents";
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
            this.bar1.Location = new System.Drawing.Point(2, 325);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(172, 17);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar1.TabIndex = 10;
            this.bar1.TabStop = false;
            this.bar1.Text = "barStatus";
            // 
            // labelStatus
            // 
            this.labelStatus.BorderType = DevComponents.DotNetBar.eBorderType.None;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.PaddingLeft = 2;
            this.labelStatus.PaddingRight = 2;
            this.labelStatus.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.labelStatus.Stretch = true;
            // 
            // labelPosition
            // 
            this.labelPosition.BorderType = DevComponents.DotNetBar.eBorderType.None;
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.PaddingLeft = 2;
            this.labelPosition.PaddingRight = 2;
            this.labelPosition.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.labelPosition.Width = 100;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.SystemColors.Control;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.CategorizeMode = DevComponents.DotNetBar.eCategorizeMode.Categories;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.LabselfName});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl1.Location = new System.Drawing.Point(2, 2);
            this.ribbonControl1.MdiSystemItemVisible = false;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.butMenuMain});
            this.ribbonControl1.RibbonStripIndent = 55;
            this.ribbonControl1.Size = new System.Drawing.Size(172, 46);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabGroups.AddRange(new DevComponents.DotNetBar.RibbonTabItemGroup[] {
            this.ribbonTabItemGroup1});
            this.ribbonControl1.TabGroupsVisible = true;
            this.ribbonControl1.TabIndex = 11;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 55);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(172, 0);
            this.ribbonPanel1.TabIndex = 1;
            // 
            // LabselfName
            // 
            this.LabselfName.Checked = true;
            this.LabselfName.Name = "LabselfName";
            this.LabselfName.Panel = this.ribbonPanel1;
            this.LabselfName.Text = "正在登录...";
            this.LabselfName.TextChanged += new System.EventHandler(this.LabselfName_TextChanged);
            // 
            // butMenuMain
            // 
            this.butMenuMain.Image = ((System.Drawing.Image)(resources.GetObject("butMenuMain.Image")));
            this.butMenuMain.Name = "butMenuMain";
            this.butMenuMain.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.butSendMsg,
            this.butSendFile,
            this.butOpenShared,
            this.butMeState,
            this.butMsgSendGourp,
            this.butMsgMis,
            this.butForFormSetting,
            this.buttonItemClose,
            this.butMenuMainExit,
            this.ButAbout});
            this.butMenuMain.Text = "buttonItem1";
            this.butMenuMain.PopupClose += new System.EventHandler(this.butMenuMain_PopupClose);
            // 
            // butSendMsg
            // 
            this.butSendMsg.Name = "butSendMsg";
            this.butSendMsg.Text = "发送消息(&M)";
            this.butSendMsg.Visible = false;
            this.butSendMsg.Click += new System.EventHandler(this.butSendMsg_Click);
            // 
            // butSendFile
            // 
            this.butSendFile.Name = "butSendFile";
            this.butSendFile.Text = "发送文件(&F)";
            this.butSendFile.Visible = false;
            this.butSendFile.Click += new System.EventHandler(this.butSendFile_Click);
            // 
            // butOpenShared
            // 
            this.butOpenShared.Name = "butOpenShared";
            this.butOpenShared.Text = "打开收件箱";
            this.butOpenShared.Visible = false;
            this.butOpenShared.Click += new System.EventHandler(this.butOpenShared_Click);
            // 
            // butMeState
            // 
            this.butMeState.BeginGroup = true;
            this.butMeState.Image = ((System.Drawing.Image)(resources.GetObject("butMeState.Image")));
            this.butMeState.Name = "butMeState";
            this.butMeState.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItemState1,
            this.buttonItemState2,
            this.buttonItemState3,
            this.buttonItemState4,
            this.buttonItemState5,
            this.buttonItemState6});
            this.butMeState.Text = "我的状态";
            // 
            // buttonItemState1
            // 
            this.buttonItemState1.Checked = true;
            this.buttonItemState1.Name = "buttonItemState1";
            this.buttonItemState1.Text = "联机";
            this.buttonItemState1.Click += new System.EventHandler(this.buttonItemState1_Click);
            // 
            // buttonItemState2
            // 
            this.buttonItemState2.Name = "buttonItemState2";
            this.buttonItemState2.Text = "忙碌";
            this.buttonItemState2.Click += new System.EventHandler(this.buttonItemState2_Click);
            // 
            // buttonItemState3
            // 
            this.buttonItemState3.Name = "buttonItemState3";
            this.buttonItemState3.Text = "接听电话";
            this.buttonItemState3.Click += new System.EventHandler(this.buttonItemState3_Click);
            // 
            // buttonItemState4
            // 
            this.buttonItemState4.Name = "buttonItemState4";
            this.buttonItemState4.Text = "离开";
            this.buttonItemState4.Click += new System.EventHandler(this.buttonItemState4_Click);
            // 
            // buttonItemState5
            // 
            this.buttonItemState5.Name = "buttonItemState5";
            this.buttonItemState5.Text = "外出就餐";
            this.buttonItemState5.Click += new System.EventHandler(this.buttonItemState5_Click);
            // 
            // buttonItemState6
            // 
            this.buttonItemState6.Name = "buttonItemState6";
            this.buttonItemState6.Text = "脱机";
            this.buttonItemState6.Visible = false;
            // 
            // butMsgSendGourp
            // 
            this.butMsgSendGourp.BeginGroup = true;
            this.butMsgSendGourp.Image = ((System.Drawing.Image)(resources.GetObject("butMsgSendGourp.Image")));
            this.butMsgSendGourp.Name = "butMsgSendGourp";
            this.butMsgSendGourp.Text = "群发消息";
            this.butMsgSendGourp.Click += new System.EventHandler(this.butMsgSendGourp_Click);
            // 
            // butMsgMis
            // 
            this.butMsgMis.Icon = ((System.Drawing.Icon)(resources.GetObject("butMsgMis.Icon")));
            this.butMsgMis.Name = "butMsgMis";
            this.butMsgMis.Text = "信息管理器";
            this.butMsgMis.Click += new System.EventHandler(this.butMsgMis_Click);
            // 
            // butForFormSetting
            // 
            this.butForFormSetting.Image = ((System.Drawing.Image)(resources.GetObject("butForFormSetting.Image")));
            this.butForFormSetting.Name = "butForFormSetting";
            this.butForFormSetting.Text = "设置";
            this.butForFormSetting.Visible = false;
            // 
            // buttonItemClose
            // 
            this.buttonItemClose.Name = "buttonItemClose";
            this.buttonItemClose.Text = "关闭";
            this.buttonItemClose.Visible = false;
            // 
            // butMenuMainExit
            // 
            this.butMenuMainExit.Name = "butMenuMainExit";
            this.butMenuMainExit.Text = "退出";
            this.butMenuMainExit.Visible = false;
            this.butMenuMainExit.Click += new System.EventHandler(this.butMenuMainExit_Click);
            // 
            // ButAbout
            // 
            this.ButAbout.BeginGroup = true;
            this.ButAbout.Name = "ButAbout";
            this.ButAbout.Text = "关于";
            this.ButAbout.Click += new System.EventHandler(this.ButAbout_Click);
            // 
            // ribbonTabItemGroup1
            // 
            this.ribbonTabItemGroup1.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange;
            this.ribbonTabItemGroup1.GroupTitle = "Tab Group";
            // 
            // 
            // 
            this.ribbonTabItemGroup1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(158)))), ((int)(((byte)(159)))));
            this.ribbonTabItemGroup1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.ribbonTabItemGroup1.Style.BackColorGradientAngle = 90;
            this.ribbonTabItemGroup1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup1.Style.BorderBottomWidth = 1;
            this.ribbonTabItemGroup1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(58)))), ((int)(((byte)(59)))));
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(2, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 277);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(170, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 277);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 4);
            this.panel3.TabIndex = 14;
            // 
            // TvUsers
            // 
            this.TvUsers.BackColor = System.Drawing.Color.White;
            this.TvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvUsers.ImageIndex = 14;
            this.TvUsers.ImageList = this.imageList1;
            this.TvUsers.ItemHeight = 20;
            this.TvUsers.Location = new System.Drawing.Point(6, 52);
            this.TvUsers.Name = "TvUsers";
            treeNode1.Name = "";
            treeNode1.Text = "部门(0/0)";
            treeNode2.Name = "";
            treeNode2.Text = "部门(0/0)";
            treeNode3.Name = "";
            treeNode3.Text = "部门(0/0)";
            treeNode4.Name = "";
            treeNode4.Text = "部门(0/0)";
            treeNode5.Name = "";
            treeNode5.Text = "部门(0/0)";
            treeNode6.Name = "";
            treeNode6.Text = "部门(0/0)";
            treeNode7.Name = "";
            treeNode7.Text = "部门(0/0)";
            treeNode8.Name = "";
            treeNode8.Text = "部门(0/0)";
            treeNode9.Name = "";
            treeNode9.Text = "部门(0/0)";
            treeNode10.Name = "";
            treeNode10.Text = "部门(0/0)";
            treeNode11.Name = "";
            treeNode11.Text = "未知(0/0)";
            this.TvUsers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.TvUsers.SelectedImageIndex = 15;
            this.TvUsers.ShowLines = false;
            this.TvUsers.ShowRootLines = false;
            this.TvUsers.Size = new System.Drawing.Size(164, 273);
            this.TvUsers.TabIndex = 27;
            this.TvUsers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvUsers_AfterCheck);
            this.TvUsers.DoubleClick += new System.EventHandler(this.TvUsers_DoubleClick);
            this.TvUsers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvUsers_AfterSelect);
            this.TvUsers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TvUsers_MouseMove);
            // 
            // imageListFace
            // 
            this.imageListFace.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListFace.ImageSize = new System.Drawing.Size(20, 20);
            this.imageListFace.TransparentColor = System.Drawing.Color.White;
            // 
            // timerCheckOnlinState
            // 
            this.timerCheckOnlinState.Interval = 60000;
            this.timerCheckOnlinState.Tick += new System.EventHandler(this.timerCheckOnlinState_Tick);
            // 
            // sockUDP1
            // 
            this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));
            this.sockUDP1.DataArrival += new LanMsg.Controls.SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "LanMsg";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(176, 344);
            this.Controls.Add(this.TvUsers);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.bar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(160, 344);
            this.Name = "FormMain";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.Text = "LanMsg";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ribbonControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
		{
			DataArrivaldelegate outdelegate = new DataArrivaldelegate( DataArrival); 
			this.BeginInvoke (outdelegate, new object[]{ Data,Ip,Port}); 
		}
		private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port); 

		private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) 
		{ 
			LanMsg.Controls.ClassMsg msg=new  ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as LanMsg.Controls.ClassMsg;
			switch(msg.MsgInfoClass)
			{
				case 0://有用户离线
					userSingnOut(msg.ID );//处理用户离线
					break;
				case 1://服务器告诉自己已经登录,登录过程
					SuccessLogin(msg);
					break;
				case 2://服务器告诉用户自己目前在线
					updateSelfState();//更新当前用户在线状态
					break;
				case 3://服务器告诉用户有新的联系人登录
					NewUserLogin(new  ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent ))) as ClassUserInfo );//添加新登录的用户资料
					break;
				case 4://收到用户部分联系人的资料
					UsersDataArrival((new  ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent ))) as Controls.ClassUsers));//收到用户所有联系人的资料
					break;
				case 5://收到用户联系人发送来的对话消息
					UserChatArrival(msg,Ip,Port);//处理对话消息
					break;
				case 6://联系人返回已经收到刚才发送的对话消息
					returnChatArrival(msg.ID );//联系人返回已经收到刚才发送的对话消息
					break;
				case 7:
					//收到联系人发送来的群发通知消息
					noticeArrival(msg,Ip,Port);//处理联系人发送来的群发通知消息
					break;
				case 10://收到联系人发出发送文件请求
					sendFileRequest(msg,Ip,Port);
					break;
                case 11://收到联系人发送来的gif图片流
                    UserGifArrival(msg,Ip,Port);//处理gif图片消息
					break;
                case 12://收到用户发送来的文本消息
					UserTextChatArrival(msg,Ip,Port);//处理用户发送来的文本消息
					break;
			}
		} 

		private void UserTextChatArrival(LanMsg.Controls.ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理用户发送来的文本消息
		{

			ClassUserInfo userinfo =this.findUser(msg.ID);
			if (userinfo!=null)
			{
				string title= userinfo.UserName  +"("+ System.DateTime.Now.ToString() +")";
				//MsgAddToDB(msgRtf,msg.ID,selfInfo.ID,msg.AssemblyVersion,System.DateTime.Now.ToString(),true);//将消息添加进数据库
				foreach(System.Windows.Forms.Form form in forms)
					if (form.Tag.ToString() == userinfo.ID )
					{
						FormSendMsg f=(form as FormSendMsg );
						f.newTextMsg(msg.MsgContent,title,new System.Drawing.Font("宋体",10), Color.Blue);
						f.Activate ();
						return;
					}

				FormSendMsg newf =new FormSendMsg();
				newf.Tag=msg.ID;
				newf.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
				newf.newTextMsg(msg.MsgContent,title,new System.Drawing.Font("宋体",10),Color.Blue );
				forms.add(newf);
				ShowNotifyIcon(1,"","收到 "+userinfo.UserName +"("+ userinfo.ID  +") 发送给您的新消息。");
				newf.Show();

			}
		}

		private void UserGifArrival(LanMsg.Controls.ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理gif图片消息
		{

			ClassUserInfo userinfo =this.findUser(msg.ID);
			if (userinfo!=null)
			{

				this.sendMsgToOneUser(new LanMsg.Controls.ClassMsg(6,selfInfo.ID,null),userinfo.IP,userinfo.Port );//告诉发消息的联系人已经收到发送的消息
				string title= userinfo.UserName  +"("+ System.DateTime.Now.ToString() +")";
				//MsgAddToDB(msgRtf,msg.ID,selfInfo.ID,msg.AssemblyVersion,System.DateTime.Now.ToString(),true);//将消息添加进数据库
				foreach(System.Windows.Forms.Form form in forms)
					if (form.Tag.ToString() == userinfo.ID )
					{
						FormSendMsg f=(form as FormSendMsg );
						f.newMsg(msg.MsgContent,title,new System.Drawing.Font("宋体",10), Color.Blue);
						f.Activate ();
						return;
					}

				FormSendMsg newf =new FormSendMsg();
				newf.Tag=msg.ID;
				newf.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
				newf.newMsg(msg.MsgContent,title,new System.Drawing.Font("宋体",10),Color.Blue );
				forms.add(newf);
				ShowNotifyIcon(1,"","收到 "+userinfo.UserName +"("+ userinfo.ID  +") 发送给您的新消息。");
				newf.Show();

			}
		}

		private void sendFileRequest(LanMsg.Controls.ClassMsg msg,System.Net.IPAddress Ip, int Port) //处理联系人发送接收文件要求
		{
			ClassUserInfo userinfo =this.findUser(msg.ID);
			if (userinfo!=null)
			{
				string[] fileInfo= System.Text.Encoding.Unicode.GetString (msg.MsgContent).Split('|');
				ShowNotifyIcon(1,"",userinfo.UserName +"("+ userinfo.ID  +") 要求发送文件给您，请接收或拒绝。");
				foreach(System.Windows.Forms.Form form in forms)
					if (form.Tag.ToString() == userinfo.ID )
					{
						FormSendMsg f=(form as FormSendMsg );
						f.ReceiveFileRequest(fileInfo[0].ToString(),fileInfo[1].ToString(),Convert.ToInt64(fileInfo[2]),Ip,Port);
						f.Activate ();
						return;
					}
				FormSendMsg newf =new FormSendMsg();
				newf.Tag=msg.ID;
				newf.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
				newf.ReceiveFileRequest(fileInfo[0].ToString(),fileInfo[1].ToString(),Convert.ToInt64(fileInfo[2]),Ip,Port);
				forms.add(newf);
				newf.Show();
			}		
		}

		private void noticeArrival(LanMsg.Controls.ClassMsg msg,System.Net.IPAddress Ip, int Port) //处理联系人发送来的群发通知消息
		{
            ClassUserInfo userinfo =this.findUser(msg.ID);
			if (userinfo!=null)
			{
				string msgContent=System.Text.Encoding.Unicode.GetString(msg.MsgContent);
//				MsgAddToDB(msgContent,msg.ID,selfInfo.ID,msg.AssemblyVersion ,System.DateTime.Now.ToString(),false);//将消息添加进数据库
				LanMsg.FormNotice nt=new FormNotice();
				nt.RTBNoticeContent.AppendText(msgContent);
				nt.RTBNoticeContent.AppendText("\n发布："+userinfo.UserName +"("+ userinfo.ID  +")");
				ShowNotifyIcon(3,"通知-消息","收到 "+userinfo.UserName +"("+ userinfo.ID  +") 发布的设计院 通知-消息");
				nt.Show();
			}
		}

		private void returnChatArrival(string ID ) //联系人返回已经收到刚才发送的对话消息
		{
			ClassUserInfo userinfo =this.findUser(ID);
			if (userinfo!=null)
				userinfo.SendIsSuccess=true;//标识刚才发送的消息联系人已经成功收到
		}

		private void UserChatArrival(LanMsg.Controls.ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理对话消息
		{

			ClassUserInfo userinfo =this.findUser(msg.ID);
			if (userinfo!=null)
			{

				this.sendMsgToOneUser(new LanMsg.Controls.ClassMsg(6,selfInfo.ID,null),userinfo.IP,userinfo.Port );//告诉发消息的联系人已经收到发送的消息
				string title= userinfo.UserName  +"("+ System.DateTime.Now.ToString() +")";
				string msgRtf=System.Text.Encoding.Unicode.GetString(msg.MsgContent);
//				MsgAddToDB(msgRtf,msg.ID,selfInfo.ID,msg.AssemblyVersion,System.DateTime.Now.ToString(),true);//将消息添加进数据库
				foreach(System.Windows.Forms.Form form in forms)
					if (form.Tag.ToString() == userinfo.ID )
					{
						FormSendMsg f=(form as FormSendMsg );
						f.newMsg(msgRtf,title,new System.Drawing.Font("宋体",10), Color.Blue);
						f.Activate ();
						return;
					}

				FormSendMsg newf =new FormSendMsg();
				newf.Tag=msg.ID;
				newf.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
				newf.newMsg(msgRtf,title,new System.Drawing.Font("宋体",10),Color.Blue );
				forms.add(newf);
				ShowNotifyIcon(1,"","收到 "+userinfo.UserName +"("+ userinfo.ID  +") 发送给您的新消息。");
				newf.Show();

			}
		}

		private void NewUserLogin(ClassUserInfo userinfo)//添加新登录的用户资料
		{
			if(userinfo.ID==selfInfo.ID )
				return;//如果新登录的联系人是自己则退出
			//this.Text="新用户"+ userinfo.ID;
			ClassUserInfo UserInfo;  
			UserInfo=findUser(userinfo.ID);

			if(UserInfo==null )
			{
				userinfo.Node=new TreeNode();
				this.TvUsers.Nodes[userinfo.Dep].Nodes.Add(userinfo.Node);
				this.MyUsers.add(userinfo);

				userinfo.State =userinfo.State ;
				userinfo.Dep =userinfo.Dep ;
				userinfo.ID=userinfo.ID;
			}
			else
			{
				UserInfo.ID=userinfo.ID;
				UserInfo.Dep=userinfo.Dep;
				UserInfo.State  =userinfo.State;
				UserInfo.IP=userinfo.IP ;
				UserInfo.Port=userinfo.Port;
				UserInfo.UserName =userinfo.UserName;
				UserInfo.AssemblyVersion=userinfo.AssemblyVersion;
			}
			updateGroupInfo();//更新部门成员上线与未上线的数据
		}

		private void updateSelfState()//更新当前用户在线状态
		{
			selfInfo.State  =OnlineState;//将自己的在线状态设置为非0表示在线
			this.LabselfName.Text=selfInfo.UserName  + selfInfo.StateInfo ;
			this.LabselfName.Refresh();
		}

		private void userSingnOut(string ID) //处理用户离线
		{
			ClassUserInfo userinfo=this.findUser(ID);
			if(userinfo!=null)
			{
				int GroupIndex=userinfo.Dep ;
				if (userinfo.Dep==10)//如果用户在未知组
				{
					userinfo.Node.Parent.Nodes.Remove(userinfo.Node);
					this.MyUsers.Romove(userinfo);//在用户列表中删除未知组的此离线用户
				}
				else
				{
					userinfo.State=0;//标识用户已经离线
				}
				updateGroupInfo();//更新部门成员上线与未上线的数据
			}
		}

	   
		private void UsersDataArrival(Controls.ClassUsers users)//收到用户所有联系人的资料
		{
			ClassUserInfo UserInfo;  
			foreach(ClassUserInfo userinfo in users)
			{
				UserInfo=findUser(userinfo.ID);
				if(UserInfo==null)
				{
					userinfo.Node=new TreeNode();
					this.TvUsers.Nodes[userinfo.Dep].Nodes.Add(userinfo.Node);
					this.MyUsers.add(userinfo);

					userinfo.ID=userinfo.ID;
					userinfo.State =userinfo.State ;
					userinfo.Dep=userinfo.Dep;

					//updateGroupInfo(userinfo);
				}
			}
			updateGroupInfo();//更新部门成员上线与未上线的数据
		}
		private void updateGroupInfo()//更新部门成员上线与未上线的数据 
		{
			int Online=0;
			for(int i=0;i<this.TvUsers.Nodes.Count;i++)
			{
				for(int j=0;j<this.TvUsers.Nodes[i].Nodes.Count;j++)
					if(this.TvUsers.Nodes[i].Nodes[j].Text.IndexOf("(脱机)")==-1)
						Online++;
				this.TvUsers.Nodes[i].Text=Convert.ToString(this.TvUsers.Nodes[i].Tag) +"("+Online.ToString() +"/"+this.TvUsers.Nodes[i].Nodes.Count.ToString() +")";
				Online=0;
			}
		}

		private void updateGroupInfo(LanMsg.ClassUserInfo userinfo)//更新部门成员上线与未上线的数据 
		{
			int Online=0;
			int userCount=0;
			foreach(ClassUserInfo TempUserinfo in this.MyUsers)
				if(TempUserinfo.Dep==userinfo.Dep )
				{
					userCount++;
					if(TempUserinfo.State!=0) Online++;
				}
           userinfo.Node.Parent.Text=Convert.ToString(userinfo.Node.Parent.Tag)+"("+Online.ToString() +"/"+userCount.ToString()+")";
		}

		public ClassUserInfo findUser(string ID)//在我的用户列表中查找用户ID
		{
			foreach(ClassUserInfo userinfo in  this.MyUsers)
				if(userinfo.ID.ToLower()==ID.ToLower())
					return userinfo;
			return null;
		}

		private void SuccessLogin(LanMsg.Controls.ClassMsg msg)//服务器告诉用户已经成功登录的处理过程
		{
			//this.Text="成功登陆";
			ClassUserInfo self=(new  ClassSerializers().DeSerializeBinary (new System.IO.MemoryStream(msg.MsgContent ))) as ClassUserInfo;
 			selfInfo.UserName =self.UserName;
            selfInfo.State =1;
			this.LabselfName.Text=selfInfo.UserName  +"(联机)";
			this.LabselfName.Refresh();
			//ShowNotifyIcon(1,"","LanMsg已经成功登录服务器。");
		}

		private void TvUsers_DoubleClick(object sender, System.EventArgs e)
		{
             ActivateOrCreateFormSend();
		}

		private void ActivateOrCreateFormSend()//激活或创建新的消息发送窗体
		{
			if(this.TvUsers.SelectedNode.Parent!=null)
			{
				foreach(System.Windows.Forms.Form fo in forms)
					if (fo.Tag == this.TvUsers.SelectedNode.Tag)
					{
						fo.Activate ();return;
					}
			        FormSendMsg f =new FormSendMsg();
				    forms.add(f);
				    LanMsg.ClassUserInfo userinfo=this.findUser( this.TvUsers.SelectedNode.Tag.ToString());
				    if(userinfo!=null)
				    f.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
				    f.Tag=this.TvUsers.SelectedNode.Tag;
                    f.Show();
			}
		}
        
		private void FormMain_Load(object sender, System.EventArgs e)
		{
			SaveSettings();
			this.Left=Screen.PrimaryScreen.WorkingArea.Width -this.Width;
			this.Top=200; 
		    BeginListen();
		}
         
		private void BeginListen()//
		{
			//AssemblyName assName = Assembly.GetExecutingAssembly().GetName(); 
			//string version = assName.Version.ToString(); 
			//System.Diagnostics.FileVersionInfo fInfo=new System.Diagnostics.FileVersionInfo();
		   System.Random i =new Random();
		   int j= i.Next(2000,6000);
           this.sockUDP1.Listen (j);//UDP开始侦听来自外部的消息.
		   selfInfo.Port=j;
		   selfInfo.ID=System.Net.Dns.GetHostName()+j.ToString();//  
		   System.Reflection.AssemblyName assName = System.Reflection.Assembly.GetExecutingAssembly().GetName(); 
		   selfInfo.AssemblyVersion = assName.Version.ToString(); 
		   System.Threading.Thread.Sleep(3000);
           Login();//用户登录 
		   this.timerCheckOnlinState.Enabled=true;
		}

		private void butMenuMainExit_Click(object sender, System.EventArgs e)
		{
           AppExit();
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!IsWindowsExit) 
			{
				this.WindowState=System.Windows.Forms.FormWindowState.Minimized;
				this.Hide();
				e.Cancel=true;
			}
		}

		private void AppExit()//关闭Sock，退出程序
		{
			this.sockUDP1.CloseSock();
			Application.Exit();
		}

		private void Login()//用户登录
		{    
			 this.LabselfName.Text="正在登录...";
			 LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(1,selfInfo.ID,System.Text.Encoding.Unicode.GetBytes(selfInfo.AssemblyVersion));
			 sendMsgToServer(msg);
		}

		private void timerCheckOnlinState_Tick(object sender, System.EventArgs e)//检测自己的在线状态
		{
            CheckOnlineState();//检测自己的在线状态
		}
        
		private int OnlineState=1;

		private void CheckOnlineState()//检测自己的在线状态
		{
			if(selfInfo.State ==0)//如果没有登录，则登录
			{
				 Login();
			}
			else//如果已经登录在线，则将自己设为脱机状态，然后向服务器发送消息告之自已在线状态
			{
		        OnlineState=selfInfo.State;
				selfInfo.State=0;
                LanMsg.Controls.ClassMsg msg=new LanMsg.Controls.ClassMsg(2,selfInfo.ID,System.Text.Encoding.Unicode.GetBytes(OnlineState.ToString()));
                sendMsgToServer(msg);
			}
		}

		public void sendMsgToServer(Controls.ClassMsg msg)//发送消息到服务器
		{
		   this.sockUDP1.Send(this.ServerIP,this.ServerPort,new  ClassSerializers().SerializeBinary(msg).ToArray());
		}
		public void sendMsgToOneUser(Controls.ClassMsg msg,System.Net.IPAddress Ip, int Port)//发送消息到用户的一个联系人
		{   
			msg.ID=selfInfo.ID;//标识本人的ID号
			this.sockUDP1.Send(Ip,Port,new ClassSerializers().SerializeBinary(msg).ToArray());
		}

		private void TvUsers_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			foreach(System.Windows.Forms.TreeNode nd in e.Node.Nodes)
				nd.Checked=e.Node.Checked;
		}

		private void butMsgSendGourp_Click(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Form form in forms)
				if( form is LanMsg.FormNotice )
				{
					form.Activate();
					return;
				}
            FormSendMsgGroup fSendMsgGroup=new FormSendMsgGroup();
			fSendMsgGroup.Tag="Notice";
			forms.add(fSendMsgGroup);
			fSendMsgGroup.Show ();
			this.TvUsers.CheckBoxes=true;
		}
	
		public void sendMsgToOneUser(Controls.ClassMsg msg,string userID)//发送消息到用户的一个联系人
		{   
			msg.ID=selfInfo.ID;//标识本人的ID号
			ClassUserInfo userinfo=this.findUser(userID);
            if(userinfo!=null)
			 this.sockUDP1.Send(userinfo.IP ,userinfo.Port ,new  ClassSerializers().SerializeBinary(msg).ToArray());
		}
		private void sendMsgToAllUser(Controls.ClassMsg msg)//发送通知消息(群发)
		{
			msg.ID=selfInfo.ID;//标识本人的ID号
			foreach(ClassUserInfo userinfo in this.MyUsers )
			{
				this.sockUDP1.Send(userinfo.IP ,userinfo.Port ,new ClassSerializers().SerializeBinary(msg).ToArray());
			}
		}
		public void sendNotice(Controls.ClassMsg msg)//发送通知消息(群发)
		{
			msg.ID=selfInfo.ID;//标识本人的ID号
			foreach(ClassUserInfo userinfo in this.MyUsers )
			{
				if(userinfo.Node.Checked)
					this.sockUDP1.Send(userinfo.IP ,userinfo.Port ,new  ClassSerializers().SerializeBinary(msg).ToArray());
			}
		}

		private System.Drawing.Point  point=new  Point(0,0);

		private void TvUsers_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Parent==null)
			{
				foreach(System.Windows.Forms.TreeNode nd in this.TvUsers.Nodes)
					nd.Collapse();
				e.Node.Expand();
			}
			else
			{
				this.butSendMsg.Visible=true;
				this.butSendFile.Visible=true;
				this.butOpenShared.Visible=true;
				this.butOpenShared.Tag=e.Node.Tag;
				this.butSendFile.Tag=e.Node.Tag;
				butMenuMain.PopupMenu(this.Left + this.point.X+10  ,this.Top + this.point.Y+50  );
			}

		}

		private void LabselfName_TextChanged(object sender, System.EventArgs e)
		{
			this.NotifyIcon.Text=this.LabselfName.Text;
	    }

		private void butMsgMis_Click(object sender, System.EventArgs e)
		{
			 OpenMsgMis("");//打开消息管理器
		}
        
		public  void OpenMsgMis(string OpenID)//打开消息管理器
		{
			foreach(System.Windows.Forms.Form form in forms)
				if (form is LanMsg.FormMsgMis)
				{
					LanMsg.FormMsgMis f=(form as  LanMsg.FormMsgMis);
					f.Activate ();
					f.selectID(OpenID);
					return;
				}

			FormMsgMis fr=new FormMsgMis();
			this.forms.add(fr);
			fr.Show();
			fr.Activate();
			fr.selectID(OpenID);
		}

		#region 添加记录到数据库
		public void MsgAddToDB(string msgContent,string sendID,string ReceiveID,string AssemblyVersion,string msgDateTime,string ImageInfo,bool IsNotNotice)//添加用户对话消息到数据库
		{
			try
			{  
				string DBtable="Notice";
				if(IsNotNotice)
				{
					DBtable="MsgRecord";
				}

				System.Data.OleDb.OleDbConnection connection=new  System.Data.OleDb.OleDbConnection(new ClassFormMain().ConStr);    
        
				System.Data.OleDb.OleDbCommand command=new System.Data.OleDb.OleDbCommand("INSERT  INTO  ["+DBtable+"](msgContent,sendID,ReceiveID,AssemblyVersion,msgDateTime,ImageInfo) VALUES( @msgContent,@sendID,@ReceiveID ,@AssemblyVersion,@msgDateTime,@ImageInfo)",  connection  );    
          
				System.Data.OleDb.OleDbParameter paramMsgContent =new System.Data.OleDb.OleDbParameter("@msgContent",System.Data.OleDb.OleDbType.LongVarChar);    
				paramMsgContent.Value  =  msgContent;    
				command.Parameters.Add(paramMsgContent);    

				System.Data.OleDb.OleDbParameter paramSendID=new System.Data.OleDb.OleDbParameter("@sendID",System.Data.OleDb.OleDbType.Char);    
				paramSendID.Value  =  sendID;    
				command.Parameters.Add(paramSendID);    

				System.Data.OleDb.OleDbParameter paramReceiveID=new System.Data.OleDb.OleDbParameter("@ReceiveID",System.Data.OleDb.OleDbType.Char);    
				paramReceiveID.Value  =  ReceiveID;    
				command.Parameters.Add(paramReceiveID);    

				System.Data.OleDb.OleDbParameter paramAssemblyVersion=new System.Data.OleDb.OleDbParameter("@AssemblyVersion",System.Data.OleDb.OleDbType.Char);    
				paramAssemblyVersion.Value  =  AssemblyVersion;    
				command.Parameters.Add(paramAssemblyVersion);    
			
				System.Data.OleDb.OleDbParameter paramMsgDateTime=new System.Data.OleDb.OleDbParameter("@msgDateTime",System.Data.OleDb.OleDbType.DBTimeStamp);    
				paramMsgDateTime.Value  =msgDateTime;    
				command.Parameters.Add(paramMsgDateTime);    


				System.Data.OleDb.OleDbParameter paramImageInfo=new System.Data.OleDb.OleDbParameter("@ImageInfo",System.Data.OleDb.OleDbType.LongVarChar);    
				paramImageInfo.Value  =ImageInfo;    
				command.Parameters.Add(paramImageInfo);    
				
				connection.Open();    
        
				int  numRowsAffected  =  command.ExecuteNonQuery();    
        
				connection.Close();    
			}
			catch(Exception e)//如果有错误发生
			{
			  
			}
		}

		#endregion

		private void SaveSettings() 
		{ 
			Microsoft.Win32.RegistryKey Reg; 
			Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true); 
			Reg.SetValue("LanMsg", Application.ExecutablePath); 
		}

		[System.Runtime.InteropServices.DllImport("user32")] 
		private static extern long AnimateWindow(long hwnd, long dwTime, long dwFlags);


		[System.Runtime.InteropServices.DllImport("winmm.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)] 
		private static extern int PlaySound(string lpszSoundName, int hModule, int dwFlags); 
		const int SND_FILENAME = 131072; 
		const int SND_ALIAS = 65536; 
		const int SND_SYNC = 0; 

		private void PlaySound(string fileStr) 
		{ 
			PlaySound(fileStr, 0, SND_FILENAME); 
		}

		private void buttonItemState1_Click(object sender, System.EventArgs e)
		{
			CheckButFalse(sender);
			this.OnlineState=1;
			updateSelfState();
		}

		private void buttonItemState2_Click(object sender, System.EventArgs e)
		{
			CheckButFalse(sender);
			this.OnlineState=2;
			updateSelfState();
		}

		private void buttonItemState3_Click(object sender, System.EventArgs e)
		{
			CheckButFalse(sender);
			this.OnlineState=3;
			updateSelfState();

		}

		private void buttonItemState4_Click(object sender, System.EventArgs e)
		{
			CheckButFalse(sender);
			this.OnlineState=4;
			updateSelfState();

		}

		private void buttonItemState5_Click(object sender, System.EventArgs e)
		{
			CheckButFalse(sender);
			this.OnlineState=5;
			updateSelfState();

		}
        
		private void CheckButFalse(object sender)
		{
            buttonItemState1.Checked=false;
			buttonItemState2.Checked=false;
			buttonItemState3.Checked=false;
			buttonItemState4.Checked=false;
			buttonItemState5.Checked=false;
			(sender as  DevComponents.DotNetBar.ButtonItem).Checked=true;
		}
 
		private void NotifyIcon_Click(object sender, System.EventArgs e)
		{
			this.Opacity=100;
			this.ShowInTaskbar=true;
			this.WindowState=System.Windows.Forms.FormWindowState.Normal;
			this.Show();
			this.Activate();
			this.Refresh();

		}

		private void FormMain_SizeChanged(object sender, System.EventArgs e)
		{

		}
 
		private void ShowNotifyIcon(int ShowClass,string title,string content)
		{
			if(title=="")title="新消息";
			LanMsg.CustomUIControls.TaskbarNotifier  taskbarNotifier=new TaskbarNotifier();
			switch(ShowClass)
			{
				case 1:
					taskbarNotifier.SetBackgroundBitmap(new Bitmap(GetType(),"skin.bmp"),Color.FromArgb(255,0,255));
					taskbarNotifier.SetCloseBitmap(new Bitmap(GetType(),"close.bmp"),Color.FromArgb(255,0,255),new Point(127,8));
					taskbarNotifier.TitleRectangle=new Rectangle(40,9,70,25);
					taskbarNotifier.ContentRectangle=new Rectangle(8,41,133,68);
					//taskbarNotifier1.TitleClick+=new EventHandler(TitleClick);
					//taskbarNotifier1.ContentClick+=new EventHandler(ContentClick);
					//taskbarNotifier1.CloseClick+=new EventHandler(CloseClick);
					break;
				case 2:
					taskbarNotifier.SetBackgroundBitmap(new Bitmap(GetType(),"skin2.bmp"),Color.FromArgb(255,0,255));
					taskbarNotifier.SetCloseBitmap(new Bitmap(GetType(),"close2.bmp"),Color.FromArgb(255,0,255),new Point(300,74));
					taskbarNotifier.TitleRectangle=new Rectangle(123,80,176,16);
					taskbarNotifier.ContentRectangle=new Rectangle(116,97,197,22);
					//taskbarNotifier2.TitleClick+=new EventHandler(TitleClick);
					//taskbarNotifier2.ContentClick+=new EventHandler(ContentClick);
					//taskbarNotifier2.CloseClick+=new EventHandler(CloseClick);
					break;
				case 3:
					taskbarNotifier.SetBackgroundBitmap(new Bitmap(GetType(),"skin3.bmp"),Color.FromArgb(255,0,255));
					taskbarNotifier.SetCloseBitmap(new Bitmap(GetType(),"close.bmp"),Color.FromArgb(255,0,255),new Point(280,57));
					taskbarNotifier.TitleRectangle=new Rectangle(150, 57, 125, 28);
					taskbarNotifier.ContentRectangle=new Rectangle(75, 92, 215, 55);
					break;
			}
			taskbarNotifier.Show(title ,content,500,3000,500);
		}

		private void TvUsers_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.point.X =e.X ;
			this.point.Y =e.Y;
		}

		private void butOpenShared_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sharedComputerName="\\\\"+ Convert.ToString(this.butOpenShared.Tag);
				System.Diagnostics.Process.Start(sharedComputerName);
			}
			catch  
			{
				MessageBox.Show("无法打开对方("+ Convert.ToString(this.butOpenShared.Tag) +")的共享文件夹(原因可能是对方没有开机或没有设置共享以及其它网络故障造成的)。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void butMenuMain_PopupClose(object sender, System.EventArgs e)
		{
			this.butOpenShared.Visible=false;
			this.butSendFile.Visible=false;
			this.butSendMsg.Visible=false;
		}

		private void butSendMsg_Click(object sender, System.EventArgs e)
		{
			ActivateOrCreateFormSend();
		}

		private void butSendFile_Click(object sender, System.EventArgs e)//发送文件
		{
            System.Windows.Forms.OpenFileDialog fd=new OpenFileDialog();
            fd.Title="选择要发送的文件";
			fd.Filter="所有文件(*.*)|*.*";
			if (fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
				ClassUserInfo userinfo =this.findUser(butSendFile.Tag.ToString());
				if (userinfo!=null)
				{
					foreach(System.Windows.Forms.Form form in forms)
						if (form.Tag.ToString() == userinfo.ID )
						{
							FormSendMsg f=(form as FormSendMsg );
							f.sendFileRequest(fd.FileName );
							f.Activate ();
							return;
						}
					FormSendMsg newf =new FormSendMsg();
					newf.Tag=userinfo.ID;
					newf.Text="与 "+ userinfo.UserName+"("+userinfo.ID+") 对话";
					newf.sendFileRequest(fd.FileName );
					forms.add(newf);
					newf.Show();
				}		
			}
		}

		private void ButAbout_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("   租李叶(QQ:25348855)\n局域网即时通知消息 LanMsg 1.0 bate","关于",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information );
		}

	 
  	}
}
