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
Player 1 starting position: 4
Player 2 starting position: 8";
            var input = DataHelper.SplitLines(data);
            var (r1, r2) = new Day21().Solve2(input, 21);
            r1.ShouldBe(444356092776315);
            r2.ShouldBe(341960390180808);
        }

        [TestCase(1, 27, 0)]
        [TestCase(2, 183, 156)]
        [TestCase(3, 990, 207)]
        [TestCase(4, 2930, 971)]
        [TestCase(5, 7907, 2728)]
        [TestCase(6, 30498, 7203)]
        [TestCase(7, 127019, 152976)]
        [TestCase(8, 655661, 1048978)]
        [TestCase(9, 4008007, 4049420)]
        [TestCase(10, 18973591, 12657100)]
        public void Example2A(int target, long e1, long e2)
        {
            const string data = @"
Player 1 starting position: 4
Player 2 starting position: 8";
            var input = DataHelper.SplitLines(data);
            var (r1, r2) = new Day21().Solve2(input, target);
            r1.ShouldBe(e1);
            r2.ShouldBe(e2);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(21);
            var result = new Day21().Solve2(input, 21);
            Console.WriteLine(result);
        }
    }
}