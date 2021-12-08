using System;
using System.Linq;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day07
    {
        public int Solve(string input)
        {
            var nums = DataHelper.SplitToIntegers(input);

            var min = nums.Min();
            var max = nums.Max();

            var bestDiff = int.MaxValue;

            for (var i = min; i < max; i++)
            {
                var diff = nums.Select(n => Math.Abs(n - i)).Sum();
                if (diff < bestDiff)
                {
                    bestDiff = diff;
                }
            }

            return bestDiff;
        }

        public int Solve2(string input)
        {
            var nums = DataHelper.SplitToIntegers(input);

            var min = nums.Min();
            var max = nums.Max();

            var bestDiff = int.MaxValue;

            for (var i = min; i < max; i++)
            {
                var diff = nums.Select(n =>
                {
                    var steps = Math.Abs(n - i);
                    var cost = steps * (steps + 1) / 2;
                    return cost;
                }).Sum();

                if (diff < bestDiff)
                {
                    bestDiff = diff;
                }
            }

            return bestDiff;
        }
    }
}