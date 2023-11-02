using Enums;
using ItemsLibary;
using Logging;
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
        public LocationsTypeEnums Type { get; set; }

        public Store(int id, string storeName, int location, LocationsTypeEnums locationsType)
        {
            ID = id;
            Name = storeName;
            Location = location;
            Type = locationsType;
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

        public void SellItem(int itemId, IVillager villager, int day)
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
                LogEvents.Log($"{villager.Name} just bought {item.ToString()} for {item.Value}$ from {Name}\n", day);
            }
        }

        public void BuyItem(int itemId, IVillager villager, int day)
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
                LogEvents.Log($"{villager.Name} just sold {item.ToString()} too {Name} for {item.Value}$\n", day);
            }
        }
    }
}