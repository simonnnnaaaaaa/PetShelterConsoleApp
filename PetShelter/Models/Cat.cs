using PetShelter.Interfaces;
using PetShelter.Resources;
using System;

namespace PetShelter.Models
{
    public class Cat : Animal, IFeedable
    {
        public bool IsIndoor { get; set; }

        public void Feed()
        {
            Console.WriteLine(string.Format(Messages.FeedCat, this.Name));
        }

        public override void Speak()
        {
            Console.WriteLine(Messages.CatSound);
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 2;
        }
    }
}
