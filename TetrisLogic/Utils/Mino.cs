using System;
using System.Linq;
using TetrisLogic.SimpleRuls;

namespace TetrisLogic
{
    public class Mino
    {
        public Block[] Blocks { get; }

        private readonly IMinoFactory minoFactory;
        private readonly int center;
        
        public Mino(Block[] blocks, int center, IMinoFactory minoFactory)
        {
            this.center = center;
            this.minoFactory = minoFactory;
            Blocks = blocks;
        }

        public Mino Rotate()
        {
            throw new NotImplementedException();
        }

        public Mino MoveLeft()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X - 1, block.Y, block.Color)).ToArray();
            return new Mino(tempBlocks, center, minoFactory);
        }

        public Mino MoveRight()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X + 1, block.Y, block.Color)).ToArray();
            return new Mino(tempBlocks, center, minoFactory);
        }

        public Mino MoveDown()
        {
            var tempBlocks = Blocks.Select(block => new Block(block.X, block.Y + 1, block.Color)).ToArray();
            return new Mino(tempBlocks, center, minoFactory);
        }
    }
}