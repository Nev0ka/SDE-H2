using Enums;
using RNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ItemsLibary
{
    public class Items : IItem
    {
        private static int count = 0;
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action? UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }

        public Items(int id, int parentID, ItemEnums type, ItemRarityEnum itemRarity)
        {
            ID = id;
            ParentID = parentID;
            Name = $"{itemRarity.ToString()} {type.ToString()}";
            ItemRarity = itemRarity;
            TypeOfItem = type;
            Value = RNGGenarator.GetValueForItem((int)itemRarity);
        }

        public static Items GetNewRandomItem(int parentID)
        {
            int max = 0;
            int lowest = 0;
            var random = new Random();
            lowest = Enum.GetValues(typeof(ItemEnums)).Cast<int>().Min();
            max = Enum.GetValues(typeof(ItemEnums)).Cast<int>().Max()+1;
            int ItemType = random.Next(lowest, max);
            lowest = Enum.GetValues(typeof(ItemRarityEnum)).Cast<int>().Min();
            max = Enum.GetValues(typeof(ItemRarityEnum)).Cast<int>().Max()+1;
            int rarity = random.Next(lowest, max);
            count++;
            return new Items(count,parentID, (ItemEnums)ItemType, (ItemRarityEnum)rarity);
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
