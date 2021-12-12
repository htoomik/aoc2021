using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test12
    {
        [Test]
        public void Example1A()
        {
            const string data = @"
start-A
start-b
A-c
A-b
b-d
A-end
b-end";
            var input = DataHelper.SplitLines(data);
            var result = new Day12().Solve(input);
            result.ShouldBe(10);
        }

        [Test]
        public void Example1B()
        {
            const string data = @"
dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";
            var input = DataHelper.SplitLines(data);
            var result = new Day12().Solve(input);
            result.ShouldBe(19);
        }

        [Test]
        public void Example1C()
        {
            const string data = @"
fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";
            var input = DataHelper.SplitLines(data);
            var result = new Day12().Solve(input);
            result.ShouldBe(226);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(12);
            var result = new Day12().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
start-A
start-b
A-c
A-b
b-d
A-end
b-end";
            var input = DataHelper.SplitLines(data);
            var result = new Day12().Solve2(input);
            result.ShouldBe(36);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(12);
            var result = new Day12().Solve2(input);
            Console.WriteLine(result);
        }
    }
}