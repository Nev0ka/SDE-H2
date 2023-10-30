using System.Collections.Generic;

namespace Logging
{
    public class LogEvents
    {
        public static List<string> LogOfEvent { get; set; } = new();

        public void Log(string message)
        {
            LogOfEvent.Add(message);
        }
    }
}