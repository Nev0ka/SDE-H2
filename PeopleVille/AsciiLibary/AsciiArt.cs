using Enums;
using System.Collections.Generic;

namespace AsciiLibary
{
    public class AsciiArt
    {
        public Dictionary<AsciiEnums, List<string>> ListOfAsciiArt { get; set; }
        public AsciiArt()
        {
            ListOfAsciiArt = GetAsciiArt();
        }

        public Dictionary<AsciiEnums, List<string>> GetAsciiArt()
        {
            Dictionary < AsciiEnums, List<string>> result = new();
            List<string> unFilteredArt = File.ReadAllLines(Environment.CurrentDirectory + "/AsciiArtwork.txt").ToList();

            result.Add(AsciiEnums.startup,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.startup));
            result.Add(AsciiEnums.theend,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.theend));
            result.Add(AsciiEnums.festival,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.festival));
            result.Add(AsciiEnums.murder,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.murder));
            result.Add(AsciiEnums.killthatcat,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.killthatcat));
            result.Add(AsciiEnums.rickroll,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.rickroll));
            result.Add(AsciiEnums.sporttournament,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.sporttournament));
            result.Add(AsciiEnums.naturaldiesater,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.naturaldiesater));

            return result;
        }

        public List<string> GetSpecifeAsciiArtFromFile(List<string> art, AsciiEnums type)
        {
            List<string> result = new();
            int startIndex = 0;
            switch (type)
            {
                case AsciiEnums.startup:
                    startIndex = art.IndexOf(AsciiEnums.startup.ToString());
                    break;
                case AsciiEnums.theend:
                    startIndex = art.IndexOf(AsciiEnums.theend.ToString());
                    break;
                case AsciiEnums.murder:
                    startIndex = art.IndexOf(AsciiEnums.murder.ToString());
                    break;
                case AsciiEnums.killthatcat:
                    startIndex = art.IndexOf(AsciiEnums.killthatcat.ToString());
                    break;
                case AsciiEnums.sporttournament:
                    startIndex = art.IndexOf(AsciiEnums.sporttournament.ToString());
                    break;
                case AsciiEnums.festival:
                    startIndex = art.IndexOf(AsciiEnums.festival.ToString());
                    break;
                case AsciiEnums.naturaldiesater:
                    startIndex = art.IndexOf(AsciiEnums.naturaldiesater.ToString());
                    break;
                case AsciiEnums.rickroll:
                    startIndex = art.IndexOf(AsciiEnums.rickroll.ToString());
                    break;
            }

            for (int i = startIndex; i < art.Count-1; i++)
            {
                if (art[i] == "end")
                {
                    break;
                }
                result.Add(art[i]);
            }
            return result;
        }
    }
}