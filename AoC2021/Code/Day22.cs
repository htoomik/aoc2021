using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day22
    {
        public long Solve(List<string> input)
        {
            var grid = new Dictionary<Tuple<int, int, int>, bool>();
            var steps = input.Select(Parse).ToList();

            foreach (var step in steps)
            {
                Apply(grid, step);
            }

            return grid.LongCount(kvp => kvp.Value);
        }

        private void Apply(Dictionary<Tuple<int,int,int>,bool> grid, Rule step)
        {
            var flipped = 0;

            var minX = Math.Max(step.MinX, -50);
            var minY = Math.Max(step.MinY, -50);
            var minZ = Math.Max(step.MinZ, -50);

            var maxX = Math.Min(step.MaxX, 50);
            var maxY = Math.Min(step.MaxY, 50);
            var maxZ = Math.Min(step.MaxZ, 50);

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    for (var z = minZ; z <= maxZ; z++)
                    {
                        var t = new Tuple<int, int, int>(x, y, z);
                        var value = grid.ContainsKey(t) && grid[t];
                        if (value != step.On)
                        {
                            grid[t] = step.On;
                            flipped++;
                        }
                    }
                }
            }

            Console.WriteLine($"{flipped} cubes flipped");
        }

        private static Rule Parse(string arg)
        {
            return new Rule(arg);
        }

        public long Solve2(List<string> input)
        {
            return 0;
        }

        private class Rule
        {
            public bool On;
            public int MinX;
            public int MaxX;
            public int MinY;
            public int MaxY;
            public int MinZ;
            public int MaxZ;

            public Rule(string s)
            {
                var parts = s.Split(' ');

                On = parts[0] == "on";

                var dims = parts[1].Split(',');
                var xDim = dims[0].Replace("x=", "").Split("..");
                var yDim = dims[1].Replace("y=", "").Split("..");
                var zDim = dims[2].Replace("z=", "").Split("..");

                MinX = int.Parse(xDim[0]);
                MinY = int.Parse(yDim[0]);
                MinZ = int.Parse(zDim[0]);

                MaxX = int.Parse(xDim[1]);
                MaxY = int.Parse(yDim[1]);
                MaxZ = int.Parse(zDim[1]);
            }
        }
    }
}