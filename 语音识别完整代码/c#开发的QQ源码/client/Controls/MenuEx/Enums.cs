//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;

namespace ControlVault.MenuSuite {

	#region Enums
	/// <summary>
	/// Size of images used in the menu
	/// </summary>
	public enum MenuImageSize {
		/// <summary>
		/// The menu does not show images.
		/// </summary>
		None,
		/// <summary>
		/// The menu uses small images (16x16)
		/// </summary>
		Small,
		/// <summary>
		/// The menu uses medium images (24x24)
		/// </summary>
		Medium,
		/// <summary>
		/// The menu uses large images (32x32)
		/// </summary>
		Large,
		/// <summary>
		/// The menu uses extra large images (48x48)
		/// </summary>
		ExtraLarge
	}
	
	/// <summary>
	/// Enumerated type indicating how to paint bar gradients
	/// </summary>
	public enum BarGradientStyle {
		/// <summary>
		/// Gradient is from left to right.
		/// </summary>
		LeftToRight,
		/// <summary>
		/// Gradient is from top to bottom
		/// </summary>
		TopToBottom
	}

	/// <summary>
	/// Indicates how to draw the menu bar
	/// </summary>
	public enum MenuBarStyle {
		/// <summary>
		/// Draw the menu bar as a single color.
		/// </summary>
		Plain,
		/// <summary>
		/// Draw the menu bar using a linear gradient.
		/// </summary>
		Gradient,
		/// <summary>
		/// Draw the menu bar using gradients to provide a convex or concave appearance.
		/// </summary>
		ConvexConcave,		
	}


	/// <summary>
	/// Skins used to draw the menu bar
	/// </summary>
	public enum Skin {
		/// <summary>
		/// Draw the menu bar in a range of whites and greys
		/// </summary>
		Whites,
		/// <summary>
		/// Draw the menu bar in a range of blue colors
		/// </summary>
		Blues,
		/// <summary>
		/// Draw the menu bar in a range of red colors
		/// </summary>
		Reds,
		/// <summary>
		/// Draw the menu bar in a range of green colors
		/// </summary>
		Greens
	}
	
	#endregion

}
