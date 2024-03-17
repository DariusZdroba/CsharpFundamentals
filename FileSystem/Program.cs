using System.Text;

namespace FileSystem
{
    internal class Program
    {
   
        static void Main(string[] args)
        {
            FileWriteUsingStreamReader();
            FileReadUsingFileInfo();
            FileReadUsingStreamReader();
        }
        static void FileReadUsingFileInfo()
        {
            // Create FileInfo object for specified path
            FileInfo file = new FileInfo(@"DummyFile.txt");

            // Open file for read/write

            FileStream fileStream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            // Create byte array, same size as FileStream length
            byte[] fileBytes = new byte[fileStream.Length];

            // define counter to check how many bytes to read, decrease counter with each byte
            int numBytesToRead = (int)fileBytes.Length;

            // number of bytes read
            int numBytesRead = 0;

            // iterate until all bytes are read
            while (numBytesToRead > 0)
            {
                int n = fileStream.Read(fileBytes, numBytesRead, numBytesToRead);
                if (n == 0) break;
                numBytesRead += n;
                numBytesToRead -= n;
            }
            // Conver the bytes from file into string
            string fileString = Encoding.UTF8.GetString(fileBytes);
            Console.WriteLine(fileString);
        }
        static void FileReadUsingStreamReader()
        {
            //Create object of FileInfo for specified path            
            FileInfo file = new FileInfo("DummyFile.txt");

            FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            //Create object of StreamReader by passing FileStream object on which it needs to operates on
            StreamReader streamReader = new StreamReader(fileStream);

            //Use ReadToEnd method to read all the content from file
            string fileContent = streamReader.ReadToEnd();

            Console.Write(fileContent);

            // Close StreamReader object after operation

            streamReader.Close();
            fileStream.Close();
        }
        static void FileWriteUsingStreamReader()
        {
            //Create object of FileInfo for specified path            
            FileInfo file = new FileInfo("DummyFile.txt");

            // open file to read / write , FileShare for access for others to read/write while the process is ongoing
            FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            // create StreamWriter object to write string to file

            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write("A line from streamwriter");
            streamWriter.Close();
        }
    }
}
