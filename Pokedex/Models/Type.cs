namespace Pokedex.Models
{
    public class Type
    {

        public int id { get; set; }
        public string name { get; set; }
        
        public List<TypePokemon> pokemon { get; set; }
    }
    public enum PokemonType
    {
        Normal,
        Fire,
        Water,
        Grass,
        Electric,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Steel,
        Dragon,
        Dark,
        Fairy
    }
}
