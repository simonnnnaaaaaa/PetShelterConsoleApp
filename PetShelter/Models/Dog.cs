using PetShelter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Models
{
    public class Dog : Animal, IFeedable
    {
        public bool IsTrained { get; set; }

        public void Feed()
        {
            Console.WriteLine($"The dog {Name} has been feed.");
        }

        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }

        public override decimal DailyCareCost()
        {
                return base.DailyCareCost() + 3;
        }
    }
}
