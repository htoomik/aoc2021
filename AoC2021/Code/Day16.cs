using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day16
    {
        public Packet Parse(string line)
        {
            return new Packet(HexToBinary(line));
        }

        public long Solve(string input)
        {
            var packet = Parse(input.Trim());
            return packet.VersionSum();
        }

        public long Solve2(string input)
        {
            var packet = Parse(input.Trim());
            return packet.Evaluate();
        }

        public class Packet
        {
            public long Version { get; }
            public PacketType Type { get; }
            public int LengthType { get; }
            public long Value { get; }
            public int CharsConsumed { get; }
            public List<Packet> SubPackets { get; } = new List<Packet>();

            public long VersionSum()
            {
                return Version + SubPackets.Sum(p => p.VersionSum());
            }

            public Packet(string binary)
            {
                var versionString = binary.Substring(0, 3);
                Version = BinaryParse(versionString);

                var typeString = binary.Substring(3, 3);
                var typeValue = BinaryParse(typeString);
                Type = (PacketType)typeValue;

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
                    Value = value;
                    CharsConsumed = pos;
                }
                else
                {
                    var lengthTypeIdString = binary.Substring(6, 1);
                    LengthType = Convert.ToInt32(lengthTypeIdString);
                    if (LengthType == 0)
                    {
                        var nextFifteen = binary.Substring(7, 15);
                        var totalSubPacketLength = (int)BinaryParse(nextFifteen);

                        var remainder = binary.Substring(22, totalSubPacketLength);
                        var consumedBySubPackets = 0;

                        while (true)
                        {
                            var subPacket = new Packet(remainder);
                            SubPackets.Add(subPacket);
                            var consumed = subPacket.CharsConsumed;
                            consumedBySubPackets += consumed;
                            remainder = remainder.Substring(consumed);
                            if (consumedBySubPackets == totalSubPacketLength)
                            {
                                break;
                            }
                        }

                        CharsConsumed = 6 + 1 + 15 + consumedBySubPackets;
                    }
                    else if (LengthType == 1)
                    {
                        var nextEleven = binary.Substring(7, 11);
                        var subPacketCount = BinaryParse(nextEleven);

                        var remainder = binary.Substring(18);
                        var consumedBySubPackets = 0;

                        for (var i = 0; i < subPacketCount; i++)
                        {
                            var subPacket = new Packet(remainder);
                            SubPackets.Add(subPacket);
                            var consumed = subPacket.CharsConsumed;
                            consumedBySubPackets += consumed;
                            remainder = remainder.Substring(consumed);
                        }

                        CharsConsumed = 6 + 1 + 11 + consumedBySubPackets;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            private long BinaryParse(string s)
            {
                return Convert.ToInt64(s, 2);
            }

            public long Evaluate()
            {
                switch (Type)
                {
                    case PacketType.Literal: return Value;
                    case PacketType.Sum: return SubPackets.Sum(s => s.Evaluate());
                    case PacketType.Product: return SubPackets.Aggregate(1L, (i, packet) => i * packet.Evaluate());
                    case PacketType.Minimum: return SubPackets.Min(s => s.Evaluate());
                    case PacketType.Maximum: return SubPackets.Max(s => s.Evaluate());
                    case PacketType.GreaterThan: return SubPackets[0].Evaluate() > SubPackets[1].Evaluate() ? 1 : 0;
                    case PacketType.LessThan: return SubPackets[0].Evaluate() < SubPackets[1].Evaluate() ? 1 : 0;
                    case PacketType.EqualTo: return SubPackets[0].Evaluate() == SubPackets[1].Evaluate() ? 1 : 0;
                    default: throw new Exception();
                }
            }
        }

        private string HexToBinary(string s)
        {
            return string.Join(
                string.Empty,
                s.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))
            );
        }

        public enum PacketType
        {
            Sum = 0,
            Product = 1,
            Minimum = 2,
            Maximum = 3,
            Literal = 4,
            GreaterThan = 5,
            LessThan = 6,
            EqualTo = 7
        }
    }
}