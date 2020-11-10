using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class TitleAkas
    {
        [Key]
        public string TitleID { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public string IsOriginalTitle { get; set; }
        
        public override string ToString()
        {
            return $"TitleID = {TitleID}, Ordering = {Ordering}, Title ={ Title}, Region = {Region}, Language = {Language},Types = {Types}, Attributes = {Attributes}, IsOriginalTitle = {IsOriginalTitle} ";
        }
    }
}