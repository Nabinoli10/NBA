type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let coaches = [
    { Name = "Steve Kerr"; FormerPlayer = true }
    { Name = "Gregg Popovich"; FormerPlayer = false }
    { Name = "Erik Spoelstra"; FormerPlayer = false }
    { Name = "Doc Rivers"; FormerPlayer = true }
    { Name = "Tyronn Lue"; FormerPlayer = true }
]

let stats = [
    { Wins = 46; Losses = 36 }
    { Wins = 22; Losses = 60 }
    { Wins = 46; Losses = 36 }
    { Wins = 17; Losses = 19 }
    { Wins = 51; Losses = 31 }
]

let teams = [
    { Name = "Golden State Warriors"; Coach = coaches.[0]; Stats = stats.[0] }
    { Name = "San Antonio Spurs"; Coach = coaches.[1]; Stats = stats.[1] }
    { Name = "Miami Heat"; Coach = coaches.[2]; Stats = stats.[2] }
    { Name = "Milwaukee Bucks"; Coach = coaches.[3]; Stats = stats.[3] }
    { Name = "LA Clippers"; Coach = coaches.[4]; Stats = stats.[4] }
]

let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)


let calculateSuccessPercentage team =
    let wins = float team.Stats.Wins
    let losses = float team.Stats.Losses
    (wins / (wins + losses)) * 100.0

let successPercentages = successfulTeams |> List.map calculateSuccessPercentage

printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "%A" team)

printfn "\nSuccess Percentages:"
List.zip successfulTeams successPercentages |> List.iter (fun (team, percentage) ->
    printfn "Team: %s, Success Percentage: %.2f%%" team.Name percentage
)
