namespace Pokedex.Models
{
    public class MoveCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Move> moves { get; set; }
    }
}
