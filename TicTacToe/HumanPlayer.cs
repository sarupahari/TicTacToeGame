using System;
using TicTacToe.AbstractClasses;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class HumanPlayer : AbstractPlayer
    {
        public override EnumPlayer PlayerValue => EnumPlayer.Player1;
        public override EnumSquareValue SquareValue => EnumSquareValue.Human;
        public override int GetPlayMove(EnumSquareValue[] squares)
        {
            while (true)
            {
                Console.WriteLine($"{PlayerValue} enter your move");
                var playerInput = int.Parse(Console.ReadLine());               

                if (playerInput >= 1 && playerInput <= 9)
                {
                    var formattedPlayerInput = playerInput - 1;
                    if (squares[formattedPlayerInput] == EnumSquareValue.Default)
                    {
                        return formattedPlayerInput;
                    }
                    else
                    {
                        Console.WriteLine($"Spot {playerInput} is taken. Please enter a new move");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid move");
                }
            }
        }
    }
}
