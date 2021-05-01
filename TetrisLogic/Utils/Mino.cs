using System;
using System.Collections.Generic;
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
            if (center < 0)
                return new Mino(Blocks.Select(x => new Block(x.X, x.Y, x.Color)).ToArray(), -1);

            var centerBlock = new Block(Blocks[center].X, Blocks[center].Y, Blocks[center].Color);
            var blocks = new List<Block>();

            foreach (var block in Blocks.Where((x, i) => i != center))
            {
                var tempBloсk = new Block(centerBlock.X - block.X, centerBlock.Y - block.Y, block.Color);
                blocks.Add(new Block(centerBlock.X + tempBloсk.Y, centerBlock.Y - tempBloсk.X, tempBloсk.Color));
            }

            blocks.Add(centerBlock);
            return new Mino(blocks.ToArray(), blocks.Count - 1);
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