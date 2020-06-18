using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static bool CheckFile(string fileName)
        {
            return File.Exists(fileName);
        }

        public static string RemoveExtraBlanksInString(string lineOfTheFile)
        {
            lineOfTheFile = lineOfTheFile.Trim();
            lineOfTheFile = Regex.Replace(lineOfTheFile, "\t", " ");
            lineOfTheFile = Regex.Replace(lineOfTheFile, "[ ]+", " ");
            return lineOfTheFile;
        }

        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage RemuveExtraBlanks.exe <input string>");
                return 1;
            }

            string inputName = args[0];
            string outputName = args[1];
            
            if (inputName == outputName)
            {
                Console.WriteLine("Same input and output file name");
                return 1;
            }

            if (!File.Exists(inputName))
            {
                Console.WriteLine( inputName + " is not open!");
                return 1;
            }

            StreamReader inputFile = new StreamReader(inputName);
            StreamWriter outputFile = new StreamWriter(outputName);
            string lineOfTheFile;

            while ((lineOfTheFile = inputFile.ReadLine()) != null)
            {
                outputFile.WriteLine(RemoveExtraBlanksInString(lineOfTheFile));
            }

            return 0;
        }
    }
}
