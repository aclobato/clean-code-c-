using Xunit;
using System.Collections.Generic;
using GildedRoseKata.Domain.Models;
using GildedRose.Application.Services;
using GildedRose.Application.Factories;
using GildedRose.Application.Interfaces;
using GildedRose.Application.Strategies;
using Moq;

namespace GildedRoseTests
{
    public class QualityUpdatingServiceTest
    {
        public Mock<IQualityUpdatingStrategyFactory> _qualityUpdatingStrategyFactory;

        public QualityUpdatingServiceTest()
        {
            _qualityUpdatingStrategyFactory = new Mock<IQualityUpdatingStrategyFactory>();
        }

        [Fact]
        public void UpdateQuality_WhenSellByDateHasNotPassed_ShouldDecreaceQualityByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new NormalItemStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(9, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSellByDateHasPassed_ShouldDecreaceQualityTwice()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = -1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new NormalItemStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenQualityIsZero_ShouldNotDecreaceQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 0, Quality = 0 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new NormalItemStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_ShouldIncreaceQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new AgedBrieStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrieAndSellByDateHasPassed_ShouldIncreaceQualityTwice()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 0, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new AgedBrieStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenAgedBrieIsQualityLimit50_ShouldNotIncreaceQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 50 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new AgedBrieStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSulfuras_ShouldNeverBeSoldOrDecreaseQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new SulfurasStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(10, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSulfurasAndSellByDateHasPassed_ShouldNeverBeSoldOrDecreaseQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 0, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new SulfurasStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(10, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInMore10Days_ShouldIncreaseQualityBy1()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 15, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new BackstagePassesStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInLessOrEquals10DaysAndMore5Days_ShouldIncreaseQualityBy2()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 8, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new BackstagePassesStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInLessOrEquals5Days_ShouldIncreaseQualityBy3()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 5, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new BackstagePassesStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(13, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellByDateHasPassed_ShouldQualityBeZero()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 0, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new BackstagePassesStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenConjuredAndSellByDateHasNotPassed_ShouldDecreaceQualityByTwo()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new ConjuredStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenConjuredAndSellByDateHasPassed_ShouldDecreaceQualityByFour()
        {
            IList<Item> items = new List<Item> { new Item { Name = "test", SellIn = -1, Quality = 10 } };
            _qualityUpdatingStrategyFactory.Setup(factory => factory.GetQualityUpdatingStrategyToItem(It.IsAny<Item>())).Returns(new ConjuredStrategy());

            QualityUpdatingService service = new QualityUpdatingService(_qualityUpdatingStrategyFactory.Object);
            service.UpdateQuality(items);

            Assert.Equal(6, items[0].Quality);
        }

    }
}
