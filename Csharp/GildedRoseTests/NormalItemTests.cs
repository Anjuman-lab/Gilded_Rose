using GildedRoseKata;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests;

[TestFixture]
public class NormalItemTests
{
    [TestCase(10, 20, 9, 19, TestName = "NormalItem_DecreasesQualityAndSellIn_ByOne")]
    [TestCase(0, 20, -1, 18, TestName = "NormalItem_QualityDegradesTwiceAsFast_AfterSellBy")]
    [TestCase(10, 0, 9, 0, TestName = "NormalItem_Quality_NeverNegative")]
    //Quality Floor
    [TestCase(0, 1, -1, 0, TestName = "NormalItem_QualityDoesNotGoNegative_WhenDegradingBy2")]
    [TestCase(-5, 0, -6, 0, TestName = "NormalItem_QualityStaysAtZero_WhenAlreadyZeroAndExpired")]
    public void UpdateQuality_NormalItems(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Multiple(() => {
            Assert.That(items[0].SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
        });
    }
}
