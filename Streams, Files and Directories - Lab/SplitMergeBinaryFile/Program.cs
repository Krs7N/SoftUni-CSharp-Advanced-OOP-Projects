using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"../../../Files/example.png";
            string joinedFilePath = @"../../../Files/example-joined.png";
            string partOnePath = @"../../../Files/part-1.bin";
            string partTwoPath = @"../../../Files/part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream source = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {
                    int odd = source.Length % 2 == 1 ? 1 : 0;
                    byte[] buffer = new byte[source.Length / 2 + odd];
                    source.Read(buffer);
                    partOne.Write(buffer);
                }

                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[source.Length / 2];
                    source.Read(buffer);
                    partTwo.Read(buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream merged = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partOne.Length];
                    partOne.Read(buffer);
                    merged.Write(buffer);
                }

                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partTwo.Length];
                    partTwo.Read(buffer);
                    merged.Write(buffer);
                }
            }
        }
    }
}