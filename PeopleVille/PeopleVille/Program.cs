using Logging;
using Simulation;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml;
using Village;

namespace PeopleVille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartupFunction();
            Simulation.Simulation sim = new();
            Village.Village village = new();
            sim.StartUpSim(village);
            int day = 0;
            while (true)
            {
                //foreach (var item in LogEvents.LogOfEvent)
                //{
                //    Console.WriteLine(item);
                //    Console.WriteLine("\n");
                //}

                Console.WriteLine($"Day {day}\n");
                foreach (var item in LogEvents.ListOfEventsAndDay)
                {
                    if (item.Key == day)
                    {
                        Console.WriteLine(item.Value + "\n");
                    }
                }
                day++;
                Console.WriteLine("Press any button to run a event. \nPress escape to stop");
                var tabKey = Console.ReadKey();
                Console.Clear();
                if (tabKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                sim.RunEvents(village,day);
                if (sim.AllVillagersIsDead)
                {
                    Console.WriteLine($"Day {day}\n");
                    Console.WriteLine("All the villager died.");
                    Thread.Sleep(12500);
                    break;
                }
            }
        }
        
        public static void StartupFunction()
        {
            Console.WriteLine("                                                 _");
            Console.WriteLine(" __                   ___                       ( )");
            Console.WriteLine("|\"\"|  ___    _   __  |\"\"\"|  __                   `");
            Console.WriteLine("|\"\"| |\"\"\"|  |\"| |\"\"| |\"\"\"| |\"\"|        _._ _");
            Console.WriteLine("|\"\"| |\"\"\"|  |\"| |\"\"| |\"\"\"| |\"\"|       (__((_(");
            Console.WriteLine("|\"\"| |\"\"\"|  |\"| |\"\"| |\"\"\"| |\"\"|      \\'-:--:-.");
            Console.WriteLine("\"'''\"''\"'\"\"'\"\"\"''\"''''\"\"\"'\"\"'\"\"'~~~~~~'-----'~~~~  ");
            Console.WriteLine("       Press any button to start");
            Console.ReadKey();
            Console.Clear();
        }
    }
}