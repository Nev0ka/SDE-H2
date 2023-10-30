namespace Locations
{
    internal class Store : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action Buy { get; set; }
        public List<ItemsLibary.Items> Items { get; set; } = new();

        public Store(int id, string storeName, int value)
        {
            ID = id;
            Name = storeName;
            Value = value;
        }

        public ItemsLibary.Items? BuyItem(int itemId, int villagerId)
        {
            return null;
        }
    }
}