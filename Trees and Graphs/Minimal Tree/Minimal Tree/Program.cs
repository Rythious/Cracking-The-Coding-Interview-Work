using System;
using System.Linq;

namespace Minimal_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give a comma-separated, ordered array of integers with unique values: ");
            var intArrayAsString = Console.ReadLine();

            // Assuming valid input and using C# convenience methods that would probably not be allowed in an interview since this is just setting up the test.
            var intArray = intArrayAsString.Split(",").Select(s => int.Parse(s.Trim())).ToArray();

            MinimalTreeCreator.Create(intArray);
            Console.ReadKey();
        }
    }
}
