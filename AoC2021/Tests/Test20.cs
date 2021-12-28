using System;
using AoC2021.Code;
using AoC2021.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2021.Tests
{
    public class Test20
    {
        [Test]
        public void Example1()
        {
            const string input = @"
..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";
            var result = new Day20().Solve(input, 2);
            result.ShouldBe(35);
        }

        [Test]
        public void Example1A()
        {
            var input = DataHelper.ReadFile("example20.txt");
            var result = new Day20().Solve(input, 2);
            result.ShouldBe(5326);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(20);
            var result = new Day20().Solve(input, 2);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string input = @"
..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";
            var result = new Day20().Solve(input, 50);
            result.ShouldBe(3351);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(20);
            var result = new Day20().Solve(input, 50);
            Console.WriteLine(result);
        }
    }
}