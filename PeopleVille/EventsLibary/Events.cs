using AsciiLibary;
using Enums;
using ItemsLibary;
using Locations;
using Logging;
using Villager;

namespace EventsLibary
{
    public class Events
    {
        public List<IVillager> ListOfVillagers { get; set; } = new();
        public int NumberOfDays { get; set; }
        public AsciiArt AsciiArt { get; set; }
        public Events(List<IVillager> villagers, int day)
        {
            ListOfVillagers = villagers;
            NumberOfDays = day;
            AsciiArt = new();
        }

        private void NaturelDiesaterEvent()
        {
            Random random = new();
            int numberOfVillagerBefore = ListOfVillagers.Count;
            int numberOfVillagerToDied = random.Next(1, ListOfVillagers.Count + 1);
            List<IVillager> listToWithoutDeadPeople = ListOfVillagers.ToList();
            for (int i = 0; i < numberOfVillagerToDied; i++)
            {
                listToWithoutDeadPeople.Remove(ListOfVillagers[i]);
            }
            ListOfVillagers = listToWithoutDeadPeople.ToList();
            if (ListOfVillagers.Count != 0)
            {
                LogEvents.Log($"{numberOfVillagerToDied} Died in a naturel diesater. {numberOfVillagerBefore - numberOfVillagerToDied} survived. \nEverybody who survived griefed and morned over their fellow villagers.\n", NumberOfDays);
            }
            else
            {
                LogEvents.Log($"{numberOfVillagerToDied} Died in a naturel diesater. Everybody died. \n", NumberOfDays);
            }
            LogEvents.Log(AsciiArt.ListOfAsciiArt[AsciiEnums.NaturalDiesater], NumberOfDays);
        }

        private void HyggeWasteTimeEvent()
        {
            LogEvents.Log($"{GetVillagePopulationAsString()} hygged the hele day \n", NumberOfDays);
        }

        private void FestivalEvent()
        {
            LogEvents.Log($"{GetVillagePopulationAsString()} enjoyed a nice festival with some great artist and good music \n", NumberOfDays);
            LogEvents.Log(AsciiArt.ListOfAsciiArt[AsciiEnums.Festival], NumberOfDays);
        }

        private void LocalSportTournamentEvent()
        {
            LogEvents.Log($"{GetVillagePopulationAsString()} enjoyed a good old football tournamant \n", NumberOfDays);
            LogEvents.Log(AsciiArt.ListOfAsciiArt[AsciiEnums.SportTournament], NumberOfDays);
        }

        private void StoryTellingEvent()
        {
            Random random = new();
            int numberForStory = random.Next(0, 3);
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
            LogEvents.Log($"{GetVillagePopulationAsString()} gattered around ChatGBT then it started telling a story and it went like:\n" + File.ReadAllText(path) + "\n", NumberOfDays);
        }

        private void NormaleWorkDayEvent()
        {
            LogEvents.Log($"{GetVillagePopulationAsString()} went to work and enjoyed a normal day of work.\n", NumberOfDays);
        }

        public void KillThatCat()
        {
            Random random = new();
            LogEvents.Log($"{ListOfVillagers[random.Next(0, ListOfVillagers.Count)].Name} killed a stray cat.\n", NumberOfDays);
            LogEvents.Log(AsciiArt.ListOfAsciiArt[AsciiEnums.KillThatCat], NumberOfDays);
        }

        public void RickRoll()
        {
            if (ListOfVillagers.Count == 1)
            {
                return;
            }
            Random rnd = new();
            int Villager1Index = rnd.Next(0, ListOfVillagers.Count);
            int Villager2Index = rnd.Next(0, ListOfVillagers.Count);
            IVillager villager1 = ListOfVillagers[Villager1Index];
            IVillager villager2 = ListOfVillagers[Villager2Index];
            ListOfVillagers.Remove(villager1);
            LogEvents.Log($"{villager1.Name} rick rolled {villager2.Name}", NumberOfDays);
            LogEvents.Log($"So {villager2.Name} Killed {villager1.Name} because of it.", NumberOfDays);
            LogEvents.Log(AsciiArt.ListOfAsciiArt[AsciiEnums.RickRoll], NumberOfDays);
        }

