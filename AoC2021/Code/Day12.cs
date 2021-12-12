using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day12
    {
        public int Solve(List<string> input)
        {
            return Explore(input, CanVisit1);
        }

        public int Solve2(List<string> input)
        {
            return Explore(input, CanVisit2);
        }

        private static int Explore(List<string> input, Func<Path, string, bool> canVisit)
        {
            var map = input
                .Select(s => new Tuple<string, string>(
                    s.Split('-')[0],
                    s.Split('-')[1]))
                .ToList();
            var reversed = map.Select(t => new Tuple<string, string>(t.Item2, t.Item1)).ToList();
            map.AddRange(reversed);

            var completedPaths = new List<Path>();

            var queue = new Queue<Path>();
            queue.Enqueue(new Path(new List<string> { "start" }));

            while (queue.TryDequeue(out var p))
            {
                var last = p.Current;

                if (last == "end")
                {
                    completedPaths.Add(p);
                    continue;
                }

                var nextSteps1 = map.Where(q => q.Item1 == last);

                foreach (var next in nextSteps1)
                {
                    if (next.Item2 == "start")
                    {
                        continue;
                    }

                    if (!canVisit(p, next.Item2))
                    {
                        continue;
                    }

                    queue.Enqueue(p.With(next.Item2));
                }
            }

            return completedPaths.Count;
        }

        private static bool CanVisit1(Path path, string nextCave)
        {
            if (!IsSmallCave(nextCave))
            {
                return true;
            }

            return !path.History.Contains(nextCave);
        }

        private static bool CanVisit2(Path path, string nextCave)
        {
            if (!IsSmallCave(nextCave))
            {
                return true;
            }

            if (!path.History.Contains(nextCave))
            {
                return true;
            }

            if (path.HasVisitedTwice == nextCave)
            {
                return false;
            }

            if (path.HasVisitedTwice != null && path.History.Contains(nextCave))
            {
                return false;
            }

            return true;
        }

        private static bool IsSmallCave(string s)
        {
            return s.ToLower() == s;
        }

        private class Path
        {
            public List<string> History { get; }

            public string HasVisitedTwice { get; }

            public Path(List<string> history, string hasVisitedTwice = null)
            {
                History = history;
                HasVisitedTwice = hasVisitedTwice;
            }

            public string Current => History.Last();

            public Path With(string next)
            {
                var hasVisitedTwice = History.Contains(next) && IsSmallCave(next);
                var history = History.Select(h => h).Append(next).ToList();
                return new Path(history, hasVisitedTwice ? next : HasVisitedTwice);
            }
        }
    }
}