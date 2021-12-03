using System;
using System.Collections.Generic;

namespace AoC2021.Code
{
    public class Day02
    {
        public int Solve(List<string> input)
        {
            var h = 0;
            var v = 0;

            foreach (var line in input)
            {
                var parts = line.Split(" ");
                var num = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "forward":
                        h += num;
                        break;
                    case "down":
                        v += num;
                        break;
                    case "up":
                        v -= num;
                        break;
                    default:
                        throw new Exception();
                }
            }

            return h * v;
        }

        public int Solve2(List<string> input)
        {
            var a = 0;
            var h = 0;
            var v = 0;

            foreach (var line in input)
            {
                var parts = line.Split(" ");
                var num = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "forward":
                        h += num;
                        v += a * num;
                        break;
                    case "down":
                        a += num;
                        break;
                    case "up":
                        a -= num;
                        break;
                    default:
                        throw new Exception();
                }
            }

            return h * v;
        }
    }
}