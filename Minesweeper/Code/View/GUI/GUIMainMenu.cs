using Microsoft.Xna.Framework.Input;
using Minesweeper.Controller;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper.View.GUI {
    public class GUIMainMenu : GuiWindowControl {
        private GuiButtonControl _button;
        private GuiVerticalSliderControl _slider;
        
        public GUIMainMenu() {
            Initialize();
        }

        private void Initialize() {
            _button = new GuiButtonControl {
                Name = "button",
                Bounds = new UniRectangle(new UniScalar(0.5f, -50), new UniScalar(0, 20), 100, 24),
                Text = "Start Game"
            };

            _button.Pressed += (sender, e) => { GameController.Instance.StartGame(); };
            
            _slider = new GuiVerticalSliderControl {
                Name = "slider",
                Bounds = new UniRectangle(20, 20, 20, 200),
                ThumbSize = .2f
            };
            this.Bounds = new UniRectangle(100.0f, 100.0f, 512.0f, 384.0f);
            Children.Add(_button);
            Children.Add(_slider);
        }

        public void Update() {
            _button.Bounds.Location.Y = _slider.Bounds.Bottom - _button.Bounds.Size.Y - _slider.ThumbPosition * _slider.Bounds.Size.Y;
        }
    }
}