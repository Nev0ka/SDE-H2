namespace PeopleVille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartupFunction();
            //Next function
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