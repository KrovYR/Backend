using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTest
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
        public void There_are_three_arguments()
        {
            string[] argument = new string[] { "Argument_1", "Argument_2", "Argument_3"};

            Assert.AreEqual(1, Program.Main(argument));
        }
    }

    [TestClass]
    public class CheckFiles
    {
        [TestMethod]
        public void Same_file_name()
        {
            string[] arguments = new string[] {"test_files\\input.txt", "test_files\\input.txt"};

            Assert.AreEqual(1, Program.Main(arguments));
        }

        [TestMethod]
        public void Incorrect_file_name()
        {
            string[] arguments = new string[] { "test_files\\Input.txt", "test_files\\output.txt" };

            Assert.AreEqual(1, Program.Main(arguments));
        }
    }

    [TestClass]
    public class Chec_function_of_removing_extra_symbols
    {
        [TestMethod]
        public void Check_correct_string()
        {
            string inputText = "Hello world!";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_correct_Cyrrillic_string()
        {
            string inputText = "Привет мир!";
            string outputText = "Привет мир!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_spaces_at_the_beginning_and_end()
        {
            string inputText = "                        Hello world!                           ";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_spaces_between_words()
        {
            string inputText = "Hello             world!";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_a_large_number_of_space()
        {
            string inputText = "                                                       Hello             world!                                ";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_tabs_at_the_beginning_and_end()
        {
            string inputText = "\t\t\t\tHello world!\t\t\t\t";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_tabs_between_words()
        {
            string inputText = "Hello\t\t\tworld!";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_a_large_number_of_tabs()
        {
            string inputText = "\t\t\t\t\t\tHello\t\t\tworld!\t\t\t\t\t";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }

        [TestMethod]
        public void Check_string_with_a_large_number_of_tabs_and_spaces()
        {
            string inputText = "\t\t\t         \t\t\t                  Hello\t     \t\tworld!     \t\t\t                    \t\t";
            string outputText = "Hello world!";

            Assert.AreEqual(outputText, Program.RemoveExtraBlanksInString(inputText));
        }
    }
}