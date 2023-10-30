namespace Locations
{
    public class House : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int OwnerID { get; set; }
        public int Location { get; set; }

        public House(int id, int ownerId, string villagerName, int value, int location)
        {
            ID = id;
            OwnerID = ownerId;
            Name = villagerName + "'s house";
            Value = value;
            Location = location;
        }
    }
}