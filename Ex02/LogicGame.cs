using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class LogicGame
    {
        //TODO: GENERATE A 4 LETTERS RANDOM SEQUNCE BETWEEN A-H WITH REPETITION 
        //TODO: GET A SEQUNCE OF LETTERS FROM THE USER AND RETURN THE V AND X ACCORDING TO THE SEQUNCE 

        public string GeneratedString { get; set; } // need to check if this is the data member 
        public int MaxNumberOfGuessesInGame { get; set; }
        public int CurrentNumberOfGuesses { get; set; }
        public LogicGame(int i_MaxNumberOfGuesses) 
        {
            MaxNumberOfGuessesInGame = i_MaxNumberOfGuesses;
            GeneratedString = generateRandomString();
        }
        //public getUserGuess(string guess)
        // number
        //toupper 
        //note = validateUserGuess 
        //if not return the string
        //checkXorVAccordingToUserInput 
        //

        
        private string generateRandomString()
        {
            string word = "";
            Random rnd = new Random();
            char nextLetter = (char)rnd.Next('A', 'H' + 1);
            word += nextLetter;
            while (word.Length < 4)
            {
                nextLetter = (char)rnd.Next('A', 'H' + 1);
                if (word.Contains(nextLetter))
                {
                    continue;
                }
                word += nextLetter;
            }
            ////need to remove this 
            Console.WriteLine($"this is the word: {word}");
            return word;
        }
        
        public string CheckXorVAccordingToUserInput(string i_UserGuess)
        {
            StringBuilder sequenceOfV = new StringBuilder();
            StringBuilder sequenceOfX = new StringBuilder();
            int pointerOfTheGeneratedString = 0;
            int pointerOfTheUserInput = 0;
            while (pointerOfTheUserInput < 4)
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
                    if(pointerOfTheGeneratedString > 3)
                    {

                        pointerOfTheUserInput++;
                        pointerOfTheGeneratedString = 0;
                    }
                }
            }

            return sequenceOfV.Append(sequenceOfX).ToString();
        }
        public bool GuessedCorrectly(string i_UserGuess)
        {
            return i_UserGuess == GeneratedString;
        }

        public bool ExceededNumberOfGuesses()
        {
            return CurrentNumberOfGuesses > MaxNumberOfGuessesInGame;
        }

        //function  that checks if we passed number of guess 

    }
}
