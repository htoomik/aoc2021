using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    [TestFixture]
    public class Test01
    {
        [Test]
        public void Example1()
        {
            const string data = @"
199
200
208
210
200
207
240
269
260
263";
            var input = DataHelper.SplitToIntegers(data);
            var result = new Day01().Solve1(input);
            result.ShouldBe(7);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadIntegers(1);
            var result = new Day01().Solve1(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
199
200
208
210
200
207
240
269
260
263";
            var input = DataHelper.SplitToIntegers(data);
            var result = new Day01().Solve2(input);
            result.ShouldBe(5);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadIntegers(1);
            var result = new Day01().Solve2(input);
            Console.WriteLine(result);
        }
    }
}