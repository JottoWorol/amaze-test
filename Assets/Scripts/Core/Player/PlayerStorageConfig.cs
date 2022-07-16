using UnityEngine;

namespace Core.Player
{
    [CreateAssetMenu(fileName = "PlayerStorageConfig", menuName = "Game Configs/PlayerStorageConfig",
        order = 0
    )]
    public class PlayerStorageConfig : ScriptableObject
    {
        [SerializeField] private int _capacity;
        [SerializeField] private float _itemHeight;
        [SerializeField] private float _itemScale = 0.8f;

        public int Capacity => _capacity;
        public float ItemHeight => _itemHeight;
        public float ItemScale => _itemScale;
    }
}