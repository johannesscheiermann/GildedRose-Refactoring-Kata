namespace GildedRose

open System.Collections.Generic
open GildedRose.DomainImplementation
open GildedRose.Domain_Dtos

type GildedRose(items: IList<Item>) =
    let Items = items

    member this.UpdateQuality() =
        for i = 0 to Items.Count - 1 do
            Items.[i] <- Items.[i]
                         |> ItemDto.toDomain
                         |> decrementSellIn
                         |> updateQuality
                         |> ItemDto.fromDomain

module Program =
    [<EntryPoint>]
    let main _ =
        printfn "OMGHAI!"
        let Items = List<Item>()

        Items.Add
            ({ Name = "+5 Dexterity Vest"
               SellIn = 10
               Quality = 20 })

        Items.Add
            ({ Name = "Aged Brie"
               SellIn = 2
               Quality = 0 })

        Items.Add
            ({ Name = "Elixir of the Mongoose"
               SellIn = 5
               Quality = 7 })

        Items.Add
            ({ Name = "Sulfuras, Hand of Ragnaros"
               SellIn = 0
               Quality = 80 })

        Items.Add
            ({ Name = "Sulfuras, Hand of Ragnaros"
               SellIn = -1
               Quality = 80 })

        Items.Add
            ({ Name = "Backstage passes to a TAFKAL80ETC concert"
               SellIn = 15
               Quality = 20 })

        Items.Add
            ({ Name = "Backstage passes to a TAFKAL80ETC concert"
               SellIn = 10
               Quality = 49 })

        Items.Add
            ({ Name = "Backstage passes to a TAFKAL80ETC concert"
               SellIn = 5
               Quality = 49 })

        Items.Add
            ({ Name = "Conjured Mana Cake"
               SellIn = 3
               Quality = 6 })

        let app = GildedRose(Items)

        for i = 0 to 30 do
            printfn "-------- day %d --------" i
            printfn "name, sellIn, quality"

            for j = 0 to Items.Count - 1 do
                printfn "%s, %d, %d" Items.[j].Name Items.[j].SellIn Items.[j].Quality

            printfn ""
            app.UpdateQuality()

        0
