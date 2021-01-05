module GildedRose.Domain_Dtos

open GildedRose.DomainTypes

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
