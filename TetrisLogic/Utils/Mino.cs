using System;
using System.Linq;
using TetrisLogic.SimpleRuls;

namespace TetrisLogic
{
    public class Mino
    {
        public Block[] Blocks { get; }
        private readonly int center;

        public Mino(Block[] blocks, int center)
        {
            this.center = center;

            Blocks = blocks;
        }

        public Mino Rotate()
        {
            throw new NotImplementedException();
        }

        public Mino MoveLeft()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X - 1, block.Y, block.Color)).ToArray();
            return new Mino(tempBlocks, center);
        }

        public Mino MoveRight()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X + 1, block.Y, block.Color)).ToArray();
            return new Mino(tempBlocks, center);
        }

        public Mino MoveDown()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X, block.Y + 1, block.Color)).ToArray();
            return new Mino(tempBlocks, center);
        }
    }
}