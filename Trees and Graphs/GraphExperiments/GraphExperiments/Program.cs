using System;

namespace GraphExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var quitting = false;
            while (!quitting)
            {
                Console.Write("Starting number: ");
                var startingValue = int.Parse(Console.ReadLine());
                Console.Write("Ending number: ");
                var endingValue = int.Parse(Console.ReadLine());

                graph.FindPath(startingValue, endingValue);

                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    quitting = true;
                }
            }
        }
    }
}
