namespace DGD208_Spring2025_HassanEsfandiariYeganeh
{
    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
        public int Hunger { get; set; } = 50;
        public int Sleep { get; set; } = 50;
        public int Fun { get; set; } = 50;

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
        }
    }
}

