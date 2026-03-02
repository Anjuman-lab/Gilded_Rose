using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public abstract class BaseItemUpdater : IItemUpdater
    {
        protected const int MaxQuality = 40;

        public abstract void Update(Item item);

        protected void IncreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Min(MaxQuality, item.Quality + amount);
        }

        protected void DecreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}
