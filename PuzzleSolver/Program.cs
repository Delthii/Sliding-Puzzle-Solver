using System;
using System.Linq;

namespace PuzzleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = new Puzzle();
            puzzle.Shuffle();
            var solver = new Solver();
           // puzzle.Print();
            var solved = solver.Solve(puzzle);
            Console.WriteLine();
           // solved.Print();
            Console.ReadKey();
        }
    }
}
