using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"../../../Files/TestFolder";
            string outputPath = @"../../../Files/output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);

            decimal folderSize = 0;

            foreach (var file in files)
            {
                folderSize += file.Length;
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.Write(folderSize / 1024 + " KB");
            }

            //File.WriteAllText(outputFilePath, folderSize / 1024 + " KB");
        }
    }
}