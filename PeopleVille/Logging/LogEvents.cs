using System.Collections.Generic;

namespace Logging
{
    public static class LogEvents
    {
        public static List<string> LogOfEvent { get; set; } = new();

        public static void Log(string message)
        {
            LogOfEvent.Add(message);
        }
    }
}