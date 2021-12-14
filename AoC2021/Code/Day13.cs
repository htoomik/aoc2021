using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day13
    {
        public int Solve(string input)
        {
            return Solve(input, true);
        }

        public int Solve2(string input)
        {
            return Solve(input, false);
        }

        private int Solve(string input, bool justDoOne)
        {
            var chunks = input.Replace("\r\n", "\n").Split("\n\n");
            var dots = DataHelper.SplitLines(chunks[0]).Select(l => DataHelper.SplitToTuples(l)).ToList();
            var folds = DataHelper.SplitLines(chunks[1]).Select(ParseFolds).ToList();

            var foldsToProcess = justDoOne ? folds.Take(1) : folds;

            var state = new HashSet<Tuple<int,int>>(dots);

            foreach (var fold in foldsToProcess)
            {
                var foldedDots = new HashSet<Tuple<int, int>>();

                if (fold.Item1 == 'y')
                {
                    var yFold = fold.Item2;

                    foreach (var dot in state)
                    {
                        var x = dot.Item1;
                        var y = dot.Item2;

                        if (y < yFold)
                        {
                            foldedDots.Add(dot);
                        }
                        else if (y > yFold)
                        {
                            foldedDots.Add(new Tuple<int, int>(x, yFold + yFold - y));
                        }
                    }
                }

                if (fold.Item1 == 'x')
                {
                    var xFold = fold.Item2;

                    foreach (var dot in state)
                    {
                        var x = dot.Item1;
                        var y = dot.Item2;

                        if (x < xFold)
                        {
                            foldedDots.Add(dot);
                        }
                        else if (x > xFold)
                        {
                            foldedDots.Add(new Tuple<int, int>(xFold + xFold - x, y));
                        }
                    }
                }

                state = foldedDots;
            }

            if (!justDoOne)
            {
                Print(state);
            }
            return state.Count;
        }

        private static void Print(HashSet<Tuple<int,int>> dots)
        {
            var maxX = dots.Max(dot => dot.Item1);
            var maxY = dots.Max(dot => dot.Item2);

            var sb = new StringBuilder();
            for (var y = 0; y <= maxY; y++)
            {
                for (var x = 0; x <= maxX; x++)
                {
                    sb.Append(dots.Contains(new Tuple<int, int>(x, y)) ? '#' : '.');
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }

        private static Tuple<char, int> ParseFolds(string line)
        {
            var parts = line.Split("=");
            var axis = parts[0].ToCharArray().Last();
            var num = int.Parse(parts[1]);

            return new Tuple<char, int>(axis, num);
        }
    }
}