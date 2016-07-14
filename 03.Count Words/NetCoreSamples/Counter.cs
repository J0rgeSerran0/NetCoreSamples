namespace NetCoreSamples
{

    using System;

    public class Counter
    {

        public int WordsFromText(string text)
        {
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return source.Length;
        }

    }

}