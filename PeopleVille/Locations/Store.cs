using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village
{
    internal class Store : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action Buy { get; set; }
        public List<ItemsLibary.Items> Items { get; set; }

        public Store(int id, string storeName, int value)
        {
            ID = id;
            Name = storeName;
            Value = value;
        }

        public void BuyItem(int itemId, int villagerId)
        {
            
        }
    }
}
