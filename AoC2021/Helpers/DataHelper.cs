using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021.Helpers
{
    public class DataHelper
    {
        public static List<string> SplitToLines(string data)
        {
            return data.Trim().Replace("\r\n", "\n").Split("\n").ToList();
        }

        public static List<int> SplitToIntegers(string data)
        {
            return SplitToLines(data).Select(int.Parse).ToList();
        }

        public static List<string> ReadLines(int day)
        {
            var path = GetPath(day);
            return File.ReadAllLines(path).ToList();
        }

        public static List<int> ReadIntegers(int day)
        {
            var path = GetPath(day);
            var content = File.ReadAllText(path);
            return SplitToIntegers(content);
        }

        private static string GetPath(int day)
        {
            var fileName = $"input{day:00}.txt";
            var path = $"c:\\code\\aoc2021\\aoc2021\\data\\{fileName}";
            return path;
        }
    }
}