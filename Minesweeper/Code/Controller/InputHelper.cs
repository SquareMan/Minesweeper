using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.View.GUI;
using MonoGame.Extended.NuclexGui.Controls;

namespace Minesweeper.Controller {
    public static class InputHelper {

        private static KeyboardState _currentKeyboardState;
        private static KeyboardState _lastKeyboardState;

        private static MouseState _currentMouseState;
        private static MouseState _lastMouseState;

        private static bool _overGUILastFrame;
        private static bool _overGUIThisFrame;

        public static void Update() {
            _lastKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            _lastMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            _overGUILastFrame = _overGUIThisFrame;
            _overGUIThisFrame = IsMouseOverGui();
        }

        public static bool IsMouseOverGui() {
            if (GameController.Instance.ActiveGUI != null) {
                return GameController.Instance.ActiveGUI.IsMouseOverControl();
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="key">The key to test</param>
        /// <returns>True is key was released this frame</returns>
        public static bool IsKeyReleased(this KeyboardState state, Keys key) {
            return state.IsKeyUp(key) && _lastKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="key">The key to test</param>
        /// <returns>True is the key was pressed this frame</returns>
        public static bool IsKeyPressed(this KeyboardState state, Keys key) {
            return state.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the left mouse button was released this frame</returns>
        public static bool IsLeftButtonReleased(this MouseState state) {
            return state.LeftButton == ButtonState.Released && _lastMouseState.LeftButton == ButtonState.Pressed 
                && !_overGUILastFrame && !_overGUIThisFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the left mouse button was pressed this frame</returns>
        public static bool IsLeftButtonPressed(this MouseState state) {
            return state.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released 
                && !_overGUILastFrame && !_overGUIThisFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the middle mouse button was released this frame</returns>
        public static bool IsMiddleButtonReleased(this MouseState state)
        {
            return state.MiddleButton == ButtonState.Released && _lastMouseState.MiddleButton == ButtonState.Pressed
                   && !_overGUILastFrame && !_overGUIThisFrame;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the middle mouse button was pressed this frame</returns>
        public static bool IsMiddleButtonPressed(this MouseState state)
        {
            return state.MiddleButton == ButtonState.Pressed && _lastMouseState.MiddleButton == ButtonState.Released
                   && !_overGUILastFrame && !_overGUIThisFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the right mouse button was released this frame</returns>
        public static bool IsRightButtonReleased(this MouseState state)
        {
            return state.RightButton == ButtonState.Released && _lastMouseState.RightButton == ButtonState.Pressed
                   && !_overGUILastFrame && !_overGUIThisFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the right mouse button was pressed this frame</returns>
        public static bool IsRightButtonPressed(this MouseState state)
        {
            return state.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released
                   && !_overGUILastFrame && !_overGUIThisFrame;
        }
    }
}