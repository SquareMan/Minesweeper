using Minesweeper.Controller;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper.View.GUI {
    public class GUIMainMenu {
        private readonly GuiManager _guiManager;

        private GuiButtonControl _button;
        private GuiVerticalSliderControl _slider;

        public GUIMainMenu(GuiManager guiManager) {
            _guiManager = guiManager;
        }

        public void Initialize() {
            _button = new GuiButtonControl {
                Name = "button",
                Bounds = new UniRectangle(new UniScalar(0.5f, -50), new UniScalar(0, 20), 100, 24),
                Text = "Start Game"
            };

            _button.Pressed += (sender, e) => { GameController.Instance.StartGame(); };

            _guiManager.Screen.Desktop.Children.Add(_button);

            _slider = new GuiVerticalSliderControl {
                Name = "slider",
                Bounds = new UniRectangle(20, 20, 20, 200),
                ThumbSize = .2f
            };
            _guiManager.Screen.Desktop.Children.Add(_slider);
        }

        public void Update() {
            _button.Bounds.Location.Y = _slider.Bounds.Top + _slider.ThumbPosition * _slider.Bounds.Size.Y;
        }

        public void Close() {
            _guiManager.Screen.Desktop.Children.Remove(_button);
            _guiManager.Screen.Desktop.Children.Remove(_slider);
        }
    }
}