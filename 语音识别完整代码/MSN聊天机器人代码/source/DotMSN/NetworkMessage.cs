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
using XihSolutions.DotMSN;
using XihSolutions.DotMSN.DataTransfer;

namespace XihSolutions.DotMSN.Core
{
	/// <summary>
	/// Presents a single message which is retreived from the network, or can be send to the network.
	/// </summary>
	/// <remarks>
	/// A NetworkMessage can represents many kind of messages: text messages, data messages, invitation messages, etc.
	/// These variations are captured in the descendants of NetworkMessage.
	/// NetworkMessage is an abstract class. It presents an abstraction which can be used when messages are send
	/// through message processors and message handlers.
	/// </remarks>
	public abstract class NetworkMessage
	{
		#region Private
		
		/// <summary>
		/// </summary>
		private byte[]			innerBody = null;

		/// <summary>
		/// </summary>
		private NetworkMessage	parentMessage = null;

		/// <summary>
		/// </summary>
		private NetworkMessage	innerMessage = null;
		#endregion

		#region Protected helper methods

		/// <summary>
		/// Helper method. Appends one array to the other. The second parameter, appendingArray, can be null. In that case the original byte array is returned and no copy is made.
		/// </summary>
		/// <param name="originalArray">The array to append to</param>
		/// <param name="appendingArray">The array which will be appended</param>
		/// <returns>A new created byte array with the two arrays merged together. Or the original array if the appendingArray was null.</returns>
		public byte[] AppendArray(byte[] originalArray, byte[] appendingArray)
		{
			if(appendingArray != null)
			{
				byte[] newArray = new byte[originalArray.Length + appendingArray.Length];
				Array.Copy(originalArray, 0, newArray, 0, originalArray.Length);
				Array.Copy(appendingArray, 0, newArray, originalArray.Length, appendingArray.Length);
				return newArray;
			}
			else
				return originalArray;
		}
		#endregion

		/// <summary>
		/// Creates the networkmessage based on the inner contents of the parent message. It invokes the <see cref="ParseBytes"/> method to parse the inner body contents of the parent message.
		/// </summary>
		/// <param name="containerMessage"></param>
		public virtual void CreateFromMessage(NetworkMessage containerMessage)
		{
			ParentMessage = containerMessage;
			ParentMessage.InnerMessage = this;

			if(ParentMessage.InnerBody != null)
				ParseBytes(ParentMessage.InnerBody);
		}
		
		/// <summary>
		/// Called when the innermessage property is set. This sets the ParentMessage property on the inner message object
		/// </summary>
		protected virtual void OnInnerMessageSet()
		{
			if(InnerMessage != null && InnerMessage.ParentMessage != this)
				InnerMessage.ParentMessage = this;
		}

		/// <summary>
		/// Called when the parent message is set. This sets the InnerMessage property on the parent message object.
		/// </summary>
		protected virtual void OnParentMessageSet()
		{
			if(ParentMessage != null && ParentMessage.InnerMessage != this)
				ParentMessage.InnerMessage = this;
		}

		/// <summary>
		/// The inner body contents. Null if not present.
		/// </summary>
		public byte[]	InnerBody
		{
			get { return innerBody; }
			set { innerBody = value;}
		}

		/// <summary>
		/// The inner message object. Null if not present.
		/// </summary>
		public NetworkMessage	InnerMessage
		{
			get { return innerMessage; }
			set { innerMessage = value; OnInnerMessageSet();}
		}

		/// <summary>
		/// The inner message object. Null if not present.
		/// </summary>
		public NetworkMessage	ParentMessage
		{
			get { return parentMessage; }
			set { parentMessage = value; OnParentMessageSet();}
		}

		/// <summary>
		/// Prepares the messages before it is sended. Some messageobjects will set properties in their 'parent' messageobject in this method.
		/// This method is automatically called for the inner message object, if present.
		/// </summary>
		/// <remarks>
		/// Called before the message data is retrieved by calling the <see cref="GetBytes"/> method.
		/// </remarks>
		public virtual void PrepareMessage()
		{
			if(InnerMessage != null)
				InnerMessage.PrepareMessage();
		}

		/// <summary>
		/// Converts the contents of this message into a array of bytes.
		/// This is used for transmitting the contents of this message across a socket connection.
		/// </summary>
		/// <returns></returns>
		public virtual byte[] GetBytes()
		{			
			throw new NotImplementedException("GetBytes() on the base class NetworkMessage is invalid.");
		}

		/// <summary>
		/// Parses incoming byte data send from the network. Must be implemented by derived classes.
		/// </summary>
		/// <param name="data">The raw message as received from the server</param>
		public virtual void ParseBytes(byte[] data)
		{
			throw new NotImplementedException("GetBytes() on the base class NetworkMessage is invalid.");
		}

		/// <summary>
		/// Constructor to instantiate a NetworkMessage object. Note that NetworkMessage is an abstract class.
		/// </summary>
		protected NetworkMessage()
		{
			
		}

		/// <summary>
		/// Textual presentation.
		/// </summary>
		/// <returns></returns>
		public virtual string ToDebugString()
		{
			if(InnerMessage != null)
				return ToString() + "\r\n" + InnerMessage.ToDebugString();
			else
				return ToString();
		}
	}
}
