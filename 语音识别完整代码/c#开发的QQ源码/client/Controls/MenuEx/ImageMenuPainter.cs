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
	/// A component which implements IMenuPainter in order to transform menus by displaying a background image
	/// </summary>
	[ToolboxBitmap((typeof(ImageMenuPainter)), "MenuPainter.bmp")]
	[ToolboxItem(true)]
	#endregion

	public class ImageMenuPainter : BaseMenuPainter {

		#region Private Variables
		private Color barColor = Color.FromArgb(172, 142, 171);
		private Color leftColor = Color.FromArgb(135, 173, 228);
		private Color rightColor = Color.FromArgb(227, 239, 255);
		private Color highlightColor = Color.FromArgb(120, 255, 238, 194);
		private Color backColor = Color.FromArgb(246, 246, 246);
		private Color checkFillColor = Color.FromArgb(255, 192, 111);
		private Color separatorColor = Color.Gainsboro;
		private Color textColor = Color.Black;
		private Image image = null;
		#endregion
				
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ImageMenuPainter class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public ImageMenuPainter(System.ComponentModel.IContainer container): base(container) {}			

		/// <summary>
		/// Initializes a new instance of the ImageMenuPainter class.
		/// </summary>		
		public ImageMenuPainter(): base() {}			
		#endregion

		#region Overridden Protected Methods

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBar"/>
		/// </summary>		
		protected override void PaintMenuBar(Graphics g, Rectangle r) {
			if (image != null) {				
				using (TextureBrush tb = new TextureBrush(image)) {
					g.FillRectangle(tb, r);
				}
			}
			else {
				using (SolidBrush b = new SolidBrush(barColor)) {
					g.FillRectangle(b, r);			
				}
			}
		}

		/// <summary>
		/// Gets the <see cref="Color"/> to be used to paint normal menu text.
		/// </summary>
		/// <returns>A <see cref="Color"/> to be used when painting text</returns>
		protected override Color GetTextColor(DrawItemState state) {
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled) {
				return SystemColors.GrayText;
			}
			else if ((state & DrawItemState.Selected) == DrawItemState.Selected) {
				return Color.Black;
			}
			else {
				return Color.Black;
			}
		}


		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBackground"/>
		/// </summary>
		protected override void PaintBackground(MenuItem item, DrawItemEventArgs e, bool TopLevel, int imageSize) {			
			Graphics g = e.Graphics;			
			if (TopLevel) {		
				if (image != null) {										
					using (TextureBrush tb = new TextureBrush(image)) {
						g.FillRectangle(tb, new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width + 1, e.Bounds.Height)));
					}
				}				
				else {
					Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width + 1, e.Bounds.Height));
					using (SolidBrush sb = new SolidBrush(barColor)) {
						g.FillRectangle(sb, rb);
					}			
				}
			}
			else {
				if (image != null) {					
					using (TextureBrush tb = new TextureBrush(image)) {
						g.FillRectangle(tb, e.Bounds);
					}					
				}
				else {					
					using (SolidBrush sb = new SolidBrush(backColor)) {
						g.FillRectangle(sb, e.Bounds);
					}			
				}
				if (imageSize != 0) {
					Color lc = image == null ? leftColor : Color.FromArgb(65, leftColor.R, leftColor.G, leftColor.B);
					Color rc = image == null ? rightColor : Color.FromArgb(65, rightColor.R, rightColor.G, rightColor.B);
					Rectangle r = new Rectangle(e.Bounds.Location, new Size(imageSize + IMAGE_BUFFER, e.Bounds.Size.Height));
					using (LinearGradientBrush lgb = new LinearGradientBrush(r, lc, rc, 0, false)) {
						g.FillRectangle(lgb, r);
					}			
				}
			}			
			
		}

		/// <summary>
		/// Overriden. See <see cref="BaseMenuPainter.PaintSeparator"/>
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
		/// Overridden. See <see cref="BaseMenuPainter.PaintHighlight"/>
		/// </summary>
		protected override void PaintHighlight(MenuItem item, DrawItemEventArgs e, bool TopLevel) {			
			if (TopLevel) {				
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width, e.Bounds.Height -1));
				using (LinearGradientBrush lgb = new LinearGradientBrush(rb, highlightColor, checkFillColor, 90, false)) {
					e.Graphics.FillRectangle(lgb, rb);
				}			
				e.Graphics.DrawRectangle(Pens.Navy, rb);
			}
			else {
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 2, e.Bounds.Height -1));
				using (SolidBrush bs = new SolidBrush(highlightColor)) {
					e.Graphics.FillRectangle(bs, rb);
				}				
				e.Graphics.DrawRectangle(Pens.Black, rb);
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
				e.Graphics.DrawRectangle(Pens.Navy, r);
			}
			e.Graphics.DrawImage(Radio ? radioCheckImage : checkImage, r, 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
		}
		

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the image drawn on the background
		/// </summary>
		/// <value>An <see cref="Image"/></value>
		[Category("Appearance")]
		[Description("Image to be used when drawing the background")]			
		public Image Image {
			get { return image; }
			set { image = value; }
		}
		#endregion		
	}
}
