using System;
using Grpc.Net.Client;
using SystemStatusService;
using Newtonsoft.Json;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to server status service");
            Console.Write("Enter server addres : ");
            string address = Console.ReadLine();
            Console.Write("Enter server token :");
            string token = Console.ReadLine();
            Console.Clear();
            sdk SystemStatus = new sdk(address, token);
            Console.WriteLine("1>Info\n2>process\n3>command\n0>exit");
            while (true)
            {
                Console.Write("Command :~>#");
                int command =int.Parse(Console.ReadLine());
                if (command == 1)
                {
                    foreach (var item in SystemStatus.Info())
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                }
                else if (command==2)
                {
                    foreach (var items in SystemStatus.Process())
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine($"ID : {item.Key} | Name : {item.Value}");
                        }
                    }
                }
                else if (command==3)
                {
                    while (true)
                    {
                        Console.Write($"{token} #enter command >");
                        string cmd = Console.ReadLine();
                        if (cmd == "exit")
                        {
                            break;
                        }
                        else if (!string.IsNullOrEmpty(cmd))
                        {
                            foreach (var item in SystemStatus.Command(cmd))
                            {
                                Console.WriteLine(item.Value);
                            }
                        }
                    }
                }
                else if (command==0)
                {
                    Console.WriteLine("Goodbye...");
                    break;
                }
                else
                {
                    Console.WriteLine($"'{command}' is not recognized as an internal or external command");
                }
            }
        }
    }
}
