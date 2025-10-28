using PetShelter.Interfaces;
using System;

namespace PetShelter.Models
{
    public class Bird : Animal, IFeedable, IFlyable
    {
        public double WingSpanCm { get; set; }
        public void Feed()
        {
            Console.WriteLine($"The bird {Name} has been feed.");
        }

        public void Fly()
        {
            Console.WriteLine($"The bird {Name} flies with a wingspan of {WingSpanCm} cm.");
        }

        public override void Speak()
        {
            Console.WriteLine("Chirp!");
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 1;
        }
    }
}
