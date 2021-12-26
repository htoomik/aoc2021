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
            var node = new Day18().Parse("[1,2]".ToCharArray());
            node.Left.Value.ShouldBe(1);
            node.Right.Value.ShouldBe(2);
        }

        [Test]
        public void Parse2()
        {
            var node = new Day18().Parse("[[1,2],3]".ToCharArray());
            node.Left.Left.Value.ShouldBe(1);
            node.Left.Right.Value.ShouldBe(2);
            node.Right.Value.ShouldBe(3);
        }

        [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
        public void Parse3(string input)
        {
            var node = new Day18().Parse(input.ToCharArray());
            node.ToString().ShouldBe(input);
        }

        [TestCase("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
        [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
        [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
        [TestCase("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]", "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
        public void Reduce(string input, string expected)
        {
            var day18 = new Day18();
            var node = day18.Parse(input.ToCharArray());
            day18.Reduce(node);
            node.ToString().ShouldBe(expected);
        }

        [Test]
        public void Example1A()
        {
            const string data = @"
[1,1]
[2,2]
[3,3]
[4,4]";
            var input = DataHelper.SplitLines(data);
            var (result, _) = new Day18().Solve(input);
            result.ShouldBe("[[[[1,1],[2,2]],[3,3]],[4,4]]");
        }

        [Test]
        public void Example1B()
        {
            const string data = @"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]";
            var input = DataHelper.SplitLines(data);
            var (result, _) = new Day18().Solve(input);
            result.ShouldBe("[[[[3,0],[5,3]],[4,4]],[5,5]]");
        }

        [Test]
        public void Example1C()
        {
            const string data = @"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]";
            var input = DataHelper.SplitLines(data);
            var (result, _) = new Day18().Solve(input);
            result.ShouldBe("[[[[5,0],[7,4]],[5,5]],[6,6]]");
        }

        [Test]
        public void Example1D()
        {
            const string data = @"
[[[[4,3],4],4],[7,[[8,4],9]]]
[1,1]";
            var input = DataHelper.SplitLines(data);
            var (result, _) = new Day18().Solve(input);
            result.ShouldBe("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]");
        }

        [Test]
        public void Example1E()
        {
            const string data = @"
[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";
            var input = DataHelper.SplitLines(data);
            var (result, sum) = new Day18().Solve(input);
            result.ShouldBe("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
            sum.ShouldBe(4140);
        }

        [Test]
        public void Example1F()
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
            var (result, sum) = new Day18().Solve(input);
            result.ShouldBe("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]");
            sum.ShouldBe(4140);
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