﻿using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class NameBasics
    {
        public string Nconst { get; set; }
        public string PrimaryName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        
        public override string ToString()
        {
            return $"Nconst = {Nconst}, PrimaryName = {PrimaryName}, BirthYear ={ BirthYear}, DeathYear = {DeathYear}";
        }
    }
}