using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string[] _guesswords = new string[] {"mother","father","sister","brother","aunty","uncle","niece","nephew","cousin","grandma","grandpa","baby","friend","neighbour","woman","man","female","male","child","children"};
        private int _numberoflives = 6;
        private int _counter = -1;
        private char[] _letterplacement;
        private string guessword;
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
            Random randomword = new Random();
            var index = randomword.Next(0, 19);
             guessword = _guesswords[index];
            _letterplacement = guessword.ToCharArray();


            //char[] guess = new char[guessword.Length];
            //foreach (char c in guessword)
            //    if (guessword.Contains(c))
            //    {
            //        Console.WriteLine(c);
            //        _rounds++;
            //    }
            //else
            //{
            //        Console.WriteLine(_letterplacement);   
            //}
            //_counter++;
        }

        public void Run()
        {
            _renderer.Render(5, 5, 6);

            for (int i = 0; i < guessword.Length; i++)
            { 
                _letterplacement[i] = '_';
            }


            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine(_letterplacement);
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();
        }

    }
}
