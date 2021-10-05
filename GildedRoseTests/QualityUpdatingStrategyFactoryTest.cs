using AutoFixture;
using FluentAssertions;
using GildedRose.Application.Factories;
using GildedRose.Application.Interfaces;
using GildedRose.Application.Strategies;
using GildedRoseKata.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests
{
    public class QualityUpdatingStrategyFactoryTest
    {
        private readonly IList<IQualityUpdatingStrategy> _strategies;
        private readonly Fixture _fixture;

        public QualityUpdatingStrategyFactoryTest()
        {
            _strategies = new List<IQualityUpdatingStrategy>
            {
                new AgedBrieStrategy(),
                new BackstagePassesStrategy(),
                new ConjuredStrategy(),
                new NormalItemStrategy(),
                new SulfurasStrategy()
            };

            _fixture = new Fixture();
        }

        [Fact]
        public void GetQualityUpdatingStrategyToItem_WhenItemNotSpecial_ShouldReturnNormalItemStrategy()
        {
            var item = new Item 
            { 
                Name = _fixture.Create<string>(), 
                SellIn = _fixture.Create<int>(), 
                Quality = _fixture.Create<int>() 
            };
            QualityUpdatingStrategyFactory factory = new QualityUpdatingStrategyFactory(_strategies);
            var strategySelected = factory.GetQualityUpdatingStrategyToItem(item);

            strategySelected.GetType().Should().Be(typeof(NormalItemStrategy));
        }

        [Fact]
        public void GetQualityUpdatingStrategyToItem_WhenAgedBrieItem_ShouldReturnAgedBrieStrategy()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = _fixture.Create<int>(),
                Quality = _fixture.Create<int>()
            };
            QualityUpdatingStrategyFactory factory = new QualityUpdatingStrategyFactory(_strategies);
            var strategySelected = factory.GetQualityUpdatingStrategyToItem(item);

            strategySelected.GetType().Should().Be(typeof(AgedBrieStrategy));
        }

        [Fact]
        public void GetQualityUpdatingStrategyToItem_WhenBackstagePassesItem_ShouldBackstagePassesStrategy()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = _fixture.Create<int>(),
                Quality = _fixture.Create<int>()
            };
            QualityUpdatingStrategyFactory factory = new QualityUpdatingStrategyFactory(_strategies);
            var strategySelected = factory.GetQualityUpdatingStrategyToItem(item);

            strategySelected.GetType().Should().Be(typeof(BackstagePassesStrategy));
        }

        [Fact]
        public void GetQualityUpdatingStrategyToItem_WhenConjuredItem_ShouldConjuredStrategy()
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = _fixture.Create<int>(),
                Quality = _fixture.Create<int>()
            };
            QualityUpdatingStrategyFactory factory = new QualityUpdatingStrategyFactory(_strategies);
            var strategySelected = factory.GetQualityUpdatingStrategyToItem(item);

            strategySelected.GetType().Should().Be(typeof(ConjuredStrategy));
        }

        [Fact]
        public void GetQualityUpdatingStrategyToItem_WhenSulfurasItem_ShouldSulfurasStrategy()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = _fixture.Create<int>(),
                Quality = _fixture.Create<int>()
            };
            QualityUpdatingStrategyFactory factory = new QualityUpdatingStrategyFactory(_strategies);
            var strategySelected = factory.GetQualityUpdatingStrategyToItem(item);

            strategySelected.GetType().Should().Be(typeof(SulfurasStrategy));
        }
    }
}
