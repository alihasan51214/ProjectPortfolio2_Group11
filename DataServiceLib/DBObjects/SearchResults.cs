using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServiceLib.DBObjects
{
    public class SearchResults
    {

        //  [NotMapped]
        public string PrimaryTitle { get; set; }
         
        public string TitleType { get; set; }
      //  public string PrimaryTitle { get; set; }
     
    }
}