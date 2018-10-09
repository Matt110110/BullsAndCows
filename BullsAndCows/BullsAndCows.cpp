/*
Author: Matruprasad Chand
Date: 06/10/2018
Info:
	* This is a console based word guessing game
	* The User will be provided with a few clues and has to guess the word correctly within the given number of tries.
	* For each letter in the right place, the user gets a bull and for each correct character placed in the wrong place the user gets a cow.
*/

#include "pch.h" // Why do you bother me? I don't need a precompiled class that does nothing more than annoy me to the end.
#include <iostream>
#include <string>
#include "FBullCowGame.h"
using namespace std;

/* 
	Substituion of types to make C++ more Unreal like
	There are a few different types of strings in Unreal, out of which I am using FText(https://docs.unrealengine.com/en-us/Programming/UnrealArchitecture/StringHandling/FText) and FString(https://docs.unrealengine.com/en-us/Programming/UnrealArchitecture/StringHandling/FString) in this project. 
	FText is unmutable and is used for string values that won't change.
	FString is mutable and is used for string values that will change during the execution of the program.
	FBullCowGame class uses the FString while the main uses FText.
*/
using FText = string;
using int32 = int32;

constexpr int32 WORD_LENGTH = 9;
FBullCowGame BCGame;

void printIntro();
void printStatus(FText guess);
void playGame();
bool willPlayAgain();
FText getGuess();

int main()
{
	do
	{
		printIntro();
		playGame();
	} while (willPlayAgain());
	cout << endl;
	return 0;
}

void playGame()
{
	int32 temp = BCGame.GetMaxTries();
	while (temp > 0)
	{

		FText guess = getGuess();
		cout << endl;
		EGuessStatus status = BCGame.IsGuessValid(guess);
		switch (status)
		{
		case EGuessStatus::OK:
			printStatus(guess);
			temp--;
			break;
		case EGuessStatus::Not_Isogram:
			break;
		case EGuessStatus::Wrong_Length:
			cout << "Please enter a " << BCGame.GetWordLength() << " letter word.\n";
			break;
		case EGuessStatus::Not_lowercase:
			break;
		default:
			break;
		}
	}
}

/*
This method takes a FText input and only accepts a Yes or a No
Why did I make it so complex? No one knows.
This could have been made far simpler by just checking for Y or by only taking a single character.
*/
bool willPlayAgain()
{
	FText response;
	cout << "\nDo you want to play again? (Y/N)\n";
	getline(cin, response);
	if (response[0] == 'Y' || response[0] == 'y')
		return true;
	else if (response[0] == 'N' || response[0] == 'n')
		return false;
	else
	{
		cout << "\nPlease enter either Yes or No.\n";
		return willPlayAgain();
	}
}

void printIntro()
{
	// system("cls"); is used to clear the console window. This is windows specific and works with the Command prompt. In linux the command and code will be different.
	system("cls");
	BCGame.Reset();
	cout << "\nWelcome to Bulls and Cows\n";
	cout << "\nCan you think of " << BCGame.GetWordLength() << " letter isogram I am thinking of?\n";
}

void printStatus(FText guess)
{
	FBullCowCount count = BCGame.SubmitGuess(guess);
	cout << "Bulls = " << count.bull << " Cows = " << count.cow << endl;
}

FText getGuess()
{
	FText Guess = "";

	// This entire system is utterly unnecessary but cool.
	if (BCGame.GetCurrentTry() == 1)
	{
		cout << "\nEnter your " << BCGame.GetCurrentTry() << "st guess: ";
	}
	else if (BCGame.GetCurrentTry() == 2)
	{
		cout << "\nEnter your " << BCGame.GetCurrentTry() << "nd guess: ";
	}
	else if (BCGame.GetCurrentTry() == 3)
	{
		cout << "\nEnter your " << BCGame.GetCurrentTry() << "rd guess: ";
	}
	else
	{
		cout << "\nEnter your " << BCGame.GetCurrentTry() << "th guess: ";
	}
	getline(cin, Guess); // TODO: Check validity of the guess, and only return valid guesses
	return Guess;
}