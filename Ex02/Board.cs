
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using Ex02.ConsoleUtils;

namespace Ex02
{
    internal class Board
    {
        private readonly int r_MaxNumberOfGuessesInGame;
        private readonly State r_GameState;
        public Board(int i_NumberOfGuesses,State i_GameState)
        {
            r_MaxNumberOfGuessesInGame = i_NumberOfGuesses;
            r_GameState = i_GameState;
            DisplayBoard();
        }
        public void RequestGuess()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
        }
        public void ShowWinningMessage()
        {
            Console.WriteLine($"You guessed after {r_GameState.m_UserGuesses.Count} steps!");
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
            Console.WriteLine("Current board status");
            Console.WriteLine("|Pins:   |Result: |");
            Console.WriteLine("|=================|");
            Console.WriteLine("| # # # #|        |");
            Console.WriteLine("|=================|");
            for (int i = 0; i < r_MaxNumberOfGuessesInGame; i++)
            {
                if (i < r_GameState.m_UserGuesses.Count)
                {
                    string currentGuess = string.Join(" ", r_GameState.m_UserGuesses[i].ToCharArray()).PadRight(7);
                    string currentResult = string.Join(" ", r_GameState.m_Results[i].ToCharArray()).PadRight(7);
                    Console.WriteLine($"|{currentGuess} |{currentResult} |");
                    Console.WriteLine("|=================|");
                }
                else
                {
                    Console.WriteLine("|        |        |");
                    Console.WriteLine("|=================|");
                }
            }
        }
    }
}
