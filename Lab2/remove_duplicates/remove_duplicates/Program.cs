using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
            }
            else
            {
                Console.WriteLine(args[0].ToCharArray().Distinct().ToArray());
            }
        }
    }
}
