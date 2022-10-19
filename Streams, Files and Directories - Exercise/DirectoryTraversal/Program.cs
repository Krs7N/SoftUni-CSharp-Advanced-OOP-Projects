using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var extensionFiles = new SortedDictionary<string, List<FileInfo>>();

            var directory = Directory.GetFiles(inputFolderPath);

            foreach (var file in directory)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!extensionFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensionFiles[fileInfo.Extension].Add(fileInfo);
            }

            var orderedFiles = extensionFiles.OrderByDescending(f => f.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var orderedFile in orderedFiles)
            {
                sb.AppendLine(orderedFile.Key);

                var ordered = orderedFile.Value.OrderByDescending(f => f.Length);

                foreach (var file in ordered)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString().Trim();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}