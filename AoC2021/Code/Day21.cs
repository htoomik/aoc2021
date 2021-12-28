using System;
using System.Collections.Generic;

namespace AoC2021.Code
{
    public class Day21
    {
        public int Solve(List<string> input)
        {
            const int target = 1000;
            var p1 = input[0][^1] - 48;
            var p2 = input[1][^1] - 48;

            return Simulate(target, p1, p2);
        }

        private static int Simulate(int target, int p1, int p2)
        {
            var s1 = 0;
            var s2 = 0;

            var d = 0;
            var dTotal = 0;

            while (true)
            {
                var r1 = 0;

                for (var i = 0; i < 3; i++)
                {
                    dTotal++;
                    d++;
                    if (d > 100)
                    {
                        d -= 100;
                    }

                    r1 += d;
                }

                p1 += r1;
                while (p1 > 10)
                {
                    p1 -= 10;
                }

                s1 += p1;

                if (s1 >= target)
                {
                    return dTotal * s2;
                }

                var r2 = 0;

                for (var i = 0; i < 3; i++)
                {
                    dTotal++;
                    d++;
                    if (d > 100)
                    {
                        d -= 100;
                    }

                    r2 += d;
                }

                p2 += r2;
                while (p2 > 10)
                {
                    p2 -= 10;
                }

                s2 += p2;

                if (s2 >= target)
                {
                    return dTotal * s1;
                }
            }
        }

        public (long, long) Solve2(List<string> input, int target)
        {
            var p1 = input[0][^1] - 48;
            var p2 = input[1][^1] - 48;

            _cache = new Dictionary<string, Tuple<long, long>>();

            var (wins1, wins2) = TakeTurn(0, 0, p1, p2, true, target);

            return (wins1, wins2);
        }

        private Dictionary<string, Tuple<long, long>> _cache;

        private Tuple<long, long> TakeTurn(int score1, int score2, int pos1, int pos2, bool p1Turn, int target)
        {
            var key = $"{score1}-{score2}-{pos1}-{pos2}-{p1Turn}-{target}";
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }

            if (score1 >= target)
            {
                var result = new Tuple<long, long>(1, 0);
                _cache[key] = result;
                return result;
            }

            if (score2 >= target)
            {
                var result = new Tuple<long, long>(0, 1);
                _cache[key] = result;
                return result;
            }

            var totalWins1 = 0L;
            var totalWins2 = 0L;

            for (var r1 = 1; r1 <= 3; r1++)
            {
                for (var r2 = 1; r2 <= 3; r2++)
                {
                    for (var r3 = 1; r3 <= 3; r3++)
                    {
                        var move = r1 + r2 + r3;

                        long wins1;
                        long wins2;
                        if (p1Turn)
                        {
                            var pos = pos1 + move;
                            if (pos > 10)
                            {
                                pos -= 10;
                            }

                            var score = score1 + pos;

                            (wins1, wins2) = TakeTurn(score, score2, pos, pos2, !p1Turn, target);
                        }
                        else
                        {
                            var pos = pos2 + move;
                            if (pos > 10)
                            {
                                pos -= 10;
                            }

                            var score = score2 + pos;

                            (wins1, wins2) = TakeTurn(score1, score, pos1, pos, !p1Turn, target);
                        }

                        totalWins1 += wins1;
                        totalWins2 += wins2;
                    }
                }
            }

            var result2 = new Tuple<long, long>(totalWins1, totalWins2);
            _cache[key] = result2;
            return result2;
        }
    }
}