using ItemsLibary;
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
            int numberOfVillagerBefore = ListOfVillagers.Count;
            int NumberOfVillagerToDied = random.Next(1,ListOfVillagers.Count+1);
            List<IVillager> ListToWithoutDeadPeople = ListOfVillagers.ToList();
            for (int i = 0;i < NumberOfVillagerToDied;i++)
            {
                ListToWithoutDeadPeople.Remove(ListOfVillagers[i]);
            }
            ListOfVillagers = ListToWithoutDeadPeople.ToList();
            LogEvents.Log($"{NumberOfVillagerToDied} Died in a naturel diesater. {numberOfVillagerBefore - NumberOfVillagerToDied} survived. \nEverybody who survived griefed and morned over their fellow villagers.", NumberOfDays);
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
            Random random = new();
            int numberForStory = random.Next(0,3);
            string path = string.Empty;
            switch (numberForStory)
            {
                case 0:
                    {
                        path = Environment.CurrentDirectory + "/peoplevillestory.txt";
                        break;
                    }
                case 1:
                    {
                        path = Environment.CurrentDirectory + "/horrorstory.txt";
                        break;
                    }
                case 2:
                    {
                        path = Environment.CurrentDirectory + "/scifistory.txt";
                        break;
                    }
                default:
                    path = Environment.CurrentDirectory + "/peoplevillestory.txt";
                    break;
            }
            LogEvents.Log("Everybody gattered around ChatGBT then it started telling a story and it went like:\n" + File.ReadAllText(path), NumberOfDays);
        }

        private void NormaleWorkDayEvent()
        {
            LogEvents.Log("Everbody went to work and enjoyed a normal day of work.", NumberOfDays);
        }

        public Action GetRandomAction()
        {
            Random rand = new();
            int numberForEvent = rand.Next(0,106);
            if (numberForEvent >= 0)
            {
                if (numberForEvent >= 51)
                {
                    if (numberForEvent >= 63)
                    {
                        if (numberForEvent >= 75)
                        {
                            if (numberForEvent >= 95)
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

        public void Trade(IVillager villager1,IVillager villager2)
        {
            if (villager1.Inventory.Count == 0)
            {
                return;
            }
            if (villager2.Inventory.Count == 0)
            {
                return;
            }
            if (villager1.Location - villager2.Location >= 200)
            {
                villager1.Location -= 200;
                villager2.Location -= 200;
                return;
            }
            else
            {
                villager2.Location = villager1.Location;
            }

            Random rnd = new();
            int slotForVillager1 = rnd.Next(0,villager1.Inventory.Count);
            int slotForVillager2 = rnd.Next(0,villager2.Inventory.Count);
            Items itemFromVillager1 = villager1.Inventory[slotForVillager1];
            Items itemFromVillager2 = villager2.Inventory[slotForVillager2];
            villager1.Inventory.Remove(itemFromVillager1);
            villager2.Inventory.Remove(itemFromVillager2);
            villager1.Inventory.Add(itemFromVillager2);
            villager2.Inventory.Add(itemFromVillager1);
            LogEvents.Log($"{villager1.Name} and {villager2.Name} found eachother.");
            LogEvents.Log($"{villager1.Name} just traded {itemFromVillager1.ToString()} with {villager2.Name} for {itemFromVillager2.ToString()}",NumberOfDays);
        }
    }
}