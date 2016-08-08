module tests
    open NUnit.Framework
    open FsUnit
    open Tennis

    [<Test>]
    let ``Game starts love-love``() = 
        let result = Score ([])
        result |> should equal "love-love"