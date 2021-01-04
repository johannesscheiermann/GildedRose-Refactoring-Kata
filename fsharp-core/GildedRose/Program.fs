namespace GildedRose

open System.Collections.Generic
open GildedRose.DomainTypes

type Item = { Name: string; SellIn: int; Quality: int }

type TempMixedItemType =
    | Legacy of Item
    | Domain of GildedRose.DomainTypes.Item

type GildedRose(items:IList<TempMixedItemType>) =
    let Items = items

    member this.UpdateQuality() =
        let update (item:TempMixedItemType) : TempMixedItemType =
            match item with
            | Domain domain ->
                match domain with
                | GildedRose.DomainTypes.Item.Normal n ->
                    TempMixedItemType.Domain domain
                | _ -> TempMixedItemType.Domain domain
            | Legacy item ->
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
                TempMixedItemType.Legacy mutableReturnVal
        for i = 0 to Items.Count - 1 do
            Items.[i] <- update Items.[i]


module Program =
    [<EntryPoint>]
    let main argv =
        printfn "OMGHAI!"
        let Items = new List<TempMixedItemType>()
        Items.Add(Legacy {Name = "+5 Dexterity Vest"; SellIn = 10; Quality = 20})
        Items.Add(Legacy {Name = "Aged Brie"; SellIn = 2; Quality = 0})
        Items.Add(Legacy {Name = "Elixir of the Mongoose"; SellIn = 5; Quality = 7})
        Items.Add(Legacy {Name = "Sulfuras, Hand of Ragnaros"; SellIn = 0; Quality = 80})
        Items.Add(Legacy {Name = "Sulfuras, Hand of Ragnaros"; SellIn = -1; Quality = 80})
        Items.Add(Legacy {Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 15; Quality = 20})
        Items.Add(Legacy {Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 10; Quality = 49})
        Items.Add(Legacy {Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 49})
        Items.Add(Legacy {Name = "Conjured Mana Cake"; SellIn = 3; Quality = 6})

        let app = new GildedRose(Items)
        for i = 0 to 30 do
            printfn "-------- day %d --------" i
            printfn "name, sellIn, quality"
            for j = 0 to Items.Count - 1 do
                 match Items.[j] with
                 | Legacy l -> printfn "%s, %d, %d" l.Name l.SellIn l.Quality
                 | Domain d ->
                     match d with
                     | GildedRose.DomainTypes.Item.Normal l ->
                         printfn "%s, %d, %d" l.Name l.SellIn (l.Quality |> Quality.valueOf)
                     | GildedRose.DomainTypes.Item.BackstagePass l ->
                         printfn "%s, %d, %d" l.Name l.SellIn (l.Quality |> Quality.valueOf)
                     | GildedRose.DomainTypes.Item.AgedBrie l ->
                         printfn "%s, %d, %d" l.Name l.SellIn (l.Quality |> Quality.valueOf)
                     | GildedRose.DomainTypes.Item.Legendary l ->
                         printfn "%s, %d, %d" l.Name l.SellIn (l.Quality |> LegendaryQuality.valueOf)
            printfn ""
            app.UpdateQuality()
        0 