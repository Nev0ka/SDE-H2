using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Villager.Inventory
{
    public interface IItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Action UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }
    }
}
