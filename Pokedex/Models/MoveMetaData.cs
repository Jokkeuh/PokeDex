namespace Pokedex.Models
{
    public class MoveMetaData
    {
        public MoveAilment? ailment { get; set; }
        public MoveCategory? category { get; set; } 
        public int? min_hits { get; set; }
        public int? max_hits { get; set; }
        public int? min_tuns { get; set; }
        public int? max_turns { get; set; }
        public int? drain { get; set; }
        public int? healing { get; set; }
        public int? crit_rate { get; set; }
        public int? ailment_chance { get; set; }
        public int? flinch_chance { get; set; }
        public int? flinch_charge { get;}
    }
}
