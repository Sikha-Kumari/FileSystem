using System;
using System.IO;

namespace FileSystems
{
    internal class Program
    {

        // show current location
        // cd path
        // history of command executed

        static void Main(string[] args)
        {
            string operations;

            Console.WriteLine("Please enter the directory for your operations");
            string input = Console.ReadLine();
            string[] commandAndPath = input.Split(' ');
            string path = commandAndPath[1];
            if (commandAndPath[0].ToLower() == "cd" && !string.IsNullOrEmpty(path.ToLower()))
            {
                DirectoryOperations.setcurrentDirectory(path);
            }

            Console.WriteLine("Please enter the operations");

            while ((operations = Console.ReadLine()) != "exit()")
            {
                string[] operationsArray = operations.Split(' ');

                string command = operationsArray[0].ToLower();
                string dirFileName = (operationsArray.Length > 1) ? operations.Split(' ')[1].ToLower() : "";
                string fullpath = path + "\\" + dirFileName;
                if (operationsArray.Length > 2)
                {
                    string destinationFileName = operationsArray[2].ToLower();
                    string destinationfullpath = path + "\\" + destinationFileName;
                    ProcessThreeParameterOperations(command, fullpath, destinationfullpath);
                }

                else if (operationsArray.Length >= 1)
                {
                    ProcessOperations(command, fullpath);
                }

                else
                {
                    Console.WriteLine("Please enter some valid operations");
                }

            }

            Console.ReadKey();

            //FileSystemOperations.WriteToFile();

        }

        private static void ProcessOperations(string command, string fullPath)
        {

            switch (command)
            {
                //get dir, get files, recursive files(chaining of dir and files)
                //(full path from current location)
                //(add help command)(ls space types of command)
                case "ls":
                    FileSystemOperations.GetDirectoryAndFiles(fullPath);
                    break;

                    //path is not being set
                case "cd..":
                    DirectoryOperations.setParentDirectory(fullPath);
                    break;

                case "pwd":
                    DirectoryOperations.getcurrentDirectory();
                    break;

                case "mkdir":
                    DirectoryOperations.makeDirectory(fullPath);
                    break;

                case "rmdir":
                    DirectoryOperations.removeDirectory(fullPath);
                    break;
                case "cat":
                    FileSystemOperations.ReadFile(fullPath);
                    break;

                default:
                    Console.WriteLine("Please enter some operations");
                    break;
            }
        }

        private static void ProcessThreeParameterOperations(string command, string fullPath, string destinationfullpath)
        {

            switch (command)
            {
                case "cp":
                    FileSystemOperations.CopyFile(fullPath, destinationfullpath);
                    break;

                case "mv":
                    FileSystemOperations.MoveFile(fullPath, destinationfullpath);
                    break;

                case "cat":
                    FileSystemOperations.WriteToFile(fullPath, destinationfullpath);
                    break;

                default:
                    Console.WriteLine("Please enter some operations");
                    break;
            }
        }
    }

    
}
