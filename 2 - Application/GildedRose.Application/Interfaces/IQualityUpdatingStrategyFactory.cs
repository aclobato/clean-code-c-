using GildedRoseKata.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Application.Interfaces
{
    public interface IQualityUpdatingStrategyFactory
    {
        public IQualityUpdatingStrategy GetQualityUpdatingStrategyToItem(Item item);
    }
}
