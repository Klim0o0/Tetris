using System;

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
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateJ()
            => new Mino(new[]
            {
                new Block(1, 0, BlockColor.Green),
                new Block(1, 1, BlockColor.Green),
                new Block(1, 2, BlockColor.Green),
                new Block(0, 2, BlockColor.Green)
            }, 2);

        private Mino CreateL()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Blue),
                new Block(0, 1, BlockColor.Blue),
                new Block(0, 2, BlockColor.Blue),
                new Block(1, 2, BlockColor.Blue)
            }, 1);

        private Mino CreateS()
            => new Mino(new[]
            {
                new Block(0, 1, BlockColor.Red),
                new Block(1, 1, BlockColor.Red),
                new Block(1, 0, BlockColor.Red),
                new Block(2, 0, BlockColor.Red)
            }, 1);

        private Mino CreateZ()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Orange),
                new Block(1, 0, BlockColor.Orange),
                new Block(1, 1, BlockColor.Orange),
                new Block(2, 1, BlockColor.Orange)
            }, 2);

        private Mino CreateO()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Purple),
                new Block(1, 0, BlockColor.Purple),
                new Block( 0, 1, BlockColor.Purple),
                new Block(1, 1, BlockColor.Purple)
            }, -1);

        private Mino CreateT()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.LightBlue),
                new Block(1, 0, BlockColor.LightBlue),
                new Block(2, 0, BlockColor.LightBlue),
                new Block(1, 1, BlockColor.LightBlue)
            }, 1);
    }
}