# 🐾 Pet Shelter Console App

A C# console application that simulates a small **Pet Shelter management system**.  
This project demonstrates key **object-oriented programming (OOP)** principles such as **inheritance**, **abstraction**, **interfaces**, and **polymorphism**, along with simple console-based input validation and menu-driven interaction.

---

## 🚀 Features

- **Add Animals** — Register new Dogs, Cats, Birds, or Reptiles.
- **List Animals** — Display all animals in a formatted table with details and daily care cost.
- **Feed All** — Feed every animal (using the `IFeedable` interface).
- **Speak All** — Each animal makes its unique sound (`Speak()` polymorphism).
- **Adopt by Id** — Remove an animal from the shelter by its unique ID.
- **Fly Birds** — Birds can fly using the `IFlyable` interface. 🕊️
- **Search / Filter** — Filter animals by type or name.
- **Total Daily Cost** — Calculate the total daily care cost for all animals.

---

## 🧠 Object Model

| Base Class | Derived Classes | Interfaces Implemented |
|-------------|-----------------|-------------------------|
| `Animal` *(abstract)* | `Dog`, `Cat`, `Bird`, `Reptile` | `IFeedable`, `IFlyable` (Bird only) |

### Common Properties
- `Id`, `Name`, `Age`, `IntakeDate`
  
### Behavior
- `Speak()` — abstract, implemented in each derived class.  
- `DailyCareCost()` — virtual, each animal adds its own cost.

---

## 📂 Project Structure

PetShelter/
├─ Interfaces/
│ ├─ IFeedable.cs
│ └─ IFlyable.cs
├─ Models/
│ ├─ Animal.cs
│ ├─ Dog.cs
│ ├─ Cat.cs
│ ├─ Bird.cs
│ └─ Reptile.cs
├─ Services/
│ └─ ShelterService.cs
└─ Program.cs

yaml
Copy code

---

## 🧩 Sample Menu


Add Dog

Add Cat

Add Bird

Add Reptile

List Animals

Feed All

Speak All

Adopt (by Id)

Fly Birds

Search / Filter

Total Daily Cost

Exit

yaml
Copy code
