using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day03
    {
        public int Solve(List<string> input)
        {
            var length = input[0].Length;
            var gamma = 0;
            var epsilon = 0;
            var bit = 1;

            for (var i = length - 1; i >= 0; i--)
            {
                var idx = i;
                var chars = input.Select(s => s[idx]).ToList();
                var zeroes = chars.Count(c => c == '0');
                var ones = chars.Count(c => c == '1');

                var mostCommon = zeroes > ones ? 0 : 1;
                var leastCommon = zeroes > ones ? 1 : 0;

                gamma += mostCommon * bit;
                epsilon += leastCommon * bit;
                bit *= 2;
            }

            return epsilon * gamma;
        }

        public int Solve2(List<string> input)
        {
            var ox = Filter(input, true, '1');
            var co2 = Filter(input, false, '0');

            return ox * co2;
        }

        private static int Filter(List<string> input, bool pickMostCommon, char defaultValue)
        {
            var length = input[0].Length;
            var matches = input;

            for (var i = 0; i < length; i++)
            {
                var idx = i;
                var chars = matches.Select(s => s[idx]).ToList();
                var zeroes = chars.Count(c => c == '0');
                var ones = chars.Count(c => c == '1');

                var pick = zeroes == ones
                    ? defaultValue
                    : pickMostCommon
                        ? zeroes > ones ? '0' :'1'
                        : zeroes > ones ? '1' : '0';
                matches = matches.Where(s => s[idx] == pick).ToList();
                if (matches.Count == 1)
                {
                    break;
                }
            }

            var match = matches.Single();
            var value = 0;
            var bit = 1;
            for (var i = length - 1; i >= 0; i--)
            {
                value += (match[i] - 48) * bit;
                bit *= 2;
            }

            return value;
        }
    }
}