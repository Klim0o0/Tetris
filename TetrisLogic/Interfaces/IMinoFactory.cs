using System;
using TetrisLogic.SimpleRuls;

namespace TetrisLogic
{
    public interface IMinoFactory
    {
        Mino CreateMino(Random random);
    }
}