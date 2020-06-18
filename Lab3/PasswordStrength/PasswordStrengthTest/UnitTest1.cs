using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTest
{
    [TestClass]
    public class ArgumentTest
    {
        [TestMethod]
        public void There_are_not_arguments()
        {
            string[] arguments = new string[] { };

            Assert.AreEqual(1, Program.Main(arguments));
        }

        [TestMethod]
        public void There_are__arguments()
        {
            string[] arguments = new string[] { "Argument_1", "Argument_2" };

            Assert.AreEqual(1, Program.Main(arguments));
        }
    }

    [TestClass]
    public class CheckCountDigit
    {
        [TestMethod]
        public void Not_numbers_in_pasword()
        {
            string pasword = "abcdef";

            Assert.AreEqual(0, Program.CountDigit(pasword));
        }

        [TestMethod]
        public void One_number_in_pasword()
        {
            string pasword = "1abcdef";

            Assert.AreEqual(1, Program.CountDigit(pasword));
        }

        [TestMethod]
        public void Many_numbers_in_pasword()
        {
            string pasword = "1234567890abcdef";

            Assert.AreEqual(10, Program.CountDigit(pasword));
        }
    }

    [TestClass]
    public class CheckCountUpperSymbols
    {
        [TestMethod]
        public void Not_upper_symbols_in_pasword()
        {
            string pasword = "12345abcdef";

            Assert.AreEqual(0, Program.CountUpperSymbols(pasword));
        }

        [TestMethod]
        public void One_upper_symbols_in_pasword()
        {
            string pasword = "12345abcDef";

            Assert.AreEqual(1, Program.CountUpperSymbols(pasword));
        }

        [TestMethod]
        public void Many_upper_symbols_in_pasword()
        {
            string pasword = "12345ABCdeF";

            Assert.AreEqual(4, Program.CountUpperSymbols(pasword));
        }
    }

    [TestClass]
    public class CheckCountLowerSymbols
    {
        [TestMethod]
        public void Not_lower_symbols_in_pasword()
        {
            string pasword = "12345ABCDEF";

            Assert.AreEqual(0, Program.CountLowerSymbols(pasword));
        }

        [TestMethod]
        public void One_lower_symbols_in_pasword()
        {
            string pasword = "12345ABCDeF";

            Assert.AreEqual(1, Program.CountLowerSymbols(pasword));
        }

        [TestMethod]
        public void Many_lower_symbols_in_pasword()
        {
            string pasword = "12345abcdeF";

            Assert.AreEqual(5, Program.CountLowerSymbols(pasword));
        }
    }

    [TestClass]
    public class CheckCountReplaySymbols
    {
        [TestMethod]
        public void Not_replay_symbols_in_pasword()
        {
            string pasword = "12345ABCDEF";

            Assert.AreEqual(0, Program.CountReplaySymbols(pasword));
        }

        [TestMethod]
        public void Two_replay_symbols_in_pasword()
        {
            string pasword = "12345abcdef1";

            Assert.AreEqual(2, Program.CountReplaySymbols(pasword));
        }

        [TestMethod]
        public void Replay_pasword()
        {
            string pasword = "xxxxx";

            Assert.AreEqual(5, Program.CountReplaySymbols(pasword));
        }

        [TestMethod]
        public void Lower_and_upper_a_pasword()
        {
            string pasword = "Aa";

            Assert.AreEqual(0, Program.CountReplaySymbols(pasword));
        }
    }

    [TestClass]
    public class CheckCountReliability
    {
        [TestMethod]
        public void Check_empty_password()
        {
            string password = "";
           
            Assert.AreEqual(0, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_letters_in_upper()
        {
            string password = "xyz";

            Assert.AreEqual(9, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_letters_in_lower()
        {
            string password = "XYZ";
            
            Assert.AreEqual(9, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_numbers()
        {
            string password = "1234";
            
            Assert.AreEqual(28, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_numbers_and_letters_lower_and_upper()
        {
            string password = "4Zx8";
            
            Assert.AreEqual(36, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_numbers_and_letters_lower_and_upper_and_replay()
        {
            string password = "2wwQ5";
            
            Assert.AreEqual(40, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_letters_upper_and_lower_not_replay_and_not_numbers()
        {
            string password = "ABcd";
            
            Assert.AreEqual(20, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_letters_upper_and_lower_and_replay_and_not_numbers()
        {
            string password = "ABcC";
            
            Assert.AreEqual(20, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_replay_letters_and_not_numbers()
        {
            string password = "QQQQ";
            
            Assert.AreEqual(8, Program.CountReliability(password));
        }

        [TestMethod]
        public void Check_password_with_replay_numbers_and_not_letters()
        {
            string password = "111";
            
            Assert.AreEqual(18, Program.CountReliability(password));
        }
    }
}
