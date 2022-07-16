using UnityEngine;

namespace Core.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private BoxCollider _cubeSpawnAreaCollider;
        [SerializeField] private BoxCollider _dropAreaCollider;
        
        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        public BoxCollider CubeSpawnAreaCollider => _cubeSpawnAreaCollider;
        public BoxCollider DropAreaCollider => _dropAreaCollider;
    }
}