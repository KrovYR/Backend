using System;
using System.Linq;

namespace PasswordStrength
{
    public class Program
    {
        // Количество цифр
        public static int CountDigit(string pasword)
        {
            return pasword.Count(char.IsNumber);
        }

        // Количество символов в верхнем регистре
        public static int CountUpperSymbols(string pasword)
        {
            return pasword.Count(char.IsUpper);
        }

        // Количество символов в нижнем регистре
        public static int CountLowerSymbols(string pasword)
        {
            return pasword.Count(char.IsLower);
        }

        // Количество повторяющихся символов
        public static int CountReplaySymbols(string password)
        {
            int replay = 0;

            foreach (char symbol in password.Distinct().ToArray())
            {
                int count = password.Count(chr => chr == symbol);
                if (count > 1)
                {
                    replay += count;
                }
            }

            return replay;
        }

        // Подсчет надежности пароля
        public static int CountReliability(string password)
        {
            int reliability = 0;
            int len = password.Length;
            int digit = CountDigit(password);
            int upper = CountUpperSymbols(password);
            int lower = CountLowerSymbols(password);
            int replay = CountReplaySymbols(password);

            reliability += 4 * len;
            reliability += digit * 4;
            if (upper > 0)
            {
                reliability += (len - upper) * 2;
            }
            if (lower > 0)
            {
                reliability += (len - lower) * 2;
            }
            if (upper + lower == len)
            {
                reliability -= len;
            }
            if (digit == len)
            {
                reliability -= len;
            }
            reliability -= replay;

            return reliability;
        }

        // Основная программа
        public static int Main(string[] args)
        { 
            // Проверка количества введенных аргументов
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
                Console.WriteLine("Usage PasswordStrength.exe <password>");
                return 1;
            }

            string password = args[0];

            Console.WriteLine(CountReliability(password));
            
            return 0;
        }
    }
}
