using TetrisLogic.SimpleRuls;
using TetrisLogic.Utils;

namespace TetrisLogic
{
    public interface IGame
    {
        int Width { get; }
        int Height { get; }
        int Score { get; }
        
        bool IsCompleted { get; }

        void UpdateState();
        AbstractBlock[] GetNextBlock();
        void MoveLeft();
        void MoveRight();
        void Rotate();
        void ChangeSpeed();
        BlockColor[,] GetBlocks();
    }
}