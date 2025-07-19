// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading.Tasks;
using KafkaChatApp;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Choose Mode: 1 - Send | 2 - Receive");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            while (true)
            {
                Console.Write("Enter message: ");
                string message = Console.ReadLine();
                await Producer.SendMessage(message);
            }
        }
        else if (choice == "2")
        {
            Consumer.Start(); // blocks forever
        }
    }
}

