using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class AgedBrieUpdater : BaseItemUpdater
    {
        public override void Update(Item item)
        {
            IncreaseQuality(item, item.SellIn <= 0 ? 2 : 1);
            item.SellIn--;
        }
    }
}
