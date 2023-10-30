using Logging;
using Village;

namespace Simulation
{
    public class Simulation
    {
        public void StartUpSim()
        {
            Village.Village village = new();
            village.CreateVillage();
            LogEvents.Log($"Village create number of villagers:{village.Villagers.Count}, number of locations: {village.LocationsInVillage.Count}");
        }
    }
}