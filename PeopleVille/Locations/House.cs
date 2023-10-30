namespace Locations
{
    public class House : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OwnerID { get; set; }
        public int Location { get; set; }

        public House(int id, int ownerId, string villagerName, int location)
        {
            ID = id;
            OwnerID = ownerId;
            Name = villagerName + "'s house";
            Location = location;
        }
    }
}