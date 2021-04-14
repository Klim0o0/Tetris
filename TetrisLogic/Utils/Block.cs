namespace TetrisLogic.SimpleRuls
{
    public class Block 
    {
        public Block(int blockX, int blockY, BlockColor blockColor)
        {
            X = blockX;
            Y = blockY;
            Color = blockColor;
        }

        public int X { get; }
        public int Y { get; }
        public BlockColor Color { get; }
    }
}