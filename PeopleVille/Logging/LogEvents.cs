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
            ListOfEventsAndDay.Add(new KeyValuePair<int, string>(day, message));
        }
        public static void Log(List<string> message, int day)
        {
            foreach (var line in message)
            {
                LogOfEvent.Add(line);
                ListOfEventsAndDay.Add(new KeyValuePair<int, string>(day, line));
            }
        }

        public static void ResetLogs()
        {
            LogOfEvent.Clear();
            ListOfEventsAndDay.Clear();
        }
    }
}