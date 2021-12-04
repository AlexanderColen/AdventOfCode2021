using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day04
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 04 - Puzzle 1");
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
                foreach (var board in boards)
                {
                    foreach (var boardNumber in board.Numbers)
                    {
                        if (boardNumber.Number == bingoNumbers[i])
                        {
                            boardNumber.Marked = true;
                        }
                    }
                }

                winningBoard = FindWinningBoard(boards);
                if (winningBoard != null)
                {
                    winningNumber = int.Parse(bingoNumbers[i]);
                }
            }

            Console.WriteLine($"Outcome: {winningNumber * ScoreBoard(winningBoard)}");
        }

        private Board FindWinningBoard(List<Board> boards)
        {
            foreach (var board in boards)
            {
                var rowWin = true;
                var columnWin = true;
                for (var i = 0; i < 5; i++)
                {
                    rowWin = board.Numbers.Where(x => x.Y == i && x.Marked).Count() == 5;
                    columnWin = board.Numbers.Where(x => x.X == i && x.Marked).Count() == 5;

                    if (rowWin || columnWin)
                    {
                        return board;
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
