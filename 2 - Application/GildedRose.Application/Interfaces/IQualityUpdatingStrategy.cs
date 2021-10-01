using GildedRoseKata.Domain.Models;

namespace GildedRose.Application.Interfaces
{
    public interface IQualityUpdatingStrategy
    {
        public void UpdateItemQuality(Item item);
    }
}
