using PetShelter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
