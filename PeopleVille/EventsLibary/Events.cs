using Logging;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using Villager;

namespace EventsLibary
{
    public class Events
    {
        public List<IVillager> ListOfVillagers { get; set; } = new();
        public int NumberOfDays { get; set; }
        public Events(List<IVillager> villagers)
        {
            ListOfVillagers = villagers;
        }
        public Events(List<IVillager> villagers, int day)
        {
            ListOfVillagers = villagers;
            NumberOfDays = day;
        }

        private void NaturelDiesaterEvent()
        {
            Random random = new();
            int NumberOfVillagerToDied = random.Next(1,ListOfVillagers.Count+1);
            List<IVillager> ListToWithoutDeadPeople = ListOfVillagers.ToList();
            for (int i = 0;i < NumberOfVillagerToDied;i++)
            {
                ListToWithoutDeadPeople.Remove(ListOfVillagers[i]);
            }
            ListOfVillagers = ListToWithoutDeadPeople.ToList();
            LogEvents.Log($"{NumberOfVillagerToDied} Died in a naturel diesater. \nEverybody who survived griefed and morned over their fellow villagers.", NumberOfDays);
        }

        private void HyggeWasteTimeEvent()
        {
            LogEvents.Log("Everybody hygged the hele day", NumberOfDays);
        }

        private void FestivalEvent()
        {
            LogEvents.Log("All the villagers enjoyed a nice festival with some great artist and good music", NumberOfDays);
        }

        private void LocalSportTournamentEvent()
        {
            LogEvents.Log("Everybody enjoyed a good old football tournamant", NumberOfDays);
        }

        private void StoryTellingEvent()
        {
            LogEvents.Log("Everybody gattered around ChatGBT then it started telling a story and it went like:\n" + File.ReadAllText(Environment.CurrentDirectory + "/peoplevillestory.txt"), NumberOfDays);
        }

        private void NormaleWorkDayEvent()
        {
            LogEvents.Log("Everbody went to work and enjoyed a normal day of work.", NumberOfDays);
        }

        public Action GetRandomAction()
        {
            Random rand = new();
            int numberForEvent = rand.Next(0,101);
            if (numberForEvent >= 0)
            {
                if (numberForEvent >= 51)
                {
                    if (numberForEvent >= 63)
                    {
                        if (numberForEvent >= 75)
                        {
                            if (numberForEvent >= 87)
                            {
                                if (numberForEvent >= 100)
                                {
                                    return NaturelDiesaterEvent;
                                }
                                return StoryTellingEvent;
                            }
                            return LocalSportTournamentEvent;
                        }
                        return FestivalEvent;
                    }
                    return HyggeWasteTimeEvent;
                }
                return NormaleWorkDayEvent;
            }
            return NormaleWorkDayEvent;
        }
    }
}