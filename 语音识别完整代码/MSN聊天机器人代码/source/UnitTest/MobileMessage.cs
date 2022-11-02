using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using NUnit.Framework;
using NUnit.Core;
using NUnit;
using XihSolutions.DotMSN;
using XihSolutions.DotMSN.Core;
using XihSolutions.DotMSN.DataTransfer;

namespace XihSolutions.DotMSN.Test
{
	/// <summary>
	/// Serializes all serializable objects into memory.
	/// </summary>
	[TestFixture, Explicit]
	public class MobileMessageTest : TestBase
	{
		public MobileMessageTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[Test]
		public void SendDirectMessage()
		{
			if(Client1.ContactList[Client2.Owner.Name].MobileDevice == true)
			{
				Client1.Nameserver.SendMobileMessage(Client1.ContactList[Client2.Owner.Name], "DotMSN mobile message test from " + Client1.Owner.Mail + " !");
			}
			else if(Client2.ContactList[Client1.Owner.Name].MobileDevice == true)
			{
				Client2.Nameserver.SendMobileMessage(Client2.ContactList[Client1.Owner.Name], "DotMSN mobile message test from " + Client2.Owner.Mail + " !");
			}

		}
	}
}
