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

        public static List<int> ReadIntegers(int day)
        {
            var fileName = $"input{day:00}.txt";
            var content = File.ReadAllText($"c:\\code\\aoc2021\\aoc2021\\data\\{fileName}");
            return SplitToIntegers(content);
        }
    }
}