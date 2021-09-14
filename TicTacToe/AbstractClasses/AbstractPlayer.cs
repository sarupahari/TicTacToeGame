using TicTacToe.Enums;

namespace TicTacToe.AbstractClasses
{
    public abstract class AbstractPlayer
    {
        public abstract EnumPlayer PlayerValue { get; }
        public virtual EnumSquareValue SquareValue => EnumSquareValue.Default;
        public abstract int GetPlayMove(EnumSquareValue[] squares);
    }
}
