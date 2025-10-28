using System;
using PetShelter.Resources;
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
                Console.WriteLine(Messages.Option1);
                Console.WriteLine(Messages.Option2);
                Console.WriteLine(Messages.Option3);
                Console.WriteLine(Messages.Option4);
                Console.WriteLine(Messages.Option5);
                Console.WriteLine(Messages.Option6);
                Console.WriteLine(Messages.Option7);
                Console.WriteLine(Messages.Option8);
                Console.WriteLine(Messages.Option9);
                Console.WriteLine(Messages.Option10);
                Console.WriteLine(Messages.Option11);
                Console.WriteLine(Messages.Option12);
               

                Console.Write(Messages.SelectOption);

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

                            shelter.AddReptile();
                            break;
                        }
                    case "5":
                        {
                            
                            shelter.ListAnimals();
                            break;
                        }
                    case "6":
                        {
                            shelter.FeedAll();
                            break;
                        }
                    case "7":
                        {
                            shelter.SpeakAll();
                            break;
                        }
                    case "8":
                        {
                            shelter.Adopt();
                            break;
                        }
                    case "9":
                        {
                            shelter.FlyBirds();
                            break;
                        }
                    case "10":
                        {
                            shelter.SearchOrFilter();
                            break;
                        }
                    case "11":
                        {
                            shelter.TotalDailyCost();
                            break;
                        }
                    case "12":
                        {
                            running = false;
                            Console.WriteLine(Messages.Goodbye);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(Messages.Invlaid);
                            break;
                        }
                }

                Console.WriteLine(Messages.PressEnter);
                Console.ReadLine();

            }

        }
    }
}
