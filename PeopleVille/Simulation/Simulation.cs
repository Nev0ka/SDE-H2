using EventsLibary;
using Logging;
using Village;

namespace Simulation
{
    public class Simulation
    {
        public List<Action> Actions { get; set; } = new();
        public int NumberOfDays { get; set; }

        public void StartUpSim(Village.Village village)
        {
            village.CreateVillage();
            LogEvents.Log($"Village create number of villagers:{village.Villagers.Count}, number of locations: {village.LocationsInVillage.Count}");
        }

        public void RunEvents(Village.Village village)
        {
            Events events = new(village.Villagers, NumberOfDays);
            events.GetRandomAction().Invoke();
            NumberOfDays++;
        }
    }
}