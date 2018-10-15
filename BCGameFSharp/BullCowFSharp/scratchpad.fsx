open System
open System.Linq
open System.Collections.Generic

let wordColl = ["brick"; "blind"; "simple"; "sample"; "world" ]
let rnd = Random().Next(0, wordColl.Length)
let secretWord = wordColl.ElementAt(rnd) 
secretWord

let isIsogram(guess:string)  =
    let uniq = guess |> Seq.distinct 
    if guess.Length = uniq.Count() then true
    else false

isIsogram("birth")