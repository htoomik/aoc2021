using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day18
    {
        private static readonly string Nums = "0123456789";

        public int Solve(List<string> input)
        {
            var data = input.Select(s => Parse(s.ToCharArray()));



            return 0;
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }

        public static (Node, int) Parse(char[] chars, int i = 1, int level = 0, Node parent = null)
        {
            Node left;
            Node right;

            var value = chars[i];
            if (Nums.Contains(value))
            {
                left = new Node { Value = value - 48, Level = level };
                i++;
            }
            else if (value == '[')
            {
                (left, i) = Parse(chars, i + 1, level + 1);
                i++;
            }
            else
            {
                throw new Exception(value.ToString());
            }

            i++; // Comma

            var value2 = chars[i];
            if (Nums.Contains(value2))
            {
                right = new Node { Value = value2 - 48, Level = level};
                i++;
            }
            else if (value2 == '[')
            {
                (right, i) = Parse(chars, i + 1, level + 1);
                i++;
            }
            else
            {
                throw new Exception(value2.ToString());
            }

            var node = new Node() { Left = left, Right = right, Level = level};
            left.Parent = node;
            right.Parent = node;

            return (node, i);
        }

        public static void Reduce(Node node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Level == 4)
            {
                var nearestRegularToTheLeft = node.GetNearestRegularToTheLeft();
                if (nearestRegularToTheLeft != null)
                {
                    nearestRegularToTheLeft.Value += node.Left.Value;
                }

                var nearestRegularToTheRight = node.GetNearestRegularToTheRight();
                if (nearestRegularToTheRight != null)
                {
                    nearestRegularToTheRight.Value += node.Right.Value;
                }

                node.Left = null;
                node.Right = null;
                node.Value = 0;
            }
            else
            {
                Reduce(node.Left);
                Reduce(node.Right);
            }
        }

        public class Node
        {
            public Node Left;
            public Node Right;
            public int? Value;
            public Node Parent { get; set; }
            public int Level { get; set; }

            public override string ToString()
            {
                if (Value.HasValue)
                {
                    return Value.ToString();
                }

                return $"[{Left},{Right}]";
            }

            public Node GetNearestRegularToTheLeft()
            {
                if (Parent == null)
                {
                    return null;
                }

                if (Parent.Left.Value.HasValue)
                {
                    return Parent.Left;
                }

                return Parent.GetNearestRegularToTheLeft();

            }

            public Node GetNearestRegularToTheRight()
            {
                if (Parent == null)
                {
                    return null;
                }

                if (Parent.Right.Value.HasValue)
                {
                    return Parent.Right;
                }

                return Parent.GetNearestRegularToTheRight();

            }
        }
    }
}