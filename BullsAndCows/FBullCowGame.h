#pragma once
#include <string>

class FBullCowGame
{
private:
	int _maxTries;
	int _currentTry;
public:
	// Getter functions
	int GetMaxTries() const;
	int GetCurrentTry() const;

	// Check functions
	bool IsGameOver() const;
	bool IsGuessValid(std::string) const;

	void Reset(int); // TODO: make a more richer return value
	void IncrementTry();
	
	// Constructors
	FBullCowGame();
	FBullCowGame(int); // Constructor for when there is a variable difficulty in the game.
	
	// Destructors
	~FBullCowGame();
};

