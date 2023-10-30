using ItemsLibary;

namespace Villager
{
    public class Villager : IVillager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ItemsLibary.Items> Inventory { get; set; } = new();
        public int Location { get; set; }
        public int Wallet { get; set; }

        public Villager(int id, string name, List<Items> inventory, int location, int wallet)
        {
            ID = id;
            Name = name;
            Inventory = inventory;
            Location = location;
            Wallet = wallet;
        }
    }
}