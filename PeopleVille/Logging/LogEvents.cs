using System.Collections.Generic;

namespace Logging
{
    public static class LogEvents
    {
        public static List<string> LogOfEvent { get; set; } = new();
        public static List<KeyValuePair<string, int>> ListOfEventsAndDay { get; set; } = new();

        public static void Log(string message)
        {
            LogOfEvent.Add(message);
        }
        public static void Log(string message, int day)
        {
            LogOfEvent.Add(message);
            ListOfEventsAndDay.Add(new KeyValuePair<string, int>(message,day));
        }
    }
}