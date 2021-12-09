using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day09
    {
        public int Solve(string input)
        {
            var values = Parse(input);

            var lowPoints = GetLowPoints(values);

            var result = lowPoints.Sum(p => p.Z + 1);
            return result;
        }

        private static List<Coords> GetLowPoints(List<List<int>> values)
        {
            var lowPoints = new List<Coords>();

            for (var i = 0; i < values.Count; i++)
            {
                for (var j = 0; j < values[i].Count; j++)
                {
                    var value = values[i][j];
                    var n = i == 0 ? int.MaxValue : values[i - 1][j];
                    var s = i == values.Count - 1 ? int.MaxValue : values[i + 1][j];
                    var w = j == 0 ? int.MaxValue : values[i][j - 1];
                    var e = j == values[i].Count - 1 ? int.MaxValue : values[i][j + 1];

                    if (value < n && value < s && value < w && value < e)
                    {
                        lowPoints.Add(new Coords(j, i, value));
                    }
                }
            }

            return lowPoints;
        }

        private static List<List<int>> Parse(string input)
        {
            return DataHelper
                .SplitLines(input)
                .Select(s => s
                    .ToCharArray()
                    .Select(c => (c - 48))
                    .ToList())
                .ToList();
        }

        public int Solve2(string input)
        {
            var values = Parse(input);
            var lowPoints = GetLowPoints(values);

            var basins = new List<HashSet<Coords>>();
            foreach (var point in lowPoints)
            {
                var basin = new HashSet<Coords>();
                basins.Add(basin);

                var queue = new Queue<Coords>();
                queue.Enqueue(point);

                var visited = new HashSet<Coords>();

                while (queue.Any())
                {
                    var current = queue.Dequeue();

                    if (!visited.Contains(current))
                    {
                        visited.Add(current);

                        if (current.Z < 9)
                        {
                            basin.Add(current);
                            var neighbours = current.GetNeighbours(values);
                            foreach (var neighbour in neighbours)
                            {
                                if (!visited.Contains(neighbour))
                                {
                                    queue.Enqueue(neighbour);
                                }
                            }
                        }
                    }
                }
            }

            var result = basins
                .OrderByDescending(b => b.Count)
                .Take(3)
                .Aggregate(1, (i, b) => i * b.Count);

            return result;
        }

        [DebuggerDisplay("{X}, {Y}: {Z}")]
        private struct Coords
        {
            public int X;
            public int Y;
            public int Z;

            public Coords(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public IEnumerable<Coords> GetNeighbours(List<List<int>> map)
            {
                var x = X;
                var y = Y;

                // North
                if (y > 0)
                {
                    yield return new Coords(x, y - 1, map[y - 1][x]);
                }

                // South
                if (y < map.Count - 1)
                {
                    yield return new Coords(x, y + 1, map[y + 1][x]);
                }

                // West
                if (x > 0)
                {
                    yield return new Coords(x - 1, y, map[y][x - 1]);
                }

                // East
                if (x < map[0].Count - 1)
                {
                    yield return new Coords(x + 1, y, map[y][x + 1]);
                }
            }
        }
    }
}