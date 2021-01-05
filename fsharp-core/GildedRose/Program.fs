namespace GildedRose

open System.Collections.Generic
open GildedRose.DomainTypes
open GildedRose.DomainImplementation

type Item =
    { Name: string
      SellIn: int
      Quality: int }

module ItemDto =
    let toDomain (dto: Item): DomainTypes.Item =
        if dto.Name.StartsWith "Sulfuras" then
            DomainTypes.Item.Legendary
                { Name = dto.Name
                  SellIn = dto.SellIn
                  Quality = (LegendaryQuality.createFrom dto.Quality) }
        else if dto.Name.StartsWith "Aged Brie" then
            DomainTypes.Item.AgedBrie
                { Name = dto.Name
                  SellIn = dto.SellIn
                  Quality = (Quality.createFrom dto.Quality) }
        else if dto.Name.StartsWith "Backstage passes" then
            DomainTypes.Item.BackstagePass
                { Name = dto.Name
                  SellIn = dto.SellIn
                  Quality = (Quality.createFrom dto.Quality) }
        else
            DomainTypes.Item.Normal
                { Name = dto.Name
                  SellIn = dto.SellIn
                  Quality = (Quality.createFrom dto.Quality) }

    let fromDomain (item: DomainTypes.Item): Item =
        match item with
        | Legendary it ->
            { Name = it.Name
              SellIn = it.SellIn
              Quality = (LegendaryQuality.valueOf it.Quality) }
        | AgedBrie it ->
            { Name = it.Name
              SellIn = it.SellIn
              Quality = (Quality.valueOf it.Quality) }
        | BackstagePass it ->
            { Name = it.Name
              SellIn = it.SellIn
              Quality = (Quality.valueOf it.Quality) }
        | Normal it ->
            { Name = it.Name
              SellIn = it.SellIn
              Quality = (Quality.valueOf it.Quality) }


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
    let main argv =
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
