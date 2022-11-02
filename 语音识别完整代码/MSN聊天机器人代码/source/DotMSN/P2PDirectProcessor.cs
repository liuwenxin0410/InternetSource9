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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Org.Mentalis.Network.ProxySocket;
using XihSolutions.DotMSN.Core;
using XihSolutions.DotMSN;

namespace XihSolutions.DotMSN.DataTransfer
{
	/// <summary>
	/// Handles the direct connections in P2P sessions.
	/// </summary>
	public class P2PDirectProcessor : SocketMessageProcessor
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public P2PDirectProcessor()
		{
			if(Settings.TraceSwitch.TraceInfo)
				System.Diagnostics.Trace.WriteLine("Constructing object", "P2PDirectProcessor");
			MessagePool = new P2PDCPool();
		}

		/// <summary>
		/// Starts listening at the specified port in the connectivity settings.
		/// </summary>
		public void Listen(IPAddress address, int port)
		{
			ProxySocket socket = GetPreparedSocket();

			// begin waiting for the incoming connection			
			socket.Bind(new IPEndPoint(address, port));
			
			socket.Listen(100);

            // set this value so we know whether to send a handshake message or not later in the process
            isListener = true;

			socket.BeginAccept(new AsyncCallback(EndAcceptCallback), socket);
		}

        /// <summary>
        /// Returns whether this processor was initiated as listening (true) or connecting (false).
        /// </summary>
        private bool isListener = false;

        /// <summary>
        /// Returns whether this processor was initiated as listening (true) or connecting (false).
        /// </summary>
        public bool IsListener
        {
            get { return isListener; }
            set { isListener = value; }
        }
          


		/// <summary>
		/// Called when an incoming connection has been accepted.
		/// </summary>
		/// <param name="ar"></param>
		protected virtual void EndAcceptCallback(IAsyncResult ar)
		{
			ProxySocket listenSocket = (ProxySocket)ar.AsyncState;						
			dcSocket = listenSocket.EndAccept(ar);
			
			//listenSocket.Shutdown(SocketShutdown.Both);
			//listenSocket.Close();																	

            // begin accepting messages
            BeginDataReceive(dcSocket);

            OnConnected();


		}		

		private Socket dcSocket = null;

		/// <summary>
		/// Closes the socket connection.
		/// </summary>
		public override void Disconnect()
		{
			base.Disconnect();
			
			// clean up the socket properly
			if(dcSocket != null && dcSocket.Connected)
			{
				dcSocket.Shutdown(SocketShutdown.Both);
				dcSocket.Close();
				dcSocket = null;
			}
		}

		/// <summary>
		/// Discards the foo message and sends the message to all handlers as a P2PDCMessage object.
		/// </summary>
		/// <param name="data"></param>
		protected override void OnMessageReceived(byte[] data)
		{			
			System.Diagnostics.Trace.WriteLine("analyzing message", "P2PDirect In");
			// check if it is the 'foo' message
			if(data.Length == 4)
				return;

			// convert to a p2pdc message
			P2PDCMessage dcMessage = new P2PDCMessage();
			dcMessage.ParseBytes(data);			

			System.Diagnostics.Trace.WriteLine(dcMessage.ToDebugString(), "P2PDirect In");
			lock(MessageHandlers)
			{
				foreach(IMessageHandler handler in MessageHandlers)
				{
					handler.HandleMessage(this, dcMessage);
				}
			}
	
		}

		/// <summary>
		/// Sends the P2PMessage directly over the socket. Accepts P2PDCMessage and P2PMessage objects.
		/// </summary>
		/// <param name="message"></param>
		public override void SendMessage(NetworkMessage message)
		{						
			// if it is a regular message convert it
			if((message is P2PDCMessage) == false)
			{
				message = new P2PDCMessage((P2PMessage)message);				
			}
			// otherwise we just assume it is a P2PDCMessage

			// prepare the message
			message.PrepareMessage();

			if(Settings.TraceSwitch.TraceVerbose)
			{				
				// this is very bloated!
				System.Diagnostics.Trace.WriteLine("Outgoing message:\r\n" + message.ToDebugString(), "P2PDirectProcessor");			
			}

			if(dcSocket != null)
				SendSocketData(dcSocket, message.GetBytes());
			else
				SendSocketData(message.GetBytes());
		}


	}
}
