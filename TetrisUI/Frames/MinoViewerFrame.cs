using SFML.Graphics;
using SFML.System;
using System;
using System.Linq;

namespace TetrisUI.Frames
{
    public class MinoViewerFrame : Transformable, Drawable
    {
        private readonly Vector2f _setoff;
        private readonly RectangleShape FillShape;
        //private Block[] blocks = Array.Empty<Block>();

        //private Vector2f blocksSetoff;

        public MinoViewerFrame()
        {
            //_setoff = setoff;
            FillShape = new(new Vector2f(UIConsts.CellLength - 1, UIConsts.CellLength - 1));
        }

        public void Update()
        {
            //if (blocks.SequenceEqual(this.blocks)) return;
            //this.blocks = blocks;

            //var xBlockSetoff = (4 * UIConsts.CellLength - (blocks.Select(x => x.X).Max() - blocks.Select(x => x.X).Min())) / 2;
            //var yBlockSetoff = (4 * UIConsts.CellLength - (blocks.Select(x => x.Y).Max() - blocks.Select(x => x.Y).Min())) / 2;
            //blocksSetoff = new(xBlockSetoff, yBlockSetoff);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            //if (blocks is null) return;
            //foreach (var block in blocks)
            //{
            //    FillShape.FillColor = UIConsts.Colors[block.Color];
            //    FillShape.Position = new(blocksSetoff.X + (_setoff.X + block.X) * UIConsts.CellLength + 1, blocksSetoff.Y + (_setoff.Y + block.Y) * UIConsts.CellLength + 1);
            //    FillShape.Draw(target, states);
            //}
        }
    }
}
