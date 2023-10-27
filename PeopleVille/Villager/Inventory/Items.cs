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
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }

        public Items(int parentID,ItemEnums type,ItemRarityEnum itemRarity)
        {
            ParentID = parentID;
            Name = $"{itemRarity.ToString()} {type.ToString()}";
            ItemRarity = itemRarity;
            TypeOfItem = type;
            Value = RNGGenarator.GetValueForItem((int)itemRarity);
            UseAction = GetAction(type);
        }

        public Action GetAction(ItemEnums type)
        {
            switch (type)
            {
                case ItemEnums.Money:
                    break;
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
                    break;
            }
            return UseAction; // not how to use it.
        }
    }
}
