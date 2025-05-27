using System;
using System.Dynamic;
using System.Security.AccessControl;

namespace Ex02
{
    class Game
    {
        public LogicGame LogicGame { get; set; }
        private string m_LastGuess;
        public Game()
        {
            Validations gameValidation = new Validations();

            //here we get the number of guesses of the game 
            Console.WriteLine("Please enter the number of requiered quess for the game this number needs to be between 4 and 10");
            string numberOfGuessAsAString = Console.ReadLine();
            while (true)
            {
                if (gameValidation.ValidateNumberOfGuesses(numberOfGuessAsAString))
                {
                    break;
                }
                Console.WriteLine("Please enter a valid number of guesses (4-10)");
                numberOfGuessAsAString = Console.ReadLine();
            }

            //create a new game 
            BoardGame boardGame = new BoardGame(int.Parse(numberOfGuessAsAString));
            LogicGame logicGame = new LogicGame(int.Parse(numberOfGuessAsAString));



            //ask the user for guesses and handle the game 
            while (true)
            {
                //if we won display won message 
                //if we lost display lost message 
                while (true)
                {
                    boardGame.RequestGuess();
                    m_LastGuess = Console.ReadLine();
                    m_LastGuess = m_LastGuess.ToUpper();
                    string userGuessValidation = gameValidation.ValidateUserGuess(m_LastGuess);
                    if (userGuessValidation == string.Empty)
                    {
                        break;
                    }
                    boardGame.DisplayError(userGuessValidation);
                }
                logicGame.CurrentNumberOfGuesses += 1;
                string VX = logicGame.CheckXorVAccordingToUserInput(m_LastGuess);
                boardGame.AddGuess(m_LastGuess, VX);
                //check if user enter q 
                //if we lost 
                //if we won 
                boardGame.DisplayBoard();
                if (logicGame.GuessedCorrectly(m_LastGuess))
                {
                    boardGame.ShowWinningMessage();
                    break;
                }
                if (logicGame.ExceededNumberOfGuesses())
                {
                    boardGame.ShowLossingMessage();
                    break;
                }
            }
            boardGame.RequestForNewGame();

            
            
            
            
            
            //need to get here y or n 


            /// and we tell the board game to get a guess from the user 
            /// here in this class we get the guess and check if it is valid if not try again 
            /// once we have a valid guess we send it to the logic game and the logic game returns the result 
            /// we send the board the guess and the result 



            //enter num,ber of guess 
            //new board(numberOfGuesses)
            //this will draw a board with number of guess as the rows 
            //new logic with number of guesses 




            //ask the user using the board class what is the number of guess he wants (4-10)
            //send the logic game the number the user entered.
            //LogicGame = new LogicGame();
            //Console.WriteLine($"This is the word that was generated {LogicGame.GeneratedString}");

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        
        
    }
}
