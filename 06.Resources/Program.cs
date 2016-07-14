namespace Resources
{

    using Microsoft.Extensions.Configuration;
    using System;
    using System.Globalization;

    public class Program
    {

        public static void Main(string[] args)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            string language = configuration["Language"];

            var question = Resources.ResourceManager.GetString("Question", new CultureInfo(language));
            Console.WriteLine(question);
            var name = Console.ReadLine();

            var text = Resources.ResourceManager.GetString("Greetings", new CultureInfo(language));
            Console.WriteLine(text, name);
            Console.ReadLine();
        }

    }

}