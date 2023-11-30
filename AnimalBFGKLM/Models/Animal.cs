namespace AnimalBFGKLM.Models
{
    public abstract class Animal
    {
        public long? AnimalId { get; set; }

        public string Nome { get; set; }

        public long Peso { get; set; }

        public int Idade { get; set; }

        public string Descricao { get; set; }
    }
}
