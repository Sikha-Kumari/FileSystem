using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FileSystems
{
    internal class Program
    {

        // show current location
        // history of command executed
        //(add help command)(ls space types of command)
        static void Main(string[] args)
        {
            //if (args.Length == 1 && HelpRequired(args[0]))
            //{
            //   // DisplayHelp();
            //}
            Console.WriteLine("Hi, Welcome to File System. This is an appliation to run your file and directory operations");

            string operations;
            Dictionary<string, string> commandList = GetCommandList();

            Console.WriteLine("Please enter the operations");
            Console.WriteLine("{0}>", Directory.GetCurrentDirectory());
            while ((operations = Console.ReadLine()) != "exit()")
            {
                args = operations.Split(' ');
                string command = args[0].ToLower();

                if (commandList.ContainsKey(command))
                {

                    Operations operation = new Operations();
                    var commandClass = commandList[command];

                    Assembly executing = Assembly.GetExecutingAssembly();

                    Type[] types = executing.GetTypes();
                    foreach (var item in types)
                    {
                        if (commandClass == item.Name)
                        {
                            object commandInstance = Activator.CreateInstance(item, new object[] { operation });
                            Invoker invoker = new Invoker();
                            invoker.StoreAndExecute((ICommand)commandInstance, args);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid operation");
                }

                Console.WriteLine("Please enter the operations or enter exit() to exit the program");
                Console.WriteLine("{0}>", Environment.CurrentDirectory);
            }
            Environment.Exit(0);
            Console.ReadKey();

        }

        private static Dictionary<string, string> GetCommandList()
        {
            string commandJson = File.ReadAllText(@"./../../../CommandConfig.json");
            var jObject = JObject.Parse(commandJson);
            JArray commandsArrary = (JArray)jObject["commands"];
            Dictionary<string, string> commandList = new Dictionary<string, string>();
            foreach (var command in commandsArrary)
            {
                commandList.Add(command["command"].ToString(), command["commandclass"].ToString());
            }
            return commandList;
        }

        private static bool HelpRequired(string param)
        {
            return param == "-h" || param == "--help";
        }

        
    }
}
