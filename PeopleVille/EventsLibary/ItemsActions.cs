using Enums;
using Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villager;

namespace ItemsLibary
{
    public class ItemsActions
    {
        public int Days { get; set; }
        public Items ItemInUse { get; set; }
        public ItemEnums ItemType { get; set; }
        public List<IVillager> ListOfVillagers { get; set; } = new();

        public ItemsActions(int day, List<IVillager> villagers)
        {
            Days = day;
            ListOfVillagers = villagers;
        }

        public void KillThatCat()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} kills a stray cat.", Days);
        }

        public void MurderVillager()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            Random random = new();
            int numberOfVillagerBeforeMurder = ListOfVillagers.Count;
            int numberOfVillagerToBeMurdered = random.Next(1, 5);
            List<IVillager> ListWithoutDeadPeople = ListOfVillagers.ToList();
            List<string> DeadPeople = new();
            for (int i = random.Next(0, numberOfVillagerBeforeMurder - numberOfVillagerToBeMurdered); i < numberOfVillagerToBeMurdered; i++)
            {
                ListWithoutDeadPeople.Remove(ListOfVillagers[i]);
                DeadPeople.Add(ListOfVillagers[i].Name);
            }
            ListWithoutDeadPeople.Remove(villager);
            ListOfVillagers = ListWithoutDeadPeople.ToList();
            foreach (var person in DeadPeople)
            {
                LogEvents.Log($"{villager.Name} killed {person}.", Days);
            }
            LogEvents.Log($"{villager.Name} commited suicide after killing all those people. \n{numberOfVillagerBeforeMurder - numberOfVillagerToBeMurdered} survived. \nEverybody who survived griefed and morned over their fellow villagers.", Days);
        }

        public void CutThingsWithKnife()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} starts cutting a piece of wood with a knife.", Days);
        }

        public void SeeWhatTimeItIs()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} check's their watch to see what time it is.");
        }

        public void PlayWithHat()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} play's with a hat.", Days);
        }

        public void WearHat()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} put's a hat on, and is looking very good.", Days);
        }

        public void WearGlasses()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} put's a pair of glasses on. Now the villager can see again.", Days);
        }

        public void FarmWithPitchfork()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} is using the pitchfork for farming purposes only.", Days);
        }

        public void ReadBook()
        {
            IVillager villager = ListOfVillagers.First(x => x.ID == ItemInUse.ParentID);
            LogEvents.Log($"{villager.Name} finds a book and starts reading it.", Days);
        }

        public Action GetAction(ItemEnums type)
        {
            Action action = KillThatCat;
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
                    ItemInUse = item;
                    item.UseAction = GetAction(item.TypeOfItem);
                    villager.Inventory[count] = item;
                    count++;
                }
            }
        }
    }
}
