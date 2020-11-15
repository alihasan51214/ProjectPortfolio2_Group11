using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServiceLib.DBObjects
{
    public class RatingTable
    { 
        public string PrimaryTitle { get; set; }
         
        public string Tconst { get; set; }
  
        public int AvarageRating { get; set; }
        public int NumVotes { get; set; } 
    }
}