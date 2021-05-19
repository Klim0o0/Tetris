using System.Drawing;

namespace TetrisLogic.SimpleRuls
{
    public class Block 
    {
        public Block(int blockX, int blockY, BlockColor blockColor,  float rotate=0)
        {
            X = blockX;
            Y = blockY;
            Color = blockColor;
            Rotate = rotate;
        }

        public int X { get; }
        public int Y { get; }
        public float Rotate { get; }
        public BlockColor Color { get; }
    }
}