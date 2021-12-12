using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day10
    {
        private static readonly Dictionary<char, int> MismatchScores = new()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 }
        };

        private static readonly Dictionary<char, int> CompletionScores = new()
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 }
        };

        public int Solve(List<string> input)
        {
            var score = 0;

            foreach (var line in input)
            {
                var (valid, next) = IsValid(line);
                if (!valid)
                {
                    score += MismatchScores[next];
                }
            }

            return score;
        }

        public long Solve2(List<string> input)
        {
            var scores = new List<long>();

            foreach (var line in input)
            {
                var (valid, score) = Complete(line);
                if (valid)
                {
                    scores.Add(score);
                }
            }

            var count = scores.Count;
            return scores.OrderBy(s => s).Skip(count / 2).First();
        }

        public (bool, char) IsValid(string input)
        {
            var stack = new Stack<char>();

            foreach (var c in input)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                    case '<':
                        stack.Push(c);
                        break;
                    default:
                        var top = stack.Pop();
                        if (Matches(top, c))
                        {
                            continue;
                        }
                        else
                        {
                            return (false, c);
                        }
                }
            }

            return (true, (char)0);
        }

        private (bool, long) Complete(string input)
        {
            var stack = new Stack<char>();
            var score = 0L;

            foreach (var c in input)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                    case '<':
                        stack.Push(c);
                        break;
                    default:
                        var top = stack.Pop();
                        if (Matches(top, c))
                        {
                            continue;
                        }
                        else
                        {
                            return (false, 0);
                        }
                }
            }

            while (stack.TryPop(out var c))
            {
                var opposite = GetOpposite(c);
                score = score * 5 + CompletionScores[opposite];
            }

            return (true, score);
        }

        private bool Matches(char left, char right)
        {
            return right == GetOpposite(left);
        }

        private char GetOpposite(char c)
        {
            if (c == '(') return ')';
            if (c == '[') return ']';
            if (c == '{') return '}';
            if (c == '<') return '>';
            throw new Exception();
        }
    }
}