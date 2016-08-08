module Tennis

    let ScoringSequence = ["love"; "15"]

    type Players = 
    | A
    | B

    let Score (rallyWinners:list<Players>):string = 
        let playerAScore, playerBScore = List.partition (fun player -> player = Players.A) rallyWinners
        
        ScoringSequence.[playerAScore.Length] + "-" + ScoringSequence.[playerBScore.Length]