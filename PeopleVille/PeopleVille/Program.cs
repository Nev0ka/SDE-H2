using Logging;
using Simulation;
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
            while (true)
            {
                foreach (var item in LogEvents.LogOfEvent)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Press any button to run a event. \nPress escape to stop");
                var key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                sim.RunEvents(village);
                Thread.Sleep(100);
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