using GildedRoseKata.Factories;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = ItemUpdaterFactory.GetUpdater(item);
            updater.Update(item);
        }
    }
}