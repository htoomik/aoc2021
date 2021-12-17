using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test16
    {
        [Test]
        public void Example1A()
        {
            const string input = "D2FE28";
            var result = new Day16().Parse(input);

            result.Version.ShouldBe(6);
            result.Type.ShouldBe(Day16.PacketType.Literal);
            result.Values.Count.ShouldBe(1);
            result.Values[0].ShouldBe(2021);
        }

        [Test]
        public void Example1B()
        {
            const string input = "38006F45291200";
            var result = new Day16().Parse(input);

            result.Version.ShouldBe(1);
            result.Type.ShouldBe(Day16.PacketType.Operator);
            result.LengthType.ShouldBe(0);
            result.PacketLength.ShouldBe(27);
            result.Values.Count.ShouldBe(27);
            result.Values[0].ShouldBe(2021);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day16().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day16().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day16().Solve2(input);
            Console.WriteLine(result);
        }
    }
}