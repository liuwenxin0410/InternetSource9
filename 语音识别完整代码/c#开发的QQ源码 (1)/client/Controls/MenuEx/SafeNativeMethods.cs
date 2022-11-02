//------------------------------------------------//
// ControlVault source code unit                  //
// © Firbeck Ltd 2005. All rights reserved        //
//------------------------------------------------//
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ControlVault.MenuSuite {

	#region Structs
	[StructLayout(LayoutKind.Sequential)]
	internal class POINT { 
		internal int x = 0;
		internal int y = 0;
	}

	/// <summary>
	/// Translates a Rectangle to a Windows API RECT
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct RECT {
		internal int left;
		internal int top;
		internal int right;
		internal int bottom;		
		internal Rectangle ToRect() {
			return new Rectangle(left, top, right - left, bottom - top);
		}
	}


	/// <summary>
	/// The MENUINFO structure contains information about a menu.
	/// </summary>
	internal struct MENUINFO {
		internal int cbSize;
		internal int fMask;
		internal int dwStyle;
		internal int cyMax;
		internal IntPtr hbrBack;
		internal int dwContextHelpID;
		internal int dwMenuData;
		internal MENUINFO(Control owner) {
			cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(MENUINFO));
			fMask = 0;
			dwStyle = 0;
			cyMax = 0;
			hbrBack = IntPtr.Zero;
			dwContextHelpID = 0;
			dwMenuData = 0;
		}
	}

	#endregion

	#region Class SafeNativeMethods

	#region Summary
	/// <summary>
	/// Native methods called from this library.
	/// </summary>
	#endregion

	internal class SafeNativeMethods {

		#region Methods
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("User32.dll")]
		internal extern static IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		
		[DllImport("kernel32.dll", SetLastError=true)] 
		internal static extern int GetLastError (); 

		[DllImport("user32.dll")]
		internal static extern int ScreenToClient(IntPtr hwnd, POINT pt);

		[DllImport("user32.dll")]
		internal static extern int DrawMenuBar(IntPtr hwnd);

		[DllImport("user32.dll")]
		internal static extern int SetMenuInfo(IntPtr hmenu, ref MENUINFO mi);

		[DllImport("gdi32.dll")] 
		internal static extern IntPtr CreatePatternBrush(IntPtr hbmp); 

		[DllImport("gdi32.dll")]
		internal static extern bool DeleteObject(IntPtr hObject);		

		[DllImport("user32.dll", SetLastError=true)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, int lParam);

		#endregion

	}
	#endregion
}
