using System.IO;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> occurenceOfWords = new Dictionary<string, int>();
            string[] separator = new string[] {" ", ",", ".", "-", "!", "?" };  

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    int occurence = 0;
                    string[] text = textReader.ReadToEnd().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (word == text[i].ToLower())
                            {
                                occurence++;
                            }
                        }
                        occurenceOfWords.Add(word, occurence);
                        occurence = 0;
                    }
                    
                }

                occurenceOfWords = occurenceOfWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x=> x.Value);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in occurenceOfWords)
                    {
                        string line = $"{word.Key} - {word.Value}";
                        writer.WriteLine(line);
                    }
                }
                           
            }
        }
    }
}
