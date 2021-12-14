using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test14
    {
        [Test]
        public void Example1()
        {
            const string data = @"
NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
            var input = DataHelper.SplitLines(data);
            var result = new Day14().Solve(input);
            result.ShouldBe(1588);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(14);
            var result = new Day14().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
            var input = DataHelper.SplitLines(data);
            var result = new Day14().Solve2(input);
            result.ShouldBe(2188189693529);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(14);
            var result = new Day14().Solve2(input);
            Console.WriteLine(result);
        }
    }
}