using System;
using System.Drawing;
using System.Linq;
using TetrisLogic.Utils;

namespace TetrisLogic.SimpleRuls
{
    public class Game : IGame
    {
        public int Width { get; }
        public int Height { get; }
        public int Score { get; private set; } = 0;
        public bool IsCompleted { get; private set; } = false;

        private Mino mino;
        private BlockColor[,] stateBlocks;
        private IMinoFactory minoFactory;
        private Mino nextBlock;

        public Game(IMinoFactory minoFactory, int width, int height)
        {
            this.minoFactory = minoFactory;
            Width = width;
            Height = height;
            stateBlocks = new BlockColor[width, height];
        }

        public void UpdateState()
        {
            nextBlock ??= minoFactory.CreateMino(new Random());

            if (mino == null)
            {
                mino = nextBlock;
                nextBlock = minoFactory.CreateMino(new Random());
                IsCompleted = !IsCorrectPosition(mino.Blocks);
                return;
            }


            MoveDown();
        }

        private void MoveDown()
        {
            mino.MoveDown();
            if (IsCorrectPosition(mino.Blocks)) return;
            FillStateMino(mino.Blocks);
            mino = null;
            TryDellLines();
        }

        private void TryDellLines()
        {
            for (var y = Height - 1; y >= 0; y--)
            {
                if (IsFullLine(y))
                {
                    Score += Width;
                    for (var x = 0; x < Width; x++)
                    {
                        stateBlocks[x, y] = BlockColor.Base;
                    }

                    for (var j = y; j >= 1; j--)
                    {
                        for (var x = 0; x < Width; x++)
                        {
                            stateBlocks[x, j] = stateBlocks[x, j - 1];
                        }
                    }
                }
            }
        }

        private bool IsFullLine(int y)
        {
            for (var x = 0; x < Width; x++)
            {
                if (stateBlocks[x, y] == BlockColor.Base)
                    return false;
            }

            return true;
        }


        public AbstractBlock[] GetNextBlock()
        {
            return nextBlock == null ? new AbstractBlock[] { } : nextBlock.Blocks;
        }


        private void FillStateMino(AbstractBlock[] blocks)
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
            mino.MoveLeft();
            if (!IsCorrectPosition(mino.Blocks))
                mino.MoveRight();
        }

        public void MoveRight()
        {
            if (mino == null)
                return;
            mino.MoveRight();
            if (!IsCorrectPosition(mino.Blocks))
                mino.MoveLeft();
        }


        public void Rotate()
        {
            if (mino == null)
                return;
            mino.Rotate();
            if (!IsCorrectPosition(mino.Blocks))
            {
                mino.Rotate();
                mino.Rotate();
                mino.Rotate();
            }
        }

        public void ChangeSpeed()
        {
            while (true)
            {
                if (mino == null)
                    return;
                MoveDown();
            }
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

        public Point[] GetDeletedBlocks { get; }

        private bool IsCorrectPosition(AbstractBlock[] blocks)
        {
            return blocks.All(block => block.X < Width && block.X >= 0 &&
                                       block.Y < Height && block.Y >= 0 &&
                                       stateBlocks[block.X, block.Y] == BlockColor.Base);
        }
    }
}