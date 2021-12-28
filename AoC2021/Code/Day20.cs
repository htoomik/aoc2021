using System;
using System.Collections.Generic;
using System.Linq;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day20
    {
        private bool infinity = false;

        public int Solve(string input, int times)
        {
            var parts = input.Trim().Replace("\r\n", "\n").Split("\n\n");

            var rules = ParseRules(parts[0]);
            var image = ParseImage(parts[1]);

            Print(image);

            for (var i = 0; i < times; i++)
            {
                image = Mutate(image, rules);
                Print(image);
            }

            return image.Values.Count(v => v);
        }

        private void Print(Dictionary<Tuple<int,int>,bool> image)
        {
            return;

            var minY = image.Keys.Select(k => k.Item1).Min();
            var minX = image.Keys.Select(k => k.Item2).Min();
            var maxY = image.Keys.Select(k => k.Item1).Max();
            var maxX = image.Keys.Select(k => k.Item2).Max();

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    var value = GetValue(image, y, x);
                    Console.Write(value ? '#' : '.');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private Dictionary<int, bool> ParseRules(string part)
        {
            return part
                .ToCharArray()
                .Select((c, i) => new Tuple<int, bool>(i, c == '#'))
                .ToDictionary(t => t.Item1, t => t.Item2);
        }

        private static Dictionary<Tuple<int, int>, bool> ParseImage(string part)
        {
            var grid = DataHelper.SplitLines(part).Select(l => l.ToCharArray()).ToArray();
            var image = new Dictionary<Tuple<int, int>, bool>();
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    var c = grid[i][j];
                    image[new Tuple<int, int>(i, j)] = c == '#';
                }
            }

            return image;
        }

        private Dictionary<Tuple<int, int>, bool> Mutate(
            Dictionary<Tuple<int, int>, bool> image,
            Dictionary<int, bool> rules)
        {
            var newImage = new Dictionary<Tuple<int, int>, bool>();

            var minY = image.Keys.Select(k => k.Item1).Min();
            var minX = image.Keys.Select(k => k.Item2).Min();
            var maxY = image.Keys.Select(k => k.Item1).Max();
            var maxX = image.Keys.Select(k => k.Item2).Max();

            for (var y = minY - 1; y <= maxY + 1; y++)
            {
                for (var x = minX - 1; x <= maxX + 1; x++)
                {
                    var newValue = GetNewValue(image, y, x, rules);
                    newImage[new Tuple<int, int>(y, x)] = newValue;
                }
            }

            if (rules[0] && !infinity)
            {
                infinity = !infinity;
            }

            if (rules[rules.Count - 1] && infinity)
            {
                infinity = !infinity;
            }

            return newImage;
        }

        private bool GetNewValue(Dictionary<Tuple<int,int>,bool> image, int y, int x, Dictionary<int,bool> rules)
        {
            var s = "";
            for (var r = -1; r <= 1; r++)
            {
                for (var c = -1; c <= 1; c++)
                {
                    var pixel = GetValue(image, y + r, x + c);
                    s += pixel ? "1" : "0";
                }
            }

            var value = Convert.ToInt32(s, 2);
            var newValue = rules[value];

            return newValue;
        }

        private bool GetValue(Dictionary<Tuple<int,int>,bool> image, int y, int x)
        {
            if (image.ContainsKey(new Tuple<int, int>(y, x)))
            {
                return image[new Tuple<int, int>(y, x)];
            }

            return infinity;
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }
    }
}