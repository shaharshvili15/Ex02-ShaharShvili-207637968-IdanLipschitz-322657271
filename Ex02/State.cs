using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class State
    {
        public int MaxNumberOfGuesses { get;}
        public int CurrentNumberOfGuesses { get; private set; }

        public List<string> m_UserGuesses { get; set; }

        public List<string> m_Results { get; set; }

        public string HiddenWord { get;}
        public State(int i_MaxNumberOfGuesses, string i_HiddenWord) 
        {
            MaxNumberOfGuesses = i_MaxNumberOfGuesses;
            HiddenWord = i_HiddenWord;
            CurrentNumberOfGuesses = 0;
            m_UserGuesses = new List<string> {};
            m_Results = new List<string>();
        }

        public bool IsWinner(string i_UserGuess)
        {
            return i_UserGuess == HiddenWord;
        }
        public bool IsGameOver()
        {
            return CurrentNumberOfGuesses >= MaxNumberOfGuesses;
        }
        public void AddGuess(string i_Guess, string i_Result)
        {
            m_UserGuesses.Add(i_Guess);
            m_Results.Add(i_Result);
            CurrentNumberOfGuesses++;
        }


    }
}
