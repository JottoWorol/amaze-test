using Core.Infrastructure;
using UnityEngine;

namespace Core.Camera
{
    public class CameraSetup
    {
        private readonly CameraView _cameraView;
        
        public CameraSetup(SceneData sceneData)
        {
            _cameraView = sceneData.CameraView;
        }
        
        public void SetFollowTarget(Transform target)
        {
            _cameraView.VirtualCamera.Follow = target;
        }
    }
}