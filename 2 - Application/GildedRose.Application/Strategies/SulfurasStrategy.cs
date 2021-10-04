using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public class SulfurasStrategy : BaseQualityUpdatinfStrategy
    {
        protected override int GetNewQualityValue(Item item)
        {
            return item.Quality;
        }

        protected override int GetNewSellInValue(Item item)
        {
            return item.SellIn;
        }
    }
}
