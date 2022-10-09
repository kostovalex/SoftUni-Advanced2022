using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsInText = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!charsInText.ContainsKey(text[i]))
                {
                    charsInText.Add(text[i], 0);
                }
                charsInText[text[i]]++;
            }
            //S: 1 time/s

            foreach (var element in charsInText)
            {
                Console.WriteLine($"{element.Key}: {element.Value} time/s");
            }
        }
    }
}
