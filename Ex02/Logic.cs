using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Logic
    {
        public string GeneratedString { get; set; }
        private const int k_NumberOfLettersInSequence = 4;
        public Logic() 
        {
            GeneratedString = generateRandomString();
        }

        private string generateRandomString()
        {
            HashSet<char> chars = new HashSet<char>();
            StringBuilder word = new StringBuilder();
            Random rnd = new Random();
            char nextLetter = (char)rnd.Next('A', 'H' + 1);
            word.Append(nextLetter);
            chars.Add(nextLetter);
            while (word.Length < k_NumberOfLettersInSequence)
            {
                nextLetter = (char)rnd.Next('A', 'H' + 1);
                if (chars.Contains(nextLetter))
                {
                    continue;
                }

                word.Append(nextLetter);
                chars.Add(nextLetter);
            }

            return word.ToString();
        }
        public string CheckXorVAccordingToUserInput(string i_UserGuess)
        {
            StringBuilder sequenceOfV = new StringBuilder();
            StringBuilder sequenceOfX = new StringBuilder();
            int pointerOfTheGeneratedString = 0;
            int pointerOfTheUserInput = 0;
            while (pointerOfTheUserInput < k_NumberOfLettersInSequence)
            {

                char currentCharInGeneratedString = GeneratedString[pointerOfTheGeneratedString];
                char currentCharInUserInput = i_UserGuess[pointerOfTheUserInput];
                if(currentCharInUserInput == currentCharInGeneratedString)
                {

                    if(pointerOfTheUserInput == pointerOfTheGeneratedString)
                    {

                        sequenceOfV.Append("V");
                    }
                    else
                    {

                        sequenceOfX.Append("X");
                    }
                    pointerOfTheUserInput++;
                    pointerOfTheGeneratedString = 0;
                }
                else
                {
                    pointerOfTheGeneratedString++;
                    if(pointerOfTheGeneratedString > k_NumberOfLettersInSequence-1)
                    {

                        pointerOfTheUserInput++;
                        pointerOfTheGeneratedString = 0;
                    }
                }
            }

            return sequenceOfV.Append(sequenceOfX).ToString();
        }
    }
}
