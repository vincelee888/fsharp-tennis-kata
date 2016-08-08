module Tennis

    let ScoringSequence = ["love"; "15"; "30"; "40"]
    let winningScore = ScoringSequence.Length
    let PlayerNames = ("A", "B")
    
    type Players = 
    | A
    | B

    let GetPlayerName (player:Players):string =
        match player with
        | A -> fst PlayerNames
        | B -> snd PlayerNames

    let ParseScoredPoints (rallyWinners:list<_>) =
        List.partition (fun player -> player = Players.A) rallyWinners

    let ScoreDescription (playerPoints) =
        ScoringSequence.[playerPoints]

    let Advantage (x, y) =
        x = winningScore + 1 && y = winningScore
    
    let Deuce (x, y) = 
        x = y && y = winningScore

    let Score (rallyWinners:list<Players>):string = 
        let playerA, playerB = ParseScoredPoints rallyWinners
        match playerA.Length, playerB.Length with
        | x, y when Advantage(x, y) -> "Adv: " + GetPlayerName A
        | x, y when Advantage(y, x) -> "Adv: " + GetPlayerName B
        | x, y when Deuce(x, y) -> "Deuce"
        | x, y when x >= winningScore && x > y + 1 -> "Game: " + GetPlayerName A
        | x, y when y = winningScore -> "Game: " + GetPlayerName B
        | x, y -> ScoreDescription(x) + "-" + ScoreDescription(y)