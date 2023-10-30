using Enums;
using RNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ItemsLibary
{
    public class Items : IItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action<string> UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }

        public Items(int parentID, ItemEnums type, ItemRarityEnum itemRarity)
        {
            ParentID = parentID;
            Name = $"{itemRarity.ToString()} {type.ToString()}";
            ItemRarity = itemRarity;
            TypeOfItem = type;
            Value = RNGGenarator.GetValueForItem((int)itemRarity);
            UseAction = GetAction(type);
        }

        public Action<string> GetAction(ItemEnums type)
        {
            Action<string> action = NoAction;
            switch (type)
            {
                case ItemEnums.Knife: // stabby stabby
                    break;
                case ItemEnums.Hat:
                    break;
                case ItemEnums.Watch:
                    break;
                case ItemEnums.Glasses:
                    break;
                case ItemEnums.Pitchfork:
                    break;
                case ItemEnums.Book:
                    break;
                default:
                    action = NoAction;
                    break;
            }
            return action;
        }

        private void NoAction(string obj)
        {
            obj = "No thing happend";
        }

        public static Items GetNewRandomItem(int parentID)
        {
            int max = 0;
            int lowest = 0;
            var random = new Random((int)DateTime.Now.Ticks);
            lowest = Enum.GetValues(typeof(ItemEnums)).Cast<int>().Min();
            max = Enum.GetValues(typeof(ItemEnums)).Cast<int>().Max();
            int ItemType = random.Next(lowest, max);
            lowest = Enum.GetValues(typeof(ItemRarityEnum)).Cast<int>().Min();
            max = Enum.GetValues(typeof(ItemRarityEnum)).Cast<int>().Max();
            int rarity = random.Next(lowest, max);
            return new Items(parentID, (ItemEnums)ItemType, (ItemRarityEnum)rarity);
        }
    }
}
