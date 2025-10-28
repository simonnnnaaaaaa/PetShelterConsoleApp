using PetShelter.Interfaces;
using PetShelter.Resources;
using System;

namespace PetShelter.Models
{
    public class Dog : Animal, IFeedable
    {
        public bool IsTrained { get; set; }

        public void Feed()
        {
            Console.WriteLine(string.Format(Messages.FeedDog, this.Name));
        }

        public override void Speak()
        {
            Console.WriteLine(Messages.DogSound);
        }

        public override decimal DailyCareCost()
        {
                return base.DailyCareCost() + 3;
        }
    }
}
