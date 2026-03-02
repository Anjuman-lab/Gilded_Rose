using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace GildedRoseTests
{
    [TestFixture]
    public class AgedBrieTests
    {
        [TestCase(10, 20, 21, TestName = "AgedBrie_IncreasesInQuality_TheOlderItGets")]
        [TestCase(10, 40, 40, TestName = "AgedBrie_Quality_NeverMoreThan40")]
        [TestCase(-1, 20, 22, TestName = "AgedBrie_IncreasesTwiceAsFast_AfterSellBy")]

        [TestCase(10, 39, 40, TestName = "AgedBrie_ReachesMaxQualityOf40")]
        [TestCase(-1, 39, 40, TestName = "AgedBrie_QualityStillCapsAt40_AfterSellBy")]
        [TestCase(0, 40, 40, TestName = "AgedBrie_QualityStillCapsAt40_AtExactlyZeroSellIn")]
        public void UpdateQuality_AgedBrie(int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}
