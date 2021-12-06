using System.Collections.Generic;
using System.Linq;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day06
    {
        public int Solve(string input, int days)
        {
            var fish = DataHelper.SplitToIntegers(input);

            for (var i = 0; i < days; i++)
            {
                var newFish = new List<int>();
                for (var f = 0; f < fish.Count; f++)
                {
                    if (fish[f] > 0)
                    {
                        fish[f]--;
                    }
                    else
                    {
                        fish[f] = 6;
                        newFish.Add(8);
                    }
                }

                fish.AddRange(newFish);
            }

            return fish.Count;
        }

        public long Solve2(string input, int days)
        {
            var fish = DataHelper.SplitToIntegers(input);

            var counts = new long[9];

            foreach (var f in fish)
            {
                counts[f]++;
            }

            for (var d = 0; d < days; d++)
            {
                var newCounts = new long[9];

                newCounts[0] = counts[1];
                newCounts[1] = counts[2];
                newCounts[2] = counts[3];
                newCounts[3] = counts[4];
                newCounts[4] = counts[5];
                newCounts[5] = counts[6];
                newCounts[6] = counts[0] + counts[7];
                newCounts[7] = counts[8];
                newCounts[8] = counts[0];

                counts = newCounts;
            }

            return counts.Sum();
        }
    }
}