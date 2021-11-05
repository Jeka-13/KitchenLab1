using Kitchen.Helpers.Enums;

namespace Kitchen.Models
{
    public class Food
    {
        public long Id;
        public string Name;
        public int PreparitionTime;
        public int Comlexity;
        public CookingApparatusType? CookingApparatus;
    }
}