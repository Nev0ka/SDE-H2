using Logging;
using System.Reflection.Metadata.Ecma335;
using Villager;

namespace EventsLibary
{
    public class Events
    {
        public List<IVillager> ListOfVillagers { get; set; } = new();
        public Events(List<IVillager> villagers)
        {
            ListOfVillagers = villagers;
        }

        public void NaturelDiesaterEvent()
        {
            Random random = new();
            int NumberOfVillagerToDied = random.Next(1,ListOfVillagers.Count+1);
            List<IVillager> ListToWithoutDeadPeople = ListOfVillagers.ToList();
            for (int i = 0;i < NumberOfVillagerToDied;i++)
            {
                ListToWithoutDeadPeople.Remove(ListOfVillagers[i]);
            }
            ListOfVillagers = ListToWithoutDeadPeople.ToList();
            LogEvents.Log($"{NumberOfVillagerToDied} Died in a naturel diesater.");
        }

        public void HyggeWasteTimeEvent()
        {
            LogEvents.Log("Everybody hygged the hele dag");
        }

        public void FestivalEvent()
        {
            LogEvents.Log("All the villagers enjoyed a nice festival with some great artist and good music");
        }

        public void LocalSportTournamentEvent()
        {
            LogEvents.Log("Everybody enjoyed a good old football tournamant");
        }

        public void StoryTellingEvent()
        {
            LogEvents.Log("Everybody gattered around ChatGBT then it started telling a story and it went like:");
            LogEvents.Log(File.ReadAllText(Environment.CurrentDirectory + "peoplevillestory.txt"));
        }
    }
}