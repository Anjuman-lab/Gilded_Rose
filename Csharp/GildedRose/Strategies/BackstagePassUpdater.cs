using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class BackstagePassUpdater : BaseItemUpdater
    {
        public override void Update(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 2)
            {
                IncreaseQuality(item, 4);
            }
            else if (item.SellIn <= 7)
            {
                IncreaseQuality(item, 3);
            }
            else
            {
                IncreaseQuality(item, 1);
            }

            item.SellIn--;
        }
    }
}
