using System;

namespace PetShelter.Models
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime IntakeDate { get; set; }

        public Animal()
        {
            IntakeDate = DateTime.Now;
        }

        public abstract void Speak();

        public virtual decimal DailyCareCost() => 5m; 

    }
}
