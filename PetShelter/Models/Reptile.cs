using PetShelter.Interfaces;
using PetShelter.Resources;
using System;

namespace PetShelter.Models
{
    public class Reptile : Animal, IFeedable
    {
        public bool IsVenomous {  get; set; }

        public void Feed()
        {
            Console.WriteLine(string.Format(Messages.FeedReptile, this.Name));
        }

        public override void Speak()
        {
            Console.WriteLine(Messages.ReptileSound);
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 5;
        }


    }
}
