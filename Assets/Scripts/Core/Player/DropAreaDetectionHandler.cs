using Core.Level;
using UnityEngine;

namespace Core.Player
{
    public class DropAreaDetectionHandler
    {
        private readonly PlayerStorage _playerStorage;
        private readonly DropArea _dropArea;
        private readonly CubeContainer _cubeContainer;

        public DropAreaDetectionHandler(PlayerStorage playerStorage, DropArea dropArea, CubeContainer cubeContainer)
        {
            _playerStorage = playerStorage;
            _dropArea = dropArea;
            _cubeContainer = cubeContainer;
        }

        public void OnDropAreaDetected()
        {
            while (_playerStorage.Count > 0)
            {
                var item = _playerStorage.GetLast();
                
                item.MoveToWithCompleteCallback(_dropArea, Vector3.zero, () =>
                {
                    _cubeContainer.Remove(item);
                });
                
                _playerStorage.Remove(item);
                item.SetCollectible(false);
            }
        }
    }
}