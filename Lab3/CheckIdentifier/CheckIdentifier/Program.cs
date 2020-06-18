using System;

namespace CheckIdentifier
{
    public class Program
    {
        // <Буква>
        public static bool IsLetter(char ch)
        {
           return ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'));
        }

        // <Цифра>
        public static bool IsNumber(char ch)
        {
            return ('0' <= ch && ch <= '9');
        }

        public static int Main(string[] args)
        {                       

            if (args.Length != 1)
            {
                Console.WriteLine("no");
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage CheckIdentifier.exe <input string>");
                return 1;
            }
            else
            {
                string identifier = args[0];

                if (String.IsNullOrEmpty(identifier))
                {
                    Console.WriteLine("no");
                    Console.WriteLine("Empty input srting");
                    return 1;
                }

                if (!IsLetter(identifier[0]))
                {
                    Console.WriteLine("no");
                    Console.WriteLine("The first character must be a letter");
                    return 1;
                }

                for (int i = 1; i < identifier.Length; i++)
                {
                    if (!IsLetter(identifier[i]) && !IsNumber(identifier[i]))
                    {
                        Console.WriteLine("no");
                        Console.WriteLine("Unknown character " + identifier[i]);
                        return 1;
                    }
                }

                Console.WriteLine("yes");
                return 0;
            }
        }
    }
}
