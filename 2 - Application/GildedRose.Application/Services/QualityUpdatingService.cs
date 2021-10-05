using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;
using System.Collections.Generic;

namespace GildedRose.Application.Services
{
    public class QualityUpdatingService: IQualityUpdatingService
    {
        private readonly IQualityUpdatingStrategyFactory _qualityUpdatingFactory;

        public QualityUpdatingService(IQualityUpdatingStrategyFactory qualityUpdatingFactory)
        {
            _qualityUpdatingFactory = qualityUpdatingFactory;
        }

        public IList<Item> UpdateQuality(IList<Item> items)
        {
            foreach(Item item in items)
            {
                UpdateItemQuality(item);
            }
            return items;
        }

        private void UpdateItemQuality(Item item)
        {
            var strategy = _qualityUpdatingFactory.GetQualityUpdatingStrategyToItem(item);
            strategy.UpdateItemQuality(item);
        }

    }
}
