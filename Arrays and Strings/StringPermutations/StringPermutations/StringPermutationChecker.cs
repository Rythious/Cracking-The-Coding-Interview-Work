using System.Collections.Generic;

namespace StringPermutations
{
    public class StringPermutationChecker
    {
        public bool AreStringsPermutationsOfEachOther(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
            {
                return false;
            }

            var letterOccurrencesForFirstString = GetCharacterOccurrences(firstString);
            var letterOccurrencesForSecondString = GetCharacterOccurrences(secondString);

            foreach (var key in letterOccurrencesForFirstString.Keys)
            {
                if (letterOccurrencesForFirstString[key] != (letterOccurrencesForSecondString?[key] ?? 0))
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<char, int> GetCharacterOccurrences(string stringToCheck)
        {
            var letterOccurrences = new Dictionary<char, int>();

            for (var i = 0; i < stringToCheck.Length; i++)
            {
                var charToCheck = stringToCheck[i];
                if (letterOccurrences.ContainsKey(charToCheck))
                {
                    letterOccurrences[charToCheck]++;
                }
                else
                {
                    letterOccurrences[charToCheck] = 1;
                }
            }

            return letterOccurrences;
        }
    }
}
