using System;

namespace StringPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("first string: ");
            var firstString = Console.ReadLine();

            Console.Write("second string: ");
            var secondString = Console.ReadLine();

            var checker = new StringPermutationChecker();

            Console.WriteLine(checker.AreStringsPermutationsOfEachOther(firstString, secondString) ? "They are permuntations of each other!" : "They are different");
            Console.ReadKey();            
        }
    }
}
