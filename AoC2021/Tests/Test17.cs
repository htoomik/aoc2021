using System;
using System.Drawing.Drawing2D;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test17
    {
        [Test]
        public void Example1()
        {
            const string input = "target area: x=20..30, y=-10..-5";
            var result = new Day17().Solve(input);
            result.ShouldBe(45);
        }

        [TestCase(7, 2, 20, 30, -10, -5, true, 3, false)]
        [TestCase(6, 3, 20, 30, -10, -5, true, 6, false)]
        [TestCase(9, 0, 20, 30, -10, -5, true, 0, false)]
        [TestCase(17, -4, 20, 30, -10, -5, false, 0, true)]
        [TestCase(6, 9, 20, 30, -10, -5, true, 45, false)]
        [TestCase(6, 10, 20, 30, -10, -5, false, 55, false)]
        public void TestShoot(
            int x, int y, int minX, int maxX, int minY, int maxY,
            bool expectedHit, int expectedPeak, bool expectedOvershoot)
        {
            var (hit, peak, undershoot, overshoot) = new Day17().Shoot(x, y, minX, maxX, minY, maxY);
            hit.ShouldBe(expectedHit);
            peak.ShouldBe(expectedPeak);
            overshoot.ShouldBe(expectedOvershoot);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(17);
            var result = new Day17().Solve(input);
            Console.WriteLine(result);
            // 666 too low
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day17().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day17().Solve2(input);
            Console.WriteLine(result);
        }
    }
}