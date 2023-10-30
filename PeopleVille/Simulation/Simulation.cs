using Logging;
using Village;

namespace Simulation
{
    public class Simulation
    {
        //Start sim function
        public void StartUpSim()
        {
            Village.Village village = new();
            village.CreateVillage();
            LogEvents log = new();
            log.Log($"Village create number of villagers:{village.Villagers.Count}, number of locations: {village.Locations.Count}");
        }
    }
}