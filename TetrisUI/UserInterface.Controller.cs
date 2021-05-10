using SFML.Graphics;
using System;
using System.Collections.Generic;
using static SFML.Window.Keyboard;
using TetrisViewModel;

namespace TetrisUI
{
    

    public partial class UserInterface : Transformable, Drawable
    {
        private readonly List<KeyEvent> UserKeyEvents = new();

        public void AddUserAction(Key key, KeyEventType keyEventType)
        {
            UserKeyEvents.Add(new(UIConsts.KeysByKeys[key], keyEventType));
        }

        public void Flush()
        {
            var ua = new UserAction(UserKeyEvents.ToArray(), Array.Empty<MouseEvent>());
            _viewModel.Update(ua);
            UserKeyEvents.Clear();
        }
    }
}
