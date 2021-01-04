﻿module GildedRose.DomainImplementation

open GildedRose.DomainTypes

let decrementSellIn: DecrementSellIn =
    fun item ->
        let decrementSellIn value = value - 1

        match item with
        | Normal it ->
            Normal
                { it with
                      SellIn = it.SellIn |> decrementSellIn }
        | BackstagePass it ->
            BackstagePass
                { it with
                      SellIn = it.SellIn |> decrementSellIn }
        | AgedBrie it ->
            AgedBrie
                { it with
                      SellIn = it.SellIn |> decrementSellIn }
        | Legendary it ->
            Legendary
                { it with
                      SellIn = it.SellIn |> decrementSellIn }

let updateNormalItemQuality (item: NormalItem): NormalItem =
    let qualityLoss = if item.SellIn < 0 then 2 else 1

    { item with
          Quality =
              ((item.Quality |> Quality.valueOf) - qualityLoss
               |> Quality.createFrom) }

let updateQuality: UpdateQuality =
    fun item ->
        match item with
        | Normal it -> it |> updateNormalItemQuality |> Normal
        | _ -> failwith "not implemented" // TODO
