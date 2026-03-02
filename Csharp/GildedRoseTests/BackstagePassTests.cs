using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests
{
    [TestFixture]
    public class BackstagePassTests
    {
        [TestCase(11, 20, 21, TestName = "BackstagePass_IncreasesNormally_Above7Days")]
        [TestCase(7, 20, 23, TestName = "BackstagePass_IncreasesBy3_At7DaysOrLess")]
        [TestCase(2, 20, 24, TestName = "BackstagePass_IncreasesBy4_At2DaysOrLess")]
        [TestCase(0, 20, 0, TestName = "BackstagePass_QualityDropsToZero_AfterConcert")]
        [TestCase(5, 39, 40, TestName = "BackstagePass_Quality_StillCapsAt40")]

        [TestCase(8, 20, 21, TestName = "BackstagePass_IncreasesBy1_At8Days")] // Boundary for the 7-day rule
        [TestCase(3, 20, 23, TestName = "BackstagePass_IncreasesBy3_At3Days")] // Boundary for the 2-day rule
        [TestCase(5, 38, 40, TestName = "BackstagePass_Quality_CapsAt40_EvenWithLargeIncrease")]
        public void UpdateQuality_BackstagePasses(int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item> 
            { 
                new Item 
                { 
                        Name = "Backstage passes to a TAFKAL80ETC concert", 
                        SellIn = sellIn, 
                        Quality = quality 
                } 
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            // Assert Quality
            Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));

            // Assert SellIn decreases by 1 (except Sulfuras)
            Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        }
    }
}
