
namespace PetShelter.Resources
{
    public class Messages
    {

        public const string FeedReptile = "The reptile {0} has been feed.";
        public const string ReptileSound = "Hiss!";

        public const string FeedDog = "The dog {0} has been feed.";
        public const string DogSound = "Woof!";

        public const string FeedCat = "The cat {0} has been feed.";
        public const string CatSound = "Meow!";

        public const string BirdFlies = "The bird {0} flies with a wingspan of {1} cm.";
        public const string FeedBird = "The bird {0} has been feed.";
        public const string BirdSound = "Chirp!";

        public const string EnterDogName = "Enter dog name: ";
        public const string EnterDogAge = "Enter Dog age: ";
        public const string IsTrained = "Is the Dog trained? (y/n): ";
        public const string DogAdded = "Dog {0} added successfully!";

        public const string EnterCatName = "Enter Cat name: ";
        public const string EnterCatAge = "Enter Cat age: ";
        public const string IsIndoor = "Is the Cat indoor? (y/n): ";
        public const string CatAdded = "Cat {0} added successfully!";

        public const string EnterBirdName = "Enter Bird name: ";
        public const string EnterBirdAge = "Enter Bird age: ";
        public const string EnterBirdWingspan = "Enter Bird wingspan (cm): ";
        public const string InvalidWingspan = "Invalid wingspan. Enter a positive number: ";
        public const string BirdAdded = "Bird {0} added successfully!";

        public const string EnterReptileName = "Enter reptile name: ";
        public const string EnterReptileAge = "Enter Reptile age: ";
        public const string IsVenomous = "Is the Reptile Venomous? (y/n): ";
        public const string ReptileAdded = "Reptile {0} added successfully!";

        public const string NameCantBeEmpty = "Name can't be empty! Try again:";
        public const string InvalidAge = "Invalid age. Enter a non-negative number: ";

        public const string NoAnimals = "No animals in the shelter yet.";
        
        public const string ListHeader = "ID | Type | Name       | Age | Extra            | Daily Cost";
        public const string ListLine = "--------------------------------------------------------------";

        public const string Trained = "Trained";
        public const string Untrained = "Untrained";

        public const string Indoor = "Indoor";
        public const string Outdoor = "Outdoor";

        public const string Venomous = "Venomous";
        public const string Nonvenomous = "Non-Venomous";

        public const string WingspanFormat = "Wingspan: {0:0.##} cm";

        public const string FedAllAnimals = "\nAll animals have been fed ({0} total).";


        public const string CurrentAnimals = "Current animals (Id | Type | Name):";
        public const string EnterId = "Enter the Id to adopt: ";
        public const string InvalidId = "Invalid Id. Enter a positive integer: ";
        public const string AnimalNotFound = "Animal not found.0";

        public const string Adopted = "Congratulations! the {0} {1} (Id {2}) has been adopted!";

        public const string NoBirds = "There are no birds in the shelter!";

        public const string options = "Options: ";
        public const string ByType = "1) By Type ";
        public const string ByName = "2) By Name ";
        public const string Choose = "Choose ";
        
        public const string Dog = "dog";
        public const string Cat = "cat";
        public const string Bird = "bird";
        public const string Reptile = "reptile";
        public const string Type = "Type(Dog / Cat / Bird / Reptile): ";
        public const string InvalidType = "Invalid type entered. Please choose one of: Dog, Cat, Bird, or Reptile.\n";
        public const string NameContains = "Name contains: ";
        public const string InvalidNameContains = "Value cannot be empty. Name contains: ";
        public const string InvalidOption = "Invalid option.";
        public const string NoMatches = "No matches found.";

        public const string TotalCosts = "Total daily care cost for all animals: {0:0.00}";
   
        public const string option1 = " 1) Add Dog";
        public const string option2 = " 2) Add Cat";
        public const string option3 = " 3) Add Bird";
        public const string option4 = " 4) Add Reptile";
        public const string option5 = " 5) List Animals";
        public const string option6 = " 6) Feed All";
        public const string option7 = " 7) Speak All";
        public const string option8 = " 8) Adopt (by Id)";
        public const string option9 = " 9) Fly Birds";
        public const string option10 = "10) Search/Filter";
        public const string option11 = "11) Total Daily Costs";
        public const string option12 = "12) Exit";



    }
}