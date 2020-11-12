using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class UsersForCreationOrUpdateDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Language { get; set; }
        public string Mail { get; set; }
       
    }
}