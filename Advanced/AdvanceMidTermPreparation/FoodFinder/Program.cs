using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray()); 

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray()); 

            List<string> words = new List<string>() { "pear", "flour", "pork", "olive" };

            while (consonants.Count!=0)
            {
                char currVow = vowels.Dequeue();
                vowels.Enqueue(currVow);
                char currCon = consonants.Pop();

                for (int i = 0; i < words.Count; i++)
                {
                    char[] currentWord = words[i].ToArray();
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        if (currCon == currentWord[j] || currVow == currentWord[j])
                        {
                            currentWord[j] = char.ToUpper(currentWord[j]);
                        }
                    }
                    words[i] = string.Join("", currentWord);
                }
            }

            List<string> found = new List<string>();
            List<string> notFound = new List<string>();

            foreach (var word in words)
            {
                bool isFound = true;
                foreach (var item in word)
                {
                    if(char.IsLower(item))
                    {
                        isFound = false;
                    }   
                }
                if (isFound)
                {
                    found.Add(word.ToLower());
                }
                else
                {
                    notFound.Add(word.ToLower());
                }
            }


            Console.WriteLine($"Words found: {found.Count}");
            foreach (var item in found)
            {
                Console.WriteLine(item);
            }
                
        }
    }
}
