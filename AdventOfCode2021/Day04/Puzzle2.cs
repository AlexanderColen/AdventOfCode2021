using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day04
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 04 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day04/input.txt");
            string[] bingoNumbers = null;
            var boards = new List<Board>();
            Board currentBoard = null;
            var y = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (bingoNumbers == null)
                {
                    bingoNumbers = line.Split(',');
                }
                else
                {
                    if (currentBoard == null)
                    {
                        currentBoard = new Board();
                    }

                    if (line != "")
                    {
                        var newNumbers = line.Split(' ').Where(x => x != "").ToList();
                        for (var x = 0; x < newNumbers.Count; x++)
                        {
                            currentBoard.Numbers.Add(new BoardNumber(x, y, newNumbers[x]));
                        }
                        y++;
                    }

                    if (y == 5)
                    {
                        boards.Add(currentBoard);
                        currentBoard = null;
                        y = 0;
                    }
                }
            }

            var winningNumber = 0;
            Board winningBoard = null;
            for (var i = 0; i < bingoNumbers.Count() && winningBoard == null; i++)
            {
                foreach (var board in boards.Where(x => !x.hasWon))
                {
                    foreach (var boardNumber in board.Numbers.Where(x => x.Number == bingoNumbers[i]))
                    {
                        boardNumber.Marked = true;
                    }
                }

                winningBoard = FindWinningBoard(boards.Where(x => !x.hasWon).ToList());
                if (winningBoard != null)
                {
                    winningNumber = int.Parse(bingoNumbers[i]);
                }
            }

            Console.WriteLine($"Outcome: {winningNumber * ScoreBoard(winningBoard)}");
        }

        private Board FindWinningBoard(List<Board> boards)
        {
            if (boards.Count() == 1)
            {
                return boards.Where(x => !x.hasWon).ToList()[0];
            }

            foreach (var board in boards)
            {
                for (var i = 0; i < 5; i++)
                {
                    var rowWin = board.Numbers.Where(x => x.Y == i && x.Marked).Count() == 5;
                    var columnWin = board.Numbers.Where(x => x.X == i && x.Marked).Count() == 5;

                    if (rowWin || columnWin)
                    {
                        board.hasWon = true;
                    }
                }
            }

            return null;
        }

        private int ScoreBoard(Board board)
        {
            var score = 0;

            foreach (var boardNumber in board.Numbers.Where(x => !x.Marked))
            {
                score += int.Parse(boardNumber.Number);
            }

            return score;
        }
    }
}
