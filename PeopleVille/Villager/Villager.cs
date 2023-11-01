using ItemsLibary;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Villager
{
    public class Villager : IVillager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Items> Inventory { get; set; } = new();
        public int Location { get; set; }
        public int Wallet { get; set; }

        public Villager(int id, string name, int location, int wallet)
        {
            ID = id;
            Name = name;
            Location = location;
            Wallet = wallet;
            Inventory = new() {
            Items.GetNewRandomItem(id),
            Items.GetNewRandomItem(id),
            Items.GetNewRandomItem(id),
            Items.GetNewRandomItem(id),
            Items.GetNewRandomItem(id),
            };
        }
    }
}