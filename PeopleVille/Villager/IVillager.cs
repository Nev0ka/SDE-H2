using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villager
{
    public interface IVillager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ItemsLibary.Items> Inventory { get; set; }
        public int Location { get; set; }
        public int Wallet { get; set; }
    }
}
