using SFML.Graphics;
using SFML.System;
using System;
using TetrisViewModel;

namespace TetrisUI
{
    public partial class UserInterface : Transformable, Drawable
    {
        private readonly BaseViewModel _viewModel;
        public Vector2f Size { get; init; }

        public UserInterface(BaseViewModel baseViewModel, Vector2f size)
        {
            Size = size;
            _viewModel = baseViewModel;
        }

        public void Update()
        {
            Flush();
        }
    }
}
