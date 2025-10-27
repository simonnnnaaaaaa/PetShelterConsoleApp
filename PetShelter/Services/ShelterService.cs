using PetShelter.Interfaces;
using PetShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Services
{
    public class ShelterService
    {
        private List<Animal> animals = new List<Animal>();
        private int nextId = 1;

        public void AddDog()
        {
            Console.WriteLine("Enter dog name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
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
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
            bool isTrained = answer == "y" || answer == "yes";

            animals.Add(new Dog
            {
                Id = nextId++,
                Name = name,
                Age = age,
                IsTrained = isTrained
            });

            Console.WriteLine($"Dog {name} added successfully!");

        }

        public void AddCat()
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
        }

        public void AddBird()
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

        }

        public void AddReptile()
        {
            Console.Write("Enter Reptile name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name cannot be empty. Enter Reptile name again: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter Reptile age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.Write("Invalid age. Enter a non-negative integer: ");
            }

            Console.Write("Is the Reptile Venomous? (y/n): ");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
            bool IsVenomous = answer == "y" || answer == "yes";

            animals.Add(new Reptile
            {
                Id = nextId++,
                Name = name,
                Age = age,
                IsVenomous = IsVenomous,
            });

            Console.WriteLine($"Reptile {name} added successfully!");
        }

        public void ListAnimals()
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
                            extra = $"Wingspan: {b.WingSpanCm:0.##} cm";
                            break;
                        case Reptile r:
                            extra = r.IsVenomous ? "Venomous" : "Non-Venomous";
                            break;
                    }

                    Console.WriteLine($"{animal.Id,2} | {type,-5} | {animal.Name,-10} | {animal.Age,3} | {extra,-15} | {animal.DailyCareCost(),6:0.00}");

                }


            }
        }

        public void FeedAll()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("No animals to feed.");
            }

            else
            {
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

            }

        }

        public void SpeakAll()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("No animals to speak.");
            }
            else
            {

                foreach (var animal in animals)
                {
                    animal.Speak();
                }
            }
        }

        public void Adopt()
        {
            if (animals.Count == 0)
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

                if (toAdopt == null)
                {
                    Console.WriteLine("Animal not found");
                }
                else
                {
                    animals.Remove(toAdopt);
                    Console.WriteLine($"Congratulations! the {toAdopt.GetType().Name} {toAdopt.Name} (Id {toAdopt.Id}) has been adopted!");
                }
            }
        }

        public void FlyBirds()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("There are no birds in the shelter!");
            }
            else
            {
                foreach(var animal in animals)
                {
                    if(animal is IFlyable f)
                    {
                        f.Fly();
                    }
                }
            }
        }

        public void SearchOrFilter()
        {
            Console.WriteLine("Options: ");
            Console.WriteLine("1) By Type");
            Console.WriteLine("2) By Name");

            Console.WriteLine("Choose: ");
            var choice = Console.ReadLine()?.Trim() ?? "";

            IEnumerable<Animal> results = Enumerable.Empty<Animal>();

            if (choice == "1")
            {
                string type = "";
                string[] validTypes = { "dog", "cat", "bird", "reptile" };

                do
                {
                    Console.Write("Type (Dog/Cat/Bird/Reptile): ");
                    type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                    if (!validTypes.Contains(type))
                    {
                        Console.WriteLine("Invalid type entered. Please choose one of: Dog, Cat, Bird, or Reptile.\n");
                    }

                } while (!validTypes.Contains(type));

                results = animals.Where(a => a.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));

            }
            else if (choice == "2")
            {
                Console.Write("Name contains: ");
                string term = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(term))
                {
                    Console.Write("Value cannot be empty. Name contains: ");
                    term = Console.ReadLine() ?? "";
                }
                term = term.Trim();

                results = animals.Where(a =>
                    a.Name?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var list = results.ToList();
            if (list.Count == 0)
            {
                Console.WriteLine("No matches found.");
                return;
            }

            Console.WriteLine("ID | Type     | Name       | Age | Extra            | Daily Cost");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (var animal in list)
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
                        extra = $"Wingspan: {b.WingSpanCm:0.##} cm";
                        break;
                    case Reptile r:
                        extra = r.IsVenomous ? "Venomous" : "Non-venomous";
                        break;
                }

                Console.WriteLine(
                    $"{animal.Id,2} | {type,-8} | {animal.Name,-10} | {animal.Age,3} | {extra,-15} | {animal.DailyCareCost(),9:0.00}");
            }
        }
    }
}
