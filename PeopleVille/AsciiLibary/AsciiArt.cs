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

            result.Add(AsciiEnums.StartUp,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.StartUp));
            result.Add(AsciiEnums.TheEnd,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.TheEnd));
            result.Add(AsciiEnums.Festival,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.Festival));
            result.Add(AsciiEnums.Murder,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.Murder));
            result.Add(AsciiEnums.KillThatCat,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.KillThatCat));
            result.Add(AsciiEnums.RickRoll,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.RickRoll));
            result.Add(AsciiEnums.SportTournament,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.SportTournament));
            result.Add(AsciiEnums.NaturalDiesater,GetSpecifeAsciiArtFromFile(unFilteredArt, AsciiEnums.NaturalDiesater));

            return result;
        }

        public List<string> GetSpecifeAsciiArtFromFile(List<string> art, AsciiEnums type)
        {
            List<string> result = new();
            int startIndex = 0;
            switch (type)
            {
                case AsciiEnums.StartUp:
                    startIndex = art.IndexOf(AsciiEnums.StartUp.ToString().ToLower());
                    break;
                case AsciiEnums.TheEnd:
                    startIndex = art.IndexOf(AsciiEnums.TheEnd.ToString().ToLower());
                    break;
                case AsciiEnums.Murder:
                    startIndex = art.IndexOf(AsciiEnums.Murder.ToString().ToLower());
                    break;
                case AsciiEnums.KillThatCat:
                    startIndex = art.IndexOf(AsciiEnums.KillThatCat.ToString().ToLower());
                    break;
                case AsciiEnums.SportTournament:
                    startIndex = art.IndexOf(AsciiEnums.SportTournament.ToString().ToLower());
                    break;
                case AsciiEnums.Festival:
                    startIndex = art.IndexOf(AsciiEnums.Festival.ToString().ToLower());
                    break;
                case AsciiEnums.NaturalDiesater:
                    startIndex = art.IndexOf(AsciiEnums.NaturalDiesater.ToString().ToLower());
                    break;
                case AsciiEnums.RickRoll:
                    startIndex = art.IndexOf(AsciiEnums.RickRoll.ToString().ToLower());
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