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


namespace ControlVault.MenuSuite {

	#region Summary
	/// <summary>
	/// A component which implements IMenuPainter in order to paint menus in a simple style.	
	/// </summary>
	[ToolboxBitmap((typeof(PlainMenuPainter)), "MenuPainter.bmp")]
	[ToolboxItem(true)]
	#endregion

	public class PlainMenuPainter : BaseMenuPainter {

		#region Private Constants		
		private Color separatorColor = Color.LightGray;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the PlainMenuPainter class.
		/// </summary>
		/// <param name="container">The <see cref="IContainer"/> to which this component is to be added.</param>
		public PlainMenuPainter(System.ComponentModel.IContainer container): base(container){}
		
		/// <summary>
		/// Initializes a new instance of the PlainMenuPainter class.
		/// </summary>		
		public PlainMenuPainter(): base(){}		
		#endregion
		
		#region Overridden Protected Methods

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBar"/>
		/// </summary>		
		protected override void PaintMenuBar(Graphics g, Rectangle r) {			
			g.FillRectangle(Brushes.White, r);						
		}

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintBackground"/>
		/// </summary>
		protected override void PaintBackground(MenuItem item, DrawItemEventArgs e, bool TopLevel, int imageSize) {
			Graphics g = e.Graphics;			
			if (TopLevel) {				
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width + 1, e.Bounds.Height));				
				g.FillRectangle(Brushes.White, rb);															
			}
			else {				
				g.FillRectangle(Brushes.White, e.Bounds);								
			}						
		}

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintSeparator"/>
		/// </summary>		
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
				e.Graphics.FillRectangle(SystemBrushes.Highlight, rb);											
			}
			else {
				Rectangle rb = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 2, e.Bounds.Height -1));
				e.Graphics.FillRectangle(SystemBrushes.Highlight, rb);
			}							
		}
		

		/// <summary>
		/// Overridden. See <see cref="BaseMenuPainter.PaintCheck"/>
		/// </summary>
		protected override void PaintCheck(MenuItem item, DrawItemEventArgs e, bool Radio, int imageSize) {
			int imgTop = e.Bounds.Top + ((e.Bounds.Height - imageSize) / 2);
			Rectangle r=  new Rectangle(new Point(IMAGE_BUFFER / 2, imgTop), new Size(imageSize, imageSize));			
			e.Graphics.FillRectangle(Brushes.White, r);		
			using (Pen p = new Pen(Color.LightGray, 1)) {
				e.Graphics.DrawRectangle(p, r);
			}
			e.Graphics.DrawImage(Radio ? radioCheckImage : checkImage, r, 0, 0, imageSize, imageSize, GraphicsUnit.Pixel);			
		}
				
		#endregion

	}
}
