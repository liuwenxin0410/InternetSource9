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
	/// Specifies the type of proxy servers that can be used
	/// </summary>
	public enum ProxyType
	{
		/// <summary>No proxy server.</summary>
		None,
		/// <summary>A SOCKS4[A] proxy server.</summary>
		Socks4,
		/// <summary>A SOCKS5 proxy server.</summary>
		Socks5
	}

	/// <summary>
	/// Specifieds the type of a notification message.
	/// </summary>
	public enum NotificationType
	{
		/// <summary>
		/// A message a remote contact send from a mobile device.
		/// </summary>
		Mobile = 0, 
		/// <summary>
		/// A calendar reminder.
		/// </summary>
		Calendar = 1,
		/// <summary>
		/// An alert notification.
		/// </summary>
		Alert = 2
	}

	/// <summary>
	/// Specifies the online presence state
	/// </summary>
	public enum PresenceStatus { 
		/// <summary>
		/// Unknown presence state.
		/// </summary>
		Unknown = 0, 
		/// <summary>
		/// Contact is offline (or a remote contact is hidden).
		/// </summary>
		Offline, 
		/// <summary>
		/// The client owner is hidden.
		/// </summary>
		Hidden, 
		/// <summary>
		/// The contact is online.
		/// </summary>
		Online, 
		/// <summary>
		/// The contact is away.
		/// </summary>
		Away, 
		/// <summary>
		/// The contact is busy.
		/// </summary>
		Busy, 
		/// <summary>
		/// The contact will be right back.
		/// </summary>
		BRB, 
		/// <summary>
		/// The contact is out to lunch.
		/// </summary>
		Lunch, 
		/// <summary>
		/// The contact is on the phone.
		/// </summary>
		Phone, 
		/// <summary>
		/// The contact is idle.
		/// </summary>
		Idle }

	/// <summary>
	/// Specifies an error a MSN Server can send.
	/// </summary>
	public enum MSNError 
	{
		/// <summary>
		/// Syntax error.
		/// </summary>
		SyntaxError = 200,
		/// <summary>
		/// Invalid parameter.
		/// </summary>
		InvalidParameter = 201,
		/// <summary>
		/// Invalid user.
		/// </summary>
		InvalidUser = 205,
		/// <summary>
		/// Missing domain.
		/// </summary>
		MissingDomain = 206,
		/// <summary>
		/// The user is already logged in.
		/// </summary>
		AlreadyLoggedIn = 207,
		/// <summary>
		/// The username specified is invalid.
		/// </summary>
		InvalidUsername = 208,	
		/// <summary>
		/// The full username specified is invalid.
		/// </summary>
		InvalidFullUsername = 209,	
		/// <summary>
		/// User's contact list is full.
		/// </summary>
		UserListFull = 210,			
		/// <summary>
		/// User is already specified.
		/// </summary>
		UserAlreadyThere = 215,		
		/// <summary>
		/// User is already on the list.
		/// </summary>
		UserAlreadyOnList = 216,
		/// <summary>
		/// User is not online.
		/// </summary>
		UserNotOnline = 217,	
		/// <summary>
		/// Already in stated mode.
		/// </summary>
		AlreadyInMode = 218,		
		/// <summary>
		/// User is in opposite (conflicting) list.
		/// </summary>
		UserInOppositeList = 219,	
		/// <summary>
		/// Contactgroup name already exists.
		/// </summary>
		ContactGroupNameExists = 228,	
		/// <summary>
		/// Switchboard request failed.
		/// </summary>
		SwitchboardFailed = 280,
		/// <summary>
		/// Switchboard transfer failed.
		/// </summary>
		SwitchboardTransferFailed = 281,
		/// <summary>
		/// Required field is missing.
		/// </summary>
		MissingRequiredField = 300,		
		/// <summary>
		/// User is not logged in.
		/// </summary>
		NotLoggedIn = 302,
		/// <summary>
		/// Internal server error.
		/// </summary>
		InternalServerError = 500,	
		/// <summary>
		/// Databaseserver error.
		/// </summary>
		DatabaseServerError = 501,
		/// <summary>
		/// File operation failed. 
		/// </summary>
		FileOperationFailed = 510,
		/// <summary>
		/// Memory allocation failure.
		/// </summary>
		MemoryAllocationFailed = 520,
		/// <summary>
		/// Server is busy.
		/// </summary>
		ServerIsBusy = 600,
		/// <summary>
		/// Server is unavailable.
		/// </summary>
		ServerIsUnavailable = 601,
		/// <summary>
		/// Nameserver is down.
		/// </summary>
		NameServerDown = 602,
		/// <summary>
		/// Database connection failed.
		/// </summary>
		DatabaseConnectionFailed = 603,
		/// <summary>
		/// Server is going down.
		/// </summary>
		ServerGoingDown = 604,
		/// <summary>
		/// Connection creation failed.
		/// </summary>
		CouldNotCreateConnection = 707, 
		/// <summary>
		/// Write is blocking.
		/// </summary>
		WriteIsBlocking = 711,
		/// <summary>
		/// Session is overloaded.
		/// </summary>
		SessionIsOverloaded = 712,
		/// <summary>
		/// Too many active users.
		/// </summary>
		TooManyActiveUsers = 713,
		/// <summary>
		/// Too many sessions.
		/// </summary>
		TooManySessions = 714,
		/// <summary>
		/// Not expected command.
		/// </summary>
		NotExpected = 715,
		/// <summary>
		/// Bad friend file.
		/// </summary>
		BadFriendFile = 717,
		/// <summary>
		/// Authentication failed.
		/// </summary>
		AuthenticationFailed = 911,
		/// <summary>
		/// Action is not allowed when user is offline.
		/// </summary>
		NotAllowedWhenOffline = 913,
		/// <summary>
		/// New users are not accepted.
		/// </summary>
		NotAcceptingNewUsers = 920 
	}
	

	/// <summary>
	/// One of the four lists used in the messenger network
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item>AllowedList - all contacts who are allowed to see <i>your</i> status</item>
	/// <item>ReverseList - all contacts who have <i>you</i> on <i>their</i> contactlist</item>
	/// <item>ForwardList - all contacts in your contactlist. You can send messages to those people</item>
	/// <item>BlockedList - all contacts who you have blocked</item>
	/// </list>
	/// </remarks>
	[FlagsAttribute]
	public enum MSNLists
	{
		/// <summary>
		/// All contacts who are allowed to see your status.
		/// </summary>
		AllowedList = 2,
		/// <summary>
		/// All contacts who have you on their contactlist.
		/// </summary>
		ReverseList = 8, 
		/// <summary>
		/// All contacts in your contactlist.
		/// </summary>
		ForwardList = 1, 
		/// <summary>
		/// All contacts who you have blocked.
		/// </summary>
		BlockedList = 4
	}

	/// <summary>
	/// Defines the privacy mode of the owner of the contactlist
	/// <list type="bullet">
	/// <item>AllExceptBlocked - Allow all contacts to send you messages except those on your blocked list</item>
	/// <item>NoneButAllowed - Reject all messages except those from people on your allow list</item></list>
	/// </summary>
	public enum PrivacyMode
	{
		/// <summary>
		/// Unknown privacy mode.
		/// </summary>
		Unknown = 0, 
		/// <summary>
		/// Allow all contacts to send you messages except those on your blocked list.
		/// </summary>
		AllExceptBlocked = 1, 
		/// <summary>
		/// ct all messages except those from people on your allow list.
		/// </summary>
		NoneButAllowed = 2
	}

	/// <summary>
	/// Defines the way MSN handles with new contacts
	/// <list type="bullet">
	/// <item>PromptOnAdd - Notify the clientprogram when a contact adds you and let the program handle the response itself</item>
	/// <item>AutomaticAdd - When someone adds you MSN will automatically add them on your list</item>
	/// </list>
	/// </summary>
	public enum NotifyPrivacy
	{
		/// <summary>
		/// Unknown notify privacy.
		/// </summary>
		Unknown = 0, 
		/// <summary>
		/// Notify the clientprogram when a contact adds you and let the program handle the response itself.
		/// </summary>
		PromptOnAdd = 1, 
		/// <summary>
		/// When someone adds you MSN will automatically add them on your list.
		/// </summary>
		AutomaticAdd = 2
	}

	/// <summary>
	/// The functions a (remote) client supports.
	/// </summary>
	[FlagsAttribute]
	public enum ClientCapacities
	{
		/// <summary>
		/// Accepts direct mobile messages.
		/// </summary>
		IsMobile = 1, 
		/// <summary>
		/// Can view ink messages.
		/// </summary>
		CanViewInk = 4, 
		/// <summary>
		/// Can view and create ink messages.
		/// </summary>
		CanViewCreateInk = 8, 
		/// <summary>
		/// Can videoconference.
		/// </summary>
		CanVideoConference = 16,
		/// <summary>
		/// Can receive pages.
		/// </summary>
		CanReceivePages = 64,
		/// <summary>
		/// Can receive direct pages.
		/// </summary>
		CanReceiveDirectPages = 128,
		/// <summary>
		/// Can handle the MSNC1 protocol.
		/// </summary>
		CanHandleMSNC1 = 268435456,
		/// <summary>
		/// Can handle the MSNC2 protocol.
		/// </summary>
		CanHandleMSNC2 = 536870912
	}
	
	/// <summary>
	/// The text decorations messenger sends with a message
	/// </summary>
	[FlagsAttribute]
	public enum TextDecorations
	{
		/// <summary>
		/// No decoration.
		/// </summary>
		None = 0, 
		/// <summary>
		/// Bold.
		/// </summary>
		Bold = 1,
		/// <summary>
		/// Italic.
		/// </summary>
		Italic = 2, 
		/// <summary>
		/// Underline.
		/// </summary>
		Underline = 4, 
		/// <summary>
		/// Strike-trough.
		/// </summary>
		Strike = 8
	}

	/// <summary>
	/// A charset that can be used in a message.
	/// </summary>
	public enum MessageCharSet
	{
		/// <summary>
		/// ANSI
		/// </summary>
		Ansi = 0, 
		/// <summary>
		/// Default charset.
		/// </summary>
		Default =	1,
		/// <summary>
		/// Symbol.
		/// </summary>
		Symbol = 2, 
		/// <summary>
		/// Mac.
		/// </summary>
		Mac = 77, 
		/// <summary>
		/// Shiftjis.
		/// </summary>
		Shiftjis = 128, 
		/// <summary>
		/// Hangeul.
		/// </summary>
		Hangeul = 129, 
		/// <summary>
		/// Johab.
		/// </summary>
		Johab = 130, 
		/// <summary>
		/// GB2312.
		/// </summary>
		GB2312 = 134,
		/// <summary>
		/// Chines Big 5.
		/// </summary>
		ChineseBig5 = 136, 
		/// <summary>
		/// Greek.
		/// </summary>
		Greek = 161, 
		/// <summary>
		/// Turkish.
		/// </summary>
		Turkish = 162, 
		/// <summary>
		/// Vietnamese.
		/// </summary>
		Vietnamese = 163, 
		/// <summary>
		/// Hebrew.
		/// </summary>
		Hebrew = 177, 
		/// <summary>
		/// Arabic.
		/// </summary>
		Arabic = 178, 
		/// <summary>
		/// Baltic.
		/// </summary>
		Baltic = 186,
		/// <summary>
		/// Russian.
		/// </summary>
		Russian = 204, 
		/// <summary>
		/// Thai.
		/// </summary>
		Thai = 222, 
		/// <summary>
		/// Eastern Europe.
		/// </summary>
		EastEurope = 238, 
		/// <summary>
		/// OEM.
		/// </summary>
		Oem = 255
	}
}
