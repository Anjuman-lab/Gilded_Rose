using GildedRoseKata.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories
{
    public interface ItemUpdaterFactory
    {
        public static IItemUpdater GetUpdater(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdater();

            if (item.Name == "Sulfuras")
                return new SulfurasUpdater();

            if (item.Name == "Backstage passes")
                return new BackstagePassUpdater();

            if (item.Name.StartsWith("Conjured"))
                return new ConjuredUpdater();

            return new NormalItemUpdater();
        }
    }
}
