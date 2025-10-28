using PetShelter.Interfaces;
using System;

namespace PetShelter.Models
{
    public class Reptile : Animal, IFeedable
    {
        public bool IsVenomous {  get; set; }

        public void Feed()
        {
            Console.WriteLine($"The reptile {Name} has been feed.");
        }

        public override void Speak()
        {
            Console.WriteLine("Hiss!");
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 5;
        }


    }
}
