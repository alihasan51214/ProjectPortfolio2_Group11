﻿using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class TitleEpisode
    {
        public string Tconst { get; set; }
        public string ParentTconst { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public override string ToString()
        {
            return $"Tconst = {Tconst}, ParentTconst = {ParentTconst}, SeasonNumber ={ SeasonNumber},EpisodeNumber ={ EpisodeNumber} ";
        }
    }
}