namespace PuzzleSolver
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return X + " " + Y + " v" + Value;
        }
    }
}
