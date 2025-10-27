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
                            Console.WriteLine("Enter dog name: ");
                            string name = Console.ReadLine();
                            while (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Name can't be empty! Try again:");
                                name = Console.ReadLine();
                            }

                            Console.Write("Enter Dog age: ");
                            int age;
                            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                            {
                                Console.Write("Invalid age. Enter a non-negative number: ");
                            }

                            Console.Write("Is the Dog trained? (y/n): ");
                            bool isTrained = Console.ReadLine()?.Trim().ToLower() == "y";

                            animals.Add(new Dog
                            {
                                Id = nextId++,
                                Name = name,
                                Age = age,
                                IsTrained = isTrained
                            });

                            Console.WriteLine($"Dog {name} added successfully!");

                            break;
                        }

                    case "2":
                        {
                            Console.Write("Enter Cat name: ");
                            string name = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.Write("Name cannot be empty. Enter Cat name again: ");
                                name = Console.ReadLine();
                            }

                            Console.Write("Enter Cat age: ");
                            int age;
                            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                            {
                                Console.Write("Invalid age. Enter a non-negative integer: ");
                            }

                            Console.Write("Is the Cat indoor? (y/n): ");
                            bool isIndoor = Console.ReadLine()?.Trim().ToLower() == "y";

                            animals.Add(new Cat
                            {
                                Id = nextId++,
                                Name = name,
                                Age = age,
                                IsIndoor = isIndoor
                            });

                            Console.WriteLine($"Cat {name} added successfully!");
                            break;
                        }
                    case "3":

                        {
                            Console.Write("Enter Bird name: ");
                            string name = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.Write("Name cannot be empty. Enter Bird name again: ");
                                name = Console.ReadLine();
                            }

                            Console.Write("Enter Bird age: ");
                            int age;
                            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                            {
                                Console.Write("Invalid age. Enter a non-negative integer: ");
                            }

                            Console.Write("Enter Bird wingspan (cm): ");
                            double wingSpan;
                            while (!double.TryParse(Console.ReadLine(), out wingSpan) || wingSpan <= 0)
                            {
                                Console.Write("Invalid wingspan. Enter a positive number: ");
                            }

                            animals.Add(new Bird
                            {
                                Id = nextId++,
                                Name = name,
                                Age = age,
                                WingSpanCm = wingSpan
                            });

                            Console.WriteLine($"Bird {name} added successfully!");
                            break;
                        }

                    case "4":
                        {
                            if (animals.Count == 0)
                            {
                                Console.WriteLine("No animals in the shelter yet.");
                            }
                            else
                            {

                                Console.WriteLine("Id | Type | Name | Age | Extra | Daily Cost");
                                Console.WriteLine("---------------------------------------------");

                                foreach (var animal in animals)
                                {
                                    string type = animal.GetType().Name;
                                    string extra = "";

                                    switch (animal)
                                    {
                                        case Dog d:
                                            extra = d.IsTrained ? "Trained" : "Untrained";
                                            break;
                                        case Cat c:
                                            extra = c.IsIndoor ? "Indoor" : "Outdoor";
                                            break;
                                        case Bird b:
                                            extra = $"Wingspan: {b.WingSpanCm} cm";
                                            break;
                                    }

                                    Console.WriteLine($"{animal.Id,2} | {type,-5} | {animal.Name,-10} | {animal.Age,3} | {extra,-15} | {animal.DailyCareCost(),6:0.00}");

                                }


                            }
                            break;
                        }

                    case "5":
                        {
                            if (animals.Count == 0)
                            {
                                Console.WriteLine("No animals to feed.");
                                break;
                            }

                            int fedCount = 0;

                            foreach (var animal in animals)
                            {
                                if (animal is IFeedable feedable)
                                {
                                    feedable.Feed();
                                    fedCount++;
                                }
                            }

                            Console.WriteLine($"\nAll animals have been fed ({fedCount} total).");

                            break;
                        }

                    case "6":
                        {
                            if (animals.Count == 0)
                            {
                                Console.WriteLine("No animals to speak.");
                                break;
                            }

                            foreach (var animal in animals)
                            {
                                animal.Speak();
                            }

                            break;
                        }

                    case "7":
                        {
                            if(animals.Count == 0)
                            {
                                Console.WriteLine("No animals available for adoption");
                            }
                            else
                            {
                                Console.WriteLine("Current animals (Id | Type | Name):");
                                foreach (var a in animals)
                                    Console.WriteLine($"{a.Id} | {a.GetType().Name} | {a.Name}");
                                Console.WriteLine();

                                int id;
                                Console.Write("Enter the Id to adopt: ");
                                while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
                                {
                                    Console.Write("Invalid Id. Enter a positive integer: ");
                                }

                                var toAdopt = animals.FirstOrDefault(a => a.Id == id);
                               
                                if(toAdopt == null)
                                {
                                    Console.WriteLine("Animal not found");
                                }
                                else
                                {
                                    animals.Remove(toAdopt);
                                    Console.WriteLine($"Congratulations! {toAdopt.Name} (Id {toAdopt.Id}) has been adopted!");
                                }
                            }

                            break;
                        }

                    case "8":
                        running = false;
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadLine();

            }

            foreach (var animal in animals)
            {
                animal.Speak();
            }

        }
    }
}
