//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlVault.MenuSuite
{


	/// <summary>
	/// Interface used by <see cref="ControlVault.MenuSuite.MenuEx"/> to allow attachment of menu painters.
	/// </summary>
	public interface IMenuPainter {
		/// <summary>
		/// Paints the menu bar
		/// </summary>		
		/// <param name="g">A <see cref="Graphics"/> object on which to paint.</param>
		/// <param name="r">The bounding <see cref="Rectangle"/> for the paint operation.</param>
		/// <remarks>This method will only be called when both these items are non- null.</remarks>
		void PaintBar(Graphics g, Rectangle r);
	
		/// <summary>
		/// Paints a <see cref="MenuItem"/>
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/> to paint.</param>
		/// <param name="e">A <see cref="DrawItemEventArgs"/> object providing data for the paint action.</param>
		/// <param name="image">An <see cref="Image"/> associated with the MenuItem. Note that this may be null.</param>
		/// <param name="imageSize">A <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the desired size of the image.</param>
		void PaintItem(MenuItem item, DrawItemEventArgs e, Image image, MenuImageSize imageSize);

		/// <summary>
		/// Measures a <see cref="MenuItem"/> object prior to painting it.
		/// </summary>
		/// <param name="item">The <see cref="MenuItem"/> to measure.</param>
		/// <param name="e">A <see cref="MeasureItemEventArgs"/> object providing data for the measure action.</param>
		/// <param name="imageSize">A <see cref="MenuImageSize"/> associated with the MenuItem. This indicates the desired size of the image.</param>
		void MeasureItem(MenuItem item, MeasureItemEventArgs e, MenuImageSize imageSize);
	}
}
