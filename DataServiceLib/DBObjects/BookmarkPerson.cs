using System;
using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class BookmarkPerson
    {
        //public int BookMarkid { get; set; }
        public string Nconst { get; set; }
        public int Userid { get; set; }
        
        public override string ToString()
        {
            return $"Nconst = {Nconst}, Userid = {Userid}";
        }
    }
}
