﻿using System.IO;

namespace AppHarbor.Commands
{
	[CommandHelp("List your applications")]
	public class AppCommand : ICommand
	{
		private readonly IAppHarborClient _client;
		private readonly TextWriter _writer;

		public AppCommand(IAppHarborClient appharborClient, TextWriter writer)
		{
			_client = appharborClient;
			_writer = writer;
		}

		public void Execute(string[] arguments)
		{
			var applications = _client.GetApplications();
			foreach (var application in applications)
			{
				_writer.WriteLine(application.Slug);
			}
		}
	}
}
