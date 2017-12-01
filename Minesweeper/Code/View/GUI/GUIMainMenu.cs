using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.Controller;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper.View.GUI {
    public class GUIMainMenu : GuiControl, IReturnsGUIControl {
        private GuiButtonControl _button;
        
        public GUIMainMenu() {
            Initialize();
        }

        private void Initialize() {
            this.Bounds = new UniRectangle(new UniScalar(0.0f,0.0f), new UniScalar(0.0f,0.0f), new UniScalar(1.0f,1.0f), new UniScalar(1.0f,1.0f));

            _button = new GuiButtonControl {
                Name = "button",
                Bounds = new UniRectangle(new UniScalar(0.5f, -125), new UniScalar(0.5f, -60), 250, 120),
                Text = "Start Game"
            };
            _button.Pressed += (sender, e) => { GameController.Instance.StartGame(); };
            
            Children.Add(_button);
        }

        public bool IsMouseOverControl() {
            return MouseOverControl != this && MouseOverControl != null;
        }
    }
}