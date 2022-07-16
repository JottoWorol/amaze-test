using Core.Infrastructure;
using Core.Player;
using Zenject;

namespace Core.Level
{
    public class LevelLoader : IInitializable

    {
        private readonly LevelView _levelView;
        private readonly PlayerSpawner _playerSpawner;

        public LevelLoader(SceneData sceneData, PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
            _levelView = sceneData.LevelView;
        }

        public void Initialize()
        {
            LoadLevel();
        }

        private void LoadLevel()
        {
            _playerSpawner.SpawnPlayerAt(_levelView.PlayerSpawnPoint.position);
        }
    }
}