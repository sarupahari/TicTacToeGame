using System;
using System.Linq;
using TicTacToe.AbstractClasses;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class ComputerPlayer : AbstractPlayer
    {
        static int[][] winningCombinations = new int[][] {
            // rows
           new int[] { 0, 1, 2 },
           new int[] { 3, 4, 5 },
           new int[] { 6, 7, 8 },
            //columns
           new int[] { 0, 3, 6 },
           new int[] { 1, 4, 7 },
           new int[] { 2, 5, 8 },
            //diagonal
           new int[] { 0, 4, 8 },
           new int[] { 2, 4, 6 }
        };

        public override EnumPlayer PlayerValue => EnumPlayer.Player2;

        public override EnumSquareValue SquareValue => EnumSquareValue.Computer;

        public override int GetPlayMove(EnumSquareValue[] squares)
        {
            int selectedMove = GetComputerPlayMove(squares);
            Console.WriteLine($"{PlayerValue} selects position {selectedMove + 1}.");
            return selectedMove;
        }

        public int GetComputerPlayMove(EnumSquareValue[] squares)
        {
            int computerPosition;
            if (EvaluateWinningMove(SquareValue, squares, out computerPosition))
            {
                return computerPosition;
            }
            if (EvaluateBlockingMove(SquareValue, squares, out computerPosition))
            {
                return computerPosition;
            }
            return GetRandomMove(SquareValue, squares);
        }

        private int GetRandomMove(EnumSquareValue value, EnumSquareValue[] squares)
        {
            Random rnd = new Random();
            int availableMoves = squares.Count(position => position == EnumSquareValue.Default);
            int x = rnd.Next(0, availableMoves);

            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i] == EnumSquareValue.Default && x < 0)
                    return i;
                x--;
            }
            return -1 ;
        }

         private bool EvaluateWinningMove(EnumSquareValue value, EnumSquareValue[] squares, out int posToPlay)
         {
            posToPlay = -1;
            foreach (var line in winningCombinations)
                if (EvaluteTwoSquareWithMatchingValue(value, line, squares, out posToPlay))
                    return true;
            return false;
         }

        private bool EvaluteTwoSquareWithMatchingValue(EnumSquareValue value, int[] line, EnumSquareValue[] squares, out int computerPositionToPlay)
        {

            // find for two match paosition
            int  count= 0;
            computerPositionToPlay = int.MinValue;
            foreach (int pos in line)
            {
                if (squares[pos] == value)
                    count++;
                else if (squares[pos] == EnumSquareValue.Default)
                    computerPositionToPlay = pos;
            }
            return count == 2 && computerPositionToPlay >= 0;
        }


        private bool EvaluateBlockingMove(EnumSquareValue value, EnumSquareValue[] squares, out int computerPositionToPlay)
        {
            computerPositionToPlay = -1;
            
            foreach (var line in winningCombinations)
                if (EvaluteTwoSquareWithMatchingValue((EnumSquareValue)(GetNextPlayer((int)value)), line,  squares, out computerPositionToPlay))
                    return true;
            return false;
        }

        private int GetNextPlayer(int player)
        {
            return (player + 1) % 2;
        }
    }
}
