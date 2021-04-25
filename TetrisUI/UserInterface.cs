using SFML.Graphics;
using System;
using TetrisLogic;
using TetrisLogic.SimpleRuls;
using TetrisUI.Frames;

namespace TetrisUI
{
    public partial class UserInterface : Transformable, Drawable
    {
        private readonly IGame _game;
        private readonly FieldFrame fieldFrame;
        private readonly ScoreFrame scoreFrame;
        private readonly MinoViewerFrame minoViewerFrame;

        public UserInterface(IGame game)
        {
            _game = game;
            fieldFrame = new(game, new(1, 1));
            scoreFrame = new(new(game.Width + 2, 2));
            minoViewerFrame = new(new(game.Width, game.Height - 4));
        }

        public void Update()
        {
            Flush();
            fieldFrame.Update();
            scoreFrame.Update(_game.Score);
            minoViewerFrame.Update(new TetraminoFactory().CreateMino(new Random()).Blocks);
        }
    }
}
