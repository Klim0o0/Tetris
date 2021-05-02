using SFML.Graphics;
using System;
using System.Collections.Generic;
using static SFML.Window.Keyboard;

namespace TetrisUI
{
    

    public partial class UserInterface : Transformable, Drawable
    {
        private readonly List<Action<IGame>> UserActions = new();

        public void AddUserAction(Key key, KeyEventType keyEventType)
        {
            if (keyEventType == KeyEventType.Realesed && key == Key.S) UserActions.Add(g => g.ChangeSpeed());
            if (keyEventType == KeyEventType.Pressed)
            {
                if (key == Key.A) UserActions.Add(g => g.MoveLeft());
                if (key == Key.D) UserActions.Add(g => g.MoveRight());
                if (key == Key.S) UserActions.Add(g => g.ChangeSpeed());
                if (key == Key.Space) UserActions.Add(g => g.Rotate());
            }
        }

        public void Flush()
        {
            foreach (var action in UserActions)
                action(_game);
            UserActions.Clear();
        }
    }
}
