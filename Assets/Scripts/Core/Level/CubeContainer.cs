using System.Collections.Generic;
using Core.Infrastructure;

namespace Core.Level
{
    public class CubeContainer
    {
        private readonly List<MovableCube> _cubes = new List<MovableCube>();
        private readonly Dictionary<CubeView, MovableCube> _viewToCube = new Dictionary<CubeView, MovableCube>();

        private readonly CubePool _cubePool;
        
        public CubeContainer(CubePool cubePool)
        {
            _cubePool = cubePool;
        }

        public void Add(MovableCube cube)
        {
            _cubes.Add(cube);
            _viewToCube.Add(cube.CubeView, cube);
        }
        
        public int Count => _cubes.Count;
        
        public bool TryGetCubeByView(CubeView view, out MovableCube cube)
        {
            return _viewToCube.TryGetValue(view, out cube);
        }

        public void Remove(MovableCube cube)
        {
            _viewToCube.Remove(cube.CubeView);
            _cubes.Remove(cube);
            _cubePool.ReturnCubeView(cube.CubeView);
        }
    }
}