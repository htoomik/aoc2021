using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test21
    {
        [Test]
        public void Example1()
        {
            const string data = @"
Player 1 starting position: 4
Player 2 starting position: 8";
            var input = DataHelper.SplitLines(data);
            var result = new Day21().Solve(input);
            result.ShouldBe(739785);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(21);
            var result = new Day21().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day21().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day21().Solve2(input);
            Console.WriteLine(result);
        }
    }
}