namespace TetrisLogic
{
    public interface IGame
    {
        int Width { get; }
        int Height { get; }
        int Score { get; }
        
        void GameStep();
        void MoveLeft();
        void MoveRight();
        void Rotate(bool direction);
        void ChangeSpeed();
        BlockColor[,] GetBlocks();
        
    }
}