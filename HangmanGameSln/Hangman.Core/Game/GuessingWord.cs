using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core.Game
{
    internal class GuessingWord
    {
        private string _guessword;
        private string _guessProgress;

        public GuessingWord(string guessword)
        {
            _guessword = guessword;

            for (int i = 0; i < _guessword.Length; i++)
            {
                _guessProgress += "-";
            }
        }
        public string GetGuessProgress()
        {
            return _guessProgress;
        }
        public void AddGuess(char letter)
        {
            char[] guessProgressArray = _guessProgress.ToCharArray();

            for (int index = 0;index < guessProgressArray.Length; index++)
            {
                if (_guessword[index] == letter)
                {
                    guessProgressArray[index] = letter;
                }
                _guessProgress = new string (guessProgressArray);
            }
        }
    }
}
