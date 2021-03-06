using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Code
{
    public class Day18
    {
        private static readonly string Nums = "0123456789";
        private List<Node> AllNodes = new List<Node>();

        public (string, int) Solve(List<string> input)
        {
            var data = input.Select(s => Parse(s.ToCharArray())).ToList();

            var agg = data[0];
            for (var i = 1; i < data.Count; i++)
            {
                // Console.WriteLine($"  {agg}");

                var add = data[i];
                // Console.WriteLine($"+ {add}");

                agg = Add(agg, add);
                // Console.WriteLine($"= {agg}");

                // Console.WriteLine();
            }

            return (agg.ToString(), agg.Magnitude);
        }

        private Node Add(Node left, Node right)
        {
            var newString = $"[{left},{right}]";
            var newNode = Parse(newString.ToCharArray());
            Reduce(newNode);
            return newNode;
        }

        public int Solve2(List<string> input)
        {
            var best = 0;
            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var (_, result) = Solve(new List<string> { input[i], input[j] });
                    if (result > best)
                    {
                        best = result;
                    }
                }
            }

            return best;
        }

        public Node Parse(char[] chars)
        {
            var (result, _) = ParseInner(chars, 1, 0);

            AllNodes = new List<Node>();
            AddRecursively(result);

            return result;
        }

        private void AddRecursively(Node node)
        {
            if (node == null)
            {
                return;
            }

            AllNodes.Add(node);
            AddRecursively(node.Left);
            AddRecursively(node.Right);
        }

        private static (Node, int) ParseInner(char[] chars, int i, int level)
        {
            Node left;
            Node right;

            var value = chars[i];
            if (Nums.Contains(value))
            {
                left = new Node { Value = value - 48, Level = level + 1 };
                i++;
            }
            else if (value == '[')
            {
                (left, i) = ParseInner(chars, i + 1, level + 1);
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
                right = new Node { Value = value2 - 48, Level = level + 1};
                i++;
            }
            else if (value2 == '[')
            {
                (right, i) = ParseInner(chars, i + 1, level + 1);
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

        public void Reduce(Node node)
        {
            var didStuff = true;
            while (didStuff)
            {
                didStuff = false;
                didStuff = didStuff || Explode(node.Left);
                didStuff = didStuff || Explode(node.Right);
                didStuff = didStuff || Split(node.Left);
                didStuff = didStuff || Split(node.Right);

                // Console.WriteLine(node);
            }
        }

        private bool Explode(Node node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Level == 4 && !node.Value.HasValue) // not already exploded
            {
                // Console.Write("Explode: ");

                var nearestRegularToTheLeft = node.Left.GetNearestRegularToTheLeft(AllNodes);
                if (nearestRegularToTheLeft != null)
                {
                    nearestRegularToTheLeft.Value += node.Left.Value;
                }

                var nearestRegularToTheRight = node.Right.GetNearestRegularToTheRight(AllNodes);
                if (nearestRegularToTheRight != null)
                {
                    nearestRegularToTheRight.Value += node.Right.Value;
                }

                AllNodes.Remove(node.Left);
                AllNodes.Remove(node.Right);
                node.Left = null;
                node.Right = null;
                node.Value = 0;

                return true;
            }

            var leftAborted = Explode(node.Left);

            if (leftAborted)
            {
                return true;
            }

            var rightAborted = Explode(node.Right);

            if (rightAborted)
            {
                return true;
            }

            return false;
        }

        private bool Split(Node node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value is >= 10)
            {
                // Console.Write("Split: ");
                var newLeftValue = node.Value.Value / 2;
                var newRightValue = (node.Value.Value + 1) / 2;

                node.Left = new Node { Value = newLeftValue, Level = node.Level + 1, Parent = node };
                node.Right = new Node { Value = newRightValue, Level = node.Level + 1, Parent = node };
                node.Value = null;

                var index = AllNodes.IndexOf(node) + 1;
                AllNodes.Insert(index, node.Right);
                AllNodes.Insert(index, node.Left);

                return true;
            }

            var leftAborted = Split(node.Left);

            if (leftAborted)
            {
                return true;
            }

            var rightAborted = Split(node.Right);

            if (rightAborted)
            {
                return true;
            }

            return false;
        }

        public class Node
        {
            public Node Left;
            public Node Right;
            public int? Value;
            public Node Parent { get; set; }
            public int Level { get; set; }

            public int Magnitude => Value ?? Left.Magnitude * 3 + Right.Magnitude * 2;

            public override string ToString()
            {
                if (Value.HasValue)
                {
                    return Value.ToString();
                }

                return $"[{Left},{Right}]";
            }

            public Node GetNearestRegularToTheLeft(List<Node> allNodes)
            {
                var index = allNodes.IndexOf(this);
                var candidates = allNodes.Take(index);
                var result = candidates.LastOrDefault(n => n.Value.HasValue);
                return result;
            }

            public Node GetNearestRegularToTheRight(List<Node> allNodes)
            {
                var index = allNodes.IndexOf(this);
                var candidates = allNodes.Skip(index + 1);
                var result = candidates.FirstOrDefault(n => n.Value.HasValue);
                return result;
            }
        }
    }
}