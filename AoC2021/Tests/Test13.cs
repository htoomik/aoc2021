using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test13
    {
        [Test]
        public void Example1()
        {
            const string input = @"
6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
            var result = new Day13().Solve(input);
            result.ShouldBe(17);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(13);
            var result = new Day13().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(13);
            var result = new Day13().Solve2(input);
            Console.WriteLine(result);

            // HKUJGAJZ
        }
    }
}