namespace PokemonsAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public int Generation { get; set; }

        // Relationship properties
        public int? NextEvolutionId { get; set; }
        public int? BaseEvolutionId { get; set; }

        // Navigation properties
        public Pokemon? NextEvolution { get; set; }
        public Pokemon? BaseEvolution { get; set; }
    }
}