using System;
using Core.Level;
using UnityEngine;

namespace Core.Player
{
    public class DropAreaDetector : MonoBehaviour
    {
        public event Action DropAreaDetected; 
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out DropAreaTag dropAreaTag))
                DropAreaDetected?.Invoke();
        }
    }
}