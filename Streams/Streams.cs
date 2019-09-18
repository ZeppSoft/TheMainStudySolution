using System;
using System.IO;

namespace Streams
{
    public class Streams
    {
        public static void TryDirectory()
        {
            var dir = new DirectoryInfo(@"C:\TestDir");

            if (dir.Exists)
            {
                Console.WriteLine(dir.FullName);
                Console.WriteLine(dir.Parent);
                Console.WriteLine(dir.Root);
                Console.WriteLine(dir.Attributes);

               // dir.CreateSubdirectory("SubDir");


               var files = dir.GetFiles("*.*");

                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                }
            }
        }

        public static void TryCreateFile()
        { 
            var file = new FileInfo(@"C:\TestDir\zepp.txt");

            FileStream stream = file.Create();

            stream.Close();


            file.Delete();
        }

        public static void TryReadFile()
        {
            var file = new FileInfo(@"C:\TestDir\zepp.txt");

            if (file.Exists)
            {
                FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader reader = new StreamReader(stream);

                var res = reader.ReadLine();
                Console.WriteLine(res);

                reader.Close();

                stream.Close();
            }
        }

        public static void  TryReadWriteMemoryStream()
        {
            var memory = new MemoryStream(256);

            
        }

    }
}
