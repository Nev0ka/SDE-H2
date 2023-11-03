using AsciiLibary;
using Enums;
using Logging;

namespace PeopleVille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            StartupFunction();
            Simulation.Simulation sim = new();
            Village.Village village = new();
            LogEvents.ResetLogs();
            sim.StartUpSim(village);
            int day = 0;
            while (true)
            {
                Console.WriteLine($"Day: {day} villagers: {village.Villagers.Count}\n");
                foreach (var item in LogEvents.ListOfEventsAndDay)
                {
                    if (item.Key == day)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
                if (sim.AllVillagersIsDead)
                {
                    Console.WriteLine($"Day {day}\n");
                    Console.WriteLine("All the villagers died.");
                    Thread.Sleep(2000);
                    if (!TheEndFunction())
                    {
                        Main(args);
                    }
                    break;
                }
                day++;
                Console.WriteLine("Press any button for next day. \nPress escape to stop");
                var tabKey = Console.ReadKey();
                Console.Clear();
                if (tabKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                sim.RunEvents(village, day);
            }
        }

        public static bool TheEndFunction()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            AsciiArt asciiArt = new();
            foreach (var item in asciiArt.ListOfAsciiArt[AsciiEnums.TheEnd])
            {
                Console.WriteLine(item);
            }
            Thread.Sleep(3500);
            Console.WriteLine("\n\n                                           Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("Tab \"R\" to restart");
            Console.WriteLine("Tab any other key to Stop");
            if (Console.ReadKey().Key == ConsoleKey.R)
            {
                return false;
            }
            return true;
        }
        public static void StartupFunction()
        {
            AsciiArt asciiArt = new();
            foreach (var item in asciiArt.ListOfAsciiArt[AsciiEnums.StartUp])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("       Press any button to start");
            Console.ReadKey();
            Console.Clear();
        }
    }
}