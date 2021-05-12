using System;
using TetrisLogic.Utils;

namespace TetrisLogic.SimpleRuls
{
    public class TetraminoFactory : IMinoFactory
    {
        public Mino CreateMino(Random random)
        {
            switch (random.Next(1, 8))
            {
                case 1:
                    return CreateI();
                case 2:
                    return CreateJ();
                case 3:
                    return CreateL();
                case 4:
                    return CreateO();
                case 5:
                    return CreateZ();
                case 6:
                    return CreateS();
                case 7:
                    return CreateT();
            }

            return null;
        }


        private Mino CreateI()
        {
            var block1 = new SimpleBlock(0, 0, BlockColor.Yellow);
            var block2 = new SimpleBlock(1, 0, BlockColor.Yellow);
            var block3 = new SimpleBlock(2, 0, BlockColor.Yellow);
            var block4 = new SimpleBlock(3, 0, BlockColor.Yellow);

            return new Mino(new[] {block1, block2, block3, block4}, 2);
        }

        private Mino CreateJ()
        {
            var block1 = new SimpleBlock(1, 0, BlockColor.Green);
            var block2 = new SimpleBlock(1, 1, BlockColor.Green);
            var block3 = new SimpleBlock(1, 2, BlockColor.Green);
            var block4 = new SimpleBlock(0, 2, BlockColor.Green);


            return new Mino(new[] {block1, block2, block3, block4}, 2);
        }


        private Mino CreateL()
        {
            var block1 = new SimpleBlock(0, 0, BlockColor.Blue);
            var block2 = new SimpleBlock(0, 1, BlockColor.Blue);
            var block3 = new SimpleBlock(0, 2, BlockColor.Blue);
            var block4 = new SimpleBlock(1, 2, BlockColor.Blue);


            return new Mino(new[] {block1, block2, block3, block4}, 1);
        }


        private Mino CreateS()
        {
            var block1 = new SimpleBlock(0, 1, BlockColor.Red);
            var block2 = new SimpleBlock(1, 1, BlockColor.Red);
            var block3 = new SimpleBlock(1, 0, BlockColor.Red);
            var block4 = new SimpleBlock(2, 0, BlockColor.Red);


            return new Mino(new[] {block1, block2, block3, block4}, 1);
        }


        private Mino CreateZ()
        {
            var block1 = new SimpleBlock(0, 0, BlockColor.Orange);
            var block2 = new SimpleBlock(1, 0, BlockColor.Orange);
            var block3 = new SimpleBlock(1, 1, BlockColor.Orange);
            var block4 = new SimpleBlock(2, 1, BlockColor.Orange);


            return new Mino(new[] {block1, block2, block3, block4}, 2);
        }


        private Mino CreateO()
        {
            var block1 = new SimpleBlock(0, 0, BlockColor.Purple);
            var block2 = new SimpleBlock(1, 0, BlockColor.Purple);
            var block3 = new SimpleBlock(0, 1, BlockColor.Purple);
            var block4 = new SimpleBlock(1, 1, BlockColor.Purple);

            return new Mino(new[] {block1, block2, block3, block4}, -1);
        }


        private Mino CreateT()
        {
            var block1 = new SimpleBlock(0, 0, BlockColor.LightBlue);
            var block2 = new SimpleBlock(1, 0, BlockColor.LightBlue);
            var block3 = new SimpleBlock(2, 0, BlockColor.LightBlue);
            var block4 = new SimpleBlock(1, 1, BlockColor.LightBlue);

            return new Mino(new[] {block1, block2, block3, block4}, 1);
        }
    }
}