using Core.Joystick;
using Core.Level;
using Core.Player;
using UnityEngine;

namespace Core.Infrastructure
{
    public class StaticData : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private JoystickConfig _joystickConfig;
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private CubeView _cubePrefab;
        [SerializeField] private PlayerStorageConfig _playerStorageConfig;

        public PlayerConfig PlayerConfig => _playerConfig;
        public JoystickConfig JoystickConfig => _joystickConfig;
        public LevelConfig LevelConfig => _levelConfig;
        public CubeView CubePrefab => _cubePrefab;
        public PlayerStorageConfig PlayerStorageConfig => _playerStorageConfig;
    }
}