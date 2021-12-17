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
            result.Value.ShouldBe(2021);
            result.CharsConsumed.ShouldBe(21);
        }

        [Test]
        public void Example1B()
        {
            const string input = "38006F45291200";
            var result = new Day16().Parse(input);

            result.Version.ShouldBe(1);
            result.LengthType.ShouldBe(0);
            result.SubPackets.Count.ShouldBe(2);
            result.CharsConsumed.ShouldBe(49);
            result.SubPackets[0].Value.ShouldBe(10);
            result.SubPackets[1].Value.ShouldBe(20);
        }

        [Test]
        public void Example1C()
        {
            const string input = "EE00D40C823060";
            var result = new Day16().Parse(input);

            result.Version.ShouldBe(7);
            result.LengthType.ShouldBe(1);
            result.SubPackets.Count.ShouldBe(3);
            result.CharsConsumed.ShouldBe(51);
            result.SubPackets[0].Value.ShouldBe(1);
            result.SubPackets[1].Value.ShouldBe(2);
            result.SubPackets[2].Value.ShouldBe(3);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(16);
            var result = new Day16().Solve(input);
            Console.WriteLine(result);
        }

        [TestCase("C200B40A82", 3)]
        [TestCase("04005AC33890", 54)]
        [TestCase("880086C3E88112", 7)]
        [TestCase("CE00C43D881120", 9)]
        [TestCase("D8005AC2A8F0", 1)]
        [TestCase("F600BC2D8F", 0)]
        [TestCase("9C005AC2F8F0", 0)]
        [TestCase("9C0141080250320F1802104A08", 1)]
        public void Example2(string input, int expected)
        {
            var result = new Day16().Solve2(input);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(16);
            var result = new Day16().Solve2(input);
            Console.WriteLine(result);
        }
    }
}