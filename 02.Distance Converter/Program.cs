namespace NetCoreSamples
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
	        var action = String.Empty;

            while (action != "X")
            {
                Console.Clear();
                Console.WriteLine("X = Exit | M = Convert to Miles | K = Convert to Kilometers");

                action = Console.ReadLine();

                // Kilometers to Miles
                if (action == "M")
                {
                    Console.Clear();
                    Console.WriteLine("Write the kilometers");
                    var kilometers = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(Converter.KilometersToMiles(kilometers).ToString());
                    Console.ReadLine();
                }

                // Miles to Kilometers
                if (action == "K")
                {
                    Console.Clear();
                    Console.WriteLine("Write the miles");
                    var miles = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(Converter.MilesToKilometers(miles).ToString());
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}