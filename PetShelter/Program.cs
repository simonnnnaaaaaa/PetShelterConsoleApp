using PetShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShelter.Interfaces;
using PetShelter.Models;

namespace PetShelter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            int nextId = 1;
            bool running = true;

            while(running)
            {
                Console.Clear();
                Console.WriteLine("1) Add Dog");
                Console.WriteLine("2) Add Cat");
                Console.WriteLine("3) Add Bird");
                Console.WriteLine("4) Exit");

                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine(choice);

                switch (choice) 
                {
                    case "1" :
                        Console.WriteLine("adding dog...");
                        break;
                    case "2":
                        Console.WriteLine("adding cat...");
                        break;
                    case "3":
                        Console.WriteLine("adding bird...");
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadLine();

            }
        }
    }
}
