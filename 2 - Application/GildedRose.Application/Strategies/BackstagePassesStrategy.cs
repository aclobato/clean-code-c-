﻿using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public class BackstagePassesStrategy : IQualityUpdatingStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            item.Quality -= 1;
            item.SellIn -= 1;
        }
    }
}