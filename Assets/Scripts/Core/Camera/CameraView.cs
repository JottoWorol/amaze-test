using Cinemachine;
using UnityEngine;

namespace Core.Camera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    }
}