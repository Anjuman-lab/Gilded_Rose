using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class SulfurasUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality.
            // Therefore, we do not decrement SellIn and we do not change Quality.
        }
    }
}
