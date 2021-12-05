using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test05
    {
        [Test]
        public void Example1()
        {
            const string data = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            var input = DataHelper.SplitLines(data);
            var result = new Day05().Solve(input);
            result.ShouldBe(5);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(5);
            var result = new Day05().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            var input = DataHelper.SplitLines(data);
            var result = new Day05().Solve2(input);
            result.ShouldBe(12);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(5);
            var result = new Day05().Solve2(input);
            Console.WriteLine(result);
        }
    }
}