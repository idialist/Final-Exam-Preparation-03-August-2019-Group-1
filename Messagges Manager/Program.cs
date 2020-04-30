using System;
using System.Collections.Generic;
using System.Linq;

namespace Messagges_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> callcenter = new Dictionary<string, List<int>>();

            int capacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArg = input.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArg[0];

                if (command == "Add")
                {
                    string name = inputArg[1];
                    int sent = int.Parse(inputArg[2]);
                    int recieve = int.Parse(inputArg[3]);

                    if (!callcenter.ContainsKey(name))
                    {
                        callcenter[name] = new List<int>() { sent, recieve };
                    }
                }
                else if (command == "Message")
                {
                    string sender = inputArg[1];
                    string reciever = inputArg[2];

                    if (callcenter.ContainsKey(sender) && callcenter.ContainsKey(reciever))
                    {
                        callcenter[sender][0] += 1;
                        callcenter[reciever][1] += 1;

                        if (callcenter[reciever][1] >= 10)
                        {
                            Console.WriteLine($"{reciever} reached the capacity!");
                            callcenter.Remove(reciever);
                            continue;
                        }
                        else if (callcenter[sender][0] >= 10)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            callcenter.Remove(sender);
                        }
                    }
                    else if (callcenter.ContainsKey(sender))
                    {
                        callcenter[sender][0] += 1;

                        if (callcenter[sender][0] >= 10)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            callcenter.Remove(sender);
                        }
                    }
                    else if (callcenter.ContainsKey(reciever))
                    {
                        callcenter[reciever][1] += 1;

                        if (callcenter[reciever][0] >= 10)
                        {
                            Console.WriteLine($"{reciever} reached the capacity!");
                            callcenter.Remove(reciever);
                        }
                    }
                }

                else if (command == "Empty")
                {
                    string name = inputArg[1];
                    if (name == "All")
                    {
                        foreach (var kvp in callcenter)
                        {
                            callcenter.Remove(kvp.Key);
                        }
                    }
                    else
                    {
                        callcenter.Remove(name);
                    }
                }
            }
            Console.WriteLine($"Users count: {callcenter.Count}");

            callcenter = callcenter.OrderByDescending(m => m.Value[1]).ThenBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);

            foreach (var kvp in callcenter)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Sum()}");
            }
        }
    }
}