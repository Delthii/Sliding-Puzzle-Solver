using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolver
{
    public interface IPuzzle
    {
        Tile Blank { get; set; }
        IEnumerable<Tile> GetPossibleMoves();
        void Move(Tile tile);
        IPuzzle Copy();
        int DistanceToSolved();
        void Print();
    }
}
