
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using Ex02.ConsoleUtils;

namespace Ex02
{
    internal class BoardGame
    {
        public int MaxNumberOfGuessesInGame { get; set; }
        private List<string> m_userGuesses;
    
        private List<string> m_results;
        public BoardGame(int i_numberOfGuesses )
        {
            MaxNumberOfGuessesInGame = i_numberOfGuesses;
            m_userGuesses = new List<string>();
            m_results = new List<string>();
            DisplayBoard();
        }

        public void RequestGuess()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
        }

        public void ShowWinningMessage()
        {
            Console.WriteLine($"You guessed after {m_userGuesses.Count} steps!");
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
            //maybe need to clear here not sure 
            Console.WriteLine("Current board status");
            Console.WriteLine("|Pins:   |Result: |");
            Console.WriteLine("|=================|");
            Console.WriteLine("| # # # #|        |");
            Console.WriteLine("|=================|");
            for (int i= 0; i< MaxNumberOfGuessesInGame; i++)
            {
                if (i < m_userGuesses.Count)
                {
                    Console.WriteLine($"|{m_userGuesses[i]}|{m_results[i]}|");
                    Console.WriteLine("|=================|");
                }
                else
                {
                    Console.WriteLine("|        |        |");
                    Console.WriteLine("|=================|");
                }
            }
            //line (you won / you lost / new guess) 
        }
        public void AddGuess(string i_UserGuess, string i_GuessResult)
        {
            m_userGuesses.Add(i_UserGuess);
            m_results.Add(i_GuessResult);
        }

    }
}
