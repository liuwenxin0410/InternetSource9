//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;


namespace ControlVault.MenuSuite
{
	#region Summary
	/// <summary>
	/// A component which implements IMenuPainter in order to transform menus into
	/// "Visual Studio.NET 2003" style menus.
	/// </summary>
  [ToolboxBitmap((typeof(VisualStudioMenuPainter)), "MenuPainter.bmp")]
	[ToolboxItem(true)]
	#endregion

	public class VisualStudioMenuPainter : BaseMenuPainter
	{

		#region Private Constants
	  private Color backColor = Color.FromArgb(252, 252, 249);
		private Color highlightColor = Color.FromArgb(193, 210, 238);
	  private Color borderColor = Color.FromArgb(49, 106, 197);
		private Color checkBorderColor = Color.FromArgb(84, 130, 204);
		private Color checkFillColor = Color.FromArgb(225, 230, 232);
		private Color separatorColor = Color.LightGray;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the VisualStudioMenuPainter class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public VisualStudioMenuPainter(System.ComponentModel.IContainer container): base(container){}
		
		/// <summary>
		/// Initializes a new instance of the VisualStudioMenuPainter class.
		/// </summary>		
		public VisualStudioMenuPainter(): base(){}		
		#endregion
		
		#region Overridden Protected Methods		
		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBar"/>
		/// </summary>		
		protected override void PaintMenuBar(Graphics g, Rectangle r) {			
			g.FillRectangle(SystemBrushes.Control, r);						
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
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width + 1, e.Bounds.Height));				
				g.FillRectangle(SystemBrushes.Control, rb);															
			}
			else {
				using (SolidBrush sb = new SolidBrush(backColor)) {
					g.FillRectangle(sb, e.Bounds);
				}
				if (imageSize != 0) {
					Rectangle r = new Rectangle(e.Bounds.Location, new Size(imageSize + IMAGE_BUFFER, e.Bounds.Size.Height));
					g.FillRectangle(SystemBrushes.Control, r);
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
		/// Overridden. See <see cref="BaseMenuPainter.PaintHighlight"/>
		/// </summary>
		protected override void PaintHighlight(MenuItem item, DrawItemEventArgs e, bool TopLevel) {
			if (TopLevel) {				
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width, e.Bounds.Height -1));
				using (SolidBrush bs = new SolidBrush(highlightColor)) {
					e.Graphics.FillRectangle(bs, rb);
				}			
				e.Graphics.DrawRectangle(Pens.Navy, rb);
			}
			else {
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 2, e.Bounds.Height -1));
				using (SolidBrush bs = new SolidBrush(highlightColor)) {
					e.Graphics.FillRectangle(bs, rb);
				}				
				using (Pen p = new Pen(borderColor, 1)) {
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
			using (SolidBrush b = new SolidBrush(checkFillColor)) {
				e.Graphics.FillRectangle(b, r);		
			}
			using (Pen p = new Pen(checkBorderColor, 1)) {
				e.Graphics.DrawRectangle(p, r);
			}
			e.Graphics.DrawImage(Radio ? radioCheckImage : checkImage, r, 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
		}
		
		
		#endregion

	}
}
