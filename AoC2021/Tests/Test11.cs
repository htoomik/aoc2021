using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test11
    {
        [Test]
        public void Example1A()
        {
            const string input = @"
11111
19991
19191
19991
11111";
            var result = new Day11().Solve(input, 2);
            result.ShouldBe(9);
        }

        [Test]
        public void Example1()
        {
            const string input = @"
5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
            var result = new Day11().Solve(input);
            result.ShouldBe(1656);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(11);
            var result = new Day11().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string input = @"
5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
            var result = new Day11().Solve2(input);
            result.ShouldBe(195);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(11);
            var result = new Day11().Solve2(input);
            Console.WriteLine(result);
        }
    }
}