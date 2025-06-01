using System;
using System.Threading;

namespace DGD208_Spring2025_HassanEsfandiariYeganeh
{
    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
        public PetStat Stats { get; set; }

        private bool isAlive = true;

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
            Stats = new PetStat();
        }

        public void StartDecay(Action<Pet> onDeath)
        {
            Thread decayThread = new Thread(() =>
            {
                while (isAlive)
                {
                    Thread.Sleep(5000);
                    Stats.Hunger = Math.Max(0, Stats.Hunger - 1);
                    Stats.Sleep = Math.Max(0, Stats.Sleep - 1);
                    Stats.Fun = Math.Max(0, Stats.Fun - 1);

                    if (Stats.Hunger == 0 || Stats.Sleep == 0 || Stats.Fun == 0)
                    {
                        isAlive = false;
                        onDeath?.Invoke(this);
                    }
                }
            });

            decayThread.IsBackground = true;
            decayThread.Start();
        }
    }
}
