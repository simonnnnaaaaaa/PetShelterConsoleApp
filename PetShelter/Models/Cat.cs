using PetShelter.Interfaces;
using System;

namespace PetShelter.Models
{
    public class Cat : Animal, IFeedable
    {
        public bool IsIndoor { get; set; }

        public void Feed()
        {
            Console.WriteLine($"The cat {Name} has been feed.");
        }

        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 2;
        }
    }
}
