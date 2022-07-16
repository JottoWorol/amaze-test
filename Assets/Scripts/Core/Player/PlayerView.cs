using UnityEngine;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _moveTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CubeDetector _cubeDetector;
        [SerializeField] private DropAreaDetector _dropAreaDetector;
        [SerializeField] private Transform _storageParent;

        public Animator Animator => _animator;
        public Transform MoveTransform => _moveTransform;
        public Rigidbody Rigidbody => _rigidbody;
        public CubeDetector CubeDetector => _cubeDetector;
        public Transform StorageParent => _storageParent;
        public DropAreaDetector DropAreaDetector => _dropAreaDetector;
    }
}