using PetShelter.Interfaces;
using PetShelter.Resources;
using System;

namespace PetShelter.Models
{
    public class Bird : Animal, IFeedable, IFlyable
    {
        public double WingSpanCm { get; set; }
        public void Feed()
        {
            Console.WriteLine(string.Format(Messages.FeedBird, this.Name));
        }

        public void Fly()
        {
            Console.WriteLine(string.Format(Messages.BirdFlies, this.Name, this.WingSpanCm));
        }

        public override void Speak()
        {
            Console.WriteLine(Messages.BirdSound);
        }

        public override decimal DailyCareCost()
        {
            return base.DailyCareCost() + 1;
        }
    }
}
