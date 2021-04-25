using SFML.Graphics;
using SFML.System;

namespace TetrisUI.Frames
{
    public class ScoreFrame : Transformable, Drawable
    {
        private readonly RectangleShape FillShape;
        private Text text;
        private readonly Vector2f _setoff;

        public ScoreFrame( Vector2f setoff)
        {
            _setoff = setoff;
            FillShape = new(new Vector2f(4 * UIConsts.CellLength, UIConsts.CellLength));
            FillShape.FillColor = Color.White;
            FillShape.Position = new(setoff.X * UIConsts.CellLength, setoff.Y * UIConsts.CellLength);
        }

        public void Update(int score)
        {
            text = new(score.ToString(), UIConsts.Font, 18);
            text.FillColor = Color.Black;
            text.Position = new(_setoff.X * UIConsts.CellLength, _setoff.Y * UIConsts.CellLength);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            FillShape.Draw(target, states);
            text?.Draw(target, states);
        }
    }
}
