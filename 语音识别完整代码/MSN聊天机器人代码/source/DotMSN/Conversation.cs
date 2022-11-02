using System;
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

using System.IO;
using XihSolutions.DotMSN.Core;
using XihSolutions.DotMSN.DataTransfer;

namespace XihSolutions.DotMSN
{
	/// <summary>
	/// A facade to the underlying switchboard session.
	/// </summary>
	/// <remarks>
	/// Conversation implements a few features for the ease of the application programmer. It provides
	/// directly basic common functionality. However, if you need to perform more advanced actions, or catch
	/// other events you have to directly use the underlying switchboard handler, or switchboard processor.
	/// 
	/// Conversation automatically requests emoticons used by remote contacts.
	/// </remarks>
	public class Conversation
	{
		#region Private
		/// <summary>
		/// </summary>
		private Messenger			_messenger = null;
		
		/// <summary>
		/// </summary>
		private SBMessageHandler	_switchboard = null;

		/// <summary>
		/// </summary>
		private bool autoRequestEmoticons = true;

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void transferSession_TransferFinished(object sender, EventArgs e)
		{
			if(Settings.TraceSwitch.TraceInfo)			
				System.Diagnostics.Trace.WriteLine("Emoticon received", "Conversation");			
		}

		#endregion

		#region Public

		/// <summary>
		/// Indicates whether emoticons from remote contacts are automatically retrieved
		/// </summary>
		public bool AutoRequestEmoticons
		{
			get { return autoRequestEmoticons; }
			set { autoRequestEmoticons = value;}
		}

		/// <summary>
		/// Messenger that created the conversation
		/// </summary>
		public Messenger Messenger
		{
			get { return _messenger; }
			set { _messenger = value;}
		}

		/// <summary>
		/// The switchboard processor. Sends and receives messages over the switchboard connection
		/// </summary>
		public SBMessageProcessor SwitchboardProcessor
		{
			get { return (SBMessageProcessor)_switchboard.MessageProcessor; }
			set { _switchboard.MessageProcessor = value;}
		}

		/// <summary>
		/// The switchboard handler. Handles incoming/outgoing messages.
		/// </summary>
		public SBMessageHandler Switchboard
		{
			get { return _switchboard; }
			set { _switchboard = value;}
		}


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">The messenger object that requests the conversation.</param>
		/// <param name="sbHandler">The switchboard to interface to.</param>		
		public Conversation(Messenger parent, SBMessageHandler sbHandler)
		{
			_switchboard   = sbHandler;
			_messenger		   = parent;
			
			sbHandler.EmoticonDefinitionReceived += new EmoticonDefinitionReceivedEventHandler(sbHandler_EmoticonDefinitionReceived);			
		}

		/// <summary>
		/// Invite a remote contact to join the conversation.
		/// </summary>
		/// <param name="contactMail"></param>
		public void Invite(string contactMail)
		{
			if(Switchboard != null)
				Switchboard.Invite(contactMail);			
		}

		/// <summary>
		/// Invite a remote contact to join the conversation.
		/// </summary>
		/// <param name="contact">The remote contact to invite.</param>
		public void Invite(Contact contact)
		{
			Invite(contact.Mail);
		}

		#endregion

		/// <summary>
		/// Automatically requests emoticons used.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sbHandler_EmoticonDefinitionReceived(object sender, EmoticonDefinitionEventArgs e)
		{			
			if(AutoRequestEmoticons == false) return;

			MSNObject existing = MSNObjectCatalog.GetInstance().Get(e.Emoticon.CalculateChecksum());
			if(existing == null)
			{				
				e.Sender.Emoticons[e.Emoticon.Shortcut] = e.Emoticon;

				// create a session and send the invitation
				P2PMessageSession session = Messenger.P2PHandler.GetSession(Messenger.Nameserver.Owner.Mail, e.Sender.Mail);
				
				object handlerObject = session.GetHandler(typeof(MSNSLPHandler));
				if(handlerObject != null)
				{
					MSNSLPHandler msnslpHandler = (MSNSLPHandler)handlerObject;					
					
					P2PTransferSession transferSession = msnslpHandler.SendInvitation(session.LocalContact, session.RemoteContact, e.Emoticon);
					transferSession.DataStream = e.Emoticon.OpenStream();
					transferSession.ClientData = e.Emoticon;					

					transferSession.TransferAborted += new EventHandler(transferSession_TransferFinished);					
					transferSession.TransferFinished += new EventHandler(transferSession_TransferFinished);
					
					MSNObjectCatalog.GetInstance().Add(e.Emoticon);
				}
				else
					throw new DotMSNException("No MSNSLPHandler was attached to the p2p message session. An emoticon invitation message could not be send.");
			}
		}


		
	}
}
