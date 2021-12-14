using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day14
    {
        public long Solve(List<string> input)
        {
            return Solve(input, 10);
        }

        public long Solve2(List<string> input)
        {
            return Solve(input, 40);
        }

        private static long Solve(List<string> input, int rounds)
        {
            var chars = input[0].ToCharArray();
            var rules = input
                .Skip(2)
                .Select(ParseRule)
                .ToDictionary(r => new Tuple<char, char>(r.Left, r.Right), r => r.Insert);

            var state = new Dictionary<Tuple<char, char>, long>();

            for (var i = 0; i < chars.Length - 1; i++)
            {
                var left = chars[i];
                var right = chars[i + 1];

                var tuple = new Tuple<char, char>(left, right);
                if (!state.ContainsKey(tuple))
                {
                    state.Add(tuple, 0);
                }

                state[tuple]++;
            }

            for (var round = 0; round < rounds; round++)
            {
                var newState = new Dictionary<Tuple<char, char>, long>();

                foreach (var pair in state)
                {
                    var insert = rules[pair.Key];
                    var newLeft = new Tuple<char, char>(pair.Key.Item1, insert);
                    var newRight = new Tuple<char, char>(insert, pair.Key.Item2);

                    if (!newState.ContainsKey(newLeft))
                    {
                        newState[newLeft] = 0;
                    }

                    if (!newState.ContainsKey(newRight))
                    {
                        newState[newRight] = 0;
                    }

                    newState[newLeft] += pair.Value;
                    newState[newRight] += pair.Value;
                }

                state = newState;
            }

            var counts = state.Keys
                .Select(s => s.Item1).Distinct()
                .ToDictionary(c => c, c => 0L);

            foreach (var kvp in state)
            {
                counts[kvp.Key.Item1] += kvp.Value;
            }

            counts[chars.Last()]++;

            var orderedCounts = counts.OrderBy(kvp => kvp.Value).ToList();
            var min = orderedCounts.First().Value;
            var max = orderedCounts.Last().Value;

            return max - min;
        }

        private static Rule ParseRule(string s)
        {
            return new Rule(s[0], s[1], s[6]);
        }

        private struct Rule
        {
            public char Left { get; }
            public char Right { get; }
            public char Insert { get; }

            public Rule(char left, char right, char insert)
            {
                Left = left;
                Right = right;
                Insert = insert;
            }
        }
    }
}