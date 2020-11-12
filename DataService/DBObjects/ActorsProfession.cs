using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class ActorsProfession
    {
       
        public string Nconst { get; set; }
        public string PrimaryProfession { get; set; }
        
        public override string ToString()
        {
            return $"Nconst = {Nconst}, PrimaryProfession = {PrimaryProfession}";
        }
    }
}