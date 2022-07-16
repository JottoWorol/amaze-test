using System.Collections.Generic;
using Core.Infrastructure;
using UnityEngine;

namespace Core.Level
{
    public class CubePool
    {
        private readonly CubeView _prefab;
        private readonly List<CubeView> _pool;
        
        public CubePool(SceneData sceneData)
        {
            _pool = sceneData.CubePoolView.Pool;
            _prefab = sceneData.CubePoolView.CubePrefab;
        }

        public CubeView GetCubeView()
        {
            foreach (var cubeView in _pool)
            {
                if (!cubeView.gameObject.activeSelf)
                {
                    cubeView.gameObject.SetActive(true);
                    cubeView.Transform.localScale = Vector3.one;
                    return cubeView;
                }
            }
            
            var cubeViewInstance = Object.Instantiate(_prefab);
            _pool.Add(cubeViewInstance);
            return cubeViewInstance;
        }
        
        public void ReturnCubeView(CubeView cubeView)
        {
            cubeView.gameObject.SetActive(false);
        }
    }
}