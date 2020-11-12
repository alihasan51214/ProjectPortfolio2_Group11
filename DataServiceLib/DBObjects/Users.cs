using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Language { get; set; }
        public string Mail { get; set; }
        
        public override string ToString()
        {
            return $"UserId = {UserId}, Name= {Name},Age= {Age}, Language= {Language}, Mail= {Mail} ";
        }
    }
}