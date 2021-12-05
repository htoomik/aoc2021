using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Code
{
    public class Day05
    {
        public int Solve(List<string> input)
        {
            var vents = input.Select(Vent.Parse).ToList();

            var maxX = Math.Max(vents.Max(v => v.X1), vents.Max(v => v.X2));
            var maxY = Math.Max(vents.Max(v => v.Y1), vents.Max(v => v.Y2));

            var map = new Map(maxX, maxY);

            foreach (var vent in vents)
            {
                if (vent.IsHorizontal())
                {
                    map.MarkHorizontal(vent);
                }

                if (vent.IsVertical())
                {
                    map.MarkVertical(vent);
                }
            }

            //Console.WriteLine(map.ToString());

            var result = map.CountOverlappingPoints();

            return result;
        }

        public int Solve2(List<string> input)
        {
            var vents = input.Select(Vent.Parse).ToList();

            var maxX = Math.Max(vents.Max(v => v.X1), vents.Max(v => v.X2));
            var maxY = Math.Max(vents.Max(v => v.Y1), vents.Max(v => v.Y2));

            var map = new Map(maxX, maxY);

            foreach (var vent in vents)
            {
                if (vent.IsHorizontal())
                {
                    map.MarkHorizontal(vent);
                }
                else if (vent.IsVertical())
                {
                    map.MarkVertical(vent);
                }
                else
                {
                    map.MarkDiagonal(vent);
                }
            }

            //Console.WriteLine(map.ToString());

            var result = map.CountOverlappingPoints();

            return result;
        }

        private class Map
        {
            private readonly int[,] _map;
            private readonly int _maxX;
            private readonly int _maxY;

            public Map(int maxX, int maxY)
            {
                _maxX = maxX;
                _maxY = maxY;
                _map = new int[maxX + 1, maxY + 1];
            }

            public void MarkHorizontal(Vent vent)
            {
                var step = vent.X1 < vent.X2 ? 1 : -1;
                var length = Math.Abs(vent.X1 - vent.X2) + 1;
                var x = vent.X1;

                for (var i = 0; i < length; i++)
                {
                    _map[vent.Y1, x]++;
                    x += step;
                }
            }

            public void MarkVertical(Vent vent)
            {
                var step = vent.Y1 < vent.Y2 ? 1 : -1;
                var length = Math.Abs(vent.Y1 - vent.Y2) + 1;
                var y = vent.Y1;

                for (var i = 0; i < length; i++)
                {
                    _map[y, vent.X1]++;
                    y += step;
                }
            }

            public void MarkDiagonal(Vent vent)
            {
                var xStep = vent.X1 < vent.X2 ? 1 : -1;
                var yStep = vent.Y1 < vent.Y2 ? 1 : -1;
                var length = Math.Abs(vent.Y1 - vent.Y2) + 1;
                var y = vent.Y1;
                var x = vent.X1;

                for (var i = 0; i < length; i++)
                {
                    _map[y, x]++;
                    x += xStep;
                    y += yStep;
                }
            }

            public int CountOverlappingPoints()
            {
                var total = 0;
                for (var y = 0; y <= _maxY; y++)
                {
                    for (var x = 0; x <= _maxX; x++)
                    {
                        if (_map[y, x] >= 2)
                        {
                            total++;
                        }
                    }
                }

                return total;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (var y = 0; y <= _maxY; y++)
                {
                    for (var x = 0; x <= _maxX; x++)
                    {
                        var value = _map[y, x];
                        var marker = value == 0 ? "." : value.ToString();
                        sb.Append(marker);
                    }

                    sb.AppendLine();
                }

                return sb.ToString();
            }
        }

        private class Vent
        {
            public int X1 { get; }
            public int Y1 { get; }
            public int X2 { get; }
            public int Y2 { get; }

            private Vent(int x1, int y1, int x2, int y2)
            {
                X1 = x1;
                X2 = x2;
                Y1 = y1;
                Y2 = y2;
            }

            public static Vent Parse(string line)
            {
                var parts = line.Split(" -> ");
                var point1 = parts[0].Split(",").Select(int.Parse).ToList();
                var point2 = parts[1].Split(",").Select(int.Parse).ToList();

                return new Vent(point1[0], point1[1], point2[0], point2[1]);
            }

            public bool IsHorizontal()
            {
                return Y1 == Y2;
            }

            public bool IsVertical()
            {
                return X1 == X2;
            }
        }
    }
}