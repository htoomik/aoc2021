using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class TestTemplate
    {
        [Test]
        public void Example1()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new DayTemplate().Solve(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(0);
            var result = new DayTemplate().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new DayTemplate().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new DayTemplate().Solve2(input);
            Console.WriteLine(result);
        }
    }
}