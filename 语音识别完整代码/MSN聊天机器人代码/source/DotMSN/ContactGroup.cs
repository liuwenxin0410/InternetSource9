#region Copyright (c) 2002-2005, Bas Geertsema, Xih Solutions (http://www.xihsolutions.net)
/*
Copyright (c) 2002-2005, Bas Geertsema, Xih Solutions (http://www.xihsolutions.net)
All rights reserved.

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, 
this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright 
notice, this list of conditions and the following disclaimer in the 
documentation and/or other materials provided with the distribution.
* Neither the names of Bas Geertsema or Xih Solutions nor the names of its 
contributors may be used to endorse or promote products derived 
from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
THE POSSIBILITY OF SUCH DAMAGE. */
#endregion

using System;
using XihSolutions.DotMSN.Core;
using XihSolutions.DotMSN.DataTransfer;

namespace XihSolutions.DotMSN
{
	/// <summary>
	/// Used as event argument when a contactgroup is affected.
	/// </summary>
	[Serializable()]
	public class ContactGroupEventArgs : EventArgs
	{
		/// <summary>
		/// </summary>
		private ContactGroup	contactGroup;

		/// <summary>
		/// The affected contact group
		/// </summary>
		public ContactGroup	 ContactGroup
		{
			get { return contactGroup; }
			set { contactGroup = value;}
		}

		/// <summary>
		/// Constructor, mostly used internal by the library.
		/// </summary>
		/// <param name="contactGroup"></param>
		public ContactGroupEventArgs(ContactGroup contactGroup)
		{
			ContactGroup = contactGroup;
		}
	}


	
	/// <summary>
	/// Defines a single contact group.
	/// </summary>
	[Serializable()]
	public class ContactGroup
	{
		#region Private

		[NonSerialized]
		private IMessageHandler	nsMessageHandler = null;

		/// <summary>
		/// </summary>
		private  string		name;
		/// <summary>
		/// </summary>
		private  int		id;

		#endregion

		#region Internal

		/// <summary>
		/// Constructor, used internally by the library.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="id"></param>
		/// <param name="nsMessageHandler"></param>
		internal ContactGroup(string name, int id, IMessageHandler nsMessageHandler)
		{
			this.name = name;
			this.id   = id;
			this.nsMessageHandler = nsMessageHandler;
		}

		/// <summary>
		/// Used by nameserver.
		/// </summary>
		/// <param name="name"></param>
		internal void SetName(string name)
		{
			this.name = name;
		}
		#endregion

		#region Public

		/// <summary>
		/// The notification message handler which controls this contact object
		/// </summary>
		public	IMessageHandler	NSMessageHandler
		{
			get { return nsMessageHandler; }
			set { nsMessageHandler = value;}
		}


		/// <summary>
		/// </summary>
		private object clientData;

		/// <summary>
		/// The custom data specified by the client programmer
		/// </summary>
		/// <remarks>The application programmer can define it's own data here. It is not used by DotMSN.</remarks>
		public object ClientData
		{
			get { return clientData; }
			set { clientData = value; }
		}

		/// <summary>
		/// Name of the contactgroup
		/// </summary>
		public string Name
		{
			get { return name; }
			set 
			{ 
				if(NSMessageHandler != null)
				{
					((NSMessageHandler)NSMessageHandler).RenameGroup(this, value);
				}
			}
		}

		/// <summary>
		/// The unique contactgroup ID assigned by MSN
		/// </summary>
		public int	  ID
		{
			get { return id; }
		}

		/// <summary>
		/// Returns the ID field as hashcode. This is necessary to compare contactgroups.
		/// </summary>
		/// <returns></returns>
		override public int GetHashCode()
		{
			return id;
		}

		/// <summary>
		/// Equals two contacgroups based on their ID
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if(obj is ContactGroup)
				return ((ContactGroup)obj).ID == id;
			return
				false;
		}

		#endregion

	}

}
