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
            var (peak, hits) = new Day17().Solve(input);
            peak.ShouldBe(45);
            hits.ShouldBe(112);
        }

        [TestCase(7, 2, true, 3, false)]
        [TestCase(6, 3, true, 6, false)]
        [TestCase(9, 0, true, 0, false)]
        [TestCase(17, -4, false, 0, true)]
        [TestCase(6, 9, true, 45, false)]
        [TestCase(6, 10, false, 55, false)]
        public void TestShoot(
            int x, int y, bool expectedHit, int expectedPeak, bool expectedOvershoot)
        {
            var (hit, peak, undershoot, overshoot) = new Day17().Shoot(x, y, 20, 30, -10, -5);
            hit.ShouldBe(expectedHit);
            peak.ShouldBe(expectedPeak);
            overshoot.ShouldBe(expectedOvershoot);
        }

        [TestCase(23, -10)]
        [TestCase(25, -7)]
        public void Example2(int x, int y)
        {
            var (hit, _, _, _) = new Day17().Shoot(x, y, 20, 30, -10, -5);
            hit.ShouldBeTrue();
        }

        [Test]
        public void Solve()
        {
            var input = DataHelper.ReadFile(17);
            var result = new Day17().Solve(input);
            Console.WriteLine(result);
        }
    }
}