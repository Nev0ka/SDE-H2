using Locations;
using System.Security.Cryptography.X509Certificates;
using Villager;

namespace Village
{
    public class Village
    {
        public List<ILocation> LocationsInVillage { get; set; } = new();
        public List<IVillager> Villagers { get; set; } = new();

        int count = 0;
        public void CreateVillage()
        {
            List<string> names = File.ReadAllLines(Environment.CurrentDirectory + "/names.txt").ToList();
            foreach (string name in names)
            {
                count++;
                Villager.Villager villager = new(count, name, count ,10);
                Villagers.Add(villager);
                if ((count % 4) == 0)
                {
                    House house = new(count*1000,count,name,count);
                    LocationsInVillage.Add(house);
                }
                if ((count % 250) == 0)
                {
                    Store store = new(count*754,"walmart",count);
                    LocationsInVillage.Add(store);
                }
            }
        }
    }
}

