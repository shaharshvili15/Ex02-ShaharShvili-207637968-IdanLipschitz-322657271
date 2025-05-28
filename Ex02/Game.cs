using System;
using System.Dynamic;
using System.Security.AccessControl;
using Ex02.ConsoleUtils;
namespace Ex02
{
    class Game
    {
        private readonly Logic r_Logic;
        private readonly Board r_Board;
        private readonly State r_State;
        private string m_LastGuess;
        private readonly Validations r_Validations;

        public Game()
        {
            r_Validations = new Validations();
            int numberOfGuesses = getUserInputNumberOfGuessesInGame();
            r_Logic = new Logic();
            r_State = new State(numberOfGuesses, r_Logic.GeneratedString);
            r_Board = new Board(numberOfGuesses,r_State);
            handleGame();
        }
       
        private void handleGame()
        {
            while (!r_State.IsGameOver())
            {
                getAGuessFromTheBoard();
                if (m_LastGuess == "Q")
                {
                    break;
                }

                Screen.Clear();
                string result = r_Logic.CheckXorVAccordingToUserInput(m_LastGuess);
                r_State.AddGuess(m_LastGuess, result);
                r_Board.DisplayBoard();
                if (r_State.IsWinner(m_LastGuess))
                {
                    r_Board.ShowWinningMessage();
                    r_Board.RequestForNewGame();
                    break;
                }
            }
            if (r_State.IsGameOver())
            {
                r_Board.ShowLossingMessage();
                r_Board.RequestForNewGame();
            }
            if (r_State.IsWinner(m_LastGuess) || r_State.IsGameOver())
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
                new Game();
            }
        }


        private void getAGuessFromTheBoard()
        {
            while (true)
            {
                r_Board.RequestGuess();
                m_LastGuess = Console.ReadLine();
                m_LastGuess = m_LastGuess.ToUpper();
                string userGuessValidation = r_Validations.ValidateUserGuess(m_LastGuess);
                if (userGuessValidation == string.Empty)
                {
                    break;
                }

                r_Board.DisplayError(userGuessValidation);
            }
        }

        private int getUserInputNumberOfGuessesInGame()
        {
            Console.WriteLine("Please enter the number of requiered guesses for your gamee (4-10)");
            string numberOfGuessAsAString = Console.ReadLine();
            while (true)
            {
                if (r_Validations.ValidateNumberOfGuesses(numberOfGuessAsAString))
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
