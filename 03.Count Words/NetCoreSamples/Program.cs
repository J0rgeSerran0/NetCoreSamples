namespace NetCoreSamples
{

    using System;

    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Write a text:");
            var text = Console.ReadLine();

            var counter = new Counter();
            Console.WriteLine(counter.WordsFromText(text).ToString());

            Console.ReadLine();
        }

    }

}