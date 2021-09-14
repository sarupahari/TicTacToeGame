using System;
using System.Linq;
using System.Text;
using TicTacToe.AbstractClasses;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class TicTacToeBoard : AbstractGameBoard
    {
        //private const int size = 3;
        //private SquareValue[,] squares = new SquareValue[size, size]
        //

        static EnumSquareValue[] tctBoard = new EnumSquareValue[9];


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
        public override string DisplayGameBoard()
        {
            StringBuilder sb = new StringBuilder();

            // extend this to be more dynamic

            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(tctBoard[0], 0)}  |  {SquareValueToString(tctBoard[1], 1)}  |  {SquareValueToString(tctBoard[2], 2)}");
            sb.AppendLine("_____|_____|_____ ");
            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(tctBoard[3], 3)}  |  {SquareValueToString(tctBoard[4], 4)}  |  {SquareValueToString(tctBoard[5], 5)}");
            sb.AppendLine("_____|_____|_____ ");
            sb.AppendLine("     |     |      ");
            sb.AppendLine($"  {SquareValueToString(tctBoard[6], 6)}  |  {SquareValueToString(tctBoard[7], 7)}  |  {SquareValueToString(tctBoard[8], 8)}");
            sb.AppendLine("     |     |      ");
            return sb.ToString();
        }

        private string SquareValueToString(EnumSquareValue value, int index)
        {
            switch (value)
            {
                case EnumSquareValue.Default:
                    return (index + 1).ToString();
                case EnumSquareValue.Human:
                    return "X";
                case EnumSquareValue.Computer:
                    return "O";
                default:
                    return string.Empty;
            }
        }

        public override void PrintBoardIntro()
        {
            // extension to handle  board size from  user input 
            Console.WriteLine("Welcome to TicTacoe Console app");            
            var columnsize = 0;
            Console.WriteLine("Please type the number of columns for the game board");
            columnsize = int.Parse(Console.ReadLine());
            
            while (columnsize != 3)
            {
                Console.WriteLine("Currently the game only support 3X3");
                Console.WriteLine("Please type the suported number columns for the game");
                columnsize = int.Parse(Console.ReadLine());
            }
        }

        public void Clear() 
        {
            for (int i = 0; i < tctBoard.Length; i++)
            {
                tctBoard[i] = EnumSquareValue.Default;
            }
        }

        public bool IsBoardFull()
        {
            return tctBoard.All(x => x != EnumSquareValue.Default);
        }

        public void PlayGame()
        {

            bool continueGame = true;
            while (continueGame)
            {
                PrintBoardIntro();
                Console.WriteLine(DisplayGameBoard());
                Random rand = new Random();
                int currentPlayerRandomValue = rand.Next(0, 2);
                EnumPlayer currentPlayer = (EnumPlayer)currentPlayerRandomValue;

                var token = currentPlayer == EnumPlayer.Player1 ? "X" : "O";


                Console.WriteLine($"The first moves belongs to {currentPlayer} and is assigned token {token}");

                AbstractPlayer playerX = new HumanPlayer();
                AbstractPlayer playerO = new ComputerPlayer();
                int playMove = 0;

                while (!IsWinner())
                {

                    if (currentPlayer == EnumPlayer.Player1)
                    {
                        playMove = playerX.GetPlayMove(tctBoard);
                    }
                    else if (currentPlayer == EnumPlayer.Player2)
                    {
                        playMove = playerO.GetPlayMove(tctBoard);

                    }

                    GetBoardWithPlayMove(playMove, currentPlayer);
                    Console.WriteLine(DisplayGameBoard());
                    if (IsWinner())
                    {
                        Console.WriteLine($"Congrats {currentPlayer}. You won!!");
                        break;
                    }
                    else if (IsBoardFull())
                    {
                        Console.WriteLine("It's a tie.");
                        break;
                    }
                    currentPlayer = GetNextPlayer(currentPlayer);
                }             
                continueGame = PlayAgain();
                if(continueGame)
                {
                    // initialize the borad with default value
                    Clear();
                }            
               
            }                  

        }

        static EnumPlayer GetNextPlayer(EnumPlayer player)
        {
            return (EnumPlayer)((((int)player) + 1) % 2);
        }

        public override bool IsWinner()
        {
            
            return winningCombinations.Any(square => HasWinnningCombinationWithSamePlayer(square[0], square[1], square[2]));
        }

        static bool HasWinnningCombinationWithSamePlayer(int a, int b, int c)
        {
            return tctBoard[a] != EnumSquareValue.Default && tctBoard[a] == tctBoard[b] && tctBoard[a] == tctBoard[c];
        }


        private void GetBoardWithPlayMove(int boardPosition, EnumPlayer player)
        {
            tctBoard[boardPosition] = GetSquareValueForPlayer(player);
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? Enter Y or N.");
            return Console.ReadKey(false).Key == ConsoleKey.Y;
        }


        private EnumSquareValue GetSquareValueForPlayer(EnumPlayer player)
        {
            switch (player)
            {
                case EnumPlayer.Player1:
                    return EnumSquareValue.Human;
                case EnumPlayer.Player2:
                    return EnumSquareValue.Computer;
                default:
                    return EnumSquareValue.Default;
            }
        }
    }
}
