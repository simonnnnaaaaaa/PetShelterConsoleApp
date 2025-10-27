using PetShelter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
