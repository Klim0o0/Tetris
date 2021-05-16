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
                new Size(Game.Width, Game.Height),
                new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B), 0, "Tetris Window",
                new List<DrawInfo>()
                {
                    new (new Point(0, 0), new Size(500, 500),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, "Tetris", 
                        CreateNestedElements(Game.GetActiveBlocks(), "", () => new List<DrawInfo>())),
                    new (new Point(0, 0), new Size(100, 100),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, "Next", 
                        CreateNestedElements(Game.GetNextBlock(), "", () => new List<DrawInfo>())),
                    new (new Point(0, 0), new Size(10, 10),
                        new Color(BlockColor.Base.R, BlockColor.Base.G, BlockColor.Base.B),
                        0, $"Score: {Game.Score}", new List<DrawInfo>())
                }
                );
        }

        private IEnumerable<DrawInfo> CreateNestedElements(
            IEnumerable<Block> blocks, string text, Func<IEnumerable<DrawInfo>> getNestedDraw)
        {
            return blocks.Select(
                b => new DrawInfo(
                    new Point(b.X, b.Y),
                    new Size(b.Size.Height, b.Size.Width),
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