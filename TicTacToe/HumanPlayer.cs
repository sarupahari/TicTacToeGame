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
                int playerInput;
                Console.WriteLine($"{PlayerValue} enter your move");

                // validate if user input is a number
                bool isNumberInput  = int.TryParse(Console.ReadLine(), out playerInput);

                if (isNumberInput)
                {

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
                else
                {
                    Console.WriteLine("Please enter a number between 1 to 9 inclusive.");
                }
            }
        }
    }
}
