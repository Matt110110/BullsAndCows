(*
Author: Matruprasad Chand
Date: 15/10/2018
This is the recreation of the C++ Bull Cow game.	
*)
open System
open BullsAndCows

let n = GetWordlength()

let PrintIntro() = 
    Console.Clear()
    Reset()
    Console.WriteLine("Welcome to Bulls and Cows")
    Console.WriteLine()
    Console.WriteLine("            }   {                 ____")
    Console.WriteLine("            (o  o)               (o  o) ")
    Console.WriteLine("    /--------\\  /                 \\  /---------\\")
    Console.WriteLine("   / |        |O                    o|         | \\ ")
    Console.WriteLine("  *  |-,------|                      |-------,,|  * ")
    Console.WriteLine("     ^        ^                      ^         ^  ")
    printfn "Can you think of %d letter isogram I am thinking of?" n
    printfn "You have a total of %d tries to guess the word correctly." maxTries

let GetStatus() =
    let x = GetCurrentTry()
    if x = 1 then printfn "Enter your %dst try" x
    elif x = 2 then printfn "Enter your %dnd try" x
    elif x = 3 then printfn "Enter your %drd try" x
    else printfn "Enter your %dth try" x
    let guess = Console.ReadLine()
    guess

let PrintStatus guess =
    let a, b = SubmitGuess(guess)
    printfn "Bulls: %d \t Cows: %d" a b

let PrintGameSummary() =
    if IsGameOver() then Console.WriteLine("Congratulations. You have beaten the game. You only took {0} tries.", GetCurrentTry() - 1)
    else printfn "Sorry you failed to beat the game. Better luck next time."

let PlayGame() =
    let mutable temp = maxTries
    while temp > 0 && not(IsGameOver()) do
        let guess = GetStatus()
        Console.WriteLine()
        let status = IsValidGuess(guess)
        match status with
            | GuessStatus.OK -> 
                PrintStatus(guess)
                temp <- temp - 1
            | GuessStatus.Invalid_Length -> printfn "Please enter a %d letter word." n 
            | GuessStatus.Not_Isogram -> printfn "Please enter an ISOGRAM (Word with no repeating letters.)"
    PrintGameSummary()

let doWhile() =
    PrintIntro()
    PlayGame()
    printf "Do you want to continue? (Y/N)"
    let choice = Console.ReadLine()
    if choice.[0] = 'y' then true
    elif choice.[0] = 'Y' then true
    else false

[<EntryPoint>]
let main argv = 
    while doWhile() do 
        PrintIntro()
        PlayGame()
    Console.WriteLine()
    0 // return an integer exit code
