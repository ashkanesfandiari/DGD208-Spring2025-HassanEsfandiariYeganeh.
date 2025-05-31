using System;
using System.Collections.Generic;

namespace DGD208_Spring2025_HassanEsfandiariYeganeh
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();

        public void Start()
        {
            Console.WriteLine("welcome to my pet sim thing :)");
            Console.WriteLine("1. adopt a pet");
            Console.WriteLine("2. view my pets");
            Console.WriteLine("3. feed a pet");
            Console.WriteLine("4. exit");

            string input = Console.ReadLine();

            if (input == "1")
            {
                AdoptPet();
            }
            else if (input == "2")
            {
                ViewPets();
            }
            else if (input == "3")
            {
                FeedPet();
            }
            else
            {
                Console.WriteLine("bye bye");
            }
        }

        private void AdoptPet()
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
                return;
            }

            Console.WriteLine("cool! now name your pet:");
            string name = Console.ReadLine();

            Pet newPet = new Pet(name, chosenType);
            pets.Add(newPet);

            Console.WriteLine($"{name} the {chosenType} has been added to your pets :)");
        }

        private void ViewPets()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("you don't have any pets yet lol");
                return;
            }

            Console.WriteLine("your pets:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"{pet.Name} the {pet.Type} - hunger: {pet.Hunger}, sleep: {pet.Sleep}, fun: {pet.Fun}");
            }
        }

        private void FeedPet()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("you got no pets to feed");
                return;
            }

            Console.WriteLine("which one you wanna feed?");
            for (int i = 0; i < pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pets[i].Name} the {pets[i].Type} (hunger: {pets[i].Hunger})");
            }

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int index) && index >= 1 && index <= pets.Count)
            {
                pets[index - 1].Hunger += 10;
                Console.WriteLine($"{pets[index - 1].Name} looks happy and full now :)");
            }
            else
            {
                Console.WriteLine("uhh that number didn't work");
            }
        }
    }
}
