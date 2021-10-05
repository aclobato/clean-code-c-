using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Interfaces
{
    public interface IQualityUpdatingStrategyFactory
    {
        public IQualityUpdatingStrategy GetQualityUpdatingStrategyToItem(Item item);
    }
}
