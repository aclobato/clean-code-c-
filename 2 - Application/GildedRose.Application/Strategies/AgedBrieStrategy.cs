using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public class AgedBrieStrategy : BaseQualityUpdatinfStrategy
    {
        protected override int GetMultiplerQualityUpdating(Item item)
        {
            return -1 * base.GetMultiplerQualityUpdating(item);
        }
    }
}
