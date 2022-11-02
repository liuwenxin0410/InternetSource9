using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LanMsg
{
	/// <summary>
	/// FormMsgMis 的摘要说明。
	/// </summary>
	public class FormMsgMis : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		public LanMsg.MyExtRichTextBox RTBRecord;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TreeView TV_user;
		private System.Windows.Forms.MenuItem meuFileExit;
		private System.Windows.Forms.MenuItem menFileExport;
		private System.Windows.Forms.MenuItem menViewRefresh;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton ButUp;
		private System.Windows.Forms.ToolBarButton ButDown;
		private System.Windows.Forms.ToolBarButton ButFirst;
		private System.Windows.Forms.ToolBarButton ButLast;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		internal System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ToolBarButton ButExit;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton ButDelRecord;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItemCopy;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemSelectAll;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemEditCopy;
		private System.Windows.Forms.MenuItem menuItemEditSelectAll;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItemEditLast;
		private System.Windows.Forms.MenuItem menuItemEditDown;
		private System.Windows.Forms.MenuItem menuItemEditFUp;
		private System.Windows.Forms.MenuItem menuItemEditFirst;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemView;
		private LanMsg.Controls.OfficeMenus officeMenus1;
		private System.Windows.Forms.MenuItem menuItemEditDelRecord;
		private System.Windows.Forms.MenuItem menuItem5;
		private ClassFormMain FormMain =new ClassFormMain();

		public FormMsgMis()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            this.TV_user.ImageList=this.FormMain.formMain.imageList1;
			this.TV_user.Nodes[0].ImageIndex=17;this.TV_user.Nodes[0].SelectedImageIndex=17;
			this.TV_user.Nodes[1].ImageIndex=16;this.TV_user.Nodes[1].SelectedImageIndex=16;
			for(int i=0;i<this.TV_user.Nodes[0].Nodes.Count ;i++)
			{
				this.TV_user.Nodes[0].Nodes[i].ImageIndex=14;
                this.TV_user.Nodes[0].Nodes[i].SelectedImageIndex=15;
			}
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMsgMis));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menFileExport = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.meuFileExit = new System.Windows.Forms.MenuItem();
			this.menuItemEdit = new System.Windows.Forms.MenuItem();
			this.menuItemEditFirst = new System.Windows.Forms.MenuItem();
			this.menuItemEditFUp = new System.Windows.Forms.MenuItem();
			this.menuItemEditDown = new System.Windows.Forms.MenuItem();
			this.menuItemEditLast = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItemEditDelRecord = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItemEditCopy = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItemEditSelectAll = new System.Windows.Forms.MenuItem();
			this.menuItemView = new System.Windows.Forms.MenuItem();
			this.menViewRefresh = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.ButExit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.ButFirst = new System.Windows.Forms.ToolBarButton();
			this.ButUp = new System.Windows.Forms.ToolBarButton();
			this.ButDown = new System.Windows.Forms.ToolBarButton();
			this.ButLast = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.ButDelRecord = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.TV_user = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.RTBRecord = new LanMsg.MyExtRichTextBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItemCopy = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemSelectAll = new System.Windows.Forms.MenuItem();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.officeMenus1 = new LanMsg.Controls.OfficeMenus(this.components);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panel5.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemFile,
																					  this.menuItemEdit,
																					  this.menuItemView});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menFileExport,
																						 this.menuItem3,
																						 this.meuFileExit});
			this.menuItemFile.Text = "文件(&F)";
			// 
			// menFileExport
			// 
			this.menFileExport.Index = 0;
			this.menFileExport.Text = "导出(&O)";
			this.menFileExport.Visible = false;
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "-";
			this.menuItem3.Visible = false;
			// 
			// meuFileExit
			// 
			this.meuFileExit.Index = 2;
			this.meuFileExit.Text = "关闭(&E)";
			this.meuFileExit.Click += new System.EventHandler(this.meuFileExit_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.Index = 1;
			this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemEditFirst,
																						 this.menuItemEditFUp,
																						 this.menuItemEditDown,
																						 this.menuItemEditLast,
																						 this.menuItem4,
																						 this.menuItemEditDelRecord,
																						 this.menuItem5,
																						 this.menuItemEditCopy,
																						 this.menuItem7,
																						 this.menuItemEditSelectAll});
			this.menuItemEdit.Text = "编辑(&E)";
			// 
			// menuItemEditFirst
			// 
			this.menuItemEditFirst.Enabled = false;
			this.menuItemEditFirst.Index = 0;
			this.menuItemEditFirst.Text = "第一页(&F)";
			this.menuItemEditFirst.Click += new System.EventHandler(this.menuItemEditFirst_Click);
			// 
			// menuItemEditFUp
			// 
			this.menuItemEditFUp.Enabled = false;
			this.menuItemEditFUp.Index = 1;
			this.menuItemEditFUp.Text = "上一页(&P)";
			this.menuItemEditFUp.Click += new System.EventHandler(this.menuItemEditFUp_Click);
			// 
			// menuItemEditDown
			// 
			this.menuItemEditDown.Enabled = false;
			this.menuItemEditDown.Index = 2;
			this.menuItemEditDown.Text = "下一页(N)";
			this.menuItemEditDown.Click += new System.EventHandler(this.menuItemEditDown_Click);
			// 
			// menuItemEditLast
			// 
			this.menuItemEditLast.Enabled = false;
			this.menuItemEditLast.Index = 3;
			this.menuItemEditLast.Text = "最后一页(L)";
			this.menuItemEditLast.Click += new System.EventHandler(this.menuItemEditLast_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "-";
			// 
			// menuItemEditDelRecord
			// 
			this.menuItemEditDelRecord.Enabled = false;
			this.menuItemEditDelRecord.Index = 5;
			this.menuItemEditDelRecord.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.menuItemEditDelRecord.Text = "删除(&D)";
			this.menuItemEditDelRecord.Click += new System.EventHandler(this.menuItemEditDelRecord_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 6;
			this.menuItem5.Text = "-";
			// 
			// menuItemEditCopy
			// 
			this.menuItemEditCopy.Index = 7;
			this.menuItemEditCopy.Text = "复制(&C)";
			this.menuItemEditCopy.Click += new System.EventHandler(this.menuItemEditCopy_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 8;
			this.menuItem7.Text = "-";
			// 
			// menuItemEditSelectAll
			// 
			this.menuItemEditSelectAll.Index = 9;
			this.menuItemEditSelectAll.Text = "全选(&A)";
			this.menuItemEditSelectAll.Click += new System.EventHandler(this.menuItemEditSelectAll_Click);
			// 
			// menuItemView
			// 
			this.menuItemView.Index = 2;
			this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menViewRefresh});
			this.menuItemView.Text = "视图(&V)";
			this.menuItemView.Visible = false;
			// 
			// menViewRefresh
			// 
			this.menViewRefresh.Index = 0;
			this.menViewRefresh.Text = "刷新(&F)";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.ButExit,
																						this.toolBarButton1,
																						this.ButFirst,
																						this.ButUp,
																						this.ButDown,
																						this.ButLast,
																						this.toolBarButton2,
																						this.ButDelRecord});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(632, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// ButExit
			// 
			this.ButExit.ImageIndex = 18;
			this.ButExit.ToolTipText = "关闭";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// ButFirst
			// 
			this.ButFirst.Enabled = false;
			this.ButFirst.ImageIndex = 15;
			this.ButFirst.ToolTipText = "第一页";
			// 
			// ButUp
			// 
			this.ButUp.Enabled = false;
			this.ButUp.ImageIndex = 15;
			this.ButUp.ToolTipText = "上一页";
			// 
			// ButDown
			// 
			this.ButDown.Enabled = false;
			this.ButDown.ImageIndex = 14;
			this.ButDown.ToolTipText = "下一页";
			// 
			// ButLast
			// 
			this.ButLast.Enabled = false;
			this.ButLast.ImageIndex = 15;
			this.ButLast.ToolTipText = "最后一页";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// ButDelRecord
			// 
			this.ButDelRecord.Enabled = false;
			this.ButDelRecord.ImageIndex = 19;
			this.ButDelRecord.ToolTipText = "删除记录";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.White;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 403);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(632, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.MinWidth = 300;
			this.statusBarPanel1.Width = 416;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarPanel2.MinWidth = 200;
			this.statusBarPanel2.Width = 200;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(4, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(628, 4);
			this.panel2.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(4, 375);
			this.panel1.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(4, 399);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(628, 4);
			this.panel3.TabIndex = 5;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new System.Drawing.Point(628, 32);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(4, 367);
			this.panel4.TabIndex = 6;
			// 
			// TV_user
			// 
			this.TV_user.Dock = System.Windows.Forms.DockStyle.Left;
			this.TV_user.ImageIndex = -1;
			this.TV_user.Location = new System.Drawing.Point(4, 32);
			this.TV_user.Name = "TV_user";
			this.TV_user.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				new System.Windows.Forms.TreeNode("所有人员 ", new System.Windows.Forms.TreeNode[] {
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("部门"),
																																								   new System.Windows.Forms.TreeNode("未知")}),
																				new System.Windows.Forms.TreeNode("通知消息")});
			this.TV_user.SelectedImageIndex = -1;
			this.TV_user.Size = new System.Drawing.Size(148, 367);
			this.TV_user.TabIndex = 7;
			this.TV_user.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_user_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(152, 32);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 367);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel5.Controls.Add(this.tabControl1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(156, 32);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(472, 367);
			this.panel5.TabIndex = 9;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(468, 363);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.RTBRecord);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(460, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "对话记录";
			// 
			// RTBRecord
			// 
			this.RTBRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RTBRecord.ContextMenu = this.contextMenu1;
			this.RTBRecord.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTBRecord.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.RTBRecord.HiglightColor = LanMsg.RtfColor.White;
			this.RTBRecord.Location = new System.Drawing.Point(0, 0);
			this.RTBRecord.Name = "RTBRecord";
			this.RTBRecord.ReadOnly = true;
			this.RTBRecord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.RTBRecord.Size = new System.Drawing.Size(460, 338);
			this.RTBRecord.TabIndex = 45;
			this.RTBRecord.Text = "";
			this.RTBRecord.TextColor = LanMsg.RtfColor.Black;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemCopy,
																						 this.menuItem2,
																						 this.menuItemSelectAll});
			// 
			// menuItemCopy
			// 
			this.menuItemCopy.Index = 0;
			this.menuItemCopy.Text = "复制(&C)";
			this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItemSelectAll
			// 
			this.menuItemSelectAll.Index = 2;
			this.menuItemSelectAll.Text = "全选(&A)";
			this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.listView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(460, 338);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "基本资料";
			this.tabPage2.Visible = false;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(460, 338);
			this.listView1.TabIndex = 11;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "项目";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "内容";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "备注";
			this.columnHeader3.Width = 200;
			// 
			// officeMenus1
			// 
			this.officeMenus1.ImageList = null;
			// 
			// FormMsgMis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 425);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.TV_user);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "FormMsgMis";
			this.Text = "信息管理器";
			this.Load += new System.EventHandler(this.FormMsgMis_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panel5.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void meuFileExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormMsgMis_Load(object sender, System.EventArgs e)
		{
			this.officeMenus1.Start(this);
			this.TV_user.ImageList=this.FormMain.formMain.imageList1;
			TvRefresh();
		}
		 
		private void TvRefresh()
		{
			foreach(LanMsg.ClassUserInfo userinfo in this.FormMain.formMain.MyUsers)
			{
				System.Windows.Forms.TreeNode Node=new TreeNode();
				Node=(userinfo.Node.Clone() as TreeNode);
				TV_user.Nodes[0].Nodes[userinfo.Dep].Nodes.Add(Node);
				Node.Parent.Tag=userinfo.DepInfo;
				Node.Parent.Text=userinfo.DepInfo +"("+Node.Parent.Nodes.Count+")";
			}
		}

		private void TV_user_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.RTBRecord.Clear();

			this.ButLast.Enabled=false;
			this.ButDown.Enabled=false;
			this.ButFirst.Enabled=false;
			this.ButUp.Enabled=false;
			this.ButDelRecord.Enabled=false;
            
			this.menuItemEditFirst.Enabled=false;
			this.menuItemEditFUp.Enabled=false;
			this.menuItemEditDown.Enabled=false;
			this.menuItemEditLast.Enabled=false;
			this.menuItemEditDelRecord.Enabled=false;

			this.PageCount=0;
			this.CurrPage=0;
            this.firstID =0;
			this.LastID=2147483647;

            this.statusBar1.Panels[0].Text="正在查看对话记录";

			if(e.Node.Parent !=null && e.Node.Parent.Parent!=null)
			{
				LanMsg.ClassUserInfo userinfo=this.FormMain.formMain.findUser(e.Node.Tag.ToString());
				
				CurrUser=userinfo.ID;

				if(userinfo!=null)
					this.statusBar1.Panels[0].Text="查看与"+userinfo.DepInfo +" "+ userinfo.UserName +"("+userinfo.ID+") 的对话记录";
				else
				    this.statusBar1.Panels[0].Text="查看与("+e.Node.Tag.ToString()+")的对话记录";

				this.PageCount =GetPageCount(e.Node.Tag.ToString(),this.FormMain.formMain.selfInfo.ID,true);
				if(this.PageCount>0)
					DBRecordToRichTextBox(CurrUser,this.FormMain.formMain.selfInfo.ID,true,false,true,false);
			}
			else if(e.Node.Parent ==null && e.Node.Nodes.Count==0)
			{
                CurrUser=this.FormMain.formMain.selfInfo.ID;
				this.statusBar1.Panels[0].Text="查看所有通知消息记录";
				this.PageCount =GetPageCount(this.FormMain.formMain.selfInfo.ID,this.FormMain.formMain.selfInfo.ID,false);
				if(this.PageCount>0)
					DBRecordToRichTextBox(CurrUser,CurrUser,false,false,true,false);
			}

			this.statusBar1.Panels[1].Text="第"+this.CurrPage.ToString()+"页(共"+ this.PageCount.ToString() +"页)";
		}

		public void selectID(string ID)
		{
			if(ID=="")return;
			if(ID=="Notice")this.TV_user.SelectedNode=this.TV_user.Nodes[1];
			else
			{
              for(int i=0;i<this.TV_user.Nodes[0].Nodes.Count ;i++)
                foreach(System.Windows.Forms.TreeNode node in TV_user.Nodes[0].Nodes[i].Nodes)
					if(node.Tag.ToString()==ID)
					{
						node.Parent.Expand();
						this.TV_user.SelectedNode=node;
			            return;
					}
			}
		}

		public int CurrPage=0;//当前浏览的页
		public int PageCount=0;//页的总数
		public int pageSize=20;//每一页显示的记录数
		public int firstID=0;
		public int LastID=2147483647;
        public string CurrUser="";
        

		private int GetPageCount(string userID,string MyID,bool IsNotNotice)//获得页数
		{
			string DBtable="Notice";
			string sql="select Null from ["+DBtable+"] where (sendID='"+ MyID +"' or ReceiveID='"+ MyID +"')";

			if(IsNotNotice)
			{
				DBtable="MsgRecord";
				sql="select Null from ["+DBtable+"] where (sendID='"+ userID +"' and ReceiveID='"+ MyID +"') or (sendID='"+ MyID +"' and ReceiveID='"+ userID +"')";

			}
			int rows=new ClassOptionData(new ClassFormMain().ConStr).ExSQLR(sql);
			int count=Convert.ToInt32(rows/this.pageSize);
			if((rows % this.pageSize)!=0)
               count += 1;
			return count;
		}
 
		private void DBRecordToRichTextBox(string userID,string MyID,bool IsNotNotice,bool IsDown,bool IsFirst,bool IsLast)
		{

			this.RTBRecord.Clear();

			string DBtable="Notice";
			string Qualification=" (sendID='"+ MyID +"' or ReceiveID='"+ MyID +"')";
			string sql="";
            
            

			if(IsNotNotice)
			{
				DBtable="MsgRecord";
				Qualification=" ((sendID='"+ userID +"' and ReceiveID='"+ MyID +"') or (sendID='"+ MyID +"' and ReceiveID='"+ userID +"'))";
			}

           
			if(IsDown)
			{
				this.CurrPage++;
                sql="select top "+ this.pageSize.ToString() +" * from ["+DBtable+"] where "+Qualification+" and ID<"+ this.LastID.ToString() +"  ORDER BY ID DESC";
			}
			else
			{
				this.CurrPage--;
				sql="select * from ["+DBtable+"] where ID in(select top "+ this.pageSize.ToString() +" ID from ["+DBtable+"] where "+Qualification+" and ID>"+ this.firstID.ToString() +")  ORDER BY ID DESC";//+"  ORDER BY ID DESC";
			}

			if(IsFirst) 
			{
			    this.CurrPage=1;
				sql="select top "+ this.pageSize.ToString() +" * from ["+DBtable+"] where "+Qualification+" ORDER BY ID DESC";
			}
			if(IsLast)
			{
			    this.CurrPage=this.PageCount;
				int mod=this.PageCount % this.pageSize;
				if( mod!=0)
				  sql="select * from ["+DBtable+"] where ID in(select top "+ mod +" ID from ["+DBtable+"] where "+Qualification+") ORDER BY ID DESC";
				else
                  sql="select * from ["+DBtable+"] where ID in(select top "+ this.pageSize.ToString() +" ID from ["+DBtable+"] where "+Qualification+"  ORDER BY ID DESC";
			}

			this.ButLast.Enabled=true;
			this.ButDown.Enabled=true;
			this.ButFirst.Enabled=true;
			this.ButUp.Enabled=true;
			this.ButDelRecord.Enabled=true;

			this.menuItemEditFirst.Enabled=true;
			this.menuItemEditFUp.Enabled=true;
			this.menuItemEditDown.Enabled=true;
			this.menuItemEditLast.Enabled=true;
            this.menuItemEditDelRecord.Enabled=true;

			if(this.CurrPage==this.PageCount)
			{
			   this.ButLast.Enabled=false;
			   this.ButDown.Enabled=false;
				this.menuItemEditDown.Enabled=false;
				this.menuItemEditLast.Enabled=false;

			}
			if(this.CurrPage==1)
			{
			    this.ButFirst.Enabled=false;
				this.ButUp.Enabled=false;
				this.menuItemEditFirst.Enabled=false;
				this.menuItemEditFUp.Enabled=false;
			}
            

			System.Data.OleDb.OleDbDataReader dr=new ClassOptionData(new ClassFormMain().ConStr ).ExSQLReDr(sql);
			
			LanMsg.ClassUserInfo sendUserInfo=this.FormMain.formMain.selfInfo ;
        
			int i=0;
            bool IsSend=false;//标识此消息是否是对方发送的

			if(dr!=null)
			{
				while(dr.Read())
				{
					if(i==0)
						this.firstID=Convert.ToInt32(dr["ID"]);
					i++;

					IsSend=false;//标识此消息否是对方发送的

					sendUserInfo=null;
					LanMsg.MyExtRichTextBox rich=new MyExtRichTextBox();
					rich.ForeColor=Color.Blue;

					sendUserInfo=this.FormMain.formMain.findUser(Convert.ToString(dr["sendID"]).Trim());

					if(sendUserInfo!=null && sendUserInfo.ID==userID)
					{
						rich.ForeColor=Color.Red;
						IsSend=true;//此消息为对方发送的
					}

					rich.AppendText(sendUserInfo.UserName  + "("+sendUserInfo.ID +")" + Convert.ToString(dr["msgDateTime"]));
					this.RTBRecord.AppendRtf(rich.Rtf);
					rich.Clear();
					rich.Dispose();

					this.RTBRecord.AppendTextAsRtf("    ");

					if(IsNotNotice)
						textMsgToRich(Convert.ToString(dr["msgContent"]),Convert.ToString(dr["imageInfo"]),IsSend);
					else
						this.RTBRecord.AppendText(Convert.ToString(dr["msgContent"])+"\n");


					LastID=Convert.ToInt32(dr["ID"]);
				}
				dr.Close();
			}
			this.statusBar1.Panels[1].Text="第"+this.CurrPage.ToString()+"页(共"+ this.PageCount.ToString() +"页)";

		}

		private void textMsgToRich(string msgContent,string ImageInfo,bool IsSend)//添加文本消息与图片到richBox
		{
            LanMsg.ClassTextMsg textMsg=new ClassTextMsg();
			textMsg.MsgContent=msgContent;
			textMsg.ImageInfo=ImageInfo;
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
					System.Drawing.Image image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources.ErrorImage.GIF")) ; 
						
//					LanMsg.MyPicture pic=new MyPicture();
//					pic.BackColor=this.RTBRecord.BackColor;
//					pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize; 
					if(Convert.ToUInt32(imageContent[1])<96)
//						pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ imageContent[1] +".gif")) ; 
				      image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources."+ imageContent[1] +".gif")) ; 
					else
					{
					    if(IsSend && new System.IO.FileInfo(Application.StartupPath +"\\ArrivalImage\\"+ imageContent[1] +".gif").Exists)
					        image=System.Drawing.Image.FromFile(Application.StartupPath +"\\ArrivalImage\\"+ imageContent[1] +".gif");
						else if(!IsSend && new System.IO.FileInfo(Application.StartupPath +"\\sendImage\\"+ imageContent[1] +".gif").Exists)
					        image=System.Drawing.Image.FromFile(Application.StartupPath +"\\sendImage\\"+ imageContent[1] +".gif");

//						pic.Tag=imageContent[1];
//						pic.Image=System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources.ErrorImage.GIF")) ;
					}

                    this.RTBRecord.InsertImage(image);
//					this.RTBRecord.InsertMyControl(pic);

					addPos ++;
				}
				this.RTBRecord.AppendText(textMsg.MsgContent.Substring(textPos,textMsg.MsgContent.Length-textPos) +"\n");
			}
			else//如果消息中没有图片，则直接添加消息文本
			{
				this.RTBRecord.AppendText(textMsg.MsgContent +"\n");
			}
		}


		private void delRecord(bool IsNotNotice)
		{
			if(MessageBox.Show("确定要删除当前的所有对话记录吗?","提示",System.Windows.Forms.MessageBoxButtons.YesNoCancel,System.Windows.Forms.MessageBoxIcon.Question)!=System.Windows.Forms.DialogResult.Yes)return;
			string DBtable="Notice";
			if(IsNotNotice)
			{
				DBtable="MsgRecord";
			}
            string sql="delete * from ["+DBtable+"] where (sendID='"+ this.CurrUser  +"' or ReceiveID='"+ this.CurrUser +"')";
		    new ClassOptionData(new ClassFormMain().ConStr).ExSQL(sql);
			this.RTBRecord.Clear();
			this.ButDelRecord.Enabled=false;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			bool t=true;
            if(this.TV_user.Nodes[1].IsSelected )t=false;

			switch(e.Button.ToolTipText)
			{
				case "第一页":
					DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,true,false);
					break;
				case "上一页":
					DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,false,false);
					break;
				case "下一页":
					DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,true,false,false);
					break;
				case "最后一页":
					DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,false,true);
					break;
				case "关闭":
					this.Dispose();
					break;
				case "删除记录":
					delRecord(t);			
					break;
			}
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{
			this.RTBRecord.Copy();
		}

		private void menuItemSelectAll_Click(object sender, System.EventArgs e)
		{
			this.RTBRecord.SelectAll();
		}

		private void menuItemEditCopy_Click(object sender, System.EventArgs e)
		{
		  this.RTBRecord.Copy();
		}

		private void menuItemEditSelectAll_Click(object sender, System.EventArgs e)
		{
		   this.RTBRecord.Focus();
		  this.RTBRecord.SelectAll();
		}

		private void menuItemEditFirst_Click(object sender, System.EventArgs e)
		{
			bool t=true;
			if(this.TV_user.Nodes[1].IsSelected )t=false;

			DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,true,false);
		}

		private void menuItemEditFUp_Click(object sender, System.EventArgs e)
		{
			bool t=true;
			if(this.TV_user.Nodes[1].IsSelected )t=false;

			DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,false,false);
		}

		private void menuItemEditDown_Click(object sender, System.EventArgs e)
		{
			bool t=true;
			if(this.TV_user.Nodes[1].IsSelected )t=false;

			DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,true,false,false);
		
		}

		private void menuItemEditLast_Click(object sender, System.EventArgs e)
		{
			bool t=true;
			if(this.TV_user.Nodes[1].IsSelected )t=false;

			DBRecordToRichTextBox(this.CurrUser,this.FormMain.formMain.selfInfo.ID,t,false,false,true);
		
		}

		private void menuItemEditDelRecord_Click(object sender, System.EventArgs e)
		{
			bool t=true;
			if(this.TV_user.Nodes[1].IsSelected )t=false;
			delRecord(t);			
		}
	}
}
