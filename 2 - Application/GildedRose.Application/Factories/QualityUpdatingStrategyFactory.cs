using GildedRose.Application.Interfaces;
using GildedRose.Application.Strategies;
using GildedRoseKata.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Application.Factories
{
    public class QualityUpdatingStrategyFactory: IQualityUpdatingStrategyFactory
    {
        private readonly IEnumerable<IQualityUpdatingStrategy> _strategies;

        public QualityUpdatingStrategyFactory(IEnumerable<IQualityUpdatingStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IQualityUpdatingStrategy GetQualityUpdatingStrategyToItem(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => _strategies.OfType<AgedBrieStrategy>().First(),
                "Backstage passes to a TAFKAL80ETC concert" => _strategies.OfType<BackstagePassesStrategy>().First(),
                "Sulfuras, Hand of Ragnaros" => _strategies.OfType<SulfurasStrategy>().First(),
                "Conjured Mana Cake" => _strategies.OfType<ConjuredStrategy>().First(),
                _ => _strategies.OfType<NormalItemStrategy>().First(),
            };
        }
    }
}
