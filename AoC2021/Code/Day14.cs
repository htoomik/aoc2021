using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day14
    {
        public int Solve(List<string> input)
        {
            var state = input[0].ToCharArray();
            var rules = input
                .Skip(2)
                .Select(ParseRule)
                .ToDictionary(r => new Tuple<char, char>(r.Left, r.Right), r => r.Insert);

            for (var round = 0; round < 10; round++)
            {
                var newState = new List<char>();

                for (int i = 0; i < state.Length - 1; i++)
                {
                    var left = state[i];
                    var right = state[i + 1];

                    newState.Add(left);
                    if (rules.TryGetValue(new Tuple<char, char>(left, right), out var insert))
                    {
                        newState.Add(insert);
                    }
                }

                newState.Add(state.Last());

                state = newState.ToArray();
            }

            var counts = state
                .GroupBy(c => c)
                .Select(g => new Tuple<char, int>(g.Key, g.Count()))
                .OrderBy(t => t.Item2);

            var min = counts.First().Item2;
            var max = counts.Last().Item2;

            return max - min;
        }

        public long Solve2(List<string> input)
        {
            return 0;
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