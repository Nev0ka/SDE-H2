using Enums;
using RNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villager.Inventory
{
    public class Items : IItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Action UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }

        public Items(ItemEnums type,ItemRarityEnum itemRarity)
        {
            Name = $"{itemRarity.ToString()} {type.ToString()}";
            ItemRarity = itemRarity;
            TypeOfItem = type;
            Value = RNGGenarator.GetValueForItem((int)itemRarity);
        }
    }
}
