# Bulls and Cows Game
* This is a small console based game built entirely with C++. 
* This is a guess the [**isogram**](https://en.wikipedia.org/wiki/Isogram) game. 

## Rules
1. The number of letters and the first letter of the unknown word is mentioned.
2. The user has a limited number of guesses.
3. After each guess the computer outputs 
    * _Bull_ : Right letter at the right place
    * _Cow_ : Right letter in the wrong place
4. You win if you manage to guess the word before your number of tries run out.

## Requirements
* __Input :__ The guessed word as a string
* __Output :__ The number of bulls, cows and the number of remaining tries.

## Possible future ideas
* Give feedback on every key press
* A large dictionary of hidden words
* User selectable word length
* Difficulty level
* Provide time limits for guesses along with number of tries
* Adding new isograms from the users' wrong inputs
* A hint system

## Screenshots:
1. Start of the game

![Start of the game](https://i.imgur.com/LLdXyg3.png)

2. Error: Entered word is not an isogram

![Error: Entered word is not an isogram](https://i.imgur.com/ZPkEMUc.png)

3. Error: Entered word is not of required length

![Error: Entered word is not of required length](https://i.imgur.com/aVWewgQ.png)

4. When the entered word is an isogram

![When the entered word is an isogram](https://i.imgur.com/Wtupv5C.png)

5. When you guess the correct word

![When you guess the correct word](https://i.imgur.com/5arvyhC.png)