using System.Collections.Generic;

namespace Logging
{
    public static class LogEvents
    {
        public static List<string> LogOfEvent { get; set; } = new();
        public static List<KeyValuePair<int, string>> ListOfEventsAndDay { get; set; } = new();

        public static void Log(string message)
        {
            LogOfEvent.Add(message);
        }
        public static void Log(string message, int day)
        {
            LogOfEvent.Add(message);
            ListOfEventsAndDay.Add(new KeyValuePair<int, string>(day,message));
        }

        public static void ResetLogs()
        {
            LogOfEvent.Clear();
            ListOfEventsAndDay.Clear();
        }
    }
}