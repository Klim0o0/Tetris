using System;
using System.Linq;

namespace TetrisLogic.SimpleRuls
{
    public class Game : IGame
    {
        public int Width { get; }
        public int Height { get; }
        public int Score { get; } = 0;

        private Mino mino;
        private BlockColor[,] stateBlocks;
        private int stepCount;
        private IMinoFactory minoFactory;

        public Game(IMinoFactory minoFactory, int width, int height, int stepCount)
        {
            this.minoFactory = minoFactory;
            Width = width;
            Height = height;
            this.stepCount = stepCount;
            stateBlocks = new BlockColor[width, height];
        }

        public void GameStep()
        {
            mino ??= minoFactory.CreateMino(new Random());

            for (var i = 0; i < stepCount; i++)
            {
                var tempMino = mino.MoveDown();
                if (!IsCorrectPosition(tempMino.Blocks))
                {
                    foreach (var block in mino.Blocks)
                    {
                        stateBlocks[block.X, block.Y] = block.Color;
                    }

                    mino = null;
                    return;
                }

                mino = tempMino;
            }
        }

        public void MoveLeft()
        {
            var tempMino = mino.MoveLeft();
            if (IsCorrectPosition(tempMino.Blocks))
                mino = tempMino;
        }

        public void MoveRight()
        {
            var tempMino = mino.MoveRight();
            if (IsCorrectPosition(tempMino.Blocks))
                mino = tempMino;
        }


        public void Rotate(bool direction)
        {
            var tempMino = mino.Rotate();
            if (IsCorrectPosition(tempMino.Blocks))
                mino = tempMino;
        }

        public void ChangeSpeed()
        {
            throw new System.NotImplementedException();
        }

        public BlockColor[,] GetBlocks()
        {
            return (BlockColor[,]) stateBlocks.Clone();
        }

        private bool IsCorrectPosition(Block[] blocks)
        {
            return blocks.All(block => block.X < Width && block.X >= 0 &&
                                       block.Y < Height && block.Y >= 0 &&
                                       stateBlocks[block.X, block.Y] == BlockColor.Base);
        }
    }
}