using System;

namespace TetrisLogic.SimpleRuls
{
    public class TetraminoFactory : IMinoFactory
    {
        public Mino CreateMino(Random random)
        {
            switch (random.Next(1, 7))
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
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateL()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateS()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateZ()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateO()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);

        private Mino CreateT()
            => new Mino(new[]
            {
                new Block(0, 0, BlockColor.Yellow),
                new Block(1, 0, BlockColor.Yellow),
                new Block(2, 0, BlockColor.Yellow),
                new Block(3, 0, BlockColor.Yellow)
            }, 2);
    }
}