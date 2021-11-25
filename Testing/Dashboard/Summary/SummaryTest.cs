﻿/// <author>Sairoop Bodepudi</author>
/// <created>19/11/2021</created>
/// <summary>
///		This is the unit testing file
///		for the summary logic module and
///		tests the summarizer functions.
/// </summary>

using Content;
using Dashboard.Server.Summary;
using NUnit.Framework;
using System.IO;

namespace Testing.Dashboard.Summary
{
	public class SummaryTest
	{
		[SetUp]
		public void Setup()
		{
			_summarizer = SummarizerFactory.GetSummarizer();
		}

		[Test]
		public void GetSummary_NullChatContext_EmptyString()
		{
			ChatContext[] chats = Utils.GetChatContext("Null Context");
			Assert.AreEqual(_summarizer.GetSummary(chats), "");
		}

		[Test]
		public void GetSummary_EmptyChatContext_EmptyString()
		{
			ChatContext[] chats = Utils.GetChatContext("Empty chat context");
			Assert.AreEqual(_summarizer.GetSummary(chats), "");
		}

		[Test]
		public void GetSummary_EmptyChats_EmptyString()
		{
			ChatContext[] chats = Utils.GetChatContext("Empty chats");
			Assert.AreEqual(_summarizer.GetSummary(chats), "");
		}

		[Test]
		public void GetSummary_ValidChatsFixedLength_ConstString()
		{
			ChatContext[] chats = Utils.GetChatContext("Fixed chat");
			string output = "CONST. CONST. CONST. CONST. CONST. CONST. CONST. CONST. CONST. CONST";
			Assert.AreEqual(_summarizer.GetSummary(chats), output);
		}

		[Test]
		public void GetSummary_ValidChatsSmall_NonEmptyString()
		{
			ChatContext[] chats = Utils.GetChatContext("Variable chat");
			Assert.IsTrue(_summarizer.GetSummary(chats).Length > 0);
		}

		[Test]
		public void GetSummary_ValidChatsGeneral_NonEmptyString()
		{
			ChatContext[] chats = Utils.GetChatContext("General chat");
			Assert.IsTrue(_summarizer.GetSummary(chats).Length > 0);
		}

		[Test]
		public void SaveSummary_ValidChatsGeneral_ReturnsTrue()
		{
			ChatContext[] chats = Utils.GetChatContext("General chat");
			Assert.AreEqual(_summarizer.SaveSummary(chats), true);
			Directory.Delete("../../../Persistence", true);
		}

		private ISummarizer _summarizer;
	}
}
