module GildedRose.UnitTests

open Xunit

type undefined = exn // TODO: remove type

module ``An items sellIn value`` =
    [<Fact>]
    let ``decreases by 1 per day`` () = undefined

module ``The quality of`` =
    [<Fact>]
    let ``items cannot fall below 0`` () = undefined

    [<Fact>]
    let ``Sulfuras is always 80`` () = undefined

    module ``normal items`` =
        [<Fact>]
        let ``cannot exceed 50`` () = undefined

        [<Fact>]
        let ``decreases daily by 1 while the sell by date has not passed`` () = undefined

        [<Fact>]
        let ``decreases daily by 2 if the sell by date has passed`` () = undefined

    module ``backstage pass like items`` =
        [<Fact>]
        let ``cannot exceed 50`` () = undefined

        [<Fact>]
        let ``drops to 0 if the sell by date has passed`` () = undefined

        [<Fact>]
        let ``increases daily by 2 if the sell by date is reached in the next 10 to 6 days`` () = undefined

        [<Fact>]
        let ``increases daily by 3 if the sell by date is reached in the next 5 days`` () = undefined

    module ``legendary items`` =
        [<Fact>]
        let ``can exceed 50`` () = undefined

        [<Fact>]
        let ``does not change due to passing days`` () = undefined
