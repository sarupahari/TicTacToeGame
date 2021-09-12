using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TicTacToe
{
    class Class1
    {
    }

    public class TicTacToeBoard : GameBoard
    {
        private const int size = 3;
        private SquareValue[,] squares = new SquareValue[size, size];


        public SquareValue GetFieldValue(int col, int row)
        {
            return squares[col, row];
        }

        public void SetFieldValue(int col, int row, SquareValue value)
        {
            squares[col, row] = value;
        }


        public override string DisplayGameBoard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(squares[0, 0], 0)}  |  {SquareValueToString(squares[0, 1], 1)}  |  {SquareValueToString(squares[0, 2], 2)}");
            sb.AppendLine("_____|_____|_____ ");
            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(squares[1, 0], 3)}  |  {SquareValueToString(squares[1, 1], 4)}  |  {SquareValueToString(squares[1, 2], 5)}");
            sb.AppendLine("_____|_____|_____ ");
            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(squares[2, 0], 6)}  |  {SquareValueToString(squares[2, 1], 7)}  |  {SquareValueToString(squares[2, 2], 8)}");
            sb.AppendLine("     |     |      ");
            return sb.ToString();
        }

        private string SquareValueToString(SquareValue value, int index)
        {
            switch (value)
            {
                case SquareValue.Default:
                    return index.ToString();
                case SquareValue.Human:
                    return "X";
                case SquareValue.Computer:
                    return "O";
                default:
                    return string.Empty;
            }
        }

        public override void PrintBoardIntro()
        {
            Console.WriteLine("Welcome to TicTacoe Console app");            
            var columnsize = 0;
            Console.WriteLine("Please type the number of columns for the game board");
            columnsize = int.Parse(Console.ReadLine());
            // only s
            while (columnsize != 3)
            {
                Console.WriteLine("Currently the game only support 3X3");
                Console.WriteLine("Plese type the suported number columns for the game");
                columnsize = int.Parse(Console.ReadLine());
            }
        }

        public override bool IsWinner()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class GameBoard
    {
        public abstract void PrintBoardIntro();
        public abstract string DisplayGameBoard();
        public abstract bool IsWinner();


    }
    public enum SquareValue
    {
        Default = 0,
        Human = 1,
        Computer = 2,
    }
}
