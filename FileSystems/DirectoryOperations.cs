using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    internal class DirectoryOperations
    {
        internal static void getDirectories(string path)
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(path);

            DirectoryInfo[] directories = currentdirectory.GetDirectories();

            foreach (DirectoryInfo dircetory in directories)
                Console.WriteLine(dircetory.Name);
        }

        internal static void makeDirectory(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine("The directory already exists in this path.");
                    return;
                }

                directory.Create();
                Console.WriteLine("The directory was created successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        internal static void removeDirectory(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (!directory.Exists)
                {
                    Console.WriteLine("The directory does not exists in this path.");
                    return;
                }

                directory.Delete();
                Console.WriteLine("The directory was removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        internal static void getcurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("You are in the directory: {0}",currentDirectory);
        }

        internal static void setcurrentDirectory(string target)
        {
            try
            {
                Environment.CurrentDirectory = (target);
                Console.WriteLine("You are in the directory: {0}" , target);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        internal static void setParentDirectory(string path)
        {
            try
            {
                DirectoryInfo currentDirectory = new DirectoryInfo(path);
                Environment.CurrentDirectory = (currentDirectory.Parent.ToString());
                Console.WriteLine("You are in the directory: {0}", Environment.CurrentDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
