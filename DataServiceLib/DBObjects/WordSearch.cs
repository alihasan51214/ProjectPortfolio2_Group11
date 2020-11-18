﻿using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class WordSearch
    {
        public string TConst { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }
        public string Lexeme { get; set; }
    }
}