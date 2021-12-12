using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test10
    {
        [TestCase("()")]
        [TestCase("[]")]
        [TestCase("([])")]
        [TestCase("{()()()}")]
        [TestCase("<([{}])>")]
        [TestCase("[<>({}){}[([])<>]]")]
        [TestCase("(((((((((())))))))))")]
        public void Example1A(string input)
        {
            var (valid, _) = new Day10().IsValid(input);
            valid.ShouldBe(true);
        }

        [TestCase("(]")]
        [TestCase("{()()()>")]
        [TestCase("(((()))}")]
        [TestCase("<([]){()}[{}])")]
        public void Example1B(string input)
        {
            var (valid, _) = new Day10().IsValid(input);
            valid.ShouldBe(false);
        }

        [Test]
        public void Example1()
        {
            const string data = @"
[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]";
            var input = DataHelper.SplitLines(data);
            var result = new Day10().Solve(input);
            result.ShouldBe(26397);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(10);
            var result = new Day10().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
            var input = DataHelper.SplitLines(data);
            var result = new Day10().Solve2(input);
            result.ShouldBe(288957);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(10);
            var result = new Day10().Solve2(input);
            Console.WriteLine(result);
        }
    }
}