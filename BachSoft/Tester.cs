using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachSoft
{
    public static class Tester
    {
        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }


        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files....");
            string mismatchPath = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatch;
            string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputPath, out hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismatchPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");

        }

        private static string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputPath, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            string[] mismaches = new string[actualOutputLines.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            for (int index = 0; index < actualOutputLines.Length; index++)
            {
                string actualLine = actualOutputLines[index];
                string expextedLine = expectedOutputPath[index];

                if (!actualLine.Equals(expextedLine))
                {
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;

                }
                mismaches[index] = output;

            }
            return mismaches;
        }
    }
}
