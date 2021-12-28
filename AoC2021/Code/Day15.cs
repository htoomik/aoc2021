using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day15
    {
        private List<List<Node>> _nodes;

        public int Solve(string input)
        {
            var grid = DataHelper.SplitToIntegerGrid(input);
            _nodes = grid
                .Select((row, y) => row
                    .Select((n, x) => new Node(x, y, n))
                    .ToList())
                .ToList();

            var queue = new Queue<(int, int)>();
            _nodes[0][0].InQueue = true;
            queue.Enqueue((0, 0));

            while (queue.TryDequeue(out var coords))
            {
                var node = _nodes[coords.Item1][coords.Item2];
                node.Visited = true;
                node.InQueue = false;

                var neighbours = GetNeighbours(node);

                foreach (var neighbour in neighbours)
                {
                    if (neighbour.Visited || neighbour.InQueue)
                    {
                        if (neighbour.Distance > neighbour.Weight + node.Distance)
                        {
                            neighbour.Distance = neighbour.Weight + node.Distance;
                            // Console.WriteLine($"Improved distance to {neighbour.Y}, {neighbour.X} is {neighbour.Distance} via {node.Y}, {node.X}");
                            neighbour.InQueue = true;
                            queue.Enqueue((neighbour.Y, neighbour.X));
                        }
                    }
                    else
                    {
                        neighbour.Distance = neighbour.Weight + node.Distance;
                        // Console.WriteLine($"Distance to {neighbour.Y}, {neighbour.X} is {neighbour.Distance} via {node.Y}, {node.X}");
                        neighbour.InQueue = true;
                        queue.Enqueue((neighbour.Y, neighbour.X));
                    }
                }
            }

            return _nodes[^1][^1].Distance;
        }

        private IEnumerable<Node> GetNeighbours(Node node)
        {
            // Left
            if (node.X > 0)
            {
                yield return _nodes[node.Y][node.X - 1];
            }

            // Right
            if (node.X < _nodes[0].Count - 1)
            {
                yield return _nodes[node.Y][node.X + 1];
            }

            // Up
            if (node.Y > 0)
            {
                yield return _nodes[node.Y - 1][node.X];
            }

            // Down
            if (node.Y < _nodes.Count - 1)
            {
                yield return _nodes[node.Y + 1][node.X];
            }
        }

        public int Solve2(string input)
        {
            var newGrid = Repeat(input);

            return Solve(newGrid);
        }

        private static string Repeat(string input)
        {
            var grid = DataHelper.SplitToIntegerGrid(input);
            var newGrid = new List<List<int>>();

            for (var r = 0; r < 5; r++)
            {
                for (var y = 0; y < grid.Count; y++)
                {
                    newGrid.Add(new List<int>());
                    var row = r * grid.Count + y;

                    for (var c = 0; c < 5; c++)
                    {
                        for (var x = 0; x < grid[0].Count; x++)
                        {
                            var originalValue = grid[y][x];
                            var newValue = originalValue + r + c;
                            if (newValue > 9)
                            {
                                newValue = newValue - 9;
                            }

                            newGrid[row].Add(newValue);
                        }
                    }
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < newGrid.Count; i++)
            {
                for (int j = 0; j < newGrid[0].Count; j++)
                {
                    sb.Append(newGrid[i][j]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
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

        private class Node
        {
            public int Distance;
            public readonly int Y;
            public readonly int X;
            public readonly int Weight;
            public bool InQueue;
            public bool Visited;

            public Node(int x, int y, int weight)
            {
                X = x;
                Y = y;
                Weight = weight;
                Distance = 0;
                InQueue = false;
                Visited = false;
            }
        }
    }
}