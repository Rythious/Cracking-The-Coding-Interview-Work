using System;

namespace URLify_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a string to URLify, with trailing space for swaps.");
            var stringToUrlify = Console.ReadLine();

            //stringToUrlify = stringToUrlify.Trim();
            //stringToUrlify = stringToUrlify.Replace(" ", "%20");

            var charArrayOfGivenString = stringToUrlify.ToCharArray();

            var indexOfCharacterToProcess = 0;

            for (int i = charArrayOfGivenString.Length - 1; i >= 0; i--)
            {
                if (charArrayOfGivenString[i] != ' ')
                {
                    indexOfCharacterToProcess = i;
                    break;
                }
            }

            for (var i = charArrayOfGivenString.Length - 1; i >= 0; i--)
            {
                var characterBeingProcessed = charArrayOfGivenString[indexOfCharacterToProcess];

                if (characterBeingProcessed == ' ')
                {
                    charArrayOfGivenString[i] = '0';
                    charArrayOfGivenString[i - 1] = '2';
                    charArrayOfGivenString[i - 2] = '%';
                    i -= 2;
                }
                else
                {
                    charArrayOfGivenString[i] = characterBeingProcessed;
                    
                }
                indexOfCharacterToProcess--;
            }

            Console.WriteLine(new string(charArrayOfGivenString));
            Console.ReadKey();
        }
    }
}
