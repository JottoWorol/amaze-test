using Core.Camera;
using Core.Level;
using UnityEngine;

namespace Core.Infrastructure
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private LevelView _levelView;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private CubePoolView _cubePoolView;
        public LevelView LevelView => _levelView;
        public CameraView CameraView => _cameraView;
        public CubePoolView CubePoolView => _cubePoolView;
    }
}