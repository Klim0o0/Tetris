using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using TetrisLogic;
using TetrisLogic.SimpleRuls;

namespace TetrisUI
{
    public class FieldFrame : Transformable, Drawable
    {
        private readonly Vector2f _setoff;
        private readonly IGame _game;
        private readonly RectangleShape FillShape;
        private BlockColor[,] sourceBlocks;
        private List<Block> blocks = new();
        private bool firstDraw = true;

        public FieldFrame(IGame game, Vector2f setoff)
        {
            _setoff = setoff;   
            _game = game;
            sourceBlocks = game.GetBlocks();
            for (var i = 0; i < sourceBlocks.GetLength(0); i++)
                for (var j = 0; j < sourceBlocks.GetLength(1); j++)
                    blocks.Add(new(i, j, sourceBlocks[i, j]));

            FillShape = new(new Vector2f(UIConsts.CellLength - 1, UIConsts.CellLength - 1));            
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            firstDraw = false;
            foreach (var block in blocks)
            {
                FillShape.Position = new((_setoff.X + block.X) * UIConsts.CellLength + 1, (_setoff.Y + block.Y) * UIConsts.CellLength + 1);
                FillShape.FillColor = UIConsts.Colors[block.Color];
                FillShape.Draw(target, states);
            }
        }

        public void Update()
        {
            if (firstDraw) return;
            blocks = new();
            var newBlocks = _game.GetBlocks();
            for (var i = 0; i < sourceBlocks.GetLength(0); i++)
            {
                for (var j = 0; j < sourceBlocks.GetLength(1); j++)
                {
                    //if (sourceBlocks[i, j] != newBlocks[i, j]) 
                        blocks.Add(new(i, j, newBlocks[i, j]));
                }
            }
            sourceBlocks = newBlocks;
        }
    }
}
