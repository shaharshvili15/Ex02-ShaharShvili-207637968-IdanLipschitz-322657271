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
        public Validations()
        {
            
        }

        public bool ValidateNumberOfGuesses(string i_UserInputNumberOfGuesses)
        {
            bool isNumber = int.TryParse(i_UserInputNumberOfGuesses, out int numberAsInt);
            return isNumber && numberAsInt>=4 && numberAsInt<=10;
        }
        public string ValidateUserGuess(string i_UserGuess)
        {
            int[] chars = new int[8];
            //check length 
            if (i_UserGuess.Length != 4)
            {
                return "Your guess must be of length 4";
            }
            foreach (char c in i_UserGuess)
            {
                //check that all letters are from A-H 
                if (!(c >= 'A' && c <= 'H'))
                {
                    return "You entered a letter not between A and H";
                }
                //check that there are no spaces
                if (char.IsWhiteSpace(c))
                {
                    return "You cannot enter spaces";
                }
                chars[(int)c - (int)'A']++;
                //check if there are duplicates 
                if (chars[(int)c - (int)'A'] > 1)
                {
                    return $"You typed the letter {c} more then once";
                }
            }
            return string.Empty;
        }

    }
}
