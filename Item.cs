using System;
using System.Threading.Tasks;

namespace DGD208_Spring2025_HassanEsfandiariYeganeh
{
    public class Item
    {
        public string Name { get; set; }
        public int HungerBoost { get; set; }
        public int SleepBoost { get; set; }
        public int FunBoost { get; set; }
        public int UseTimeSeconds { get; set; }

        public Item(string name, int hunger, int sleep, int fun, int seconds)
        {
            Name = name;
            HungerBoost = hunger;
            SleepBoost = sleep;
            FunBoost = fun;
            UseTimeSeconds = seconds;
        }

        public async Task Use(Pet pet)
        {
            await Task.Delay(UseTimeSeconds * 1000);
            pet.Stats.Hunger = Math.Min(100, pet.Stats.Hunger + HungerBoost);
            pet.Stats.Sleep = Math.Min(100, pet.Stats.Sleep + SleepBoost);
            pet.Stats.Fun = Math.Min(100, pet.Stats.Fun + FunBoost);
        }
    }
}
