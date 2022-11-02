//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;


namespace ControlVault.MenuSuite {	

	#region Summary
	/// <summary>
	/// A component which implements IMenuPainter in order to paint menus in a variety of styles.	
	/// </summary>
	[ToolboxBitmap((typeof(SkinMenuPainter)), "MenuPainter.bmp")]
	[ToolboxItem(true)]
	#endregion

	public class SkinMenuPainter : BaseMenuPainter {

		#region Private Variables		
		private Skin skin = Skin.Reds;
		private Color barColor1 = Color.White;
		private Color barColor2 = Color.LightGray;		
		private Color itemLeftColor = Color.FromArgb(227, 239, 255);
		private Color itemBackColor = Color.FromArgb(246, 246, 246);
		private Color itemRightColor = Color.FromArgb(135, 173, 228);
		private Color highlightColor = Color.FromArgb(255, 238, 194);		
		private Color checkFillColor = Color.FromArgb(255, 192, 111);
		private Color separatorColor = Color.FromArgb(134, 161, 211);		
		private Color textColor = Color.Black;
		private Color titleColor = Color.Black;
		private MenuBarStyle menuBarStyle = MenuBarStyle.ConvexConcave;		
		#endregion
				
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SkinMenuPainter class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public SkinMenuPainter(System.ComponentModel.IContainer container): base(container) {}			

		/// <summary>
		/// Initializes a new instance of the SkinMenuPainter class.
		/// </summary>		
		public SkinMenuPainter(): base() {}			
		#endregion

		#region Private Methods
		/// <summary>
		/// Paints a linear gradient in the supplied rectangle
		/// </summary>
		/// <param name="source">A <see cref="RectangleF"/> rectangle from which the gradient is painted</param>
		/// <param name="dest">The destination <see cref="RectangleF"/> in which the gradient is painted</param>
		/// <param name="g">A <see cref="Graphics"/> object for drawing</param>
		/// <param name="c1">The starting <see cref="Color"/> for the gradient</param>
		/// <param name="c2">The ending <see cref="Color"/> for the gradient</param>
		/// <param name="mode">An <see cref="LinearGradientMode"/> indicating how to draw the gradient.</param>
		private void PaintGradient(RectangleF source, RectangleF dest, Graphics g, Color c1, Color c2, LinearGradientMode mode) {			
			LinearGradientBrush b  = new LinearGradientBrush(source, c1, c2, mode);
			b.WrapMode = WrapMode.TileFlipX;
			try {				
				g.FillRectangle(b, dest);
			}

			finally {
				b.Dispose();
			}
		}

		private void SetSkin() {
			switch (skin) {
				case Skin.Whites: {
					barColor1 = Color.LightGray;
					barColor2 = Color.GhostWhite;					
					itemBackColor = Color.GhostWhite;
					itemLeftColor = Color.GhostWhite;					
					itemRightColor = Color.Gainsboro;
					highlightColor = Color.White;
					checkFillColor = Color.White;
					separatorColor = Color.DarkGoldenrod;
					textColor = Color.Black;
					titleColor = Color.Black;
					menuBarStyle = MenuBarStyle.ConvexConcave;		
					break;
				}
				case Skin.Blues: {
					barColor1 = Color.FromArgb(73, 139, 224);
					barColor2 = Color.FromArgb(31, 97, 185);					
					itemBackColor = Color.FromArgb(224, 232, 237);
					itemLeftColor = Color.FromArgb(224, 232, 237);					
					itemRightColor = Color.FromArgb(73, 139, 224);
					highlightColor = Color.FromArgb(31, 97, 185);		
					checkFillColor = Color.FromArgb(224, 232, 237);
					separatorColor = Color.FromArgb(31, 97, 185);					
					textColor = Color.Black;
					titleColor = Color.White;
					menuBarStyle = MenuBarStyle.ConvexConcave;		
					break;
				}
				case Skin.Reds: {					
					barColor1 = Color.FromArgb(150, 37, 37);
					barColor2 = Color.FromArgb(211, 165, 165);
					itemBackColor = Color.White;
					itemLeftColor = Color.FromArgb(211, 165, 165);					
					itemRightColor = Color.FromArgb(146, 34, 34);
					highlightColor = Color.FromArgb(211, 165, 165);		
					checkFillColor = Color.FromArgb(211, 165, 165);
					separatorColor = Color.Maroon;
					textColor = Color.Maroon;
					titleColor = Color.White;
					menuBarStyle = MenuBarStyle.ConvexConcave;		
					break;
				}
				case Skin.Greens: {					
					barColor1 = Color.FromArgb(83, 159, 117);
					barColor2 = Color.FromArgb(229, 240, 235);					
					itemBackColor = Color.FromArgb(229, 240, 235);
					itemLeftColor = Color.FromArgb(147, 195, 168);					
					itemRightColor = Color.FromArgb(83, 159, 117);					
					highlightColor = Color.FromArgb(201, 225, 211);
					checkFillColor = Color.FromArgb(147, 195, 168);
					separatorColor = Color.FromArgb(51, 144, 92);
					textColor  = Color.FromArgb(83, 159, 117);					
					titleColor = Color.White;
					menuBarStyle = MenuBarStyle.Gradient;		
					break;
				}

			}
		}
		#endregion

