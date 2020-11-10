using System;
using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class UserTitleRate
    {
        [Key]
        public int UserId { get; set; }
        public int TitleIndividRating { get; set; }
        public string Tconst { get; set; }
        public DateTime UserTitleRateDate { get; set; }
        
        public override string ToString()
        {
            return $"UserId = {UserId}, TitleIndividRating= {TitleIndividRating},Tconst= {Tconst}, UserTitleRateDate= {UserTitleRateDate} ";
        }
    }
}