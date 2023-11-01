using Logging;
using Simulation;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using Village;

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
            sim.StartUpSim(village);
            int day = 0;
            while (true)
            {
                //foreach (var item in LogEvents.LogOfEvent)
                //{
                //    Console.WriteLine(item);
                //    Console.WriteLine("\n");
                //}

                Console.WriteLine($"Day: {day} villager: {village.Villagers.Count}\n");
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
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("  ██████████    ░░          ██      ██████████                  ██████████                ░░    ██████████░░  ");
                    Console.WriteLine("    ░░▒▒▒▒  ▒▒  ██          ██      ██████▒▒                    ████▒▒        ██░░        ██    ██        ░░  ");
                    Console.WriteLine("      ▒▒██      ██          ██      ██                          ██            ██  ▒▒      ██    ██          ██");
                    Console.WriteLine("        ▒▒      ██▓▓██████████      ██    ██                    ▒▒    ▒▒      ██    ░░    ██    ██          ██");
                    Console.WriteLine("        ██      ██▓▓██▒▒    ██      ████████▒▒                  ██████████    ██        ████    ██        ▒▒██");
                    Console.WriteLine("        ██      ██          ██      ██                          ██            ██      ░░██▒▒    ██      ░░████");
                    Console.WriteLine("        ██      ██          ██    ░░██                          ██            ██        ░░      ██    ▒▒████  ");
                    Console.WriteLine("        ██      ██          ██      ██▓▓██████                  ██████████                      ██████████    ");
                    Thread.Sleep(3500);
                    Console.WriteLine("\n\n                                           Press enter to continue");
                    Console.ReadLine();
                    Console.WriteLine("Tab \"R\" to restart");
                    Console.WriteLine("Tab any other key to Stop");
                    if (Console.ReadKey().Key == ConsoleKey.R)
                    {
                        Main(args);
                    }
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