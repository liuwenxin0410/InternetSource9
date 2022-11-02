//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace ControlVault.MenuSuite {

	#region Summary
	/// <summary>
	/// Implements custom painting for a Main Menu
	/// </summary>	
	[ProvideProperty("ImageIndex", typeof(Component)) ]
	[DefaultProperty("ImageList")]
	[ToolboxBitmap(typeof(MenuEx))]
	#endregion

	public class MenuEx : Component, IExtenderProvider {
	
		#region Private Constants
		private const int MIM_BACKGROUND = 0x2;
		private const int WM_NCPAINT = 0x0085;
		#endregion

		#region Private Variables
		private System.ComponentModel.Container components = null;				
		private ImageList imageList;
		private Hashtable hashTable = new Hashtable();		
		private IMenuPainter menuPainter;		
		private Form form;		
		private MainMenu mainMenu;
		private IntPtr BarBrush;
		private Bitmap barBitmap = null;		
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the MenuEx class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public MenuEx(System.ComponentModel.IContainer container) {
			container.Add(this);			
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the MenuEx class.
		/// </summary>		
		public MenuEx() {
			InitializeComponent();
		}
		#endregion

		#region Private Methods

		/// <summary>
		/// Find the <see cref="MainMenu"/> on the owning <see cref="Form"/>. If a MainMenu is found, create the 
		/// <see cref="Bitmap"/> used for the painting of the Menu Bar, and attach to the <see cref="Control.Resize"/> event
		/// of the Form in order to recreate the bitmap when the form is resized.
		/// </summary>
		/// <param name="item">A <see cref="MenuItem"/> object, used to find the MainMenu object.</param>
		private void CheckForm(MenuItem item) {
			if ((mainMenu == null) && (item != null)) {
				mainMenu = item.GetMainMenu();								
				if (mainMenu != null) {
					form = mainMenu.GetForm();
					if (form != null) {			
						if (menuPainter != null) {
							RecreateBitmap();							
						}
						
						form.Resize +=new EventHandler(form_Resize);
					}
				}
			}						
		}

		/// <summary>
		/// Creates a Pattern Brush from the internal barBitmap object, and notifies Windows that this is to be used
		/// for painting the Menu Bar
		/// </summary>
		private void SetBrush() {
			BarBrush = SafeNativeMethods.CreatePatternBrush(barBitmap.GetHbitmap());

			MENUINFO mi = new MENUINFO(form);
			mi.fMask = MIM_BACKGROUND;
			mi.hbrBack = BarBrush;

			SafeNativeMethods.SetMenuInfo(mainMenu.Handle, ref mi);	
			SafeNativeMethods.SendMessage(form.Handle, WM_NCPAINT, 0, 0);
		}

		/// <summary>
		/// Re-creates the bitmap used for painting the menu bar.
		/// </summary>
		private void RecreateBitmap() {
			if ((form != null) && (menuPainter != null)) {
				if (barBitmap != null) {
					barBitmap.Dispose();
				}

				Rectangle r= new Rectangle(0, 0, form.Width, SystemInformation.MenuHeight);

				// Dispose of the brush used for painting the bar.
				if (BarBrush != IntPtr.Zero) {
					SafeNativeMethods.DeleteObject(BarBrush);
					BarBrush = IntPtr.Zero;
				}

				// Recreate the bitmap, then call the menuPainter to draw the bitmap.
				barBitmap = new Bitmap(form.Width, SystemInformation.MenuHeight);

				using (Graphics g = Graphics.FromImage(barBitmap)) {										
					menuPainter.PaintBar(g, new Rectangle(0, 0, form.Width, SystemInformation.MenuHeight));
				}

				// Re-create the brush and notify Windows
				SetBrush();
			}																			
		}

		/// <summary>
		/// Forces re-creation of the Menu Bar bitmap when the form is resized.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> which triggered this event.</param>
		/// <param name="e">An <see cref="EventArgs"/> object providing data for this event.</param>
		private void form_Resize(object sender, EventArgs e) {
			RecreateBitmap();
		}

		/// <summary>
		/// Event handler for each MenuItem's MeasureItem event.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> which triggered this event.</param>
		/// <param name="e">A <see cref="MeasureItemEventArgs"/> object providing data for this event.</param>
		private void MeasureMenuItem(object sender, MeasureItemEventArgs e) {			
			if (menuPainter != null) {
				MenuItem item = (MenuItem) sender;
				CheckForm(item);
				menuPainter.MeasureItem(item, e, GetImageSize());
			}
		}

		/// <summary>
		/// Event Handler for each MenuItem's DrawItem event;
		/// </summary>
		/// <param name="sender">The <see cref="object"/> which triggered this event.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this event.</param>
		private void DrawMenuItem( Object sender, DrawItemEventArgs e ) {			
			if (menuPainter != null) {
				MenuItem item = (MenuItem) sender;
				Image img = GetImage(item);
				menuPainter.PaintItem(item, e, img, GetImageSize());
			}			
		}

		/// <summary>
		/// Gets the image associated with a MenuItem
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/> for which the image is required.</param>
		/// <returns>An <see cref="Image"/> object</returns>
		private Image GetImage(MenuItem item) {
			if (imageList != null) {
				int ix = GetImageIndex(item);
				if (ix >= 0 && ix < imageList.Images.Count) {
					return imageList.Images[ix];
				}
			}
			return null;
		}

		/// <summary>
		/// Returns an appropriate size for the menu images.
		/// </summary>
		/// <returns>A <see cref="MenuImageSize"/> value</returns>
		private MenuImageSize GetImageSize() {
			if (imageList == null) {
				return MenuImageSize.None;
			}
			else {
				if (imageList.ImageSize.Height <= 16) {
					return MenuImageSize.Small;
				}
				else if (imageList.ImageSize.Height <= 24) {
					return MenuImageSize.Medium;
				}
				else if (imageList.ImageSize.Height <= 32) {
					return MenuImageSize.Large;
				}
				else {
					return MenuImageSize.ExtraLarge;
				}
			}
		}
						
		#endregion

		#region Protected Methods
		/// <summary> 
		/// Cleans up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				SafeNativeMethods.DeleteObject(BarBrush);
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Forcibly recreates the menu bar bitmap. 
		/// </summary>
		public void RefreshBar() {
			RecreateBitmap();
		}

		
		/// <summary>
		/// Allows manual attachment of menu items to the painter.
		/// </summary>
		/// <param name="items">A <see cref="MenuItem"/> array containing a list of items to be attached.</param>
		public void Attach(MenuItem[] items) {			
			foreach (MenuItem item in items) {
				if (item != null) {
					item.OwnerDraw = true ;
					item.MeasureItem += new MeasureItemEventHandler(MeasureMenuItem) ;
					item.DrawItem  += new DrawItemEventHandler(DrawMenuItem) ;
				}
			}
		}

		/// <summary>
		/// Allows manual attachment of menu items to the painter.
		/// </summary>
		/// <param name="items">A <see cref="MenuItem"/> array containing a list of items to be attached.</param>
		public void Attach(System.Windows.Forms.Menu.MenuItemCollection items) {			
			foreach (MenuItem item in items) {
				if (item != null) {
					item.OwnerDraw = true ;
					item.MeasureItem += new MeasureItemEventHandler(MeasureMenuItem) ;
					item.DrawItem  += new DrawItemEventHandler(DrawMenuItem) ;
				}
			}
		}
		#endregion

		#region Properties		
		/// <summary>
		/// Gets or sets the <see cref="ImageList"/> which is used to hold menu images.
		/// </summary>
		/// <value>An <see cref="ImageList"/> which is used to hold menu images.</value>
		[DefaultValue(null)]
		[Category("Appearance")]
		[Description("The ImageList used to draw menu images.")]
		public ImageList ImageList {
			get { return imageList ;  }
			set { imageList = value; }		
		}
		

		/// <summary>
		/// Gets or sets the painter to use when drawing the menu items.
		/// </summary>
		/// <value>An <see cref="IMenuPainter"/> used to draw the menu items.</value>
		[Category("Appearance")]
		[Description("The IMenuPainter used to draw the menu items.")]
		[DefaultValue(null)]
		public IMenuPainter MenuPainter {
			get { return menuPainter ;  }
			set { 
				menuPainter = value; 								
				RecreateBitmap();				
			}
		}
				
		
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region IExtenderProvider Members
		/// <summary>
		/// Indicates the type of object for which extended properties are provided.
		/// </summary>
		/// <param name="extendee">An <see cref="object"/> which is to be considered for extended properties.</param>
		/// <returns><b>true</b> if the object is to have extended properties, otherwise <b>false</b>.</returns>
		public bool CanExtend(object extendee) {			
			return extendee is MenuItem;
		}

		/// <summary>
		/// Gets the ImageIndex property for a given menuitem
		/// </summary>
		/// <param name="component">The <see cref="Component"/> for which the ImageIndex property is required</param>
		/// <returns>An <see cref="int"/> giving the image index.</returns>		
		[Category("Appearance")]
		public int GetImageIndex(Component component) {
			if (component != null && hashTable != null) {
				if (hashTable.ContainsKey(component)) {
					return (int)hashTable[component];
				}
			}
			return -1;			
		}

		/// <summary>
		/// Sets the ImageIndex property for a given Menucomponent
		/// </summary>
		/// <param name="component">The <see cref="Component"/> for which the ImageIndex property is required</param>
		/// <param name="value">An <see cref="int"/> giving the image index.</param>
		public void SetImageIndex(Component component, int value) {			
			if (component != null && hashTable != null) {
				hashTable[component] = value;

				MenuItem item = component as MenuItem;				

					
				if (value == -2) {					
					item.OwnerDraw = false;
					return;
				}
			
				item.OwnerDraw = true ;
				item.MeasureItem += new MeasureItemEventHandler(MeasureMenuItem) ;
				item.DrawItem  += new DrawItemEventHandler(DrawMenuItem) ;
			}
		}     


		#endregion

		
	}
	
}
