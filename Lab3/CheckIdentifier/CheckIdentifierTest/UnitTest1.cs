using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;

namespace CheckIdentifierTest
{
    [TestClass]
    public class ArgumentTest
    {

        [TestMethod]
        public void There_are_no_arguments()
        {
            string[] argument = new string[] { };

            Assert.AreEqual(1, Program.Main(argument));
        }

        [TestMethod]
        public void There_are_two_arguments()
        {
            string[] argument = new string[] { "Argument_1", "Argument_2" };

            Assert.AreEqual(1, Program.Main(argument));
        }

    }

    [TestClass]
    public class IsLetterTest
    {
        [TestMethod]
        public void Letter_A()
        {
            Assert.AreEqual(true, Program.IsLetter('A'));
        }

        [TestMethod]
        public void Letter_Z()
        {
            Assert.AreEqual(true, Program.IsLetter('Z'));
        }

        [TestMethod]
        public void Letter_a()
        {
            Assert.AreEqual(true, Program.IsLetter('a'));
        }

        [TestMethod]
        public void Letter_z()
        {
            Assert.AreEqual(true, Program.IsLetter('z'));

        }

        [TestMethod]
        public void Letter_4()
        {
            Assert.AreEqual(false, Program.IsLetter('4'));
        }

        [TestMethod]
        public void Argument_d()
        {
            Assert.AreEqual(true, Program.IsLetter('d'));
        }
    }

    [TestClass]
    public class IsNumberTest
    {
        [TestMethod]
        public void Number_0()
        {
            Assert.AreEqual(true, Program.IsNumber('0'));
        }

        [TestMethod]
        public void Letter_Z()
        {
            Assert.AreEqual(true, Program.IsNumber('9'));
        }

        [TestMethod]
        public void Not_Number()
        {
            Assert.AreEqual(false, Program.IsLetter('à'));
        }
    }

    [TestClass]
    public class CheckIdentifier
    {
        [TestMethod]
        public void Correct_idetifiter()
        {
            string[] argument = new string[] { "Ch1" }; 
            Assert.AreEqual(0, Program.Main(argument));
        }

        [TestMethod]
        public void Fist_symbol_is_digit_in_idetifiter()
        {
            string[] argument = new string[] { "1Ch" };
            Assert.AreEqual(1, Program.Main(argument));
        }

        [TestMethod]
        public void Idetifiter_have_incorrect_symbol()
        {
            string[] argument = new string[] { "Ch*1" };
            Assert.AreEqual(1, Program.Main(argument));
        }
    }
}
