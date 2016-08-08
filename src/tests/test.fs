module tests
    open NUnit.Framework
    open FsUnit
    open Tennis

    let pointsSequence p n = seq { for x in 1..n do yield p }

    [<Test>]
    let ``Game starts love-love``() = 
        let result = Score ([])
        result |> should equal "love-love"

    [<Test>]
    let ``First player scores point``() =
        let result = Score([Players.A])
        result |> should equal "15-love"

    [<Test>]
    let ``First player scores two points``() =
        let twoPointsToA = pointsSequence A 2
        let result = Score (Seq.toList twoPointsToA)
        result |> should equal "30-love"

    [<Test>]
    let ``First player scores three points``() =
        let threePointsToA = pointsSequence A 3
        let result = Score (Seq.toList threePointsToA)
        result |> should equal "40-love"

    [<Test>]
    let ``First player scores four points``() =
        let fourPointsToA = pointsSequence A 4
        let result = Score (Seq.toList fourPointsToA)
        result |> should equal "Game: A"

    [<Test>]
    let ``Second player scores four points``() =
        let fourPointsToB = pointsSequence B 4
        let result = Score (Seq.toList fourPointsToB)
        result |> should equal "Game: B"

    [<Test>]
    let ``Both players on four points``() =
        let ralliesWon = [A;B;A;B;A;B;A;B]
        let result = Score ralliesWon
        result |> should equal "Deuce"

    [<Test>]
    let ``Both players on four points, then player scores one``() =
        let ralliesWon = [A;B;A;B;A;B;A;B;A]
        let result = Score ralliesWon
        result |> should equal "Adv: A"

    [<Test>]
    let ``Both players on four points, then other player scores one``() =
        let ralliesWon = [A;B;A;B;A;B;A;B;B]
        let result = Score ralliesWon
        result |> should equal "Adv: B"