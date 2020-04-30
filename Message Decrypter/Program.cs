using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^(\$|%)(?<comand>[A-Z][a-z]{2,})\1. \[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<thirth>[0-9]+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                List<char> numbers = new List<char>();

                Match matches = Regex.Match(input,pattern);

                if (matches.Success)
                {
                    string name = matches.Groups["comand"].Value;
                    int first =int.Parse(matches.Groups["first"].Value);
                    int second = int.Parse(matches.Groups["second"].Value);
                    int thirth = int.Parse(matches.Groups["thirth"].Value);

                    numbers.Add((char)first);
                    numbers.Add((char)second);
                    numbers.Add((char)thirth);

                    Console.WriteLine($"{name}: {string.Join("",numbers)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
