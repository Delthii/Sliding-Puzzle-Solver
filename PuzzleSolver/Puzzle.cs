using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver
{
    public class Puzzle : IPuzzle
    {
        public Tile Blank { get; set; }
        private static readonly Tile[] DefaultTiles = new Puzzle().GetBoard().OrderBy(x => x.Value).ToArray();
        private readonly Tile[,] board = new Tile[3,3];

        public Puzzle()
        {
            for (var i = 0; i < 9; i++)
            {
                var t = new Tile
                {
                    X = i / 3,
                    Y = i % 3,
                    Value = i != 8 ? i + 1 : 0
                };
                board[t.X, t.Y] = t;
                if (t.Value == 0) Blank = t;
            }
        }

        public void Shuffle()
        {
            var r = new Random();
            var c = 0;
            while (++c < r.Next(100,200))
            {
                foreach(var tile in GetPossibleMoves().OrderBy(x => r.Next()))
                {
                    Move(tile);
                }
            }
        }

        public IPuzzle Copy()
        {
            var p = new Puzzle();
            foreach (var tile in GetBoard())
            {
                p.board[tile.X, tile.Y] = new Tile
                {
                    X = tile.X,
                    Y = tile.Y,
                    Value = tile.Value
                };
                if (tile.Value == 0) p.Blank = p.board[tile.X, tile.Y];
            }

            return p;
        }

        public int DistanceToSolved()
        {
            var tiles = GetBoard().OrderBy(x => x.Value).ToArray();
            var dist = 0;
            for (int i = 0; i < DefaultTiles.Count(); i++)
            {
                var dx = Math.Abs(tiles[i].X - DefaultTiles[i].X);
                var dy = Math.Abs(tiles[i].Y - DefaultTiles[i].Y);
                dist += dx + dy;
            }

            return dist;
        }

        public IEnumerable<Tile> GetPossibleMoves()
        {
            var possibleMoves = new List<Tile>();
            Add(possibleMoves, 1, 0);
            Add(possibleMoves, -1, 0);
            Add(possibleMoves, 0, 1);
            Add(possibleMoves, 0, -1);

            return possibleMoves;
        }

        private void Add(List<Tile> possibleMoves, int dx, int dy)
        {
            var x = Blank.X + dx;
            var y = Blank.Y + dy;
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                possibleMoves.Add(board[x, y]);
            }
        }

        public void Move(Tile tile)
        {
            var x = Blank.X;
            var y = Blank.Y;
            Blank.X = tile.X;
            Blank.Y = tile.Y;
            board[tile.X, tile.Y] = Blank;
            tile.X = x;
            tile.Y = y;
            board[x,y] = tile;
        }

        public IEnumerable<Tile> GetBoard()
        {
            return board.Cast<Tile>().ToArray();
        }

        public void Print()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Console.Write((board[i,j].Value > 0 ? board[i, j].Value + ""  : " ") + " ");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return GetBoard().Aggregate("", (current, tile) => current + tile.Value);
        }
    }
}
