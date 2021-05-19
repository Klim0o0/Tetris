using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TetrisLogic;
using TetrisLogic.SimpleRuls;

namespace TetrisViewModel
{
    public class ViewModel : BaseViewModel
    {
        public ViewModel(IGame game) : base(game)
        {
        }

        public override DrawInfo GetDrawInfo()
        {
            return new (
                new Point(0, 0), 
                new Size(100, 100),
                new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B), 0, "Tetris Window",
                new List<DrawInfo>()
                {
                    new (new Point(10, 10), new Size(60, 90),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, "Tetris", 
                        CreateNestedElements(
                            Game.GetActiveBlocks(), "", 
                            () => new List<DrawInfo>(),
                            block => new Point(100 / block.X, 100 /block.Y),
                            block =>new Size(100 / Game.Width, 100 / Game.Height))),
                    new (new Point(80, 10), new Size(40, 40),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, "Next", 
                        CreateNestedElements(
                            Game.GetNextBlock(), "", 
                            () => new List<DrawInfo>(),
                            block => new Point(100 / block.X, 100 /block.Y),
                            block =>new Size(100 / Game.Width, 100 / Game.Height))),
                    new (new Point(80, 60), new Size(30, 30),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, $"Score: {Game.Score}", new List<DrawInfo>())
                }
                );
        }

        private IEnumerable<DrawInfo> CreateNestedElements(
            IEnumerable<Block> blocks, string text, 
            Func<IEnumerable<DrawInfo>> getNestedDraw,
            Func<Block, Point> createPoint,
            Func<Block, Size> createSize)
        {
            return blocks.Select(
                b => new DrawInfo(
                    createPoint(b),
                    createSize(b),
                    new Color(b.Color.R, b.Color.G, b.Color.B),
                    b.Rotate, text, getNestedDraw())
            );
        }

        public override void Update(UserAction userAction)
        {
            throw new NotImplementedException();
        }
    }
}