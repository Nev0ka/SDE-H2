using ItemsLibary;
using Villager;

namespace Locations
{
    public class Store : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> Transactions { get; set; } = new();
        public List<Items> StoreInventory { get; set; } = new();
        public int Location { get; set; }

        public Store(int id, string storeName, int location)
        {
            ID = id;
            Name = storeName;
            Location = location;
            StoreInventory = new()
            {
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
                Items.GetNewRandomItem(ID),
            };
        }

        public void SellItem(int itemId, Villager.Villager villager)
        {
            Items item = StoreInventory.First(x => x.ID == itemId);
            if (villager.Wallet < item.Value)
            {
                return;
            }
            else
            {
                villager.Inventory.Add(item);
                Transactions.Add(item.Value);
                villager.Wallet -= item.Value;
                StoreInventory.Remove(item);
            }
        }

        public void BuyItem(int itemId, Villager.Villager villager)
        {
            Items item = villager.Inventory.First(x => x.ID == itemId);
            if (Transactions.Sum() < item.Value)
            {
                return;
            }
            else
            {
                StoreInventory.Add(item);
                villager.Inventory.Remove(item);
                Transactions.Add(-item.Value);
                villager.Wallet += item.Value;
            }
        }
    }
}