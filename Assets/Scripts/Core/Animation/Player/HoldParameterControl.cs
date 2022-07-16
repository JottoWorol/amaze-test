using Core.Player;

namespace Core.Animation.Player
{
    public class HoldParameterControl
    {
        private readonly PlayerStorage _playerStorage;
        private readonly PlayerAnimation _playerAnimation;

        public HoldParameterControl(PlayerStorage playerStorage, PlayerAnimation playerAnimation)
        {
            _playerStorage = playerStorage;
            _playerAnimation = playerAnimation;
            _playerStorage.ContentChanged += OnStorageContentChanged;
        }
        
        public void Dispose()
        {
            if (_playerStorage == null)
                return;
            
            _playerStorage.ContentChanged -= OnStorageContentChanged;
        }

        private void OnStorageContentChanged()
        {
            _playerAnimation.SetHolding(_playerStorage.Count > 0);
        }
    }
}