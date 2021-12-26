using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test18
    {
        [Test]
        public void Parse1()
        {
            var (node, _) = Day18.Parse("[1,2]".ToCharArray());
            node.Left.Value.ShouldBe(1);
            node.Right.Value.ShouldBe(2);
        }

        [Test]
        public void Parse2()
        {
            (var node, _) = Day18.Parse("[[1,2],3]".ToCharArray());
            node.Left.Left.Value.ShouldBe(1);
            node.Left.Right.Value.ShouldBe(2);
            node.Right.Value.ShouldBe(3);
        }

        [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
        public void Parse3(string input)
        {
            var (node, _) = Day18.Parse(input.ToCharArray());
            node.ToString().ShouldBe(input);
        }

        [TestCase("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
        [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
        [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
        public void Reduce1(string input, string expected)
        {
            var (node, _) = Day18.Parse(input.ToCharArray());

            Day18.Reduce(node);
            node.ToString().ShouldBe(expected);
        }

        [Test]
        public void Example1()
        {
            const string data = @"
[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";
            var input = DataHelper.SplitLines(data);
            var result = new Day18().Solve(input);
            result.ShouldBe(4140);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day18().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day18().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day18().Solve2(input);
            Console.WriteLine(result);
        }
    }
}