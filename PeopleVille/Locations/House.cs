using Enums;

namespace Locations
{
    public class House : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OwnerID { get; set; }
        public int Location { get; set; }
        public LocationsTypeEnums Type { get; set; }

        public House(int id, int ownerID, string villagerName, int location, LocationsTypeEnums locationsType)
        {
            ID = id;
            OwnerID = ownerID;
            Name = villagerName + "'s house";
            Location = location;
            Type = locationsType;
        }
    }
}