using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.AccessControl;
using System.Text;
using Ex02.ConsoleUtils;
namespace Ex02
{
    class GameManager
    {
        private GameLogic r_GameLogic;
        private GameBoard r_GameBoard;
        private List<eGameLetter> m_LastGuess;

        public GameManager()
        {
            int numberOfGuesses = getUserInputNumberOfGuessesInGame();

            r_GameLogic = new GameLogic(numberOfGuesses);
            r_GameBoard = new GameBoard(r_GameLogic);
            m_LastGuess = new List<eGameLetter>();
            handleGame();
        }

        public void PlayAgain()
        {
            int numberOfGuesses = getUserInputNumberOfGuessesInGame();
            r_GameLogic = new GameLogic(numberOfGuesses);
            r_GameBoard = new GameBoard(r_GameLogic);
            m_LastGuess = new List<eGameLetter>();
            handleGame();
        }

        private void handleGame()
        {
            while (!r_GameLogic.IsGameOver())
            {
                m_LastGuess = r_GameBoard.RequestGuess();
                if (m_LastGuess[0] == eGameLetter.Q)
                {
                    break;
                }

                List<eFeedback> result = r_GameLogic.CheckXorVAccordingToUserInput(m_LastGuess);

                r_GameBoard.AddResultToList(result);
                r_GameBoard.DisplayBoard();
                if (r_GameLogic.IsWinner(m_LastGuess))
                {
                    r_GameBoard.ShowWinningMessage();
                    r_GameBoard.RequestForNewGame();
                    break;
                }
            }

            if (r_GameLogic.IsGameOver() && !r_GameLogic.IsWinner(m_LastGuess))
            {
                r_GameBoard.ShowLossingMessage();
                r_GameBoard.RequestForNewGame();
            }
            if (r_GameLogic.IsWinner(m_LastGuess) || r_GameLogic.IsGameOver())
            {
                newGame();
            }
        }

        private void newGame()
        {
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                Screen.Clear();
                PlayAgain();
            }
        }

        public bool ValidateNumberOfGuesses(string i_UserInputNumberOfGuesses)
        {
            bool isNumber = int.TryParse(i_UserInputNumberOfGuesses, out int numberAsInt);

            return isNumber && numberAsInt >= 4 && numberAsInt <= 10;
        }


        private int getUserInputNumberOfGuessesInGame()
        {
            Console.WriteLine("Please enter the number of requiered guesses for your game (4-10)");
            string numberOfGuessAsAString = Console.ReadLine();
            while (true)
            {
                if (ValidateNumberOfGuesses(numberOfGuessAsAString))
                {
                    break;
                }

                Console.WriteLine("Please enter a valid number of guesses (4-10)");
                numberOfGuessAsAString = Console.ReadLine();
            }

            return int.Parse(numberOfGuessAsAString);
        }
    }
}
