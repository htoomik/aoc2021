using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test02
    {
        [Test]
        public void Example1()
        {
            const string data = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var input = DataHelper.SplitLines(data);
            var result = new Day02().Solve(input);
            result.ShouldBe(150);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(2);
            var result = new Day02().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var input = DataHelper.SplitLines(data);
            var result = new Day02().Solve2(input);
            result.ShouldBe(900);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(2);
            var result = new Day02().Solve2(input);
            Console.WriteLine(result);
        }

    }
}