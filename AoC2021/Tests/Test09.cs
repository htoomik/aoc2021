using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test09
    {
        [Test]
        public void Example1()
        {
            const string data = @"
2199943210
3987894921
9856789892
8767896789
9899965678";
            var input = data.Trim();
            var result = new Day09().Solve(input);
            result.ShouldBe(15);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(9);
            var result = new Day09().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
2199943210
3987894921
9856789892
8767896789
9899965678";
            var input = data.Trim();
            var result = new Day09().Solve2(input);
            result.ShouldBe(1134);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(9);
            var result = new Day09().Solve2(input);
            Console.WriteLine(result);
        }
    }
}