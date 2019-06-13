using System.Collections.Generic;

namespace PuzzleSolver
{
    public interface IPuzzle
    {
        IEnumerable<Tile> GetPossibleMoves();
        void Move(Tile tile);
        IPuzzle Copy();
        int DistanceToSolved();
        void Print();
        IPuzzle Predecessor { get; set; }
    }
}
