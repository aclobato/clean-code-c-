using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public abstract class BaseQualityUpdatinfStrategy : IQualityUpdatingStrategy
    {
        private const int MIN_QUALITY_VALUE = 0; 
        private const int MAX_QUALITY_VALUE = 50;

        public void UpdateItemQuality(Item item)
        {
            item.Quality = GetNewQualityValue(item);
            item.SellIn = GetNewSellInValue(item);
        }

        protected virtual int GetNewQualityValue(Item item)
        {
            var multiplier = GetMultiplerQualityUpdating(item);
            var newQuality = item.Quality - (multiplier * 1);

            if (newQuality < MIN_QUALITY_VALUE)
            {
                newQuality = MIN_QUALITY_VALUE;
            }

            if (newQuality > MAX_QUALITY_VALUE)
            {
                newQuality = MAX_QUALITY_VALUE;
            }

            return newQuality;
        }

        protected virtual int GetNewSellInValue(Item item)
        {
            return item.SellIn - 1;
        }

        protected virtual int GetMultiplerQualityUpdating(Item item)
        {
            return item.SellIn <= MIN_QUALITY_VALUE ? 2 : 1;
        }
    }
}
