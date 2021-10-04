using GildedRose.Application.Interfaces;
using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Strategies
{
    public class ConjuredStrategy : BaseQualityUpdatinfStrategy
    {
        protected override int GetMultiplerQualityUpdating(Item item)
        {
            return 2 * base.GetMultiplerQualityUpdating(item);
        }  
    }
}
