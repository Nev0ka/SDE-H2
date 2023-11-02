using ItemsLibary;

namespace Villager
{
    public interface IVillager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Items> Inventory { get; set; }
        public int Location { get; set; }
        public int Wallet { get; set; }
    }
}
