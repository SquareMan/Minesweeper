using System;
using Minesweeper.Controller;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper.View.GUI {
    public class GUIGame : GuiControl
    {
        private GuiButtonControl _mainMenuButton;
        private GuiButtonControl _optionsButton;

        private GuiWindowControl _optionsWindow;

        public GUIGame() {
            Initialize();
        }

        private void Initialize() {
            this.Bounds = new UniRectangle(new UniScalar(0.0f,0.0f), new UniScalar(0.0f,0.0f), new UniScalar(1.0f,1.0f), new UniScalar(1.0f,1.0f));

            _mainMenuButton = new GuiButtonControl
            {
                Name = "MainMenuButton",
                Bounds = new UniRectangle(new UniScalar(0.9f, -30), new UniScalar(0.9f, 20), 100, 24),
                Text = "Main Menu"
            };
            _mainMenuButton.Pressed += (sender, e) => { GameController.Instance.MainMenu(); };

            _optionsButton = new GuiButtonControl {
                Name = "OptionsButton",
                Bounds = new UniRectangle(new UniScalar(0.9f, -30), new UniScalar(0.9f, 0), 100, 24),
                Text = "Options"
            };
            _optionsButton.Pressed += Options;

            Children.Add(_mainMenuButton);
            Children.Add(_optionsButton);

            _optionsWindow = new GuiWindowControl() {
                Name = "OptionsWindow",
                Bounds = new UniRectangle(
                    new UniScalar(0.3f, 0.0f), new UniScalar(0.3f, 0.0f), new UniScalar(0.3f, 0.0f),
                    new UniScalar(0.3f, 0.0f)),
                Title = "Options"
            };
        }

        void Options(Object sender, EventArgs e)
        {
            Children.Add(_optionsWindow);
        }
    }
}