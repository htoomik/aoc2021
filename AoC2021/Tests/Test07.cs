using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test07
    {
        [Test]
        public void Example1()
        {
            const string data = @"16,1,2,0,4,2,7,1,2,14";
            var result = new Day07().Solve(data);
            result.ShouldBe(37);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(7);
            var result = new Day07().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"16,1,2,0,4,2,7,1,2,14";
            var result = new Day07().Solve2(data);
            result.ShouldBe(168);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(7);
            var result = new Day07().Solve2(input);
            Console.WriteLine(result);
        }
    }
}