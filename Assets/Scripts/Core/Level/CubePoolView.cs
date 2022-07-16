using System.Collections.Generic;
using Core.Infrastructure;
using UnityEngine;

namespace Core.Level
{
    public class CubePoolView : MonoBehaviour
    {
        [SerializeField] private List<CubeView> _pool = new List<CubeView>();
        [SerializeField] private CubeView _cubePrefab;

        public List<CubeView> Pool => _pool;
        public CubeView CubePrefab => _cubePrefab;
    }
}