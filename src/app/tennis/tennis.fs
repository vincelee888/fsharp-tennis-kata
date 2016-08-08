module Tennis

    let ScoringSequence = ["love"; "15"; "30"]

    type Players = 
    | A
    | B

    let ParseScoredPoints (rallyWinners:list<_>) =
        List.partition (fun player -> player = Players.A) rallyWinners

    let ScoreDescription (playerPoints:list<_>) =
        ScoringSequence.[playerPoints.Length]

    let Score (rallyWinners:list<Players>):string = 
        let playerAScore, playerBScore = ParseScoredPoints rallyWinners
        ScoreDescription(playerAScore) + "-" + ScoreDescription(playerBScore)