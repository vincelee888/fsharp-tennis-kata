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
        let twoPointsToA = pointsSequence Players.A 2
        let result = Score (Seq.toList twoPointsToA)
        result |> should equal "30-love"

    [<Test>]
    let ``First player scores three points``() =
        let threePointsToA = pointsSequence Players.A 3
        let result = Score (Seq.toList threePointsToA)
        result |> should equal "40-love"

    [<Test>]
    let ``First player scores four points``() =
        let fourPointsToA = pointsSequence Players.A 4
        let result = Score (Seq.toList fourPointsToA)
        result |> should equal "Game: A"

    [<Test>]
    let ``Second player scores four points``() =
        let fourPointsToB = pointsSequence Players.B 4
        let result = Score (Seq.toList fourPointsToB)
        result |> should equal "Game: B"
