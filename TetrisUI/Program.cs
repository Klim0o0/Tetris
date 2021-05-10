using System;
using TetrisLogic.SimpleRuls;

namespace TetrisUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new TetraminoFactory(), 10, 20);
            new GameLoop(new(null, new(600f, 800f))).Run();
        }
    }
}
