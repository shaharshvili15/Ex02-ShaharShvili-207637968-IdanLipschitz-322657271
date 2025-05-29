using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Validations
    {
        private const int k_NumberOfLettersInSequence = 4;
        public bool ValidateNumberOfGuesses(string i_UserInputNumberOfGuesses)
        {
            bool isNumber = int.TryParse(i_UserInputNumberOfGuesses, out int numberAsInt);

            return isNumber && numberAsInt >= 4 && numberAsInt <= 10;
        }
        public string ValidateUserGuess(string i_UserGuess)
        {
            string returnValue = string.Empty;
            int[] chars = new int[26];

            if (i_UserGuess == "Q")
            {
                returnValue = string.Empty;
            }
            else
            {
                if (i_UserGuess.Length != k_NumberOfLettersInSequence)
                {
                    returnValue = "Your guess must be of length 4";
                }

                foreach (char c in i_UserGuess)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        returnValue = "You cannot enter spaces";
                        break;
                    }

                    if (!(c >= 'A' && c <= 'H'))
                    {
                        returnValue = "You entered a letter not between A and H";
                        break;
                    }

                    chars[(int)c - (int)'A']++;
                    if (chars[(int)c - (int)'A'] > 1)
                    {
                        returnValue = $"You typed the letter {c} more then once";
                        break;
                    }
                }
            }

            return returnValue;
        }
    }
}
