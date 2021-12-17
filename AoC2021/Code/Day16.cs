using System;
using System.Collections.Generic;
using System.Threading;

namespace AoC2021.Code
{
    public class Day16
    {
        public Transmission Parse(string line)
        {
            return new Transmission(line);
        }

        public int Solve(List<string> input)
        {
            return 0;
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }

        public class Transmission
        {
            public int Version { get; }
            public PacketType Type { get; }
            public int LengthType { get; }
            public int PacketLength { get; }
            public List<int> Values { get; }

            public Transmission(string line)
            {
                var binary = Convert.ToString(Convert.ToInt32(line, 16), 2);

                var versionString = binary.Substring(0, 3);
                Version = BinaryParse(versionString);

                var typeString = binary.Substring(3, 3);
                var typeValue = BinaryParse(typeString);
                Type = typeValue == 4 ? PacketType.Literal : PacketType.Operator;

                if (Type == PacketType.Literal)
                {
                    var pos = 6;
                    var allParts = "";
                    while (true)
                    {
                        var starter = binary.Substring(pos, 1);
                        var nextFour = binary.Substring(pos + 1, 4);
                        allParts += nextFour;
                        pos += 5;
                        if (starter == "0")
                        {
                            break;
                        }
                    }

                    var value = BinaryParse(allParts);
                    Values = new List<int> { value };
                }
            }

            private int BinaryParse(string s)
            {
                return Convert.ToInt32(s, 2);
            }
        }

        public enum PacketType
        {
            Unknown,
            Literal,
            Operator
        }
    }
}