using System;
using System.Collections;
using System.Collections.Generic;
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
            var solved = solver.Solve(puzzle);
            var s = new Stack<IPuzzle>();
            while (solved.Predecessor != null)
            {
                s.Push(solved);
                solved = solved.Predecessor;
            }

            int c = s.Count();
            while (s.Any())
            {
                s.Pop().Print();
                Console.WriteLine();
            }
            Console.WriteLine("Solution found in " + c + " steps.");
            Console.ReadKey();
        }
    }
}
