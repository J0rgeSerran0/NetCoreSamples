namespace ConsoleApplication
{

    using System;

    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Write the Farenheit temperature:");
            var temperature = Console.ReadLine();

            var converter = new Converter();
            var result = converter.FarenheitToCelsius(Convert.ToDouble(temperature));

            Console.WriteLine(String.Format("The temperature in Celsius is {0}", result));
            Console.ReadLine();
        }

    }

}