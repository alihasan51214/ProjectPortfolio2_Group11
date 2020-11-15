using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectPortfolio2_Group11.Model { 
    public class RatingTableDTO
    { 
        public string PrimaryTitle { get; set; }
         
        public string Tconst { get; set; }
  
        public int AvarageRating { get; set; }
        public int NumVotes { get; set; } 
    }
}