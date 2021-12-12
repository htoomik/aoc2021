using System;
using System.Collections.Generic;
using System.Text;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day11
    {
        public int Solve(string input, int turns = 100)
        {
            var grid = new Grid(DataHelper.SplitToIntegerGrid(input));
            var flashes = 0;

            for (var i = 1; i <= turns; i++)
            {
                grid.Increase();
                flashes += grid.Flash();
            }

            return flashes;
        }

        public int Solve2(string input)
        {
            var grid = new Grid(DataHelper.SplitToIntegerGrid(input));
            var turns = 0;
            var goal = grid.Rows * grid.Cols;

            while (true)
            {
                turns++;
                grid.Increase();
                var flashes = grid.Flash();

                if (flashes == goal)
                {
                    return turns;
                }
            }
        }

        private class Grid
        {
            private readonly List<List<int>> _values;
            public int Rows { get; }
            public int Cols { get; }

            public Grid(List<List<int>> values)
            {
                _values = values;
                Rows = _values.Count;
                Cols = _values[0].Count;
            }

            public void Increase()
            {
                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < Cols; j++)
                    {
                        _values[i][j]++;
                    }
                }
            }

            public int Flash()
            {
                var toFlash = new Queue<Tuple<int, int>>();
                var flashed = new HashSet<Tuple<int, int>>();

                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < Cols; j++)
                    {
                        if (_values[i][j] > 9)
                        {
                            toFlash.Enqueue(new Tuple<int, int>(i, j));
                        }
                    }
                }

                while (toFlash.TryDequeue(out var f))
                {
                    if (flashed.Contains(f))
                    {
                        continue;
                    }

                    flashed.Add(f);

                    BoostNeighbours(f, toFlash);
                }

                foreach (var f in flashed)
                {
                    _values[f.Item1][f.Item2] = 0;
                }

                return flashed.Count;
            }

            private void BoostNeighbours(Tuple<int,int> f, Queue<Tuple<int,int>> toFlash)
            {
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        var newI = f.Item1 + i;
                        var newJ = f.Item2 + j;

                        if (newI >= 0 && newI < Rows &&
                            newJ >= 0 && newJ < Cols &&
                            (i != 0 || j != 0))
                        {
                            _values[newI][newJ]++;

                            if (_values[newI][newJ] > 9)
                            {
                                toFlash.Enqueue(new Tuple<int, int>(newI, newJ));
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        sb.Append(_values[i][j]);
                    }

                    sb.AppendLine();
                }

                return sb.ToString();
            }
        }
    }
}