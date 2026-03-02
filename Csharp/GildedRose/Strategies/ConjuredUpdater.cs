using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class ConjuredUpdater : BaseItemUpdater
    {
        public override void Update(Item item)
        {
            int degradeAmount = item.SellIn <= 0 ? 4 : 2;
            DecreaseQuality(item, degradeAmount);
            item.SellIn--;
        }
    }
}
