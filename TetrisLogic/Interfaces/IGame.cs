using TetrisLogic.SimpleRuls;

namespace TetrisLogic
{
    public interface IGame
    {
        int Width { get; }
        int Height { get; }
        int Score { get; }
        
        bool IsCompleted { get; }

        void UpdateState();
        Block[] GetNextBlock();
        void MoveLeft();
        void MoveRight();
        void Rotate();
        void ChangeSpeed();
        BlockColor[,] GetBlocks();
    }
}