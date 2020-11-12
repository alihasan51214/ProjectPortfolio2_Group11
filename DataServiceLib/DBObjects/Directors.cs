﻿using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class Directors
    {
        public string Tconst { get; set; }
        public string Nconst { get; set; }
        
        public override string ToString()
        {
            return $"Tconst = {Tconst}, Nconst= {Nconst}";
        }
    }
}