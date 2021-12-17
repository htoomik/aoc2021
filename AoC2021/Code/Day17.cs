using System;
using System.Collections.Generic;

namespace AoC2021.Code
{
    public class Day17
    {
        public int Solve(string input)
        {
            // target area: x=20..30, y=-10..-5
            var parts = input.Replace("target area: x=", "").Split(", y=");
            var xParts = parts[0].Split("..");
            var yParts = parts[1].Split("..");

            var minX = int.Parse(xParts[0]);
            var maxX = int.Parse(xParts[1]);
            var minY = int.Parse(yParts[0]);
            var maxY = int.Parse(yParts[1]);

            var best = 0;
            for (var x = 1; x < minX; x++)
            {
                for (var y = 1; y < 1000; y++)
                {
                    var (hit, peak, hopelessX, hopelessY) = Shoot(x, y, minX, maxX, minY, maxY);
                    if (hit)
                    {
                        Console.WriteLine($"Found a working combination: x {x}, y {y}, peak {peak}");
                        if (peak > best)
                        {
                            best = peak;
                        }
                    }

                    if (hopelessX)
                    {
                        Console.WriteLine($"x {x} will never reach");
                        break;
                    }

                    if (hopelessY)
                    {
                        Console.WriteLine($"x {x} y {y} is too much");
                        break;
                    }
                }
            }

            return best;
        }

        public (bool, int, bool, bool) Shoot(int initialX, int initialY, int minX, int maxX, int minY, int maxY)
        {
            var x = 0;
            var y = 0;
            var xv = initialX;
            var yv = initialY;
            var peak = 0;

            while (true)
            {
                x += xv;
                y += yv;
                xv -= Math.Sign(xv);
                yv -= 1;

                if (y > peak)
                {
                    peak = y;
                }

                if (minX <= x && x <= maxX &&
                    minY <= y && y <= maxY)
                {
                    return (true, peak, false, false);
                }

                if (maxX < x)
                {
                    // Overshot
                    return (false, peak, false, true);
                }

                if (y < minY)
                {
                    var hopelessX = xv == 0 && x < minX;
                    return (false, peak, hopelessX, false);
                }
            }
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }
    }
}