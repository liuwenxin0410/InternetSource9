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
using System.Collections;
using System.Text;
using XihSolutions.DotMSN.Core;
using XihSolutions.DotMSN.DataTransfer;

namespace XihSolutions.DotMSN
{
	/// <summary>
	/// A message that defines a list of emoticons used in the next textmessage.
	/// </summary>
	[Serializable()]
	public class EmoticonMessage : NetworkMessage
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public EmoticonMessage()
		{
			emoticons = new ArrayList();
		}

		/// <summary>
		/// Constructor with a single emoticon supplied.
		/// </summary>
		/// <param name="emoticon"></param>
		public EmoticonMessage(Emoticon emoticon)
		{			
			emoticons = new ArrayList();
			emoticons.Add(emoticon);
		}

		/// <summary>
		/// Constructor with multiple emoticons supplied.
		/// </summary>
		/// <param name="emoticons"></param>
		public EmoticonMessage(ArrayList emoticons)
		{
			Emoticons = (ArrayList)emoticons.Clone();			
		}

		/// <summary>
		/// </summary>
		private ArrayList emoticons;

		/// <summary>
		/// The emoticon that is defined in this message
		/// </summary>
		public ArrayList Emoticons
		{
			get { return emoticons; }
			set { emoticons = value;}
		}

		/// <summary>
		/// Sets the Emoticon property.
		/// </summary>
		/// <param name="data"></param>
		public override void ParseBytes(byte[] data)
		{			
			// set the text property for easy retrieval
			string body = System.Text.Encoding.UTF8.GetString(data);
			
			Emoticons = new ArrayList();
			
			string[] values = body.Split('\t');
						
			for(int i = 0; i < values.Length; i += 2)
			{
				Emoticon emoticon = new Emoticon();
				emoticon.Shortcut = values[0].Trim();
				emoticon.ParseContext(values[1].Trim());

				Emoticons.Add(emoticon);
			}

			
		}

		/// <summary>
		/// Sets the mime-headers in the <see cref="MSGMessage"/> object. This is the 'parent' message object.
		/// </summary>
		public override void PrepareMessage()
		{
			base.PrepareMessage();			
			if(ParentMessage != null)
			{
				MSGMessage msgMessage = (MSGMessage)ParentMessage;
				msgMessage.MimeHeader["Content-Type"] = "text/x-mms-emoticon";				
			}
		}

	
		/// <summary>
		/// Gets the header with the body appended as a byte array
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{			
			StringBuilder builder = new StringBuilder();
			for(int i = 0; i < emoticons.Count; i++)
			{	
				if(i > 0) builder.Append('\t');

				Emoticon emoticon = (Emoticon)emoticons[i];
				builder.Append(emoticon.Shortcut).Append('\t').Append(emoticon.ContextPlain);
			}
			return System.Text.Encoding.UTF8.GetBytes(builder.ToString());
		}


		/// <summary>
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "[EmoticonMessage] " + System.Text.Encoding.UTF8.GetString(GetBytes());
		}

	}
}
