using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test03
    {
        [Test]
        public void Example1()
        {
            const string data = @"
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            var input = DataHelper.SplitToLines(data);
            var result = new Day03().Solve(input);
            result.ShouldBe(198);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(3);
            var result = new Day03().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            var input = DataHelper.SplitToLines(data);
            var result = new Day03().Solve2(input);
            result.ShouldBe(230);
        }


        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(3);
            var result = new Day03().Solve2(input);
            Console.WriteLine(result);
        }
    }
}