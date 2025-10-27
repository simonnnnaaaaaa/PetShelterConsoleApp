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
