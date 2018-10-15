module BullsAndCows

open System
open System.Linq

type GuessStatus =
    | OK = 0
    | Not_Isogram = 1
    | Invalid_Length = 2

let wordColl = ["brick"; "blind"; "simple"; "sample"; "world"; "birth" ] // Always use semi-colon as separators. If comma is used there wont be any compiler errors but the code will not work.
let mutable private isGameWon = false
let mutable private currentTry = 1

let IsGameOver() = isGameWon
//To access an element in F# we have to go for X.[] instead of X[]
// Use of Linq is not necessary but since I am opening it anyway so using it. Might change it later.
let mutable private secretWord = wordColl.ElementAt(Random().Next(0, wordColl.Length))
let GetWordlength() = secretWord.Length
let maxTries = GetWordlength() - 1
let GetCurrentTry() = currentTry
let Reset() =
    isGameWon <- false
    secretWord <- wordColl.ElementAt(Random().Next(0, wordColl.Length))
    currentTry <- 1

    // A completely different approach to the isIsogram problem. Here I simply remove the duplicate elements from a string and compare the lengths. 
let isIsogram(guess:string)  =
    let uniq = guess |> Seq.distinct 
    if guess.Length = uniq.Count() then true
    else false
    
let SubmitGuess(guess:string) =
    let mutable bull = 0
    let mutable cow = 0
    for i = 0 to guess.Length - 1 do
        for j = 0 to secretWord.Length - 1 do
            if guess.[i] = secretWord.[j] then 
                if i = j then bull <- bull + 1
                else cow <- cow + 1
    if bull = GetWordlength() then isGameWon <- true
    currentTry <- currentTry + 1
    (bull, cow)

let IsValidGuess guess =
    if not(isIsogram(guess)) then GuessStatus.Not_Isogram
    elif guess.Length <> GetWordlength() then GuessStatus.Invalid_Length
    else GuessStatus.OK