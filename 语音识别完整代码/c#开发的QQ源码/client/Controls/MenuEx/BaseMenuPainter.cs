//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ControlVault.MenuSuite
{
	#region Summary
	/// <summary>
	/// Base component for MenuPainter implementations
	/// </summary>
	[ToolboxItem(false)]
	#endregion

	public class BaseMenuPainter : Component, IMenuPainter
	{

		#region Protected Constants
		/// <summary>
		/// Size of the Check Box area on a menu item
		/// </summary>
		protected const int CHECK_SIZE = 16;		
		/// <summary>
		/// Height of a MenuItem separator
		/// </summary>
		protected const int MENU_SEPARATOR_HEIGHT = 2;		
		/// <summary>
		/// Buffer to add to a MenuItem height
		/// </summary>
		protected const int MENU_BORDER_SIZE = 6;
		/// <summary>
		/// Buffer around a menu item image
		/// </summary>
		protected const int IMAGE_BUFFER = 8;
		/// <summary>
		/// Buffer to the left of a shortcut
		/// </summary>
		protected const int SHORTCUT_BUFFER = 20 ;
		/// <summary>
		/// Buffer to the right of a shortcut
		/// </summary>
		protected const int SHORTCUT_RIGHT_BUFFER = 15 ;
		/// <summary>
		/// Buffer after a top-level menu item
		/// </summary>
		protected const int TOPLEVEL_MENU_BUFFER = 11;
		/// <summary>
		/// Buffer to the left of menu item text
		/// </summary>
		protected const int TEXT_LEFT_BUFFER = 8;				
		/// <summary>
		/// Menu image size for small images
		/// </summary>
		protected const int SMALL_IMAGE_SIZE = 16;
		/// <summary>
		/// Menu image size for medium images
		/// </summary>
		protected const int MEDIUM_IMAGE_SIZE = 24;
		/// <summary>
		/// Menu image size for large images
		/// </summary>
		protected const int LARGE_IMAGE_SIZE = 32;
		/// <summary>
		/// Menu image size for extra-large images.
		/// </summary>
		protected const int EXTRA_LARGE_IMAGE_SIZE = 48;
		#endregion

		#region Private Variables
		private System.ComponentModel.Container components = null;		
		#endregion

		#region Protected Variables
		/// <summary>
		/// <see cref="StringFormat"/> object used to calculate menu sizes.
		/// </summary>
		protected StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic) ;		
		/// <summary>
		/// The <see cref="Image"/> used to draw the 'Check' for a checked menu item.
		/// </summary>
		protected Image checkImage;
		/// <summary>
		/// The <see cref="Image"/> used to draw the 'Radio Check' for a checked menu item.
		/// </summary>
		protected Image radioCheckImage;
		#endregion		

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the BaseMenuPainter class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public BaseMenuPainter(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			Initialize();		
		}

		/// <summary>
		/// Initializes a new instance of the BaseMenuPainter class.
		/// </summary>
		public BaseMenuPainter()
		{
			InitializeComponent();
   		Initialize();			
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Initializes the stringFormat and checkImage variables.
		/// </summary>
		private void Initialize() {			
			stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show ;
			Stream stream = GetResourceStream("Tick") ;
			if (stream != null) {
				checkImage = Image.FromStream(stream) ;
			}
			
			stream = null;

			stream = GetResourceStream("RadioCheck") ;
			if (stream != null) {
				radioCheckImage = Image.FromStream(stream) ;
			}
		}

		/// <summary>
		/// Returns a stream containing the specified icon resource
		/// </summary>
		/// <param name="iconName">A <see cref="string"/> containing the icon name.</param>
		/// <returns>A <see cref="Stream"/> containing the resource.</returns>
		private Stream GetResourceStream(string iconName) {
			return GetType().Assembly.GetManifestResourceStream(String.Format("ControlVault.MenuSuite.{0}.ico", iconName)) ;
		}
		

		/// <summary>
		/// Converts a <see cref="MenuImageSize"/> value to an appropriate integer value.
		/// </summary>
		/// <param name="imageSize">A <see cref="MenuImageSize"/> value to convert.</param>
		/// <returns>An <see cref="int"/> value giving the image size.</returns>
		private int GetImageHeight(MenuImageSize imageSize) {
			switch (imageSize) {
				case MenuImageSize.Small:
					return SMALL_IMAGE_SIZE;
				case MenuImageSize.Medium:
					return MEDIUM_IMAGE_SIZE;
				case MenuImageSize.Large:
					return LARGE_IMAGE_SIZE;
				case MenuImageSize.ExtraLarge:
					return EXTRA_LARGE_IMAGE_SIZE;
				default: 
					return  SMALL_IMAGE_SIZE;
			}
		}	
	
		
		/// <summary>
		/// Implementation of the IMenuPainter Paint method. 
		/// </summary>		
		/// <param name="item">The <see cref="MenuItem"/> to be painted.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this event.</param>
		/// <param name="image">An <see cref="Image"/> to draw in the menu item. This may be null.</param>
		/// <param name="imageSize">An <see cref="MenuImageSize"/> associated with the MenuItem. This indicates how large the icons are.</param>
		private void InternalPaintItem(MenuItem item, DrawItemEventArgs e, Image image, MenuImageSize imageSize) {						
			int sz = GetImageHeight(imageSize);			
				
			PaintBackground(item, e, item.Parent is MainMenu, sz);

			if (item.Text == "-") {
				PaintSeparator(e, sz);
			}
			else {
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
					PaintHighlight(item, e, item.Parent is MainMenu);
				}

				if (! (item.Parent is MainMenu)) {
					int checkSize = sz < CHECK_SIZE ? CHECK_SIZE : sz;
					if (item.Checked) {
						PaintCheck(item, e, false, checkSize);
					}
					else if (item.RadioCheck) {
						PaintCheck(item, e, true, checkSize);
					}
					else {
						if (image != null) {
							PaintImage(item, e, image, sz);
						}
					}
				}

				PaintText(item, e, sz);
			
				if (! (item.Parent is MainMenu)) {
					string shortcut = GetShortcutText(item);			

					if (shortcut != null) {
						PaintShortcut(item, e);
					}
				}
			}

		}

		/// <summary>
		/// Implementation of the IMenuPainter Measure method. 
		/// </summary>		
		/// <param name="item">The <see cref="MenuItem"/> to be painted.</param>
		/// <param name="e">A <see cref="MeasureItemEventArgs"/> object providing data for this event.</param>		
		/// <param name="imageSize">A <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the size of the image.</param>
		private void InternalMeasureItem(MenuItem item, MeasureItemEventArgs e, MenuImageSize imageSize) {
			MeasureMenuItem(item, e, imageSize);			
		}

		/// <summary>
		/// Paints the menu bar background
		/// </summary>
		/// <param name="g">A <see cref="Graphics"/> object to use when painting the background.</param>
		/// <param name="r">The bounding <see cref="Rectangle"/> for the paint operation</param>
		private void InternalPaintBar(Graphics g, Rectangle r) {
			PaintMenuBar(g, r);			
		}

		#endregion

		#region Protected Methods		
		/// <summary>		
		/// Calculates the height of a <see cref="MenuItem"/>
		/// </summary>
		/// <param name="item">A <see cref="MenuItem"/> for which the size is required.</param>
		/// <param name="imageSize">A <see cref="MenuImageSize"/> value indicating the size of the images.</param>
		/// <returns>An <see cref="int"/> value containing the calculated height of the menu item.</returns>
		protected virtual int CalculateItemHeight(MenuItem item, MenuImageSize imageSize) {
			if (item.Text == "-" )
				return MENU_SEPARATOR_HEIGHT ;
			else {								
				return GetImageHeight(imageSize) + MENU_BORDER_SIZE;				
			}
		}

		/// <summary>
		/// Gets the <see cref="Color"/> to be used to paint normal menu text.
		/// </summary>
		/// <returns>A <see cref="Color"/> to be used when painting text</returns>
		protected virtual Color GetTextColor(DrawItemState state) {
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled) {
				return SystemColors.GrayText;
			}
			else if ((state & DrawItemState.Selected) == DrawItemState.Selected) {
				return SystemColors.HighlightText;
			}
			else {
				return SystemColors.MenuText;
			}
		}

		
		/// <summary>
		/// Paints the menu bar background
		/// </summary>
		/// <param name="g">A <see cref="Graphics"/> object to use when painting the background.</param>
		/// <param name="r">The bounding <see cref="Rectangle"/> for the paint operation</param>
		protected virtual void PaintMenuBar(Graphics g, Rectangle r) {
			g.FillRectangle(SystemBrushes.Menu, r);			
		}


		/// <summary>
		/// Gets the shortcut text for a MenuItem
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/> for which a shortcut is required.</param>
		/// <returns>A <see cref="string"/> containing the shortcut text.</returns>
		protected string GetShortcutText(MenuItem item) {
			if ((item.ShowShortcut) && (item.Shortcut != Shortcut.None)) {
				Keys keys = (Keys) item.Shortcut ;
				return Convert.ToChar(Keys.Tab) + System.ComponentModel.TypeDescriptor.GetConverter(keys.GetType()).ConvertToString(keys) ;				
			}
			else {
				return null;
			}
		}

		/// <summary>
		/// Implementation of the IMenuPainter Measure method. 
		/// </summary>		
		/// <param name="item">The <see cref="MenuItem"/> to be painted.</param>
		/// <param name="e">A <see cref="MeasureItemEventArgs"/> object providing data for this event.</param>		
		/// <param name="imageSize">A <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the size of the image.</param>
		protected virtual void MeasureMenuItem(MenuItem item, MeasureItemEventArgs e, MenuImageSize imageSize) {
			e.ItemHeight = CalculateItemHeight(item, imageSize);			
			e.ItemWidth =  CalculateItemWidth(item, e.Graphics, true, item.Parent is MainMenu, GetImageHeight(imageSize));			
		}

		/// <summary>		
		/// Calculates the width of a <see cref="MenuItem"/>
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/> for which the height is required.</param>
		/// <param name="g">A <see cref="Graphics"/> object used to measure the string size</param>
		/// <param name="showImages">A <see cref="bool"/> value indicating whether to show images.</param>
		/// <param name="topLevel">A <see cref="bool"/> value indicating whether this is a top level menu.</param>
		/// <param name="imageWidth">A <see cref="int"/> value indicating the size of the images in the menu.</param>
		/// <returns>An <see cref="int"/> value containing the calculated height of the menu item.</returns>				
		protected virtual int CalculateItemWidth(MenuItem item, Graphics g, bool showImages, bool topLevel, int imageWidth) {			
			int w = (int)g.MeasureString(item.Text, SystemInformation.MenuFont, 1000, stringFormat).Width;			
			int sw = 0;			
			string shortcut = GetShortcutText(item);
			if (shortcut != null) {
				sw = (int)g.MeasureString(shortcut, SystemInformation.MenuFont, 1000, stringFormat).Width;			
			}

			if (topLevel) {
				return w + TOPLEVEL_MENU_BUFFER;
			}
			else {
				if (showImages) {
					return w + SHORTCUT_BUFFER + sw + IMAGE_BUFFER + imageWidth + TEXT_LEFT_BUFFER;
				}
				else {
					return w + SHORTCUT_BUFFER + sw + TEXT_LEFT_BUFFER;
				}
			}
		}

		
		

		/// <summary>
		/// Paints the background of a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="TopLevel">A <see cref="bool"/> indicating whether this is a top level menu item.</param>
		/// <param name="imageSize">An <see cref="int"/> associated with the MenuItem. This indicates the size of the image.</param>
		protected virtual void PaintBackground(MenuItem item, DrawItemEventArgs e, bool TopLevel, int imageSize) {			
			e.Graphics.FillRectangle(Brushes.White, e.Bounds);									
		}

		/// <summary>
		/// Paints the background of a highlighted <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="TopLevel">A <see cref="bool"/> indicating whether this is a top level menu item.</param>
		protected virtual void PaintHighlight(MenuItem item, DrawItemEventArgs e, bool TopLevel) {
			e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);									
		}

		/// <summary>
		/// Paints the image on a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="image">The <see cref="Image"/> to draw on the Menu</param>
		/// <param name="imageSize">An <see cref="int"/> giving the image size to use when painting menus.</param>
		protected virtual void PaintImage(MenuItem item, DrawItemEventArgs e, Image image, int imageSize) {			
			if (image != null) {
				int imgTop = e.Bounds.Top + ((e.Bounds.Height - imageSize) / 2);
				e.Graphics.DrawImage(image, new Rectangle(new Point(IMAGE_BUFFER / 2, imgTop), new Size(imageSize, imageSize)), 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
			}
		}

		/// <summary>
		/// Paints the Menu Text of a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="imageSize">An <see cref="int"/> value indicating the size of the images drawn when painting menus.</param>
		protected virtual void PaintText(MenuItem item, DrawItemEventArgs e, int imageSize) {				
			Font menuFont = SystemInformation.MenuFont;
			using (Brush b = new SolidBrush(GetTextColor(e.State))) {
				if (item.Parent is MainMenu) {
						e.Graphics.DrawString(item.Text, menuFont, b, e.Bounds.Left + TEXT_LEFT_BUFFER, e.Bounds.Top + ((e.Bounds.Height - menuFont.Height) / 2), stringFormat);									
				}
				else {
					e.Graphics.DrawString(item.Text, menuFont, b, e.Bounds.Left + IMAGE_BUFFER + imageSize + TEXT_LEFT_BUFFER, e.Bounds.Top + ((e.Bounds.Height - menuFont.Height) / 2), stringFormat);									
				}
			}
		}

		/// <summary>
		/// Paints separator bars
		/// </summary>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="imageSize">An <see cref="int"/> value indicating the size of menu images.</param>
		protected virtual void PaintSeparator(DrawItemEventArgs e, int imageSize) {
			int iTop = e.Bounds.Top + (e.Bounds.Height / 2);
			e.Graphics.DrawLine(Pens.DarkGray, new Point(e.Bounds.Left + TEXT_LEFT_BUFFER, iTop), new Point(e.Bounds.Left + e.Bounds.Width - 3, iTop));
		}


		/// <summary>
		/// Paints the Menu Shortcut of a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		protected virtual void PaintShortcut(MenuItem item, DrawItemEventArgs e) {
			Font menuFont = SystemInformation.MenuFont;
			using (Brush b = new SolidBrush(GetTextColor(e.State))) {
				string shortcut = GetShortcutText(item);
				if (shortcut != null) {
					int sw= (int) e.Graphics.MeasureString( shortcut, menuFont, 1000, stringFormat).Width ;
					e.Graphics.DrawString(shortcut, menuFont, b, (e.Bounds.Width) - SHORTCUT_RIGHT_BUFFER - sw , e.Bounds.Top + ((e.Bounds.Height - menuFont.Height) / 2), stringFormat);
				}
			}
		}


		/// <summary>
		/// Paints the Checked portion of a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>		
		/// <param name="Radio">A <see cref="bool"/> indicating whether this is a RadioButton type check.</param>
		/// <param name="imageSize">An <see cref="int"/> containing the desired image size.</param>
		protected virtual void PaintCheck(MenuItem item, DrawItemEventArgs e, bool Radio, int imageSize) {
			int imgTop = e.Bounds.Top + ((e.Bounds.Height - imageSize) / 2);
			Rectangle r=  new Rectangle(new Point(IMAGE_BUFFER / 2, imgTop), new Size(imageSize, imageSize));
			e.Graphics.FillRectangle(SystemBrushes.Control, r);			
			e.Graphics.DrawImage(Radio ? radioCheckImage : checkImage, r, 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
		}
								

		/// <summary> 
		/// Clean up any resources being used.
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
		#endregion

		#region Public Methods

		/// <summary>
		/// Overridden. See <see cref="Object.ToString()"/>
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return GetType().Name;
		}
			
		#region IMenuPainter Members
		/// <summary>
		/// Implementation of the IMenuPainter PaintBar method
		/// </summary>
		/// <param name="g">The <see cref="Graphics"/> object on which to paint.</param>
		/// <param name="r">The bounding <see cref="Rectangle"/> for the paint operation</param>
		public void PaintBar(Graphics g, Rectangle r) {
			InternalPaintBar(g, r);
		}
		
		/// <summary>
		/// Implementation of the IMenuPainter Paint method. 
		/// </summary>		
		/// <param name="item">The <see cref="MenuItem"/> to be painted.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this event.</param>
		/// <param name="image">An <see cref="Image"/> to draw in the menu item. This may be null.</param>
		/// <param name="imageSize">An <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the size of the image to be drawn.</param>
		public void PaintItem(MenuItem item, DrawItemEventArgs e, Image image, MenuImageSize imageSize) {
			InternalPaintItem(item, e, image, imageSize);
		}

		/// <summary>
		/// Implementation of the IMenuPainter Measure method. 
		/// </summary>		
		/// <param name="item">The <see cref="MenuItem"/> to be painted.</param>
		/// <param name="e">A <see cref="MeasureItemEventArgs"/> object providing data for this event.</param>		
		/// <param name="imageSize">An <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the size of the image to be drawn.</param>
		public void MeasureItem(MenuItem item, MeasureItemEventArgs e, MenuImageSize imageSize) {
			InternalMeasureItem(item, e, imageSize);
		}

		#endregion

		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
		
	}
}
