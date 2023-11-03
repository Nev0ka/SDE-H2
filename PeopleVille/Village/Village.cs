using Locations;
using Villager;

namespace Village
{
    public class Village
    {
        public List<ILocation> LocationsInVillage { get; set; } = new();
        public List<IVillager> Villagers { get; set; } = new();

        public void CreateVillage()
        {
            List<string> names;
            List<string> storeNames;
            try
            {
                names = File.ReadAllLines(Environment.CurrentDirectory + "/names.txt").ToList();
                storeNames = File.ReadAllLines(Environment.CurrentDirectory + "/storenames.txt").ToList();
            }
            catch (Exception)
            {
                throw new("Failed to load in the names for villager please check that you have a names.txt and storenames.txt in you program output folder.");
            }
            Random rnd = new();
            int numberOfVillagers = rnd.Next(200, names.Count + 1);
            for (int i = 0; i < numberOfVillagers; i++)
            {
                Villager.Villager villager = new(i, names[i], i, 10);
                Villagers.Add(villager);
                if (i == 0)
                {
                    continue;
                }
                if ((i % 4) == 0)
                {
                    House house = new(i * 1000, i, names[i], i, Enums.LocationsTypeEnums.House);
                    LocationsInVillage.Add(house);
                }
                if ((i % 200) == 0)
                {
                    Store store = new(i * 754, storeNames[rnd.Next(0, storeNames.Count)], i, Enums.LocationsTypeEnums.Store);
                    LocationsInVillage.Add(store);
                }
            }
        }
    }
}
