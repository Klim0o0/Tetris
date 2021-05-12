namespace TetrisLogic.Utils
{
    public abstract class AbstractBlock
    {
        public AbstractBlock(int blockX, int blockY, BlockColor blockColor)
        {
            X = blockX;
            Y = blockY;
            Color = blockColor;
        }

        public int X { get; set; }
        public int Y { get;set; }
        public BlockColor Color { get; }

        public AbstractBlock[] Blocks;

        public abstract void BlockAction(AbstractBlock[,] blocks);
    }
}