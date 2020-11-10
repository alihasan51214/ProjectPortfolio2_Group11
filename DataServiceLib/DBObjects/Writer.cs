using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class Writer
    {
        [Key]
        public string Tconst { get; set; }
        public string Writers { get; set; }
        
        public override string ToString()
        {
            return $"Tconst = {Tconst}, Writers= {Writers} ";
        }
    }
}