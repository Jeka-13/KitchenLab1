using System;
using System.Runtime.Serialization;
using Kitchen.Helpers.Enums;

namespace Kitchen.Models
{
    public class CookingApparatus
    {
        public long Id;
        public CookingApparatusType Type;
        public bool Busy;

        private static ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        public CookingApparatus()
        {
            Id = idGenerator.GetId(this, out bool firstTime);
            Busy = false;
        }

    }
    
}