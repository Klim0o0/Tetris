using System.Drawing;

namespace TetrisLogic.SimpleRuls
{
    public class Block 
    {
        public Block(int blockX, int blockY, BlockColor blockColor,  Size size, float rotate=0)
        {
            X = blockX;
            Y = blockY;
            Color = blockColor;
            Rotate = rotate;
            Size = size;
        }

        public int X { get; }
        public int Y { get; }
        public float Rotate { get; }
        public Size Size { get; }
        public BlockColor Color { get; }
    }
}