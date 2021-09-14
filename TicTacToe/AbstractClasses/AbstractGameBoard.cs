namespace TicTacToe.AbstractClasses
{
    public abstract class AbstractGameBoard
    {
        public abstract void PrintBoardIntro();
        public abstract string DisplayGameBoard();
        public abstract bool IsWinner();
    }
}
