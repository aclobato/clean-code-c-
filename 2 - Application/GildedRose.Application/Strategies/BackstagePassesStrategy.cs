using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public class BackstagePassesStrategy : BaseQualityUpdatinfStrategy
    {

        protected override int GetNewQualityValue(Item item)
        {
            if (item.SellIn <= 0)
            {
                return 0;
            }
            else
            {
                return base.GetNewQualityValue(item);
            }
        }


        protected override int GetMultiplerQualityUpdating(Item item)
        {
            var multiplier = 1;
            if (item.SellIn <= 5)
            {
                multiplier = 3;
            }
            else if (item.SellIn <= 10)
            {
                multiplier = 2;
            } 
               
            return -1 * multiplier * base.GetMultiplerQualityUpdating(item);
        }
    }
}
