using PetShelter.Interfaces;
using PetShelter.Models;
using PetShelter.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PetShelter.Services
{
    public class ShelterService
    {
        private List<Animal> animals = new List<Animal>();
        private int nextId = 1;

        public void AddDog()
        {
            Console.WriteLine(Messages.EnterDogName);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(Messages.NameCantBeEmpty);
                name = Console.ReadLine();
            }

            Console.Write(Messages.EnterDogAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.Write(Messages.InvalidAge);
            }

            Console.Write(Messages.IsTrained);
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
            bool isTrained = answer == "y" || answer == "yes";

            animals.Add(new Dog
            {
                Id = nextId++,
                Name = name,
                Age = age,
                IsTrained = isTrained
            });

            Console.WriteLine(String.Format(Messages.DogAdded, name));

        }

        public void AddCat()
        {
            Console.Write(Messages.EnterCatName);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write(Messages.NameCantBeEmpty);
                name = Console.ReadLine();
            }

            Console.Write(Messages.EnterCatAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.Write(Messages.InvalidAge);
            }

            Console.Write(Messages.IsIndoor);
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
            bool isIndoor = answer == "y" || answer == "yes";

            animals.Add(new Cat
            {
                Id = nextId++,
                Name = name,
                Age = age,
                IsIndoor = isIndoor
            });

            Console.WriteLine(string.Format(Messages.CatAdded, name));
        }

        public void AddBird()
        {
            Console.Write(Messages.EnterBirdName);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write(Messages.NameCantBeEmpty);
                name = Console.ReadLine();
            }

            Console.Write(Messages.EnterBirdAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.Write(Messages.InvalidAge);
            }

            Console.Write(Messages.EnterBirdWingspan);
            double wingSpan;
            while (!double.TryParse(Console.ReadLine(), out wingSpan) || wingSpan <= 0)
            {
                Console.Write(Messages.InvalidWingspan);
            }

            animals.Add(new Bird
            {
                Id = nextId++,
                Name = name,
                Age = age,
                WingSpanCm = wingSpan
            });

            Console.WriteLine(string.Format(Messages.BirdAdded, name));

        }

        public void AddReptile()
        {
            Console.Write(Messages.EnterReptileName);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write(Messages.NameCantBeEmpty);
                name = Console.ReadLine();
            }

            Console.Write(Messages.EnterReptileAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.Write(Messages.InvalidAge);
            }

            Console.Write(Messages.IsVenomous);
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
            bool IsVenomous = answer == "y" || answer == "yes";

            animals.Add(new Reptile
            {
                Id = nextId++,
                Name = name,
                Age = age,
                IsVenomous = IsVenomous,
            });

            Console.WriteLine(string.Format(Messages.ReptileAdded, name));
        }

        public void ListAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine(Messages.NoAnimals);
            }
            else
            {

                Console.WriteLine(Messages.ListHeader);
                Console.WriteLine(Messages.ListLine);

                foreach (var animal in animals)
                {
                    string type = animal.GetType().Name;
                    string extra = "";

                    switch (animal)
                    {
                        case Dog d:
                            extra = d.IsTrained ? Messages.Trained : Messages.Untrained;
                            break;
                        case Cat c:
                            extra = c.IsIndoor ? Messages.Indoor : Messages.Outdoor;
                            break;
                        case Bird b:
                            extra = string.Format(Messages.WingspanFormat, b.WingSpanCm);
                            break;
                        case Reptile r:
                            extra = r.IsVenomous ?Messages.Venomous : Messages.Nonvenomous;
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
                Console.WriteLine(Messages.NoAnimals);
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

                Console.WriteLine(string.Format(Messages.FedAllAnimals, fedCount));

            }

        }

        public void SpeakAll()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine(Messages.NoAnimals);
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
                Console.WriteLine(Messages.NoAnimals);
            }
            else
            {
                Console.WriteLine(Messages.CurrentAnimals);
                foreach (var a in animals)
                    Console.WriteLine($"{a.Id} | {a.GetType().Name} | {a.Name}");
                Console.WriteLine();

                int id;
                Console.Write(Messages.EnterId);
                while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
                {
                    Console.Write(Messages.InvalidId);
                }

                var toAdopt = animals.FirstOrDefault(a => a.Id == id);

                if (toAdopt == null)
                {
                    Console.WriteLine(Messages.AnimalNotFound);
                }
                else
                {
                    animals.Remove(toAdopt);
                    Console.WriteLine(string.Format(Messages.Adopted, toAdopt.GetType().Name, toAdopt.Name, toAdopt.Id));
                }
            }
        }

        public void FlyBirds()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine(Messages.NoBirds);
            }
            else
            {
                foreach (var animal in animals)
                {
                    if (animal is IFlyable f)
                    {
                        f.Fly();
                    }
                }
            }
        }

        public void SearchOrFilter()
        {
            Console.WriteLine(Messages.options);
            Console.WriteLine(Messages.ByType);
            Console.WriteLine(Messages.ByName);

            Console.WriteLine(Messages.Choose);
            var choice = Console.ReadLine()?.Trim() ?? "";

            IEnumerable<Animal> results = Enumerable.Empty<Animal>();

            if (choice == "1")
            {
                string type = "";
                string[] validTypes = { Messages.Dog, Messages.Cat, Messages.Bird, Messages.Reptile };

                do
                {
                    Console.Write(Messages.Type);
                    type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                    if (!validTypes.Contains(type))
                    {
                        Console.WriteLine(Messages.InvalidType);
                    }

                } while (!validTypes.Contains(type));

                results = animals.Where(a => a.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));

            }
            else if (choice == "2")
            {
                Console.Write(Messages.NameContains);
                string term = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(term))
                {
                    Console.Write(Messages.InvalidNameContains);
                    term = Console.ReadLine() ?? "";
                }
                term = term.Trim();

                results = animals.Where(a =>
                    a.Name?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else
            {
                Console.WriteLine(Messages.InvalidOption);
                return;
            }

            var list = results.ToList();
            if (list.Count == 0)
            {
                Console.WriteLine(Messages.NoMatches);
                return;
            }

            Console.WriteLine(Messages.ListHeader);
            Console.WriteLine(Messages.ListLine);

            foreach (var animal in list)
            {
                string type = animal.GetType().Name;
                string extra = "";

                switch (animal)
                {
                    case Dog d:
                        extra = d.IsTrained ? Messages.Trained: Messages.Untrained;
                        break;
                    case Cat c:
                        extra = c.IsIndoor ? Messages.Indoor : Messages.Outdoor;
                        break;
                    case Bird b:
                        extra = Messages.WingspanFormat;
                        break;
                    case Reptile r:
                        extra = r.IsVenomous ? Messages.Venomous : Messages.Nonvenomous;
                        break;
                }

                Console.WriteLine(
                    $"{animal.Id,2} | {type,-8} | {animal.Name,-10} | {animal.Age,3} | {extra,-15} | {animal.DailyCareCost(),9:0.00}");
            }
        }

        public void TotalDailyCost()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine(Messages.NoAnimals);
            }
            else
            {
                var totalCost = animals.Sum(a => a.DailyCareCost());
                Console.WriteLine(string.Format(Messages.TotalCosts, totalCost));
            }

        }
    }
}
