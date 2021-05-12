using TetrisLogic.Utils;

namespace TetrisLogic.SimpleRuls
{
    public class SimpleBlock : AbstractBlock
    {
        public SimpleBlock(int blockX, int blockY, BlockColor blockColor) : base(blockX, blockY, blockColor)
        {
        }


        public override void BlockAction(AbstractBlock[,] blocks)
        {
        }
    }
}