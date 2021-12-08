using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day08
    {
        /*
         *     aaaa
         *    b    c
         *    b    c
         *     dddd
         *    e    f
         *    e    f
         *     gggg
         */

        public int Solve(List<string> input)
        {
            return input.Select(SolveInner).Sum();
        }

        private int SolveInner(string input)
        {
            var parts = input.Split(" | ");
            var output = parts[1].Split(' ').Select(p => p.ToCharArray()).ToArray();

            var knownLengths = new HashSet<int> { 2, 3, 4, 7 };
            var numOf1478 = output.Count(o => knownLengths.Contains(o.Length));

            return numOf1478;
        }

        public int Solve2(List<string> input)
        {
            return input.Select(SolveInner2).Sum();
        }

        public int SolveInner2(string input)
        {
            var parts = input.Split(" | ");
            var signals = parts[0].Split(' ').Select(p => p.ToCharArray()).ToArray();
            var output = parts[1].Split(' ').Select(p => string.Join("", p.ToCharArray().OrderBy(c => c)));

            var one = signals.Single(s => s.Length == 2);
            var seven = signals.Single(s => s.Length == 3);
            var four = signals.Single(s => s.Length == 4);
            var twoThreeFive = signals.Where(s => s.Length == 5).ToArray();
            var zeroSixNine = signals.Where(s => s.Length == 6).ToArray();
            var eight = signals.Single(s => s.Length == 7);

            var a = seven.Except(one).Single();
            var cf = seven.Except(new[] { a }).ToArray();
            var bd = four.Except(one).ToArray();

            var three = twoThreeFive.Single(s => cf.All(s.Contains));
            var five = twoThreeFive.Single(s => bd.All(s.Contains));
            var two = twoThreeFive.Except(new[] { three }).Except(new[] { five }).Single();

            var c = two.Intersect(one).Single();
            var f = cf.Except(new[] { c }).Single();
            var b = five.Except(three).Single();
            var d = bd.Except(new[] { b }).Single();

            var zero = zeroSixNine.Single(s => !s.Contains(d));
            var six = zeroSixNine.Single(s => !s.Contains(c));
            var nine = zeroSixNine.Except(new[] { zero }).Except(new[] { six }).Single();

            var ordered = new[] { zero, one, two, three, four, five, six, seven, eight, nine }
                .Select(num => num.OrderBy(n => n).ToArray())
                .Select(num => string.Join("",num))
                .ToList();

            var total = output
                .Select(s => ordered.IndexOf(s))
                .Aggregate("", (current, value) => current + value);

            return int.Parse(total);
        }
    }
}