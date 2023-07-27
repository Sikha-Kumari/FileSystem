using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    public class Operations
    {
        public void GetDirectories(string path)
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(path);

            DirectoryInfo[] directories = currentdirectory.GetDirectories();

            foreach (DirectoryInfo dircetory in directories)
                Console.WriteLine(dircetory.Name);
        }

        public void SetcurrentDirectory(string target)
        {
            try
            {
                Environment.CurrentDirectory = (target);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void GetcurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("You are in the directory: {0}", currentDirectory);
        }

        public void MakeDirectory(string path)
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

        public void RemoveDirectory(string path)
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

        public void SetParentDirectory(string path)
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

        public void GetDirectoryAndFiles(string path)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(path);
            DirectoryInfo[] directories = currentDirectory.GetDirectories("*", SearchOption.AllDirectories);
            FileInfo[] files = currentDirectory.GetFiles("*", SearchOption.AllDirectories);

            foreach (DirectoryInfo directory in directories)
                Console.WriteLine("Directory Name: {0} Full Path: {1} Type: {2}", directory.Name, directory.FullName, directory.Attributes);

            foreach (FileInfo file in files)
            {
                Console.WriteLine("File Name: {0} Full Path: {1} Type: {2}", file.Name, file.FullName, file.Extension + " File");
            }
        }

        public void ReadFile(string path)
        {
            FileInfo file = new FileInfo(path);
            FileStream fileReadStream = file.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fileReadStream);
            string fileContent = streamReader.ReadToEnd();
            streamReader.Close();
            fileReadStream.Close();
            Console.WriteLine("Content of file {0} is", file.Name);
            Console.WriteLine(fileContent);
        }

        public void WriteToFile(string path, string contentFilePath)
        {
            File.AppendAllText(path, File.ReadAllText(contentFilePath));
            Console.WriteLine("Content of file: {0} has been added to file: {1} ", contentFilePath, path);
        }

        public void CopyFile(string sourceFile, string DestinationFile)
        {
            FileInfo sourceFileInfo = new FileInfo(sourceFile);
            FileInfo DestinationFileInfo = new FileInfo(DestinationFile);

            try
            {
                if (File.Exists(DestinationFile))
                {
                    DestinationFileInfo.Delete();
                }
                sourceFileInfo.CopyTo(DestinationFile);

                Console.WriteLine("Content of {0} was copied to {1}.", sourceFile, DestinationFile);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        public void MoveFile(string sourceFile, string DestinationFile)
        {
            FileInfo sourceFileInfo = new FileInfo(sourceFile);
            FileInfo DestinationFileInfo = new FileInfo(DestinationFile);

            try
            {
                if (File.Exists(DestinationFile))
                {
                    DestinationFileInfo.Delete();
                }
                sourceFileInfo.MoveTo(DestinationFile);
                File.Delete(sourceFile);
                Console.WriteLine("Content of {0} was moved to {1}.", sourceFile, DestinationFile);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }
    }
}
