﻿using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class ActorsKnownForTitles
    {
        public string Nconst { get; set; }
        public string KnownForTitles { get; set; }
        
        public override string ToString()
        {
            return $"Nconst = {Nconst}, PrimaryProfession = {KnownForTitles}";
        }
    }
}