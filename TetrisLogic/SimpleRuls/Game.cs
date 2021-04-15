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
        private IMinoFactory minoFactory;

        public Game(IMinoFactory minoFactory, int width, int height)
        {
            this.minoFactory = minoFactory;
            Width = width;
            Height = height;
            stateBlocks = new BlockColor[width, height];
        }

        public bool GameStep()
        {
            if (mino == null)
            {
                mino = minoFactory.CreateMino(new Random());
                return IsCorrectPosition(mino.Blocks);
            }


            var tempMino = mino.MoveDown();
            if (!IsCorrectPosition(tempMino.Blocks))
            {
                FillStateMino(mino.Blocks);
                mino = null;
                return true;
            }

            mino = tempMino;
            return true;
        }

        public Block[] GetCurrentBlock()
        {
            return mino != null ? mino.Blocks : Array.Empty<Block>();
        }

        private void FillStateMino(Block[] blocks)
        {
            foreach (var block in blocks)
            {
                stateBlocks[block.X, block.Y] = block.Color;
            }
        }


        public void MoveLeft()
        {
            if (mino == null)
                return;
            var tempMino = mino.MoveLeft();
            if (IsCorrectPosition(tempMino.Blocks))
                mino = tempMino;
        }

        public void MoveRight()
        {
            if (mino == null)
                return;
            var tempMino = mino.MoveRight();
            if (IsCorrectPosition(tempMino.Blocks))
                mino = tempMino;
        }


        public void Rotate()
        {
            if (mino == null)
                return;
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