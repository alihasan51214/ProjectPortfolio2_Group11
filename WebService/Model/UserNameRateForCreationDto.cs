using System;
using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class UserNameRateForCreationOrUpdateDTO
    { 
      
        public int NameIndividRating { get; set; }
        public string Nconst { get; set; }
        public DateTime DateTime { get; set; }
    
    }
}