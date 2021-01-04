namespace GildedRose

open System.Collections.Generic

type Item = { Name: string; SellIn: int; Quality: int }

type GildedRose(items:IList<Item>) =
    let Items = items

    member this.UpdateQuality() =
        let update item =
            let mutable mutableReturnVal = item
            if mutableReturnVal.Name <> "Aged Brie" && mutableReturnVal.Name <> "Backstage passes to a TAFKAL80ETC concert" then
                if mutableReturnVal.Quality > 0 then
                    if mutableReturnVal.Name <> "Sulfuras, Hand of Ragnaros" then
                        mutableReturnVal <- { mutableReturnVal with Quality = (mutableReturnVal.Quality - 1) } 
            else
               if mutableReturnVal.Quality < 50 then
                    mutableReturnVal <- { mutableReturnVal with Quality = (mutableReturnVal.Quality + 1) } 
                    if mutableReturnVal.Name = "Backstage passes to a TAFKAL80ETC concert" then
                        if mutableReturnVal.SellIn < 11 then
                            if mutableReturnVal.Quality < 50 then
                                mutableReturnVal <- { mutableReturnVal with Quality = (mutableReturnVal.Quality + 1) } 
                        if mutableReturnVal.SellIn < 6 then
                            if mutableReturnVal.Quality < 50 then
                                mutableReturnVal <- { mutableReturnVal with Quality = (mutableReturnVal.Quality + 1) } 
            if mutableReturnVal.Name <> "Sulfuras, Hand of Ragnaros" then                 
                mutableReturnVal <- { mutableReturnVal with SellIn  = (mutableReturnVal.SellIn - 1) } 
            if mutableReturnVal.SellIn < 0 then
                if mutableReturnVal.Name <> "Aged Brie" then
                    if mutableReturnVal.Name <> "Backstage passes to a TAFKAL80ETC concert" then
                        if mutableReturnVal.Quality > 0 then
                            if mutableReturnVal.Name <> "Sulfuras, Hand of Ragnaros" then
                                mutableReturnVal <- { mutableReturnVal with Quality   = (mutableReturnVal.Quality  - 1) } 
                    else
                        mutableReturnVal <- { mutableReturnVal with Quality   = (mutableReturnVal.Quality  - mutableReturnVal.Quality) } 
                else
                    if mutableReturnVal.Quality < 50 then
                        mutableReturnVal <- { mutableReturnVal with Quality   = (mutableReturnVal.Quality + 1) }
            mutableReturnVal
        for i = 0 to Items.Count - 1 do
            Items.[i] <- update Items.[i]


module Program =
    [<EntryPoint>]
    let main argv =
        printfn "OMGHAI!"
        let Items = new List<Item>()
        Items.Add({Name = "+5 Dexterity Vest"; SellIn = 10; Quality = 20})
        Items.Add({Name = "Aged Brie"; SellIn = 2; Quality = 0})
        Items.Add({Name = "Elixir of the Mongoose"; SellIn = 5; Quality = 7})
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = 0; Quality = 80})
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = -1; Quality = 80})
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 15; Quality = 20})
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 10; Quality = 49})
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 49})
        Items.Add({Name = "Conjured Mana Cake"; SellIn = 3; Quality = 6})

        let app = new GildedRose(Items)
        for i = 0 to 30 do
            printfn "-------- day %d --------" i
            printfn "name, sellIn, quality"
            for j = 0 to Items.Count - 1 do
                 printfn "%s, %d, %d" Items.[j].Name Items.[j].SellIn Items.[j].Quality
            printfn ""
            app.UpdateQuality()
        0 