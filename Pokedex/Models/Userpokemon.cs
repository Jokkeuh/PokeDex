using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Userpokemon
    {
        [Key]
        public int USERPOKEMONID { get; set; }
        public int PokemonID { get; set;}
        public int USERID { get; set;}
    }
}
