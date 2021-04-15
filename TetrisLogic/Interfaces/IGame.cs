using TetrisLogic.SimpleRuls;

namespace TetrisLogic
{
    public interface IGame
    {
        int Width { get; }
        int Height { get; }
        int Score { get; }

        bool GameStep();
        Block[] GetCurrentBlock();
        void MoveLeft();
        void MoveRight();
        void Rotate();
        void ChangeSpeed();
        BlockColor[,] GetBlocks();
    }
}