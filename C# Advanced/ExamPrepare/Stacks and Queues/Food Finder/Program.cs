using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            List<char> letters = new List<char>();

            while (consonants.Count != 0)
            {
                char currVowe = vowels.Peek();
                char currConsonant = consonants.Peek();
                if (currVowe == 'e' || currVowe == 'a' || currVowe == 'o' ||
                    currVowe == 'u' || currVowe == 'i')
                {
                    if (!letters.Contains(currVowe))
                    {
                        letters.Add(currVowe);
                    }
                }
                if (currConsonant == 'p' || currConsonant == 'r' || currConsonant == 'f' ||
                    currConsonant == 'l' || currConsonant == 'k' || currConsonant == 'v')
                {
                    if (!letters.Contains(currConsonant))
                    {
                        letters.Add(currConsonant);
                    }
                }


                vowels.Enqueue(vowels.Dequeue());
                consonants.Pop();
            }
 
            List<string> words = new List<string>();
            words.Add("pear");
            words.Add("flour");
            words.Add("pork");
            words.Add("olive");

            List<string> foundedWords = new List<string>();

            foreach (var word in words)
            {
                bool exist = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!letters.Contains(word[i]))
                    {
                        exist = false;
                        break;
                    }
                }

                if (exist)
                {
                    foundedWords.Add(word);
                }
            }

            Console.WriteLine($"Words found: {foundedWords.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, foundedWords));
        }
    }
}
