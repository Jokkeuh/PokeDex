using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models
{
    public class Pokemon
    {
        [Key]
        public int? PokemonID { get; set; }
        public string? url { get; set; }
        [Required]
        [MaxLength(50)]
        public string? PokemonName { get; set; }
        [NotMapped]
        public int? id { get; set; }
        [NotMapped]
        public string? name { get; set; }
        [NotMapped]
        public int? base_experience { get; set; }
        [NotMapped]
        public int? height { get; set; }
        [NotMapped]
        public Sprites? sprites { get; set; }
        [NotMapped]
        public List<Stat>? stats { get; set; } = new List<Stat>();
        [NotMapped]
        public List<TypePokemon>? types { get; set; } = new List<TypePokemon>();
    }
}
