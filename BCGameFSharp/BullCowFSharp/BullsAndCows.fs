module BullsAndCows

type GuessStatus =
    | OK = 0
    | Not_Isogram = 1
    | Invalid_Length = 2