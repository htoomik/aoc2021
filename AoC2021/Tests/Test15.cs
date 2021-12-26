using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test15
    {
        [Test]
        public void Example1()
        {
            const string input = @"
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
            var result = new Day15().Solve(input);
            result.ShouldBe(40);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(15);
            var result = new Day15().Solve(input);
            Console.WriteLine(result);
            // 459 too high
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day15().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(15);
            var result = new Day15().Solve2(input);
            Console.WriteLine(result);
        }
    }
}