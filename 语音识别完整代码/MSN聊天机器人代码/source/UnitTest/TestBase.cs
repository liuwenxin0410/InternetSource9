using System;
using System.IO;
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
	/// Base class for unit tests.
	/// </summary>
	/// <remarks>Handles basic connections and event-catch methods.</remarks>
	[TestFixture]
	public class TestBase
	{
		private DotMSN.Messenger	_client1 = null;
		protected Messenger Client1
		{
			get { return _client1; }
		}

		private DotMSN.Messenger	_client2 = null;
		protected DotMSN.Messenger	Client2
		{
			get { return _client2; }
		}

		private int	multiplier = 1;
		public int Multiplier
		{
			get { return multiplier; }
			set { multiplier = value;}
		}


		#region Constructor and credentials
		public TestBase()
		{
			_client1 = new Messenger();
			_client1.Credentials = new Credentials("tvbot_test@msn.com", "8wkL5t", "msmsgs@msnmsgr.com", "Q1P7W2E4J9R8U3S5");
			_client2 = new Messenger();
			_client2.Credentials = new Credentials("msnbot200@hotmail.com", "200wkL5t", "msmsgs@msnmsgr.com", "Q1P7W2E4J9R8U3S5");	
		}

		#endregion

		#region init and teardown
		[TestFixtureSetUp]
		public void Connect()
		{			
			System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(System.Console.Out));
            DotMSN.Settings.TraceSwitch.Level = TraceLevel.Verbose;

			Client1.Nameserver.ServerErrorReceived += new ErrorReceivedEventHandler(Nameserver_ServerErrorReceived);
			Client2.Nameserver.ServerErrorReceived += new ErrorReceivedEventHandler(Nameserver_ServerErrorReceived);
			Client1.NameserverProcessor.HandlerException += new ProcessorExceptionEventHandler(NameserverProcessor_HandlerException);
			Client2.NameserverProcessor.HandlerException += new ProcessorExceptionEventHandler(NameserverProcessor_HandlerException);
			
			Client1.Nameserver.SynchronizationCompleted += CreateWaitHandler();
			Client2.Nameserver.SynchronizationCompleted += CreateWaitHandler();
				Client1.Connect();
				Client2.Connect();
			Wait(45000);

			

			XihSolutions.DotMSN.Contact.ContactChangedEventHandler busyHandler = new XihSolutions.DotMSN.Contact.ContactChangedEventHandler(Owner_ContactOnline);
			
			CreateWait();			
				Client1.Owner.ContactOnline += busyHandler;
				Client1.Owner.Status = PresenceStatus.Busy;
			Wait(2000);
				Client1.Owner.ContactOnline -= busyHandler;			

			CreateWait();			
				Client2.Owner.ContactOnline += busyHandler;
				Client2.Owner.Status = PresenceStatus.Busy;
			Wait(2000);
				Client2.Owner.ContactOnline -= busyHandler;
		}

		[TestFixtureTearDown]
		public void Disconnect()
		{
			Client1.Disconnect();
			Client2.Disconnect();
		}

		#region Eventwaiting helper methods

		private int stackCount = 0;

		ManualResetEvent currentWait = new ManualResetEvent(false);
		ManualResetEvent currentPulse = new ManualResetEvent(false);

		protected void CreateWait()
		{			
			stackCount++;
		}

		protected void CreateWait(int count)
		{			
			while(count-- > 0)
			{
				stackCount++;
			}
		}

		protected EventHandler CreateWaitHandler()
		{
			CreateWait();
			return new EventHandler(handler_Pulse);			
		}

		public void Wait(int timeOut)
		{			
			if(stackCount == 0) return;						
			currentWait.Reset();
			if(currentWait.WaitOne(timeOut * multiplier, false) == false)
			{
				throw new Exception("Timeout occured. Waited for " + timeOut.ToString() + " ms");
			}
			stackCount = 0;
		}
	
		protected void Pulse()
		{			
			lock(this)
			{
				string text = "Pulse ";
				if(currentWait == null)
					text += "currentWait = null";
				else
					text += "currentWait != null";
				text += " stack : " + stackCount.ToString();

				stackCount--;
				if(stackCount <= 0)
					currentWait.Set();				
			}
		}

		protected void handler_Pulse(object sender, EventArgs e)
		{
			Pulse();
		}
		
		#endregion
		
		#endregion

		private void Nameserver_ServerErrorReceived(object sender, MSNErrorEventArgs e)
		{
			throw new DotMSNException("Server error : " + e.MSNError.ToString());			
		}

		private void Owner_ContactOnline(object sender, EventArgs e)
		{
			Pulse();
		}

		private void NameserverProcessor_HandlerException(object sender, ExceptionEventArgs e)
		{
			// make sure we get this exception. otherwise it is silently ignored.
            if (Settings.TraceSwitch.TraceError)
                System.Diagnostics.Trace.WriteLine("** Handler exceptino ** " + e.Exception.ToString(), "DotMSN Test suite");
			throw e.Exception;
		}
	}
}
