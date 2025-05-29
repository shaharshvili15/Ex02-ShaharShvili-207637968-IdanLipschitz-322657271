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
        private int m_CurrentNumberOfGuesses;

        public List<string> m_UserGuesses { get; }

        public List<string> m_Results { get;}

        public string HiddenWord { get;}
        public State(int i_MaxNumberOfGuesses, string i_HiddenWord) 
        {
            MaxNumberOfGuesses = i_MaxNumberOfGuesses;
            HiddenWord = i_HiddenWord;
            m_CurrentNumberOfGuesses = 0;
            m_UserGuesses = new List<string> {};
            m_Results = new List<string>();
        }

        public bool IsWinner(string i_UserGuess)
        {

            return i_UserGuess == HiddenWord;
        }
        public bool IsGameOver()
        {

            return m_CurrentNumberOfGuesses >= MaxNumberOfGuesses;
        }
        public void AddGuess(string i_Guess, string i_Result)
        {
            m_UserGuesses.Add(i_Guess);
            m_Results.Add(i_Result);
            m_CurrentNumberOfGuesses++;
        }
    }
}
