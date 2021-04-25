using SFML.Graphics;

namespace TetrisUI
{
    public partial class UserInterface : Transformable, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            scoreFrame.Draw(target, states);
            fieldFrame.Draw(target, states);
            minoViewerFrame.Draw(target, states);
        }
    }
}
