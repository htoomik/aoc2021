using System;
using System.Collections.Generic;
using System.Linq;
using AoC2021.Helpers;

namespace AoC2021.Code
{
    public class Day04
    {
        public int Solve(string input)
        {
            var chunks = DataHelper.SplitLines(input, doubleBreak: true);
            var numbersDrawn = ParseNumbers(chunks.First());
            var boards = chunks.Skip(1).Select(ParseBoard).ToList();

            foreach (var number in numbersDrawn)
            {
                foreach (var board in boards)
                {
                    board.Mark(number);
                }

                var winner = boards.Where(b => b.HasBingo()).ToList();
                switch (winner.Count)
                {
                    case > 1:
                        throw new Exception();
                    case 1:
                        return winner.Single().Score(number);
                }
            }

            throw new Exception();
        }

        public int Solve2(string input)
        {
            var chunks = DataHelper.SplitLines(input, doubleBreak: true);
            var numbersDrawn = ParseNumbers(chunks.First());
            var boards = chunks.Skip(1).Select(ParseBoard).ToList();

            foreach (var number in numbersDrawn)
            {
                foreach (var board in boards)
                {
                    board.Mark(number);
                }

                var winners = boards.Where(b => b.HasBingo()).ToList();

                if (winners.Count == boards.Count)
                {
                    return winners.First().Score(number);
                }

                boards = boards.Except(winners).ToList();
            }

            throw new Exception();
        }

        private static List<int> ParseNumbers(string line)
        {
            return DataHelper.SplitToIntegers(line);
        }

        private Board ParseBoard(string chunk)
        {
            return Board.Parse(chunk);
        }

        private class Board
        {
            private readonly int _size;
            private readonly int[,] _values;
            private readonly bool[,] _marks;

            private Board(int[,] values, int size)
            {
                _size = size;
                _values = values;
                _marks = new bool[size, size];
            }

            public static Board Parse(string input)
            {
                var lines = DataHelper.SplitLines(input);
                var size = lines.Count;

                var values = new int[size, size];

                for (var i = 0; i < size; i++)
                {
                    var nums = DataHelper.SplitToIntegers(lines[i], ' ');
                    for (var j = 0; j < nums.Count; j++)
                    {
                        values[i, j] = nums[j];
                    }
                }

                return new Board(values, size);

            }

            public void Mark(int number)
            {
                for (var i = 0; i < _size; i++)
                {
                    for (var j = 0; j < _size; j++)
                    {
                        if (_values[i, j] == number)
                        {
                            _marks[i, j] = true;
                        }
                    }
                }
            }

            public bool HasBingo()
            {
                for (var i = 0; i < _size; i++)
                {
                    var rowTotal = 0;
                    var colTotal = 0;

                    for (var j = 0; j < _size; j++)
                    {
                        if (_marks[i, j])
                        {
                            rowTotal++;
                        }

                        if (_marks[j, i])
                        {
                            colTotal++;
                        }
                    }

                    if (rowTotal == _size ||
                        colTotal == _size)
                    {
                        return true;
                    }
                }

                return false;
            }

            public int Score(int number)
            {
                var total = 0;
                for (var i = 0; i < _size; i++)
                {
                    for (var j = 0; j < _size; j++)
                    {
                        if (!_marks[i, j])
                        {
                            total += _values[i, j];
                        }
                    }
                }

                return total * number;
            }
        }
    }
}