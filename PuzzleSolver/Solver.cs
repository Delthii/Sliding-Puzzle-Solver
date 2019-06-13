using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace PuzzleSolver
{
    public class Solver
    {
        public IPuzzle Solve(IPuzzle puzzle)
        {
            var prioQ = new SimplePriorityQueue<IPuzzle>();
            prioQ.Enqueue(puzzle, puzzle.DistanceToSolved());
            const string correct = "123456780";
            var seen = new HashSet<string>();
            while (true)
            {
                puzzle = prioQ.Dequeue();

                if (puzzle.ToString().Equals(correct))
                {
                    return puzzle;
                }
                seen.Add(puzzle.ToString());

                foreach (var tile in puzzle.GetPossibleMoves().ToArray())
                {
                    var copy = puzzle.Copy();
                    copy.Move(tile);
                    if (!seen.Contains(copy.ToString()))
                    {
                        copy.Predecessor = puzzle;
                        prioQ.Enqueue(copy, copy.DistanceToSolved());
                    }
                }
            }
        }
    }
}
