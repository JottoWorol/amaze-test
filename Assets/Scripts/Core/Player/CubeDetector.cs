using System;
using Core.Infrastructure;
using UnityEngine;

namespace Core.Player
{
    public class CubeDetector : MonoBehaviour
    {
        public event Action<CubeView> CubeDetected;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out CubeView cubeView))
                CubeDetected?.Invoke(cubeView);
        }
    }
}