        public Action GetRandomAction()
        {
            Random rand = new();
            int numberForEvent = rand.Next(0, 100);
            if (numberForEvent >= (int)EventsEnums.NaturelDiesater)
            {
                return NaturelDiesaterEvent;
            }
            if (numberForEvent >= (int)EventsEnums.RickRoll)
            {
                return RickRoll;
            }
            if (numberForEvent >= (int)EventsEnums.KillThatCat)
            {
                return KillThatCat;
            }
            if (numberForEvent >= (int)EventsEnums.StoryTelling)
            {
                return StoryTellingEvent;
            }
            if (numberForEvent >= (int)EventsEnums.SportTournament)
            {
                return LocalSportTournamentEvent;
            }
            if (numberForEvent >= (int)EventsEnums.Festival)
            {
                return FestivalEvent;
            }
            if (numberForEvent >= (int)EventsEnums.Hygge)
            {
                return HyggeWasteTimeEvent;
            }
            if (numberForEvent >= (int)EventsEnums.NormalWorkDay)
            {
                return NormaleWorkDayEvent;
            }
            return NormaleWorkDayEvent;
        }

        public void Trade(IVillager villager1, IVillager villager2)
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
                if (villager2.Location > villager1.Location)
                {
                    villager2.Location -= 200;
                }
                else
                {
                    villager2.Location += 200;
                }
                return;
            }
            else
            {
                villager2.Location = villager1.Location;
            }

            Random rnd = new();
            int indexForVillager1 = rnd.Next(0, villager1.Inventory.Count);
            int indexForVillager2 = rnd.Next(0, villager2.Inventory.Count);
            Items itemFromVillager1 = villager1.Inventory[indexForVillager1];
            Items itemFromVillager2 = villager2.Inventory[indexForVillager2];
            villager1.Inventory.Remove(itemFromVillager1);
            villager2.Inventory.Remove(itemFromVillager2);
            villager1.Inventory.Add(itemFromVillager2);
            villager2.Inventory.Add(itemFromVillager1);
            LogEvents.Log($"{villager1.Name} and {villager2.Name} found eachother.");
            LogEvents.Log($"{villager1.Name} just traded {itemFromVillager1.ToString()} with {villager2.Name} for {itemFromVillager2.ToString()}\n", NumberOfDays);
        }

        public void UseStore(IVillager villager, Store store, bool Isbuying)
        {
            Random rnd = new();
            if (villager.Location - store.Location >= 200)
            {
                if (villager.Location > store.Location)
                {
                    villager.Location -= 200;
                }
                else
                {
                    villager.Location += 200;
                }
            }

            if (Isbuying)
            {
                if (villager.Wallet == 0)
                {
                    return;
                }
                if (store.StoreInventory.Count == 0)
                {
                    return;
                }
                int IndexOfItemForVillagerToBuy = rnd.Next(store.StoreInventory.Count);
                Items itemToBuy = store.StoreInventory[IndexOfItemForVillagerToBuy];
                store.SellItem(itemToBuy.ID, villager, NumberOfDays);
                return;
            }
            else
            {
                if (store.Transactions.Sum() == 0)
                {
                    return;
                }
                if (villager.Inventory.Count == 0)
                {
                    return;
                }
                int IndexOfItemToSell = rnd.Next(villager.Inventory.Count);
                Items itemToSell = villager.Inventory[IndexOfItemToSell];
                store.BuyItem(itemToSell.ID, villager, NumberOfDays);
                return;
            }
        }

        public string GetVillagePopulationAsString()
        {
            string result;
            if (ListOfVillagers.Count == 1)
            {
                result = ListOfVillagers[0].Name;
            }
            else
            {
                result = "Everybody";
            }
            return result;
        }
    }
}