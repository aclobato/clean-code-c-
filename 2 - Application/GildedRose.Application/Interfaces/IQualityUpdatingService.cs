using GildedRoseKata.Domain.Models;
using System.Collections.Generic;

namespace GildedRose.Application.Interfaces
{
    public interface IQualityUpdatingService
    {
        public IList<Item> UpdateQuality(IList<Item> items);
    }
}
