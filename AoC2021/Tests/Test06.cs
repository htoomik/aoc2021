using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test06
    {
        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        public void Example1(int days, int expected)
        {
            const string input = "3,4,3,1,2";
            var result = new Day06().Solve(input, days);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(6);
            var result = new Day06().Solve(input, 80);
            Console.WriteLine(result);
        }

        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        [TestCase(256, 26984457539)]
        public void Example2(int days, long expected)
        {
            const string input = "3,4,3,1,2";
            var result = new Day06().Solve2(input, days);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(6);
            var result = new Day06().Solve2(input, 256);
            Console.WriteLine(result);
        }
    }
}