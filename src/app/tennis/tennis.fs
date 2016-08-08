module Tennis

    let ScoringSequence = ["love"; "15"; "30"; "40"]
    let winningScore = ScoringSequence.Length
    
    type Players = 
    | A
    | B

    let ParseScoredPoints (rallyWinners:list<_>) =
        List.partition (fun player -> player = Players.A) rallyWinners

    let ScoreDescription (playerPoints) =
        ScoringSequence.[playerPoints]

    let Score (rallyWinners:list<Players>):string = 
        let playerA, playerB = ParseScoredPoints rallyWinners
        match playerA.Length, playerB.Length with
        | x, y when x = winningScore + 1 && y = winningScore -> "Adv: A"
        | x, y when x = winningScore && y = winningScore -> "Deuce"
        | x, y when x = winningScore -> "Game: A"
        | x, y when y = winningScore -> "Game: B"
        | x, y -> ScoreDescription(x) + "-" + ScoreDescription(y)