using System;

namespace Final_Exam_Preparation_03_August_2019_Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArg = input.Split(" " ,StringSplitOptions.RemoveEmptyEntries);
                string comand = inputArg[0];

                if (comand == "Translate")
                {
                    char charToReplace = char.Parse(inputArg[1]);
                    char replaceChar = char.Parse(inputArg[2]);

                    text = text.Replace(charToReplace ,replaceChar);
                    Console.WriteLine(text);
                }
                else if (comand == "Includes")
                {
                    string word = inputArg[1];
                    if (text.Contains(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (comand == "Start")
                {
                    string word = inputArg[1];
                    string[] temp = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (temp[0] == word)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
       
                }
                else if (comand == "Lowercase")
                {
                    
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (comand == "FindIndex")
                {
                    char curr = char.Parse(inputArg[1]);
                    if (text.Contains(curr))
                    {
                        int index = text.LastIndexOf(curr);
                        Console.WriteLine(index);
                    }
                }
                else if (comand == "Remove")
                {
                    int startIndex = int.Parse(inputArg[1]);
                    int indexNum = int.Parse(inputArg[2]);

                    if (startIndex >= 0 && (indexNum + startIndex) <= text.Length -1)
                    {
                        text = text.Remove(startIndex, indexNum);
                    }

                    Console.WriteLine(text);
                }
            }
        }
    }
}
