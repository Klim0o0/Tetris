using System;
using System.Linq;

namespace TetrisLogic.SimpleRuls
{
    public class Game : IGame
    {
        public int Width { get; }
        public int Height { get; }
        public int Score { get; } = 0;
        public bool IsCompleted { get; private set; } = false;

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

        public void UpdateState()
        {
            if (mino == null)
            {
                mino = minoFactory.CreateMino(new Random());
                IsCompleted = !IsCorrectPosition(mino.Blocks);
                return;
            }


            var tempMino = mino.MoveDown();
            if (!IsCorrectPosition(tempMino.Blocks))
            {
                FillStateMino(mino.Blocks);
                mino = null;
                return;
            }

            mino = tempMino;
        }

        public Block[] GetNextBlock()
        {
            throw new NotImplementedException();
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
            var t = new BlockColor[Width, Height];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    t[i, j] = stateBlocks[i, j];
                }
            }

            if (mino == null) return t;

            foreach (var block in mino.Blocks)
                t[block.X, block.Y] = block.Color;


            return t;
        }

        private bool IsCorrectPosition(Block[] blocks)
        {
            return blocks.All(block => block.X < Width && block.X >= 0 &&
                                       block.Y < Height && block.Y >= 0 &&
                                       stateBlocks[block.X, block.Y] == BlockColor.Base);
        }
    }
}