using SFML.Graphics;
using SFML.System;

namespace TetrisUI
{
    public partial class UserInterface : Transformable, Drawable
    {
        private readonly RectangleShape _fillShape = new();
        private readonly Text _text = new();

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var ((x, y), (w, h), (r, g, b, a), rotate, text) in _viewModel.GetDrawInfo())
            {
                var pos = new Vector2f((float)x * Size.X / 100f, (float)y * Size.Y / 100f);
                var size = new Vector2f((float)w * Size.X / 100f, (float)h * Size.Y / 100f);

                _fillShape.Position = pos;
                _fillShape.Size = size;
                _fillShape.FillColor = new(r, g, b, a);
                //_fillShape.Transform.

                _fillShape.Draw(target, states);

                if (text is null || text == "")
                {
                    _text.DisplayedString = text;
                    _text.Position = new(pos.X + size.X / 2 - (_text.GetLocalBounds().Width / 2), pos.Y + size.Y / 2 - (_text.GetLocalBounds().Height / 2));
                    _text.Font = UIConsts.Font;
                    //Text. = new((float)w * _size.X / 100f, (float)h * _size.Y / 100f);
                    //Text.FillColor = new(r, g, b, a);
                    
                    _text.Draw(target, states);
                }
            }

            //scoreFrame.Draw(target, states);
            //fieldFrame.Draw(target, states);
            //minoViewerFrame.Draw(target, states);
        }
    }
}
