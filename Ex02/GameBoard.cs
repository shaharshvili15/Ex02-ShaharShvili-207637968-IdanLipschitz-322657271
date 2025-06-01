using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex02
{
    internal class GameBoard
    {
        private readonly GameLogic r_GameLogic;
        private List<string> m_UserGuesses;
        private List<string> m_Results;

        private readonly Dictionary<char, eGameLetter> r_LetterDictionary = new Dictionary<char, eGameLetter>()
        {{'A',eGameLetter.A},
        { 'B',eGameLetter.B},
        { 'C',eGameLetter.C},
        { 'D',eGameLetter.D},
        { 'E',eGameLetter.E},
        { 'F',eGameLetter.F},
        { 'G',eGameLetter.G},
        { 'H',eGameLetter.H},
        { 'Q',eGameLetter.Q }};

        private readonly Dictionary<eFeedback, char> r_FeedbackDictionary = new Dictionary<eFeedback, char>()
        { { eFeedback.Bull,'V'},
         { eFeedback.Cow,'X'} };
        public GameBoard(GameLogic i_GameLogic)
        {
  
            r_GameLogic = i_GameLogic;
            m_UserGuesses = new List<string>();
            m_Results = new List<string>();
            DisplayBoard();
        }
        private string validateUserInput(string i_UserGuess)
        {
            string returnMessage = string.Empty;
            if(i_UserGuess == "Q")
            {
                returnMessage = string.Empty;
            }
            else
            {
                if (i_UserGuess.Length != 4)
                {
                    returnMessage = "Your guess must be of length 4";

                }
                else
                {
                    foreach (char c in i_UserGuess)
                    {
                        if (char.IsWhiteSpace(c))
                        {
                            returnMessage = "You cannot enter spaces";
                            break;
                        }

                        if (!(c >= 'A' && c <= 'H'))
                        {
                            returnMessage = "You entered a letter not between A and H";
                            break;
                        }
                    }
                    string duplicationMessage = r_GameLogic.CheckForDuplications(i_UserGuess);
                    returnMessage = returnMessage == string.Empty ? duplicationMessage : returnMessage;
                }
            }
            
            return returnMessage;
        }
        public List<eGameLetter> RequestGuess()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            string userGuess;
            while (true)
            {
                userGuess = Console.ReadLine();
                userGuess = userGuess.ToUpper();
                string userGuessValidation = validateUserInput(userGuess);
                if (string.IsNullOrEmpty(userGuessValidation))
                {
                    break;
                }
                DisplayError(userGuessValidation);
            }
            m_UserGuesses.Add(userGuess);
            r_GameLogic.CurrentNumberOfGuesses++; 

            return convertUserGuessStringToEnumList(userGuess);
        }
        public void ShowWinningMessage()
        {
            Console.WriteLine($"You guessed after {r_GameLogic.CurrentNumberOfGuesses} steps!");
        }

        public void ShowLossingMessage() 
        {
            Console.WriteLine("No more guesses allowed. You lost!");
        }

        public void RequestForNewGame()
        {
            Console.WriteLine("Would you like to start a new game? <Y/N>");
        }

        public void DisplayError(string message) 
        {
            Console.WriteLine(message);
        }

        public void DisplayBoard()
        {
            Screen.Clear();
            Console.WriteLine("Current board status");
            Console.WriteLine("|Pins:    |Result: |");
            Console.WriteLine("|==================|");
            Console.WriteLine("| # # # # |        |");
            Console.WriteLine("|==================|");
            for (int i = 0; i < r_GameLogic.MaxNumberOfGuesses; i++)
            {
                if (i < m_UserGuesses.Count)
                {
                    string currentGuess = string.Join(" ", m_UserGuesses[i].ToCharArray()).PadRight(7);
                    string currentResult = string.Join(" ", m_Results[i].ToCharArray()).PadRight(6);

                    Console.WriteLine($"| {currentGuess} | {currentResult} |");
                    Console.WriteLine("|==================|");
                }
                else
                {
                    Console.WriteLine("|         |        |");
                    Console.WriteLine("|==================|");
                }
            }
        }
        private List<eGameLetter> convertUserGuessStringToEnumList(string i_UserGuess)
        {
            List<eGameLetter> GuessAsList = new List<eGameLetter>();
            foreach (char c in i_UserGuess)
            {
                GuessAsList.Add(r_LetterDictionary[c]);
            }

            return GuessAsList;
        }
        private string convertResultFromListEnumToString(List<eFeedback> i_Feedback)
        {
            StringBuilder sb = new StringBuilder();
            foreach (eFeedback item in i_Feedback)
            {
                sb.Append(r_FeedbackDictionary[item]);
            }

            return sb.ToString();
        }
        public void AddResultToList(List<eFeedback> i_Feedback)
        {
            m_Results.Add(convertResultFromListEnumToString(i_Feedback));
        }
    }
}