using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_WhenSellByDateHasNotPassed_ShouldDecreaceQualityByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSellByDateHasPassed_ShouldDecreaceQualityTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenQualityIsZero_ShouldNotDecreaceQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_ShouldIncreaceQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrieAndSellByDateHasPassed_ShouldIncreaceQualityTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenAgedBrieIsQualityLimit50_ShouldNotIncreaceQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSulfuras_ShouldNeverBeSoldOrDecreaseQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(10, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSulfurasAndSellByDateHasPassed_ShouldNeverBeSoldOrDecreaseQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(10, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInMore10Days_ShouldIncreaseQualityBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInLessOrEquals10DaysAndMore5Days_ShouldIncreaseQualityBy2()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellInLessOrEquals5Days_ShouldIncreaseQualityBy3()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenBackstagePassesAndSellByDateHasPassed_ShouldQualityBeZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenConjuredAndSellByDateHasNotPassed_ShouldDecreaceQualityByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenConjuredAndSellByDateHasPassed_ShouldDecreaceQualityByFour()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(6, Items[0].Quality);
        }

    }
}
