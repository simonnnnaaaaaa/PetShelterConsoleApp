using PetShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PetShelter.Interfaces;
using PetShelter.Services;

namespace PetShelter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var shelter = new ShelterService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1) Add Dog");
                Console.WriteLine("2) Add Cat");
                Console.WriteLine("3) Add Bird");
                Console.WriteLine("4) List Animals");
                Console.WriteLine("5) Feed All");
                Console.WriteLine("6) Speak All");
                Console.WriteLine("7) Adopt (by Id)");
                Console.WriteLine("8) Exit");

                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine(choice);

                switch (choice)
                {
                    case "1":
                        {
                            shelter.AddDog();
                            break;
                        }
                    case "2":
                        {
                            shelter.AddCat();
                            break;
                        }
                    case "3":
                        {
                            shelter.AddBird();
                            break;
                        }
                    case "4":
                        {
                            
                            shelter.ListAnimals();
                            break;
                        }
                    case "5":
                        {
                            shelter.FeedAll();
                            break;
                        }
                    case "6":
                        {
                            shelter.SpeakAll();
                            break;
                        }
                    case "7":
                        {
                            shelter.Adopt();
                            break;
                        }
                    case "8":
                        {
                            running = false;
                            Console.WriteLine("Goodbye");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option, try again!");
                            break;
                        }
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadLine();

            }

        }
    }
}
