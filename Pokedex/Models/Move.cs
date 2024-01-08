namespace Pokedex.Models
{
    public class Move
    {
        public int? id { get; set; }
        public string? name { get; set; } 
        public int? accuracy { get; set; }
        public int? effect_chance { get; set; }
        public int? pp { get; set; }
        public int? priority { get; set; }
        public int? power { get; set; }
        public Type? type { get; set; }
        public MoveMetaData? meta { get; set; }
    }
}
