namespace GildedRose.DomainTypes

type ValidationError = private ValidationError of string

type Quality = private Quality of int

module Quality =
    let createFrom quality =
        if quality < 0 then Quality 0
        else if quality > 50 then Quality 50
        else Quality quality

    let valueOf (Quality quality) = quality

type NormalItem =
    { Name: string
      SellIn: int // Intentionally a primitive int type
      Quality: Quality }

type BackstagePassItem =
    { Name: string
      SellIn: int // Intentionally a primitive int type
      Quality: Quality }

type AgedBrieItem =
    { Name: string
      SellIn: int // Intentionally a primitive int type
      Quality: Quality }

type LegendaryQuality = private LegendaryQuality of int

module LegendaryQuality =
    let createFrom quality =
        if quality < 0 then LegendaryQuality 0 else LegendaryQuality quality

    let valueOf (LegendaryQuality quality) = quality

type LegendaryItem =
    { Name: string
      SellIn: int // Intentionally a primitive int type
      Quality: LegendaryQuality }

type Item =
    | Normal of NormalItem
    | BackstagePass of BackstagePassItem
    | AgedBrie of AgedBrieItem
    | Legendary of LegendaryItem

type DecrementSellIn = Item -> Item
type UpdateQuality = Item -> Item
