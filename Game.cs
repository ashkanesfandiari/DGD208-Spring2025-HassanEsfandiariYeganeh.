using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DGD208_Spring2025_HassanEsfandiariYeganeh
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();

        private List<Item> items = new List<Item>
        {
            new Item("Food", 30, 0, 0, 3),
            new Item("Bed", 0, 40, 0, 4),
            new Item("Toy", 0, 0, 35, 2)
        };

        public async void Start()
        {
            Console.WriteLine("welcome to my pet sim thing :)");
            Console.WriteLine("by Hassan Esfandiari Yeganeh - 2305045045");

            while (true)
            {
                Console.WriteLine("\nmain menu:");
                Console.WriteLine("1. adopt a pet");
                Console.WriteLine("2. view my pets");
                Console.WriteLine("3. feed a pet");
                Console.WriteLine("4. exit");
                Console.WriteLine("5. show detailed stats");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("ok so pick a pet type:");
                    foreach (var pet in Enum.GetValues(typeof(PetType)))
                    {
                        Console.WriteLine($"- {pet}");
                    }

                    string typeInput = Console.ReadLine();

                    if (!Enum.TryParse(typeInput, true, out PetType chosenType))
                    {
                        Console.WriteLine("uhh that type doesn't exist");
                        continue;
                    }

                    Console.WriteLine("cool! now name your pet:");
                    string name = Console.ReadLine();

                    Pet newPet = new Pet(name, chosenType);
                    pets.Add(newPet);
                    newPet.StartDecay(OnPetDied);

                    Console.WriteLine($"{name} the {chosenType} has been added to your pets :)");
                }
                else if (input == "2")
                {
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("you don't have any pets yet lol");
                        continue;
                    }

                    Console.WriteLine("your pets:");
                    foreach (var pet in pets)
                    {
                        Console.WriteLine($"{pet.Name} the {pet.Type}");
                    }
                }
                else if (input == "3")
                {
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("you got no pets lol");
                        continue;
                    }

                    Console.WriteLine("which pet?");
                    for (int i = 0; i < pets.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {pets[i].Name} the {pets[i].Type}");
                    }

                    int petChoice = int.Parse(Console.ReadLine()) - 1;
                    if (petChoice < 0 || petChoice >= pets.Count)
                    {
                        Console.WriteLine("bad pick");
                        continue;
                    }

                    Pet chosenPet = pets[petChoice];

                    Console.WriteLine("pick an item:");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].Name}");
                    }

                    int itemChoice = int.Parse(Console.ReadLine()) - 1;
                    if (itemChoice < 0 || itemChoice >= items.Count)
                    {
                        Console.WriteLine("nah that ain't right");
                        continue;
                    }

                    Console.WriteLine($"using {items[itemChoice].Name} on {chosenPet.Name}...");
                    await items[itemChoice].Use(chosenPet);
                    Console.WriteLine("done :)");
                }
                else if (input == "5")
                {
                    if (pets.Count == 0)
                    {
                        Console.WriteLine("no pets to show stats for");
                        continue;
                    }

                    Console.WriteLine("detailed pet stats:");
                    foreach (var pet in pets)
                    {
                        Console.WriteLine($"{pet.Name} the {pet.Type} -> hunger: {pet.Stats.Hunger}, sleep: {pet.Stats.Sleep}, fun: {pet.Stats.Fun}");
                    }
                }
                else if (input == "4")
                {
                    Console.WriteLine("bye bye");
                    break;
                }
                else
                {
                    Console.WriteLine("wrong choice");
                }
            }
        }

        private void OnPetDied(Pet pet)
        {
            pets.Remove(pet);
            Console.WriteLine($"{pet.Name} the {pet.Type} has died...");
        }
    }
}
