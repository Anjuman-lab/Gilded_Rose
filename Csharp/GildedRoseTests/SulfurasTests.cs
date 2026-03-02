using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace GildedRoseTests
{
    [TestFixture]
    public class SulfurasTests
    {
        [TestCase(10, 20, 10, 20)]
        [TestCase(-1, 20, -1, 20)]
        public void UpdateQuality_Sulfuras_NeverChanges(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var items = new List<Item> { new Item { Name = "Sulfuras", SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Multiple(() => {
                Assert.That(items[0].SellIn, Is.EqualTo(expectedSellIn));
                Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
            });
        }
    }
}
