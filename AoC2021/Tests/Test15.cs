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
        public void Example1A()
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
            var result = new Day15().SolveA(input);
            result.ShouldBe(40);
        }

        [Test]
        public void Example1B()
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
            var result = new Day15().SolveB(input);
            result.ShouldBe(40);
        }

        [Test]
        public void Part1A()
        {
            var input = DataHelper.ReadFile(15);
            var result = new Day15().SolveA(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Part1B()
        {
            var input = DataHelper.ReadFile(15);
            var result = new Day15().SolveB(input);
            Console.WriteLine(result);
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
            var input = DataHelper.ReadLines(0);
            var result = new Day15().Solve2(input);
            Console.WriteLine(result);
        }
    }
}