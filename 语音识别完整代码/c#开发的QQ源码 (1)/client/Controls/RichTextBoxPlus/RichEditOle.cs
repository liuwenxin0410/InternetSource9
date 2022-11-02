using System;
using System.Runtime.InteropServices;

namespace LanMsg.Windows.Forms
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("00020D00-0000-0000-c000-000000000046")]
	public interface IRichEditOle
	{
	    int GetClientSite(IntPtr lplpolesite);
		int GetObjectCount();
		int GetLinkCount();
		int GetObject(int iob, REOBJECT lpreobject, [MarshalAs(UnmanagedType.U4)]GetObjectOptions flags);
	    int InsertObject(REOBJECT lpreobject);
		int ConvertObject(int iob, CLSID rclsidNew, string lpstrUserTypeNew);
		int ActivateAs(CLSID rclsid, CLSID rclsidAs);
		int SetHostNames(string lpstrContainerApp, string lpstrContainerObj);
		int SetLinkAvailable(int iob, int fAvailable);
		int SetDvaspect(int iob, uint dvaspect);
		int HandsOffStorage(int iob);
		int SaveCompleted(int iob, IntPtr lpstg);
		int InPlaceDeactivate();
		int ContextSensitiveHelp(int fEnterMode);
		//int GetClipboardData(CHARRANGE FAR * lpchrg, uint reco, IntPtr lplpdataobj);
		//int ImportDataObject(IntPtr lpdataobj, CLIPFORMAT cf, HGLOBAL hMetaPict);
	}
	
	public enum GetObjectOptions
	{
		REO_GETOBJ_NO_INTERFACES	= 0x00000000,
		REO_GETOBJ_POLEOBJ			= 0x00000001,
		REO_GETOBJ_PSTG				= 0x00000002,
		REO_GETOBJ_POLESITE			= 0x00000004,
		REO_GETOBJ_ALL_INTERFACES	= 0x00000007,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CLSID
	{
		public int		a;
		public short	b;
		public short	c;
		public byte		d;
		public byte		e;
		public byte		f;
		public byte		g;
		public byte		h;
		public byte		i;
		public byte		j;
		public byte		k;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct SIZEL
	{
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class REOBJECT
	{
		public REOBJECT()
		{
		}

		public int			cbStruct = Marshal.SizeOf(typeof(REOBJECT));		// Size of structure
		public int			cp = 0;												// Character position of object
		public CLSID		clsid = new CLSID();								// Class ID of object
		public IntPtr		poleobj = IntPtr.Zero;								// OLE object interface
		public IntPtr		pstg = IntPtr.Zero;									// Associated storage interface
		public IntPtr		polesite = IntPtr.Zero;								// Associated client site interface
		public SIZEL		sizel = new SIZEL();								// Size of object (may be 0,0)
		public uint			dvaspect = 0;										// Display aspect to use
		public uint			dwFlags = 0;										// Object status flags
		public uint			dwUser = 0;											// Dword for user's use
	}
}
