using System;
using Core.Animation.Player;
using Core.Camera;
using Core.Infrastructure;
using Core.Level;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Player
{
    public class PlayerSpawner : IDisposable
    {
        private readonly CameraSetup _cameraSetup;
        private readonly PlayerAnimation _playerAnimation;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerMove _playerMove;
        private readonly PlayerStorageConfig _playerStorageConfig;
        private readonly CubeContainer _cubeContainer;
        private readonly DropArea _dropArea;

        private Player _player;
        private HoldParameterControl _holdParameterControl;

        public PlayerSpawner(StaticData staticData, PlayerMove playerMove, CameraSetup cameraSetup,
            PlayerAnimation playerAnimation, CubeContainer cubeContainer, DropArea dropArea)
        {
            _playerMove = playerMove;
            _cameraSetup = cameraSetup;
            _playerAnimation = playerAnimation;
            _cubeContainer = cubeContainer;
            _dropArea = dropArea;
            _playerStorageConfig = staticData.PlayerStorageConfig;
            _playerConfig = staticData.PlayerConfig;
        }

        public void SpawnPlayerAt(Vector3 position)
        {
            var playerView = Object.Instantiate(_playerConfig.PlayerPrefab, position, Quaternion.identity);

            _playerMove.SetPlayerView(playerView);
            _cameraSetup.SetFollowTarget(playerView.MoveTransform);
            _playerAnimation.SetAnimator(playerView.Animator);

            var storage = new PlayerStorage(playerView.StorageParent, _playerStorageConfig);
            _holdParameterControl = new HoldParameterControl(storage, _playerAnimation);
            
            _player = new Player(playerView, 
                new CubeDetectionHandler(storage, _cubeContainer),
                new DropAreaDetectionHandler(storage, _dropArea, _cubeContainer));
            _player.Initialize();
        }

        public void Dispose()
        {
            _player?.Dispose();
            _holdParameterControl?.Dispose();
        }
    }
}