using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day01
    {
        public int Solve1(List<int> input)
        {
            var total = 0;
            for (var i = 1; i < input.Count; i++)
            {
                var previous = input[i - 1];
                var current = input[i];
                if (current > previous)
                {
                    total++;
                }
            }

            return total;
        }

        public int Solve2(List<int> input)
        {
            var array = input.ToArray();
            var total = 0;

            for (var i = 3; i < input.Count; i++)
            {
                var previousThree = array[(i - 3)..(i)];
                var currentThree = array[(i - 2)..(i + 1)];
                var previousSum = previousThree.Sum();
                var currentSum = currentThree.Sum();
                if (currentSum > previousSum)
                {
                    total++;
                }
            }

            return total;
        }
    }
}