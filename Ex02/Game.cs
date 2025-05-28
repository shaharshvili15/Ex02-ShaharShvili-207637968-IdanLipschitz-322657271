using System;
using System.Dynamic;
using System.Security.AccessControl;
using Ex02.ConsoleUtils;
namespace Ex02
{
    class Game
    {
        private readonly Logic m_logic;
        private readonly Board m_board;
        private readonly State m_State;
        private string m_LastGuess;
        private readonly Validations m_Validations;


        public Game()
        {
            m_Validations = new Validations();

            //here we get the number of guesses of the game
            int numberOfGuesses = GetUserInputNumberOfGuessesInGame();

            //create a new game 
            m_logic = new Logic(numberOfGuesses);
            m_State = new State(numberOfGuesses, m_logic.GeneratedString);
            m_board = new Board(numberOfGuesses,m_State);
            
            
            HandleGame();
        }
       
        private void HandleGame()
        {
            while (!(m_State.IsGameOver()))
            {

                GetAGuessFromTheBoard();
                if (m_LastGuess == "Q")
                {
                    break;
                }

                Screen.Clear();

                string result = m_logic.CheckXorVAccordingToUserInput(m_LastGuess);
                m_board.AddGuess(m_LastGuess, result);
                m_board.DisplayBoard();
                if (m_State.IsWinner(m_LastGuess))
                {
                    m_board.ShowWinningMessage();
                    m_board.RequestForNewGame();
                    break;
                
                }
                if (m_State.IsGameOver())
                {
                    m_board.ShowLossingMessage();
                    m_board.RequestForNewGame();
                    break;
                }
            }
            NewGame();

        }

        private void NewGame()
        {
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                Screen.Clear();
                new Game();
            }
        }


        private void GetAGuessFromTheBoard()
        {
            while (true)
            {
                m_board.RequestGuess();
                m_LastGuess = Console.ReadLine();
                m_LastGuess = m_LastGuess.ToUpper();
                string userGuessValidation = m_Validations.ValidateUserGuess(m_LastGuess);
                if (userGuessValidation == string.Empty)
                {
                    break;
                }
                m_board.DisplayError(userGuessValidation);
            }
        }

        private int GetUserInputNumberOfGuessesInGame()
        {
            Console.WriteLine("Please enter the number of requiered guesses for your gamee (4-10)");
            string numberOfGuessAsAString = Console.ReadLine();
            while (true)
            {
                if (m_Validations.ValidateNumberOfGuesses(numberOfGuessAsAString))
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
