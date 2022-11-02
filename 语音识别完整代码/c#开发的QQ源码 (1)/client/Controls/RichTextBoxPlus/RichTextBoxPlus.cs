using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LanMsg.Windows.Forms;

namespace LanMsg 
{
	public class RichTextBoxPlus : RichTextBox, IDisposable
	{
		protected IRichEditOle IRichEditOleValue = null;
		protected IntPtr IRichEditOlePtr = IntPtr.Zero;

		/// <summary>
		/// Create the RichTextBoxPlus object.
		/// </summary>
		public RichTextBoxPlus()
		{			
		}
		
		/// <summary>
		/// Get the IRichEditOle interface from the RichTextBox.
		/// </summary>
		/// <returns>The <see cref="IRichEditOle"/> interface.</returns>
		public IRichEditOle GetRichEditOleInterface()
		{
			if (this.IRichEditOleValue == null)
			{
				//REOBJECT reObject = new REOBJECT();
				//reObject.cp = 0;
				//reObject.dwFlags = GetObjectOptions.REO_GETOBJ_POLEOBJ;
				//IntPtr ptr = Marshal.AllocCoTaskMem(reObject.cbStruct);
				//Marshal.StructureToPtr(reObject, ptr, false);

				// Allocate the ptr that EM_GETOLEINTERFACE will fill in.
				IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)));	// Alloc the ptr.
				Marshal.WriteIntPtr(ptr, IntPtr.Zero);	// Clear it.
				try
				{
					if (0 != API.SendMessage(this.Handle, Messages.EM_GETOLEINTERFACE, IntPtr.Zero, ptr))
					{
						// Read the returned pointer.
						IntPtr pRichEdit = Marshal.ReadIntPtr(ptr);
						try
						{
							if (pRichEdit != IntPtr.Zero)
							{
								// Query for the IRichEditOle interface.
								Guid guid = new Guid("00020D00-0000-0000-c000-000000000046");
								Marshal.QueryInterface(pRichEdit, ref guid, out this.IRichEditOlePtr);
							
								// Wrap it in the C# interface for IRichEditOle.
								this.IRichEditOleValue = (IRichEditOle)Marshal.GetTypedObjectForIUnknown(this.IRichEditOlePtr, typeof(IRichEditOle));
								if (this.IRichEditOleValue == null)
								{
									throw new Exception("Failed to get the object wrapper for the interface.");
								}
							}
							else
							{
								throw new Exception("Failed to get the pointer.");
							}
						}
						finally
						{
							Marshal.Release(pRichEdit);
						}
					}
					else
					{
						throw new Exception("EM_GETOLEINTERFACE failed.");
					}
				}
				catch (Exception err)
				{
					Trace.WriteLine(err.ToString());
					this.ReleaseRichEditOleInterface();
				}
				finally
				{
					// Free the ptr memory.
					Marshal.FreeCoTaskMem(ptr);
					//Marshal.DestroyStructure(ptr, typeof(REOBJECT));
				}
			}
			return this.IRichEditOleValue;
		}

		/// <summary>
		/// Releases the IRichEditOle interface if it hasn't been already.
		/// </summary>
		/// <remarks>This is automatically called in Dispose if needed.</remarks>
		public void ReleaseRichEditOleInterface()
		{
			if (this.IRichEditOlePtr != IntPtr.Zero)
			{
				Marshal.Release(this.IRichEditOlePtr);
			}

			this.IRichEditOlePtr = IntPtr.Zero;
			this.IRichEditOleValue = null;
		}

		#region IDisposable Members

		public void Dispose()
		{
			this.ReleaseRichEditOleInterface();
		}

		#endregion
	}
}
