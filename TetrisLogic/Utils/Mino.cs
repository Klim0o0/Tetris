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
            //не работает
            var centerBlock = Blocks[center];
            return new Mino(Blocks.Where((x, i) => i != center)
                    .Select(block => new Block(
                        centerBlock.X + centerBlock.Y - block.Y,
                        block.Y + centerBlock.X - centerBlock.Y,
                        block.Color)).Append(centerBlock).ToArray(),
                center);
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