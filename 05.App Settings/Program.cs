namespace NetCoreSamples
{

	using Microsoft.Extensions.Configuration;
	using System;
	using System.IO;

	public class Program
	{

		private static string logFile;

		public static void Main(string[] args)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			var configuration = builder.Build();

			logFile = configuration["Logging:LogFile"];

			Console.WriteLine($"LogFile: {logFile}");

			var dateTime = DateTime.Now;

			WriteToLog($"Test at {dateTime}");
			Console.WriteLine("The text has been registered on the log");

			Console.ReadLine();
		}


		private static void WriteToLog(string text)
		{
			var log = File.AppendText(logFile);
			log.WriteLine(text);
			log.Dispose();
		}

	}

}