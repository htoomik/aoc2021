using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021.Helpers
{
    public class DataHelper
    {
        public static List<string> SplitLines(string data, bool doubleBreak = false)
        {
            var separator = doubleBreak ? "\n\n" : "\n";
            return data.Trim().Replace("\r\n", "\n").Split(separator).ToList();
        }

        public static List<int> SplitLinesToIntegers(string data)
        {
            return SplitLines(data).Select(int.Parse).ToList();
        }

        public static List<int> SplitToIntegers(string data, char separator = ',')
        {
            return data
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        public static Tuple<int, int> SplitToTuples(string data, char separator = ',')
        {
            var parts = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public static List<List<int>> SplitToIntegerGrid(string input)
        {
            return SplitLines(input)
                .Select(s => s
                    .ToCharArray()
                    .Select(c => (c - 48))
                    .ToList())
                .ToList();
        }

        public static List<string> ReadLines(int day)
        {
            var path = GetPath(day);
            return File.ReadAllLines(path).ToList();
        }

        public static List<int> ReadIntegers(int day)
        {
            var content = ReadFile(day);
            return SplitLinesToIntegers(content);
        }

        public static string ReadFile(int day)
        {
            var path = GetPath(day);
            return File.ReadAllText(path);
        }

        public static string ReadFile(string fileName)
        {
            var path = $"c:\\code\\aoc2021\\aoc2021\\data\\{fileName}";
            return File.ReadAllText(path);
        }

        private static string GetPath(int day)
        {
            var fileName = $"input{day:00}.txt";
            var path = $"c:\\code\\aoc2021\\aoc2021\\data\\{fileName}";
            return path;
        }
    }
}