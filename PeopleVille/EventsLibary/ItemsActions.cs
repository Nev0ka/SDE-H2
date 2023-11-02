﻿using Enums;
using Locations;
using Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villager;
using static System.Formats.Asn1.AsnWriter;

namespace ItemsLibary
{
    public class ItemsActions
    {
        public int Days { get; set; }
        public  IVillager villager { get; set; }
        public List<IVillager> ListOfVillagers { get; set; } = new();
        public List<ILocation> ListOfLocations { get; set; } = new();

        public ItemsActions(int day, Village.Village village)
        {
            Days = day;
            ListOfVillagers = village.Villagers;
            ListOfLocations = village.LocationsInVillage;
        }

        public void Nothing()
        {
            LogEvents.Log("failed",Days);
        }

        public void MurderVillager()
        {
            Random random = new();
            int numberOfVillagerBeforeMurder = ListOfVillagers.Count;
            int numberOfVillagerToBeMurdered = random.Next(1, 5);
            List<IVillager> ListWithoutDeadPeople = ListOfVillagers.ToList();
            List<string> DeadPeople = new();
            if (numberOfVillagerBeforeMurder <= numberOfVillagerToBeMurdered)
            {
                DeadPeople = ListWithoutDeadPeople.Select(x => x.Name).ToList();
                ListWithoutDeadPeople.Clear();
            }
            else
            {
                int startIndex = random.Next(0, numberOfVillagerBeforeMurder - numberOfVillagerToBeMurdered);
                for (int i = startIndex; i < startIndex + numberOfVillagerToBeMurdered; i++)
                {
                    ListWithoutDeadPeople.Remove(ListOfVillagers[i]);
                    DeadPeople.Add(ListOfVillagers[i].Name);
                }
                ListWithoutDeadPeople.Remove(villager);
                ListOfVillagers = ListWithoutDeadPeople.ToList();
            }
            foreach (var person in DeadPeople)
            {
                LogEvents.Log($"{villager.Name} killed {person}.\n", Days);
            }
            LogEvents.Log($"{villager.Name} committed suicide after killing all those people. \n{numberOfVillagerBeforeMurder - numberOfVillagerToBeMurdered - 1} survived. \nEverybody who survived griefed and morned over their fellow villagers.\n", Days);
        }

        public void CutThingsWithKnife()
        {
            LogEvents.Log($"{villager.Name} started cutting a piece of wood with a knife.\n", Days);
        }

        public void SeeWhatTimeItIs()
        {
            LogEvents.Log($"{villager.Name} checked their watch to see what time it is.\n");
        }

        public void PlayWithHat()
        {
            LogEvents.Log($"{villager.Name} played with a hat.\n", Days);
        }

        public void WearHat()
        {
            LogEvents.Log($"{villager.Name} put a hat on, and is looking very good.\n", Days);
        }

        public void WearGlasses()
        {
            LogEvents.Log($"{villager.Name} put a pair of glasses on. Now the {villager.Name} can see again.\n", Days);
        }

        public void FarmWithPitchfork()
        {
            LogEvents.Log($"{villager.Name} used the pitchfork for farming purposes only.\n", Days);
        }

        public void ReadBook()
        {
            LogEvents.Log($"{villager.Name} found a book and starts reading it.\n", Days);
        }

        public Action GetAction(ItemEnums type)
        {
            Action action = Nothing;
            Random rand = new();
            int numberForHowToUseKnife = rand.Next(0, 100);
            int numberForWhatToDoWithHat = rand.Next(0, 10);
            switch (type)
            {
                case ItemEnums.Knife:
                    if (numberForHowToUseKnife >= 0)
                    {
                        if (numberForHowToUseKnife >= 90)
                        {
                            action = MurderVillager;
                            break;
                        }
                        action = CutThingsWithKnife;
                    }
                    break;
                case ItemEnums.Hat:
                    if (numberForWhatToDoWithHat >= 0)
                    {
                        if (numberForWhatToDoWithHat >= 6)
                        {
                            action = PlayWithHat;
                            break;
                        }
                        action = WearHat;
                    }
                    break;
                case ItemEnums.Watch:
                    action = SeeWhatTimeItIs;
                    break;
                case ItemEnums.Glasses:
                    action = WearGlasses;
                    break;
                case ItemEnums.Pitchfork:
                    action = FarmWithPitchfork;
                    break;
                case ItemEnums.Book:
                    action = ReadBook;
                    break;
                default:
                    break;
            }
            return action;
        }

        public void AddActionToItems()
        {
            foreach (var villager in ListOfVillagers)
            {
                int count = 0;
                foreach (var item in villager.Inventory.ToList())
                {
                    item.UseAction = GetAction(item.TypeOfItem);
                    villager.Inventory[count] = item;
                    count++;
                }
            }

            foreach (var location in ListOfLocations.Where(x => x.Type == LocationsTypeEnums.Store))
            {
                int count = 0;
                Store store = (Store)location;
                foreach (var items in store.StoreInventory.ToList())
                {
                    items.UseAction = GetAction(items.TypeOfItem);
                    store.StoreInventory[count] = items;
                    count++;
                }
            }
        }
    }
}