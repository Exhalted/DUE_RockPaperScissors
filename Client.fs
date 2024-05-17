namespace RockPaperScissors
 
open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
 
type Type =
    | Rock
    | Paper
    | Scissors
 
[<JavaScript>]
module RockPaperScissors =
    let result = Var.Create ""
 
    let Random () =  
        match Math.Floor(Math.Random() * 3.0) with
        | 0 -> Rock
        | 1 -> Paper
        | 2 -> Scissors
        | _ -> failwithf "Unexpected number"
 
    let ComputeWinner = function
        | (Scissors, Rock) | (Rock, Paper) | (Paper, Scissors) -> "Computer Wins!"
        | (Rock, Scissors) | (Paper, Rock) | (Scissors, Paper) -> "You Win!"
        | _ -> "It's a Draw!"
 
    let HandleClick (player: Type) = 
        result.Set(ComputeWinner(player, Random()))
 
    [<SPAEntryPoint>]
    let Main () =
        div [] [
            h1 [] [text "Rock Paper Scissors"]
            button [on.click (fun _ _ -> HandleClick Rock)] [text "Rock"]
            button [on.click (fun _ _ -> HandleClick Paper)] [text "Paper"]
            button [on.click (fun _ _ -> HandleClick Scissors)] [text "Scissors"]
            p [] [text result.V]
        ]
        |> Doc.RunById "main"