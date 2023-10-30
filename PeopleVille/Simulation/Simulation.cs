using Logging;
using Village;

namespace Simulation
{
    public class Simulation
    {
        public void StartUpSim(Village.Village village)
        {
            village.CreateVillage();
            LogEvents.Log($"Village create number of villagers:{village.Villagers.Count}, number of locations: {village.LocationsInVillage.Count}");
        }
    }
}