		#region Overridden Protected Methods

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBar"/>
		/// </summary>		
		protected override void PaintMenuBar(Graphics g, Rectangle r) {
			switch (menuBarStyle) {					
				case MenuBarStyle.Plain: {
					using (SolidBrush b = new SolidBrush(barColor1)) {
						g.FillRectangle(b, r);
					}					
					break;
				}
				case MenuBarStyle.Gradient: {					
					PaintGradient(r, r, g, barColor1, barColor2, LinearGradientMode.Horizontal);
					break;
				}
				case MenuBarStyle.ConvexConcave: {										
					Rectangle r1 = new Rectangle(r.Location, new Size(r.Width, r.Height / 2));									  
					PaintGradient(r1, r1, g, barColor2, barColor1, LinearGradientMode.Vertical);					
					r1.Offset(0, r.Height / 2);					
					PaintGradient(r1, r1, g, barColor1, barColor2, LinearGradientMode.Vertical);					
					break;
				}				
			}
		}
		

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBackground"/>
		/// </summary>
		protected override void PaintBackground(MenuItem item, DrawItemEventArgs e, bool TopLevel, int imageSize) {						
			Graphics g = e.Graphics;			
			if (TopLevel) {							
				MainMenu mainMenu = item.GetMainMenu();
				if (mainMenu != null) {
					Form frm = mainMenu.GetForm();
					if (frm != null) {
						int formWidth = frm.ClientRectangle.Width + 4;
						Rectangle rForm = new Rectangle(0, 0, formWidth, SystemInformation.MenuHeight);
						switch (menuBarStyle) {					
							case MenuBarStyle.Plain: {			
								using (LinearGradientBrush rb = new LinearGradientBrush(rForm, barColor1, barColor2, 0, false)) {
									g.FillRectangle(rb, e.Bounds);
								}			
								break;
							}
							case MenuBarStyle.Gradient: {					
								PaintGradient(rForm, e.Bounds, g, barColor1, barColor2, LinearGradientMode.Horizontal);
								break;
							}
							case MenuBarStyle.ConvexConcave: {										
								e.Graphics.SetClip(e.Bounds);
								Rectangle r1 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width, SystemInformation.MenuHeight / 2));
								PaintGradient(r1, r1, g, barColor1, barColor2, LinearGradientMode.Vertical);					
								r1.Offset(0, SystemInformation.MenuHeight / 2);
								PaintGradient(r1, r1, g, barColor2, barColor1, LinearGradientMode.Vertical);					
								break;
							}				
						}
					}
				}
			}
			else {
				using (SolidBrush sb = new SolidBrush(itemBackColor)) {
					g.FillRectangle(sb, e.Bounds);
				}			

				if (imageSize != 0) {
					Rectangle r = new Rectangle(e.Bounds.Location, new Size(imageSize + IMAGE_BUFFER, e.Bounds.Size.Height));
					using (LinearGradientBrush lgb = new LinearGradientBrush(r, itemLeftColor, itemRightColor, 0, false)) {
						g.FillRectangle(lgb, r);
					}			
				}
			}			
			
		}

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintSeparator"/>
		/// </summary>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		/// <param name="imageSize">An <see cref="int"/> containing the desired image size.</param>
		protected override void PaintSeparator(DrawItemEventArgs e, int imageSize) {
			int iTop = e.Bounds.Top + (e.Bounds.Height / 2);			
			using (Pen p = new Pen(separatorColor, 1)) {
				e.Graphics.DrawLine(p, new Point(e.Bounds.Left + imageSize + IMAGE_BUFFER + 3, iTop), new Point(e.Bounds.Left + e.Bounds.Width - 3, iTop));
			}
		}
		

		/// <summary>
		/// Gets the <see cref="Color"/> to be used to paint normal menu text.
		/// </summary>
		/// <returns>A <see cref="Color"/> to be used when painting text</returns>
		protected override Color GetTextColor(DrawItemState state) {
			return textColor;
		}




		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintHighlight"/>
		/// </summary>
		protected override void PaintHighlight(MenuItem item, DrawItemEventArgs e, bool TopLevel) {
			if (TopLevel) {				
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width -1, e.Bounds.Height -1));
				using (LinearGradientBrush lgb = new LinearGradientBrush(rb, highlightColor, checkFillColor, 90, false)) {
					e.Graphics.FillRectangle(lgb, rb);
				}			
				using (Pen p = new Pen(textColor, 1)) {
					e.Graphics.DrawRectangle(p, rb);
				}
			}
			else {
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 2, e.Bounds.Height -1));
				using (SolidBrush bs = new SolidBrush(highlightColor)) {
					e.Graphics.FillRectangle(bs, rb);
				}				
				using (Pen p = new Pen(textColor)) {
					e.Graphics.DrawRectangle(p, rb);
				}
			}
		}
		


		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintCheck"/>
		/// </summary>
		protected override void PaintCheck(MenuItem item, DrawItemEventArgs e, bool Radio, int imageSize) {
			int imgTop = e.Bounds.Top + ((e.Bounds.Height - imageSize) / 2);
			Rectangle r=  new Rectangle(new Point(IMAGE_BUFFER / 2, imgTop), new Size(imageSize, imageSize));
			if (! Radio) {
				using (SolidBrush b = new SolidBrush(checkFillColor)) {
					e.Graphics.FillRectangle(b, r);		
				}
				using (Pen p = new Pen(textColor, 1)) {
					e.Graphics.DrawRectangle(p, r);
				}
			}
			e.Graphics.DrawImage(Radio ? radioCheckImage : checkImage, r, 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
		}

		
		/// <summary>
		/// Paints the Menu Shortcut of a <see cref="MenuItem"/> object.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/>  to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for this operation.</param>
		protected override void PaintShortcut(MenuItem item, DrawItemEventArgs e) {
			Font menuFont = SystemInformation.MenuFont;
			using (Brush b = new SolidBrush(item.Enabled ? textColor: SystemColors.GrayText)) {
				string shortcut = GetShortcutText(item);
				if (shortcut != null) {
					int sw= (int) e.Graphics.MeasureString( shortcut, menuFont, 1000, stringFormat).Width ;
					e.Graphics.DrawString(shortcut, menuFont, b, (e.Bounds.Width) - SHORTCUT_RIGHT_BUFFER - sw , e.Bounds.Top + ((e.Bounds.Height - menuFont.Height) / 2), stringFormat);
				}
			}
		}

		#endregion

		#region Properties		

		/// <summary>
		/// Gets or sets the skin to use when drawing the menus.
		/// </summary>
		[Category("Appearance")]
		[Description("The skin to use when drawing the menus.")]
			//[DefaultValue(typeof(Skin),"Reds")]
		public Skin Skin {
			get { return skin; }
			set { 
				skin = value; 
				SetSkin();
			}
		}


		#endregion


	}
}
