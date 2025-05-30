using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameLogic
    {
        public List<eGameLetter> GeneratedWord { get; set; }
        private const int k_NumberOfLettersInSequence = 4;
        public int MaxNumberOfGuesses { get; }
        public int CurrentNumberOfGuesses { get; set; }
        public GameLogic(int i_maxNumberOfGuesses)
        {
            MaxNumberOfGuesses = i_maxNumberOfGuesses;
            CurrentNumberOfGuesses = 0;
            GeneratedWord = generateRandomString();
        }
        public bool IsWinner(List<eGameLetter> i_UserGuess)
        {
            return GeneratedWord.SequenceEqual(i_UserGuess);
        }

        public bool IsGameOver()
        {
            return CurrentNumberOfGuesses >= MaxNumberOfGuesses;
        }
        private List<eGameLetter> generateRandomString()
        {
            List<eGameLetter> word = new List<eGameLetter>();
            Random rnd = new Random();
            eGameLetter nextLetter;
            while (word.Count < k_NumberOfLettersInSequence)
            {
                nextLetter = (eGameLetter)rnd.Next(0, Enum.GetValues(typeof(eGameLetter)).Length);
                if (word.Contains(nextLetter))
                {
                    continue;
                }
                word.Add(nextLetter);
            }

            return word;
        }
        public List<eFeedback> CheckXorVAccordingToUserInput(List<eGameLetter> i_UserGuess)
        {
            List<eFeedback> listOfBulls = new List<eFeedback>();
            List<eFeedback> listOfCows = new List<eFeedback>();
            int pointerOfTheGeneratedString = 0;
            int pointerOfTheUserInput = 0;
            while (pointerOfTheUserInput < i_UserGuess.Count)
            {
                eGameLetter currentCharInGeneratedString = GeneratedWord[pointerOfTheGeneratedString];
                eGameLetter currentCharInUserInput = i_UserGuess[pointerOfTheUserInput];
                if (currentCharInUserInput == currentCharInGeneratedString)
                {

                    if (pointerOfTheUserInput == pointerOfTheGeneratedString)
                    {
                        listOfBulls.Add(eFeedback.Bull);
                    }
                    else
                    {
                        listOfCows.Add(eFeedback.Cow);
                    }
                    pointerOfTheUserInput++;
                    pointerOfTheGeneratedString = 0;
                }
                else
                {
                    pointerOfTheGeneratedString++;
                    if (pointerOfTheGeneratedString > k_NumberOfLettersInSequence - 1)
                    {

                        pointerOfTheUserInput++;
                        pointerOfTheGeneratedString = 0;
                    }
                }
            }

            listOfBulls.AddRange(listOfCows);

            return listOfBulls;
        }
        public string CheckForDuplications(string i_UserGuess)
        {
            string message = string.Empty;
            HashSet<char> seenLetters = new HashSet<char>();
            foreach (char currentLetter in i_UserGuess)
            {
                if (seenLetters.Contains(currentLetter))
                {
                    message = $"You typed a letter more then once ";
                    break;
                }
                seenLetters.Add(currentLetter);
            }

            return message;
        }


    }
}
