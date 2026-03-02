using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;


namespace GildedRoseTests
{
    public class ConjuredItemTests
    {
        [TestCase(10, 20, 18, TestName = "Conjured_DegradesTwiceAsFast_AsNormal")]
        [TestCase(0, 20, 16, TestName = "Conjured_Degrades4TimesAsFast_AfterSellBy")]
        [TestCase(10, 1, 0, TestName = "Conjured_Quality_NeverNegative")]
        [TestCase(0, 3, 0, TestName = "Conjured_QualityFloorIsZero_WhenDegradingByFour")]
        public void UpdateQuality_ConjuredItems(int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}
