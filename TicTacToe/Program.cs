using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var tictactoeGame = new TicTacToeBoard();

            tictactoeGame.PlayGame();

        }
    }
}