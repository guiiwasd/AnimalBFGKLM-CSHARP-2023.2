namespace AnimalBFGKLM.Models
{
    public class AnimalTipo : Animal
    {
        public bool Domestico { get; set; }
        public bool Selvagem { get; set; }

        public string? Comportamento { get; set; }
        public string? Habitat { get; set; }
    }
}
