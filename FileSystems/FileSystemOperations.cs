using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    internal class FileSystemOperations
    {


        // print getdirectory and the type(file/type)
        internal static void GetDirectoryAndFiles(string path)
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
        internal static void ReadFile(string path)
        {
            FileInfo file = new FileInfo(path);
            FileStream fileReadStream = file.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fileReadStream);
            string fileContent = streamReader.ReadToEnd();
            streamReader.Close();
            fileReadStream.Close();
            Console.WriteLine(fileContent);
        }

        internal static void WriteToFile(string path, string contentFilePath)
        {
            File.AppendAllText(path, File.ReadAllText(contentFilePath));
            //FileInfo file = new FileInfo(path);
            //FileStream fileWriteStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            // StreamWriter streamWriter = new StreamWriter(fileWriteStream);
            //streamWriter.WriteLine("Another line from streamwriter");
            //streamWriter.Close();
            //fileWriteStream.Close();
        }

        // Copies the content of the source file to destination file
        internal static void CopyFile(string sourceFile, string DestinationFile)
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

                Console.WriteLine("{0} was copied to {1}.", sourceFile, DestinationFile);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        internal static void MoveFile(string sourceFile, string DestinationFile)
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
                Console.WriteLine("{0} was moved to {1}.", sourceFile, DestinationFile);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }
    }
}
