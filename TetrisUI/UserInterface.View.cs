using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using TetrisViewModel;

namespace TetrisUI
{
    public class NodeDrawble : Transformable, Drawable
    {
        private readonly List<NodeDrawble> nested = new();
        public readonly Vector2f Size;
        public readonly SFML.Graphics.Color FillColor;
        private readonly Text _text;

        public NodeDrawble(DrawInfo drawInfo, Vector2f parentPoint, Vector2f parentSize)
        {
            var ((x, y), (w, h), (r, g, b, a), rotate, text, nested) = drawInfo;
            x += w / 2.0;
            y += h / 2.0;
            var pos = new Vector2f((float)x * parentSize.X / 100f + parentPoint.X, (float)y * parentSize.Y / 100f + parentPoint.Y);
            var size = new Vector2f((float)w * parentSize.X / 100f, (float)h * parentSize.Y / 100f);

            Origin = new(size.X / 2, size.Y / 2);
            Position = pos;
            Size = size;
            FillColor = new(r, g, b, a);
            Rotation = rotate;

            if (!(text is null || text == ""))
            {
                _text = new();
                _text.DisplayedString = text;
                _text.FillColor = new(0, 0, 0, 255);
                _text.Font = UIConsts.Font;
            }

            if (nested is null) return;
            foreach (var nestedDrawInfo in nested)
                this.nested.Add(new(nestedDrawInfo, new(), Size));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            var shapeRect = default(FloatRect);

            using (var shape = new RectangleShape())
            {
                shape.Size = new(Size.X - 2, Size.Y - 2);
                shape.FillColor = FillColor;
                shape.Draw(target, states);

                shapeRect = shape.GetGlobalBounds();
            }

            var textRect = _text.GetGlobalBounds();
            _text.Position = new(
                 shapeRect.Left + (shapeRect.Width / 2) - (textRect.Width / 2),
                 shapeRect.Top + (shapeRect.Height / 2) - textRect.Height
                );
            _text.Draw(target, states);

            foreach (var di in nested)
                di.Draw(target, states);
        }
    }

    public partial class UserInterface : Transformable, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var drawInfo in _viewModel.GetDrawInfo())
                using(var drawble = new NodeDrawble(drawInfo))
                {
                    drawble.Draw(target, states);
                }
        }
    }
}
