using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class BookmarkTitle
    {
        
        public string Userid { get; set; }
        public string Tconst { get; set; }

        public override string ToString()
        {
            return $"Userid = {Userid}, Tconst = {Tconst}";
        }
    }
}
