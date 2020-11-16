using System;
using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class TitleNameRate
    {
        public int UserId { get; set; }
        public int NameIndividRating { get; set; }
        public string NConst { get; set; }
        public DateTime DateTime { get; set; }
    }
}