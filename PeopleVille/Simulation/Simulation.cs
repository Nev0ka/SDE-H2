using EventsLibary;
using Logging;
using System.Runtime.CompilerServices;
using Village;
using Villager;

namespace Simulation
{
    public class Simulation
    {
        public int NumberOfDays { get; set; }
        public bool AllVillagersIsDead { get; set; } = false;
        delegate void Actions();
        delegate void Trade(Village.Village village);

        public void StartUpSim(Village.Village village)
        {
            village.CreateVillage();
            LogEvents.Log($"Village create number of villagers:{village.Villagers.Count}, number of locations: {village.LocationsInVillage.Count}");
        }

        public void RunEvents(Village.Village village,int numberOfDays)
        {
            NumberOfDays = numberOfDays;
            Events events = new(village.Villagers, NumberOfDays);
            if (village.Villagers.Count != 1)
            {
                Trade trade = new(RunTradeEvent);
                trade(village);
            }
            Actions ActionDelegate = new(events.GetRandomAction());
            ActionDelegate.Invoke();
            if (events.ListOfVillagers.Count != village.Villagers.Count)
            {
                village.Villagers = events.ListOfVillagers;
            }
            if (village.Villagers.Count == 0)
            {
                AllVillagersIsDead = true;
            }
        }

        public void RunTradeEvent(Village.Village village)
        {
            Events events = new(village.Villagers, NumberOfDays);
            Random rnd = new();
            if (rnd.Next(100) >= 80)
            {
                int numberOfTrades = rnd.Next(5);
                for (int i = 0; i < numberOfTrades; i++)
                {
                    Random rng = new(rnd.Next());
                    int villagernumber1 = rng.Next(village.Villagers.Count);
                    int villagernumber2 = rng.Next(village.Villagers.Count);
                    if (villagernumber1 == villagernumber2)
                    {
                        villagernumber2 = rng.Next(village.Villagers.Count);
                    }
                    events.Trade(village.Villagers[villagernumber1], village.Villagers[villagernumber2]);
                }
            }
        }
    }
}