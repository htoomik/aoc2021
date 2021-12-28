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

        public int Solve2(List<string> input)
        {
            const int target = 1000;
            var p1 = input[0][^1] - 48;
            var p2 = input[1][^1] - 48;

            return 0;
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
    }
}