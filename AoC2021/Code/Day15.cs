using System;
using System.Collections.Generic;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day15
    {
        public int SolveA(string input)
        {
            var grid = DataHelper.SplitToIntegerGrid(input);
            var max = grid.Count - 1;

            var best = int.MaxValue;

            var queue = new Queue<Path>();
            queue.Enqueue(new Path(0, 0, 0));

            while (queue.TryDequeue(out var candidate))
            {
                if (candidate.X == max && candidate.Y == max)
                {
                    if (candidate.TotalRisk < best)
                    {
                        best = candidate.TotalRisk;
                    }
                }
                else
                {
                    if (candidate.Y != max)
                    {
                        var next = candidate.Move(0, 1, grid[candidate.Y + 1][candidate.X]);
                        queue.Enqueue(next);
                    }

                    if (candidate.X != max)
                    {
                        var next = candidate.Move(1, 0, grid[candidate.Y][candidate.X + 1]);
                        queue.Enqueue(next);
                    }
                }
            }

            return best;
        }

        private List<List<int>> _grid;
        private int _max;

        public int SolveB(string input)
        {
            _grid = DataHelper.SplitToIntegerGrid(input);
            _max = _grid.Count - 1;

            var result = Go(0, 0, 0);
            return result;
        }

        private int Go(int x, int y, int r)
        {
            if (x == _max && y == _max)
            {
                return r;
            }

            var goDown = int.MaxValue;
            var goRight = int.MaxValue;

            if (y < _max)
            {
                goDown = Go(x, y + 1, r + _grid[y + 1][x]);
            }

            if (x < _max)
            {
                goRight = Go(x + 1, y, r + _grid[y][x + 1]);
            }

            return Math.Min(goDown, goRight);
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }

        private readonly struct Path
        {
            public int TotalRisk { get; }
            public int X { get; }
            public int Y { get; }

            public Path(int x, int y, int r)
            {
                X = x;
                Y = y;
                TotalRisk = r;
            }

            public Path Move(int x, int y, int r)
            {
                return new Path(X + x, Y + y, TotalRisk + r);
            }
        }
    }
}