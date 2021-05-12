using System;
using System.Collections.Generic;
using System.Linq;
using TetrisLogic.SimpleRuls;
using TetrisLogic.Utils;

namespace TetrisLogic
{
    public class Mino
    {
        public AbstractBlock[] Blocks { get; }
        private readonly int center;

        public Mino(AbstractBlock[] blocks, int center)
        {
            foreach (var block in blocks)
            {
                block.Blocks = blocks.Where(b => b != block).ToArray();
            }

            this.center = center;

            Blocks = blocks;
        }

        public void Rotate()
        {
            if (center < 0)
                return;

            foreach (var block in Blocks.Where((x, i) => i != center))
            {
                var x = Blocks[center].X + Blocks[center].Y - block.Y;
                var y = Blocks[center].Y - (Blocks[center].X - block.X);
                block.X = x;
                block.Y = y;
            }
        }

        public void MoveLeft()
        {
            foreach (var block in Blocks)
            {
                block.X--;
            }
        }

        public void MoveRight()
        {
            foreach (var block in Blocks)
            {
                block.X++;
            }
        }

        public void MoveDown()
        {
            foreach (var block in Blocks)
            {
                block.Y++;
            }
        }
    }
}