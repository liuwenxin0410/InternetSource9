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
	/// </summary>
	public delegate void ProcessorExceptionEventHandler(object sender, ExceptionEventArgs e);

	/// <summary>
	/// Defines methods to send network messages.
	/// </summary>
	/// <remarks>
	/// IMessageProcessor is the abstraction of an object which can send network messages.
	/// Network messages can be any kind of messages: text messages, data messages.
	/// By using this interface a de-coupling is established between the handling of messages
	/// and the I/O of messages.
	/// IMessageProcessor is mostly used internal.
	/// </remarks>
	public interface IMessageProcessor
	{		
		/// <summary>
		/// Sends a message to be processed by the processor.
		/// </summary>
		/// <param name="message"></param>
		void		SendMessage(NetworkMessage message);
		/// <summary>
		/// Registers a handler that wants to receive incoming messages.
		/// </summary>
		/// <param name="handler"></param>
		void		RegisterHandler(IMessageHandler handler);
		/// <summary>
		/// Unregisters (removes) a handler that no lange wants to receive incoming messages.
		/// </summary>
		/// <param name="handler"></param>
		void		UnregisterHandler(IMessageHandler handler);
	}
}
