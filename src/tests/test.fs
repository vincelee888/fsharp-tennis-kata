module tests
    open NUnit.Framework
    open FsUnit
    open Tennis

    [<Test>]
    let ``Game starts love-love``() = 
        let result = Score ([])
        result |> should equal "love-love"

    [<Test>]
    let ``First player scores point``() =
        let result = Score([Players.A])
        result |> should equal "15-love"