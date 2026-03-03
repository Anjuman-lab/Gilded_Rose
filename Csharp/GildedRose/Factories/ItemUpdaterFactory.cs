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
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot update a null item.");
            }

            if (item.Name == "Aged Brie")
                return new AgedBrieUpdater();

            if (item.Name == "Sulfuras, Hand of Ragnaros") 
                return new SulfurasUpdater();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstagePassUpdater();

            if (item.Name.StartsWith("Conjured"))
                return new ConjuredUpdater();

            return new NormalItemUpdater();
        }
    }
}
