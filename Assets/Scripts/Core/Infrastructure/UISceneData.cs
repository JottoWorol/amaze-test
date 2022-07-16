using Core.Joystick;
using UnityEngine;

namespace Core.Infrastructure
{
    public class UISceneData : MonoBehaviour
    {
        [SerializeField] private ScreenTouchView _screenTouchView;
        [SerializeField] private JoystickView _joystickView;
        public ScreenTouchView ScreenTouchView => _screenTouchView;
        public JoystickView JoystickView => _joystickView;
    }
}