using SFML.Graphics;
using SFML.Window;
using System;
using Color = SFML.Graphics.Color;

namespace TetrisUI
{
    public class GameLoop
    {
        public readonly RenderWindow _window;
        //private readonly IGame _game;
        private readonly UserInterface _ui;

        private int TickDelay = 30;
        private int TickCounter;

        public GameLoop(UserInterface ui)
        {
            _ui = ui;
            //_game = game;
            var w = (7 + game.Width) * UIConsts.CellLength;
            var h = (game.Height > 10 ? game.Height + 1 : 10) * UIConsts.CellLength;
            _window = new RenderWindow(new VideoMode((uint)w, (uint)h), "Test");
            _window.SetVerticalSyncEnabled(true);
            _window.Closed += GWindow_Closed;
            _window.KeyPressed += KeyPressed;
            _window.KeyReleased += KeyReleased;
        }

        public void Run()
        {
            while (_window.IsOpen)
            {
                //if (_game == null) continue;
                GC.Collect();
                _window.DispatchEvents();
                _window.Clear(Color.Black);

                Update();

                // Рисовать здесь
                _ui.Update();
                _window?.Draw(_ui);

                _window.Display();
            }
        }

        private void Update()
        {
            if (TickCounter++ >= TickDelay)
            {
                _game.UpdateState();
                TickCounter = 0;
            }
        }

        private void KeyReleased(object sender, KeyEventArgs e) => _ui.AddUserAction(e.Code, KeyEventType.Realesed);

        private void KeyPressed(object sender, KeyEventArgs e) => _ui.AddUserAction(e.Code, KeyEventType.Pressed);

        private void GWindow_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
