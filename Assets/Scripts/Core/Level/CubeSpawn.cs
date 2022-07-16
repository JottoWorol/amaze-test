using Core.Infrastructure;
using UnityEngine;
using Zenject;

namespace Core.Level
{
    public class CubeSpawn : ITickable
    {
        private readonly CubeView _cubePrefab;
        private readonly LevelConfig _levelConfig;
        private readonly CubeContainer _cubeContainer;
        private readonly BoxCollider _spawnAreaCollider;
        private CubePool _cubePool;

        private float _timer;

        public CubeSpawn(StaticData staticData, CubeContainer cubeContainer, SceneData sceneData, CubePool cubePool)
        {
            _cubeContainer = cubeContainer;
            _cubePool = cubePool;
            _levelConfig = staticData.LevelConfig;
            _cubePrefab = staticData.CubePrefab;
            _spawnAreaCollider = sceneData.LevelView.CubeSpawnAreaCollider;

            _timer = _levelConfig.CubeSpawnInterval;
        }

        public void Tick()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                ResetTimer();
                
                if(_cubeContainer.Count < _levelConfig.MaxSpawnedCubes)
                    SpawnCube();
            }
        }

        private void ResetTimer()
        {
            _timer = _levelConfig.CubeSpawnInterval +
                     Random.Range(-_levelConfig.CubeSpawnIntervalVariance, _levelConfig.CubeSpawnIntervalVariance);
        }

        private Vector3 GetRandomPosition()
        {
            var bounds = _spawnAreaCollider.bounds;

            var x = Random.Range(bounds.min.x, bounds.max.x);
            var z = Random.Range(bounds.min.z, bounds.max.z);

            return new Vector3(x, 0, z);
        }

        private void SpawnCube()
        {
            var view = _cubePool.GetCubeView();
            view.Transform.position = GetRandomPosition();
            view.Transform.rotation = Quaternion.identity;

            _cubeContainer.Add(new MovableCube(view));
        }
    }
}