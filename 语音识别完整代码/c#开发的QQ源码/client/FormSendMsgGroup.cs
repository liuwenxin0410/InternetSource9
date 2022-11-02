using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LanMsg
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FormSendMsgGroup : DevComponents.DotNetBar.Office2007RibbonForm 
	{
		private DevComponents.DotNetBar.RibbonControl ribbonControl1;
		private DevComponents.Editors.ComboItem comboItem1;
		private DevComponents.Editors.ComboItem comboItem2;
		private DevComponents.Editors.ComboItem comboItem3;
		private DevComponents.DotNetBar.Bar bar1;
		private DevComponents.DotNetBar.LabelItem labelItem1;
		private DevComponents.DotNetBar.ComboBoxItem comboBoxInfoClass;
		private DevComponents.Editors.ComboItem comb1;
		private DevComponents.Editors.ComboItem comb3;
		private DevComponents.DotNetBar.ButtonItem butSendMsg;
		private System.ComponentModel.IContainer components;
		private DevComponents.DotNetBar.ButtonItem butSave;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private LanMsg.MyExtRichTextBox RTBSendContent;
		private DevComponents.DotNetBar.ButtonItem buttonItem1;
		private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
		private DevComponents.DotNetBar.DockSite barLeftDockSite;
		private DevComponents.DotNetBar.DockSite barRightDockSite;
		private DevComponents.DotNetBar.DockSite barTopDockSite;
		private DevComponents.DotNetBar.DockSite barBottomDockSite;
		private ClassFormMain FormMain =new ClassFormMain();

		public FormSendMsgGroup()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            this.comboBoxInfoClass.SelectedIndex=0;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			FormMain.formMain.forms.Romove(this);
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSendMsgGroup));
			this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
			this.butSave = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
			this.comboItem1 = new DevComponents.Editors.ComboItem();
			this.comboItem2 = new DevComponents.Editors.ComboItem();
			this.comboItem3 = new DevComponents.Editors.ComboItem();
			this.bar1 = new DevComponents.DotNetBar.Bar();
			this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
			this.comboBoxInfoClass = new DevComponents.DotNetBar.ComboBoxItem();
			this.comb1 = new DevComponents.Editors.ComboItem();
			this.comb3 = new DevComponents.Editors.ComboItem();
			this.butSendMsg = new DevComponents.DotNetBar.ButtonItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.RTBSendContent = new LanMsg.MyExtRichTextBox();
			this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
			this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
			this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
			this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
			this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
			((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.BackColor = System.Drawing.SystemColors.Control;
			this.ribbonControl1.CaptionVisible = true;
			this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ribbonControl1.DockPadding.Bottom = 2;
			this.ribbonControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
																						  this.butSave});
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
			this.ribbonControl1.TabIndex = 43;
			// 
			// butSave
			// 
			this.butSave.Icon = ((System.Drawing.Icon)(resources.GetObject("butSave.Icon")));
			this.butSave.Name = "butSave";
			this.butSave.Tooltip = "消息另存为";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// buttonItem1
			// 
			this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
			this.buttonItem1.Name = "buttonItem1";
			this.buttonItem1.Text = "buttonItem1";
			// 
			// comboItem1
			// 
			this.comboItem1.Text = "通知";
			// 
			// comboItem2
			// 
			this.comboItem2.Text = "消息(需要回复内容)";
			// 
			// comboItem3
			// 
			this.comboItem3.Text = "通知(需要确认收到)";
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
																				this.comboBoxInfoClass,
																				this.butSendMsg});
			this.bar1.ItemSpacing = 2;
			this.bar1.Location = new System.Drawing.Point(2, 323);
			this.bar1.Name = "bar1";
			this.bar1.Size = new System.Drawing.Size(496, 25);
			this.bar1.Stretch = true;
			this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar1.TabIndex = 48;
			this.bar1.TabStop = false;
			this.bar1.Text = "barStatus";
			// 
			// labelItem1
			// 
			this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.None;
			this.labelItem1.Name = "labelItem1";
			this.labelItem1.PaddingLeft = 4;
			this.labelItem1.Text = "发送类别：";
			// 
			// comboBoxInfoClass
			// 
			this.comboBoxInfoClass.ItemHeight = 14;
			this.comboBoxInfoClass.Items.AddRange(new object[] {
																   this.comb1,
																   this.comb3});
			this.comboBoxInfoClass.Name = "comboBoxInfoClass";
			this.comboBoxInfoClass.Stretch = true;
			// 
			// comb1
			// 
			this.comb1.Text = "通知";
			// 
			// comb3
			// 
			this.comb3.Text = "普通消息";
			// 
			// butSendMsg
			// 
			this.butSendMsg.Name = "butSendMsg";
			this.butSendMsg.Text = " 发送(&S)";
			this.butSendMsg.Click += new System.EventHandler(this.butSendMsg_Click);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(2, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(8, 299);
			this.panel1.TabIndex = 49;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(490, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(8, 299);
			this.panel2.TabIndex = 50;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(480, 8);
			this.panel3.TabIndex = 51;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(10, 315);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(480, 8);
			this.panel4.TabIndex = 52;
			// 
			// RTBSendContent
			// 
			this.dotNetBarManager1.SetContextMenuEx(this.RTBSendContent, "ButtonItem1");
			this.RTBSendContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTBSendContent.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.RTBSendContent.HiglightColor = LanMsg.RtfColor.White;
			this.RTBSendContent.Location = new System.Drawing.Point(10, 32);
			this.RTBSendContent.MaxLength = 1000;
			this.RTBSendContent.Name = "RTBSendContent";
			this.RTBSendContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.RTBSendContent.Size = new System.Drawing.Size(480, 283);
			this.RTBSendContent.TabIndex = 53;
			this.RTBSendContent.Text = "";
			this.RTBSendContent.TextColor = LanMsg.RtfColor.Black;
			this.RTBSendContent.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RTBSendContent_LinkClicked);
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
			this.dotNetBarManager1.DefinitionName = "FormSendMsgGroup.dotNetBarManager1.xml";
			this.dotNetBarManager1.EnableFullSizeDock = false;
			this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
			this.dotNetBarManager1.ParentForm = this;
			this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
			this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
			this.dotNetBarManager1.ThemeAware = false;
			this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
			this.dotNetBarManager1.ItemClick += new System.EventHandler(this.dotNetBarManager1_ItemClick);
			// 
			// barLeftDockSite
			// 
			this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
			this.barLeftDockSite.Location = new System.Drawing.Point(2, 2);
			this.barLeftDockSite.Name = "barLeftDockSite";
			this.barLeftDockSite.NeedsLayout = false;
			this.barLeftDockSite.Size = new System.Drawing.Size(0, 346);
			this.barLeftDockSite.TabIndex = 54;
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
			this.barRightDockSite.TabIndex = 55;
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
			this.barTopDockSite.TabIndex = 56;
			this.barTopDockSite.TabStop = false;
			// 
			// barBottomDockSite
			// 
			this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barBottomDockSite.Location = new System.Drawing.Point(2, 348);
			this.barBottomDockSite.Name = "barBottomDockSite";
			this.barBottomDockSite.NeedsLayout = false;
			this.barBottomDockSite.Size = new System.Drawing.Size(496, 0);
			this.barBottomDockSite.TabIndex = 57;
			this.barBottomDockSite.TabStop = false;
			// 
			// FormSendMsgGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(500, 350);
			this.Controls.Add(this.RTBSendContent);
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
			this.Name = "FormSendMsgGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "消息群发";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSendMsgGroup_Closing);
			((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void butSendMsg_Click(object sender, System.EventArgs e)
		{
			if(this.RTBSendContent.Text.Trim()=="")
			{
					MessageBox.Show("不能发送空消息。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				    return;
			}
			this.FormMain.formMain.MsgAddToDB(this.RTBSendContent.Text.TrimEnd(),this.FormMain.formMain.selfInfo.ID,"",this.FormMain.formMain.selfInfo.AssemblyVersion ,System.DateTime.Now.ToString(),"",false);
            this.FormMain.formMain.sendNotice(new Controls.ClassMsg(7,"",System.Text.Encoding.Unicode.GetBytes(this.RTBSendContent.Text.TrimEnd())));
			MessageBox.Show("消息已经发送。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.RTBSendContent.Clear();
			this.Close();
			this.Dispose();
		}

		private void butSave_Click(object sender, System.EventArgs e)
		{
		   System.Windows.Forms.SaveFileDialog fd=new SaveFileDialog ();
			fd.Filter="写字板文档(*.rtf)|*.rtf";
			if(fd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
                this.RTBSendContent.SaveFile(fd.FileName,System.Windows.Forms.RichTextBoxStreamType.RichText );
			}
		}

		private void FormSendMsgGroup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			FormMain.formMain.TvUsers.CheckBoxes=false;
		}

		private void RTBSendContent_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
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

		private void dotNetBarManager1_ItemClick(object sender, System.EventArgs e)
		{
			switch((sender as DevComponents.DotNetBar.ButtonItem ).Name )
			{
				case "复制"	:
					if(this.RTBSendContent.Focus())
						this.RTBSendContent.Copy (); 
					break;
				case "粘贴"	:
					if(this.RTBSendContent.Focus())
						this.RTBSendContent.Paste (); 
					break;
				case "全选"	:
					if(this.RTBSendContent.Focus())
						this.RTBSendContent.SelectAll (); 
					break;
				case "剪切"	:
					if(this.RTBSendContent.Focus())
						this.RTBSendContent.Cut (); 
					break;

			}		
		}

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>


	}
}
