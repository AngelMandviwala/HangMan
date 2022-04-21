using System;
using System.Collections.Generic;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;

        private string[] _guesswords = new string[] {"mother","father","sister","brother","aunty","uncle","niece","nephew","cousin","grandma","grandpa",
                                                     "baby","friend","neighbour","woman","man","female","male","child","children"};
        private int _numberoflives = 6;
        private char[] _letterplacement;
        private string guessword;
        private bool _wrongletter = false;
        private bool _correctletter = true;
       
        

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
            Random randomword = new Random();
            var index = randomword.Next(0, 19);
             guessword = _guesswords[index];
            _letterplacement = guessword.ToCharArray();
        }

        public void Run()
        {
            string letterplacement = string.Empty;

            for (int i = 0; i < guessword.Length; i++)
            {
                _letterplacement[i] = '-';
            }

            while (_numberoflives > 0 && _numberoflives <= 6)
            {
                _renderer.Render(5, 5, _numberoflives);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(_letterplacement);
                Console.SetCursorPosition(0, 15);



                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What is your next guess: ");

                var nextGuess = char.Parse(Console.ReadLine());
                //try
                //{
                //    nextGuess = char.Parse(Console.ReadLine());
                //}
                //catch (Exception ex)
                //{
                //    Console.Clear();
                //    Console.WriteLine("PLease only enter letters.");
                //    Console.ReadLine();
                //    Console.Clear();
                //    continue;
                //}


                bool correctGuess = false;
                {
                    for (var l = 0; l < guessword.Length; l++)
                    {
                        if (nextGuess == guessword[l])
                        {
                            _letterplacement[l] = nextGuess;
                            correctGuess = true;

                        }
                    }

                    if (!correctGuess)
                    {
                        _numberoflives--;

                        _renderer.Render(5, 5, _numberoflives);
                    }
                }

            }

            string letterPlacement = new string(_letterplacement);

            if (letterPlacement == guessword)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("You have won!!!");

            }
            if (letterPlacement != guessword)
            {


                Console.SetCursorPosition(0, 20);
                Console.WriteLine("\nYou have lost!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nThe word you had to guess was: " + guessword);
            }
        }

    }
}
