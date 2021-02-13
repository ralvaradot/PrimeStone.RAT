using System;

namespace PrimeStone.RAT.Entities
{
    public abstract class ClassBase
    {
        public DateTime CreateAt { get; set; }
        public string UserCreated { get; set; }
        public DateTime? UpadtedAt { get; set; }
        public string UserLastUpdated { get; set; }
    }
}
