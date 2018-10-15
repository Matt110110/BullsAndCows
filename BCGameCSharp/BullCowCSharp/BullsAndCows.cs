/**
Author: Matruprasad Chand
Date: 11/10/2018
Info:
	* This is a console based word guessing game
	* The User will be provided with a few clues and has to guess the word correctly within the given number of tries.
	* For each letter in the right place, the user gets a bull and for each correct character placed in the wrong place the user gets a cow.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullCowCSharp
{
    class BullsAndCows
    {
        public BullsAndCows()
        {
            Reset();
            MaxTries = secretWord.Length - 1;
        }

        public BullsAndCows(int x)
        {
            Reset();
            MaxTries = x;
        }

        public int MaxTries { get; private set; }
        public int CurrentTry { get; private set; }
        public bool IsGameWon { get; private set; }

        private static string secretWord; // This is where the differences might start appearing
        private List<string> wordCol = new List<string> { "brick", "blind", "simple", "sample", "world" };

        //Private methods
        //This shows just how simple things are in C#. Random number generation and assignemnt can be done in a single line while in C++ what mt19937 and what else.
        private void SetSecretWord() { secretWord = wordCol.ElementAt(new Random().Next(0, wordCol.Count)); }

        public void Reset()
        {
            IsGameWon = false;
            SetSecretWord();
            CurrentTry = 1;
        }

        private bool IsIsogram(string guess)
        {
            if (guess.Length < 2)
            {
                return true;
            }
            Dictionary<char, bool> letterSeen = new Dictionary<char, bool>();
            foreach (var letter in guess)
            {
                bool x;
                if (letterSeen.TryGetValue(letter, out x)) // Tries to get the value of the given index. If accessed normally like an array, it will throw exception if the key is not present.
                {
                    return false;
                }
                else
                {
                    letterSeen[letter] = true;
                }
            }
            return true;
        }

        // Public methods
        public int GetWordLength() => secretWord.Length; // Lambda expressions in C# are far simpler to use than in C++. But that might be due to practice and familiarity. 

        // Instead of creating a struct I can use a Tuple<> in C#.
        public Tuple<int, int> SubmitGuess(string guess)
        {
            var bull = 0;
            var cow = 0;
            for (var i = 0; i < GetWordLength(); i++)
            {
                for (var j = 0; j < GetWordLength(); j++)
                {
                    if (guess[i] == secretWord[j])
                    {
                        if (i == j)
                        {
                            bull++;
                        }
                        else
                        {
                            cow++;
                        }
                    }
                }

            }
            if (bull == GetWordLength())
            {
                IsGameWon = true;
            }
            SubmitGuess++;
            return Tuple.Create(bull, cow);
        }

        public GuessStatus IsGuessValid(string guess)
        {
            if (!IsIsogram(guess))
            {
                return GuessStatus.Not_Isogram;
            }
            else if (guess.Length != GetWordLength())
            {
                return GuessStatus.Invalid_Length;
            }
            else
            {
                return GuessStatus.OK;
            }
        }
    }
}
